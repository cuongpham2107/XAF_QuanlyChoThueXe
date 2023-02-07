using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(TenQuocGia))]
    [ImageName("earth")]
    [XafDisplayName("Quốc gia")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class QuocGia : BaseObject, IListViewInline
    { 
        public QuocGia(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string dienGiai;
        bool status;
        string tenQuocGia;
        string maQuocGia;
        [XafDisplayName("Mã quốc gia")]
        public string MaQuocGia
        {
            get => maQuocGia;
            set => SetPropertyValue(nameof(MaQuocGia), ref maQuocGia, value);
        }
        [XafDisplayName("Tên quốc gia")]
        public string TenQuocGia
        {
            get => tenQuocGia;
            set => SetPropertyValue(nameof(TenQuocGia), ref tenQuocGia, value);
        }
        [XafDisplayName("Còn dùng")]
        public bool Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
        [XafDisplayName("Diễn giải")]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
    }
}