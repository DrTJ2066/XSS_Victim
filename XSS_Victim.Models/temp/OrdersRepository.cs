using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XSS_Victim.Models.Repositories
{
    public class OrdersRepository : RepositoryBase, IRepositoryBase<DAL.SocialDataEntities>
    {
        public long GetNewOrderID() {
            var res = this.Context.CustomerOrders.Select(w => w.IDOrder);

            if (res.Count() == 0)
                return 1;
            else
                return res.Max() + 1;
        }

        public DAL.CustomerOrders AddOrder(DAL.CustomerOrders newOrder) {
            newOrder.IDOrder = GetNewOrderID();
            newOrder.IsRead = false;
            newOrder.OrderDateTime = RoyaDateEngine.DateEngine.CurrentShamsiDate().ToString();
            newOrder.OrderDateTimeGregorian = RoyaDateEngine.DateEngine.CurrentGregorianDate();
            
            this.Context.AddToCustomerOrders(newOrder);
            this.Context.SaveChanges();

            return newOrder;
        }

        public long GetUnreadOrdersCount() {
            return this.Context.CustomerOrders.Count(w => w.IsRead == false);
        }

        public List<DAL.CustomerOrders> GetUnreadOrdersList() {
            var res = this.Context.CustomerOrders
                                  .Include("Cities")
                                  .Include("Provinces")
                                  .Include("Countries")
                                  .Where(w => w.IsRead != true);

            if (res.Count() > 0)
                return res.ToList();
            else
                return new List<DAL.CustomerOrders>();
        }

        public List<DAL.CustomerOrders> GetOrdersList() {
            var res = this.Context.CustomerOrders;

            if (res.Count() > 0)
                return res.ToList();
            else
                return new List<DAL.CustomerOrders>();
        }


        public void DeleteOrder(long orderID) {
            var order = this.Context.CustomerOrders.FirstOrDefault(w => w.IDOrder == orderID);

            if (order != null) {
                this.Context.CustomerOrders.DeleteObject(order);
                this.Context.SaveChanges();
            }
        }

        public DAL.CustomerOrders GetOrderDetails(long orderID) {
            var order = this.Context.CustomerOrders.Include("Products").FirstOrDefault(w => w.IDOrder == orderID) ?? new DAL.CustomerOrders();
            return order;
        }

        public void MarkAsRead(long orderID, bool isRead) {
            var order = this.Context.CustomerOrders.FirstOrDefault(w => w.IDOrder == orderID);

            if (order != null) {
                order.IsRead = isRead;
                this.Context.SaveChanges();
            }
        }

        public string  ToEmailMessage(DAL.CustomerOrders orderInfo) {
            var orderDateTime = RoyaDateEngine.SimpleDateTime.Parse(orderInfo.OrderDateTime);

            var res = Properties.Resources.OrderDetailsForEmail;
            res = res.Replace("{Name}", orderInfo.CustomerFullName)
                     .Replace("{OrderDetails}", orderInfo.OrderDetails)
                     .Replace("{Tel}", orderInfo.Telephone)
                     .Replace("{Mobile}", orderInfo.Mobile)
                     .Replace("{EMail}", orderInfo.EMail)
                     .Replace("{Address}", orderInfo.Address)
                     .Replace("{OrderDate}", orderDateTime.ToShortDateString())
                     .Replace("{OrderTime}", orderDateTime.ToShortTimeString())
                     .Replace("{OrderDateTime}", orderDateTime.ToString());

            return res;
        }
    }
}

