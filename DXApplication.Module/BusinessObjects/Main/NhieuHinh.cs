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

namespace DXApplication.Module.BusinessObjects.Main
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(MoTa))]
    [ImageName("gallery")]
    [XafDisplayName("Thư viện ảnh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class NhieuHinh : BaseObject
    { 
        public NhieuHinh(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        Xe xe;
        string dienGiai;
        byte[] hinhAnh;
        string moTa;
        [XafDisplayName("Mô tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Hình ảnh")]
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Diễn giải")]
        [Size(SizeAttribute.Unlimited)]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
        //[XafDisplayName("Thuộc xe")]
        //[Association("Xe-NhieuHinhs")]
        //public Xe Xe
        //{
        //    get => xe;
        //    set => SetPropertyValue(nameof(Xe), ref xe, value);
        //}
    }
}