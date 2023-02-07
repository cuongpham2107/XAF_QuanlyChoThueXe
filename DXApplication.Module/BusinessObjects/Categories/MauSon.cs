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
    [DefaultProperty(nameof(MauSonXe))]
    [ImageName("color-palette")]
    [XafDisplayName("Mầu sơn")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class MauSon : BaseObject, IListViewInline
    { 
        public MauSon(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string dienGiai;
        string mauSonXe;
        [XafDisplayName("Mầu sơn")]
        public string MauSonXe
        {
            get => mauSonXe;
            set => SetPropertyValue(nameof(MauSonXe), ref mauSonXe, value);
        }
        [XafDisplayName("Diễn giải")]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
    }
}