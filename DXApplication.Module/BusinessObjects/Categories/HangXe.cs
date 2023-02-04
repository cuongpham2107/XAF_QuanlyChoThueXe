using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(NhanHieu))]
    //[ImageName("car")]
    [XafDisplayName("Hãng xe")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class HangXe : BaseObject
    { 
        public HangXe(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string dienGiai;
        QuocGia quocGia;
        string nhanHieu;
        [XafDisplayName("Nhãn hiệu")]
        public string NhanHieu
        {
            get => nhanHieu;
            set => SetPropertyValue(nameof(NhanHieu), ref nhanHieu, value);
        }
        [XafDisplayName("Quốc gia")]
        public QuocGia QuocGia
        {
            get => quocGia;
            set => SetPropertyValue(nameof(QuocGia), ref quocGia, value);
        }
        [XafDisplayName("Diễn giải")]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
    }
}