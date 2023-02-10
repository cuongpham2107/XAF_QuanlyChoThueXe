using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Chat
{
    [DefaultClassOptions]
   
    public class ChatMessage : BaseObject
    { 
        public ChatMessage(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }


        private DateTime _CreatedDate;
        [XafDisplayName("Ngày gửi")]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { SetPropertyValue(nameof(CreatedDate), ref _CreatedDate, value); }
        }
        private ApplicationUser _ToUser;
        [XafDisplayName("Người gửi ")]
        public ApplicationUser ToUser
        {
            get { return _ToUser; }
            set { SetPropertyValue(nameof(ToUser), ref _ToUser, value); }
        }
        private ApplicationUser _FromUser;
        [XafDisplayName("Gửi đến người dùng")]
        public ApplicationUser FromUser
        {
            get { return _FromUser; }
            set { SetPropertyValue(nameof(FromUser), ref _FromUser, value); }
        }
        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { SetPropertyValue(nameof(Message), ref _Message, value); }
        }
       


    }
}