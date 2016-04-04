using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using RoyaMVC_EN.AccountManagement;
using WebMatrix.Data;

namespace XSS_Victim.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            InitializeProductsCategories(filterContext);

            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);

            if (WebMatrix.WebData.WebSecurity.IsAuthenticated) {
                if (string.IsNullOrWhiteSpace(CurrentUser.UserName)) {
                    var repoUsers = new XSS_Victim.Models.Repositories.UsersRepository();
                    repoUsers.SetCurrentUser(WebMatrix.WebData.WebSecurity.CurrentUserName);

                    filterContext.Controller.ViewBag.UserFullName = CurrentUser.DisplayName;
                }
            }
            else {
                if (!string.IsNullOrWhiteSpace(CurrentUser.UserName)) {
                    CurrentUser.ClearData();
                }

                filterContext.Controller.ViewBag.UserFullName = "";
            }

        }

        private void InitializeProductsCategories(ActionExecutingContext filterContext) {
            //var repoProducts = new Models.Repositories.ProductsRepository();
            //var resCategoriesList = repoProducts.GetCategoriesListWithProducts();

            //filterContext.Controller.ViewBag.ProductCategoriesList = resCategoriesList;
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer() {
                System.Data.Entity.Database.SetInitializer<UsersContext<RoyaMVC_EN.Models.Users>>(null);

                try {
                    using (var context = new UsersContext<RoyaMVC_EN.Models.Users>("DefaultConnection")) {
                        if (!context.Database.Exists()) {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            //((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                            throw new InvalidOperationException("Database does not exists!");
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "IDUser", "UserName", autoCreateTables: false);
                }
                catch (Exception ex) {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}