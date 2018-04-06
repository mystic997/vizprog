using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YachtKlub.validator;

namespace YachtKlub
{
    public static class PopupMargin
    {
        public static int Count { get; set; }
        static PopupMargin()
        {
            Count = 1;
        }
    }

    class PopupCaller
    {
        public string Messsage { get; set; }
        public int BoxTopMargin { get; set; }
        public int BoxBottomMargin { get; set; }
        public Status status { get; set; }

        public PopupCaller()
        {
            Messsage = "";
            BoxTopMargin = 0;
            BoxBottomMargin = 0;
            status = Status.OK;
        }

        public void CallPopup()
        {
            var PopupMessage = new PopupMessage(Messsage, status);
            PopupMessage.Top = this.BoxTopMargin;
            PopupMessage.Bottom = this.BoxBottomMargin;
            PopupMessage.Focusable = false;
            PopupMessage.ShowActivated = false;
            PopupMessage.ShowDialog();
        }
    }

    class PrintMessageBox
    {
        public PrintMessageBox(string message, Status status)
        {
            PopupCaller PopupCaller = new PopupCaller();
            PopupCaller.Messsage = message;
            if (message.Length > 51)
                PopupCaller.BoxBottomMargin = 22 * PopupMargin.Count;
            PopupCaller.BoxTopMargin = 22 * PopupMargin.Count++; //42

            PopupCaller.status = status;

            var myThread = new System.Threading.Thread(new System.Threading.ThreadStart(PopupCaller.CallPopup));
            myThread.SetApartmentState(System.Threading.ApartmentState.STA);
            myThread.Start();
        }
    }
}
