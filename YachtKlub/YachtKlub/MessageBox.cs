using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YachtKlub
{
    class PopupCaller
    {
        public string Messsage { get; set; }
        public int BoxTopMargin { get; set; }
        public Status status { get; set; }

        public PopupCaller()
        {
            Messsage = "";
            BoxTopMargin = 0;
            status = Status.OK;
        }

        public void CallPopup()
        {
            var PopupMessage = new PopupMessage(Messsage, status);
            PopupMessage.Top = this.BoxTopMargin;
            PopupMessage.Focusable = false;
            PopupMessage.ShowActivated = false;
            PopupMessage.ShowDialog();
        }
    }

    class MessageBox
    {
        public MessageBox(List<string> messages, Status status)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                PopupCaller PopupCaller = new PopupCaller();
                PopupCaller.Messsage = messages[i];
                PopupCaller.BoxTopMargin = 40 * i;
                PopupCaller.status = status;

                var myThread = new System.Threading.Thread(new System.Threading.ThreadStart(PopupCaller.CallPopup));
                myThread.SetApartmentState(System.Threading.ApartmentState.STA);
                myThread.Start();
            }
        }
    }
}
