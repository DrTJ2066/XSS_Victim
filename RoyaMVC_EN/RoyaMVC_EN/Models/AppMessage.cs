using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN.Models {
    public enum AppMessageTypes { ErrorMessage, InfoMessage, ExclamationMessage }

    public class AppMessage {
        public string MessageBody { get; set; }
        public AppMessageTypes MessageType { get; set; }

        public AppMessage(string messageBody, AppMessageTypes messageType) {
            this.MessageBody = messageBody;
            this.MessageType = messageType;
        }

        public AppMessage(AppMessage msg) {
            this.MessageBody = msg.MessageBody;
            this.MessageType = msg.MessageType;
        }

        public AppMessage() {
            this.MessageType = AppMessageTypes.InfoMessage;
            this.MessageBody = "";
        }

        public string GetClassName(string infoStyle, string errorStyle, string exclamationStyle) {
            var res = "";

            switch (this.MessageType) {
                case AppMessageTypes.ErrorMessage: res = errorStyle; break;
                case AppMessageTypes.InfoMessage: res = infoStyle; break;
                case AppMessageTypes.ExclamationMessage: res = exclamationStyle; break;
            }

            return res;
        }



        public static List<AppMessage> messagesList = new List<AppMessage>();

        public static void ClearMessages() {
            messagesList = new List<AppMessage>();
        }

        public static List<AppMessage> Add(string messageBody, AppMessageTypes messageType, bool clearBeforeAdding = false) {
            return Add(new AppMessage(messageBody, messageType), clearBeforeAdding);
        }

        public static List<AppMessage> Add(AppMessage msg, bool clearBeforeAdding = false) {
            if (clearBeforeAdding)
                ClearMessages();

            messagesList.Add(msg);
            return messagesList;
        }
    }
}
