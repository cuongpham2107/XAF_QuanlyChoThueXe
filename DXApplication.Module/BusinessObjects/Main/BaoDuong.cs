using DevExpress.CodeParser;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.BusinessObjects;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.Categories;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.Main
{
    [DefaultClassOptions]
    [CustomDetailView(Tabbed = true)]
    [NavigationItem(Menu.MenuMain)]
    [DefaultProperty(nameof(TenPhieuBaoDuong))]
    [ImageName("insurance")]
    
    [XafDisplayName("Bảo dưỡng xe")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("TrangThai", AppearanceItemType = "ViewItem", TargetItems = "TrangThaiBaoDuong", Criteria = "[TrangThaiBaoDuong] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiBaoDuong,dx#", Context = "Any", BackColor = "DeepSkyBlue",FontColor ="White", Priority = 1)]

    [Appearance("HideEdit", AppearanceItemType= "ViewItem",TargetItems ="*",Criteria = "[TrangThaiBaoDuong] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiBaoDuong,dx#", Context ="Any", Enabled =false)]   

    
    public class BaoDuong : BaseObject, IListViewPopup
    { 
        public BaoDuong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string tenPhieuBaoDuong;
        Xe xe;
        string dienGiai;
        TrangThaiBaoDuong trangThaiBaoDuong;
        ApplicationUser applicationUser;
        DateTime ngay;
        int thanhTien;
        int donGia;
        DonVi donVi;
        int soLuong;
        LoaiBaoDuong loaiBaoDuong;
        #region Properties
        [XafDisplayName("Tên phiếu bảo dưỡng")]
        [VisibleInDetailView(true)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [ModelDefault("AllowEdit","False")]
        public string TenPhieuBaoDuong
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                   return $"{Ngay}-{LoaiBaoDuong}";
                }
                return null;
            }
            set => SetPropertyValue(nameof(TenPhieuBaoDuong), ref tenPhieuBaoDuong, value);
        }
        [VisibleInDetailView(true)]
        [VisibleInListView(true)]
        [Association("Xe-BaoDuongs")]
        public Xe Xe
        {
            get => xe;
            set => SetPropertyValue(nameof(Xe), ref xe, value);
        }
        [XafDisplayName("Loại")]
        public LoaiBaoDuong LoaiBaoDuong
        {
            get => loaiBaoDuong;
            set => SetPropertyValue(nameof(LoaiBaoDuong), ref loaiBaoDuong, value);
        }
        [XafDisplayName("Số lượng")]
        public int SoLuong
        {
            get => soLuong;
            set => SetPropertyValue(nameof(SoLuong), ref soLuong, value);
        }
        [XafDisplayName("Đơn vị")]
        public DonVi DonVi
        {
            get => donVi;
            set => SetPropertyValue(nameof(DonVi), ref donVi, value);
        }
        [XafDisplayName("Đơn giá")]
        public int DonGia
        {
            get => donGia;
            set => SetPropertyValue(nameof(DonGia), ref donGia, value);
        }
        [XafDisplayName("Thành tiền")]
        [ModelDefault("AllowEdit","False")]
        public int ThanhTien
        {
            get
            {
                return DonGia * SoLuong;
            }
        }
        [XafDisplayName("Ngày")]
        public DateTime Ngay
        {
            get => ngay;
            set => SetPropertyValue(nameof(Ngay), ref ngay, value);
        }
        [XafDisplayName("Người thực hiện")]
        public ApplicationUser ApplicationUser
        {
            get => applicationUser;
            set => SetPropertyValue(nameof(ApplicationUser), ref applicationUser, value);
        }
        [XafDisplayName("Trạng thái")]
        public TrangThaiBaoDuong TrangThaiBaoDuong
        {
            get => trangThaiBaoDuong;
            set => SetPropertyValue(nameof(TrangThaiBaoDuong), ref trangThaiBaoDuong, value);
        }
        [XafDisplayName("Diễn giải")]
        [Size(SizeAttribute.Unlimited)]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
        #endregion

        #region Action
        //[Action(Caption ="Duyệt & Chốt", AutoCommit = true,ConfirmationMessage ="Bạn có chắc duyệt dữ liệu này? Sau khi duyệt, bạn không thể chỉnh sửa được nữa"  ,TargetObjectsCriteria = "[TrangThaiBaoDuong] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiBaoDuong,lt#", ImageName= "Check", TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueAtLeastForOne, SelectionDependencyType = MethodActionSelectionDependencyType.RequireSingleObject)]
        //public void StatusAction()
        //{
        //    TrangThaiBaoDuong = TrangThaiBaoDuong.dx;
        //    Session.Save(this);
        //}

        #endregion
    }
}