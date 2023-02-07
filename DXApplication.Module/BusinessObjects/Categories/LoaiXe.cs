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
using DomainComponents.Common;
using DXApplication.Module.Extension;

namespace DXApplication.Module.BusinessObjects.Categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(TenLoaiXe))]
    [ImageName("car")]
    [XafDisplayName("Loại xe")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]


    public class LoaiXe : BaseObject, IListViewInline
    { 
        public LoaiXe(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        KieuXe kieuXe;
        string dienGiai;
        int soCho;
        string tenLoaiXe;
        string nhanHieu;
        [XafDisplayName("Nhãn hiệu")]
        public string Don
        {
            get => nhanHieu;
            set => SetPropertyValue(nameof(Don), ref nhanHieu, value);
        }
        [XafDisplayName("Loại xe")]
        public string TenLoaiXe
        {
            get => tenLoaiXe;
            set => SetPropertyValue(nameof(TenLoaiXe), ref tenLoaiXe, value);
        }
        [XafDisplayName("Số chỗ")]
        public int SoCho
        {
            get => soCho;
            set => SetPropertyValue(nameof(SoCho), ref soCho, value);
        }
        [XafDisplayName("Kiểu xe")]
        public KieuXe KieuXe
        {
            get => kieuXe;
            set => SetPropertyValue(nameof(KieuXe), ref kieuXe, value);
        }
        [XafDisplayName("Diễn giải")]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
    }
}