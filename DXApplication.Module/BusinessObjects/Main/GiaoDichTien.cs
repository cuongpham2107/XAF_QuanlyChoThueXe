using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Blazor.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.Main
{
    [DefaultClassOptions]
    [CustomDetailView(Tabbed = true)]
    [NavigationItem(Menu.MenuMain)]
    [DefaultProperty($"{nameof(LyDo)}-{nameof(Ngay)}")]
    [ImageName("lending")]
    [XafDisplayName("Giao dịch tiền")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [CustomRootListView(FieldsToSum = new[] { "Ngay:Count", "Thu:Sum", "Chi:Sum", "Tong:Sum" })]

    [Appearance("Thu", BackColor = "Blue", FontColor = "White", TargetItems = "Thu", Context = "Any", Priority = 1)]
    [Appearance("Chi", BackColor = "Gold", FontColor = "Black", TargetItems = "Chi", Context = "Any", Priority = 2)]

    public class GiaoDichTien : BaseObject, IListViewPopup
    {
        public GiaoDichTien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        BaoDuong baoDuong;
        ChoThue choThue;
        int tong;
        int chi;
        int thu;

        DateTime? ngay;
        [XafDisplayName("Ngày")]
        public DateTime? Ngay
        {
            get => ngay;
            set => SetPropertyValue(nameof(Ngay), ref ngay, value);
        }
        private LyDo lyDo;
        [XafDisplayName("Lý do")]
        public LyDo LyDo
        {
            get => lyDo;
            set => SetPropertyValue(nameof(LyDo), ref lyDo, value);
        }

        [XafDisplayName("Thu")]
        public int Thu
        {
            get => thu;
            set => SetPropertyValue(nameof(Thu), ref thu, value);
        }
        [XafDisplayName("Chi")]
        public int Chi
        {
            get => chi;
            set => SetPropertyValue(nameof(Chi), ref chi, value);
        }
        [XafDisplayName("Tổng")]
        public int Tong
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    return Thu - Chi;
                }
                return 0;
               
            }
            set => SetPropertyValue(nameof(Tong), ref tong, value);
        }

        [Appearance("HideChoThue", AppearanceItemType.ViewItem, "[BaoDuong] Is Not Null", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = true)]
        [XafDisplayName("Cho Thuê")]
        [ModelDefault("AllowEdit", "False")]
        public ChoThue ChoThue
        {
            get => choThue;
            set => SetPropertyValue(nameof(ChoThue), ref choThue, value);
        }
        [Appearance("HideBaoDuong", AppearanceItemType.ViewItem, "[ChoThue] Is Not Null", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = true)]
        [XafDisplayName("Bảo dưỡng")]
        [ModelDefault("AllowEdit", "False")]
        public BaoDuong BaoDuong
        {
            get => baoDuong;
            set => SetPropertyValue(nameof(BaoDuong), ref baoDuong, value);
        }
    }
}