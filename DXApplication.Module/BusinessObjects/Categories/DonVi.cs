using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Categories
{
    [DefaultClassOptions]
    
    public class DonVi : BaseObject
    { 
        public DonVi(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        bool conDung;
        string dienGiai;
        string tenDonVi;
        [XafDisplayName("Tên đơn vị")]
        public string TenDonVi
        {
            get => tenDonVi;
            set => SetPropertyValue(nameof(TenDonVi), ref tenDonVi, value);
        }
        [XafDisplayName("Còn dùng")]
        public bool ConDung
        {
            get => conDung;
            set => SetPropertyValue(nameof(ConDung), ref conDung, value);
        }
        [XafDisplayName("Diễn giải")]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
    }
}