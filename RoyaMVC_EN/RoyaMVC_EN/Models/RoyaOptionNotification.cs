using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models
{
    public class RoyaOptionNotification
    {
        /// <summary>
        /// Data to be shown in the notification box.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// default value is : "notification green"
        /// </summary>
        public string CssClass { get; set; }

        public RoyaOptionNotification() {
            this.Content = "";
            this.CssClass = "notification green";
        }

        public RoyaOptionNotification(string content) {
            this.Content = content;
            this.CssClass = "notification green";
        }

        public RoyaOptionNotification(string content, string cssClass) {
            this.Content = content;
            this.CssClass = cssClass;
        }
    }
}
