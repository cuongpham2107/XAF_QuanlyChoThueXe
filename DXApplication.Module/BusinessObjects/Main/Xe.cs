using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.Categories;
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
    //[CustomDetailView(Tabbed = true)]
    [NavigationItem(Menu.MenuMain)]
    [DefaultProperty(nameof(TenXe))]
    [ImageName("car")]
    [XafDisplayName("Xe")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItems)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", BackColor = "224,224,224", TargetItems = "*", Criteria = "[TrangThaiXe] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiXe,dct#", Context = "Any", Enabled = false, Priority = 0)]

    [Appearance("TrangThaiKhaDung", BackColor = "Blue", FontColor = "White",Criteria = "[TrangThaiXe] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiXe,kd#", TargetItems = "TrangThaiXe", Context = "Any", Priority = 1)]
    [Appearance("TrangThaiDangChoThue", BackColor = "Gold", FontColor = "Black", Criteria = "[TrangThaiXe] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiXe,dct#", TargetItems = "TrangThaiXe", Context = "Any", Priority = 2)]
    public class Xe : BaseObject
    { 
        public Xe(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }


        string tenXe;
        ChoThue choThue;
        DateTime? hetHanBaoHiem;
        DateTime dangKyLanDau;
        DateTime hetDangKiem;
        string soCho;
        string soMay;
        string soKhung;
        string dungTich;
        TrangThaiXe trangThaiXe;
        string dienGiai;
        bool trangThai;
        int giaThueThang;
        int giaThueNgay;
        int giaThueGio;
        string tenChuXe;
        QuocGia quocGia;
        MauSon mauSon;
        string bienSo;
        string doiXe;
        LoaiXe loaiXe;
        #region Xe
        [XafDisplayName("Tên xe")]
        [ModelDefault("AllowEdit","False")]
        [VisibleInDetailView(true)]
        [VisibleInListView(true)]
        public string TenXe
        {
            get
            {
                return $"{LoaiXe}-{DoiXe}-{BienSo}";
            }
            set => SetPropertyValue(nameof(TenXe), ref tenXe, value);
        }
        [XafDisplayName("Loại xe")]
        public LoaiXe LoaiXe
        {
            get => loaiXe;
            set => SetPropertyValue(nameof(LoaiXe), ref loaiXe, value);
        }
        [XafDisplayName("Đời xe")]
        public string DoiXe
        {
            get => doiXe;
            set => SetPropertyValue(nameof(DoiXe), ref doiXe, value);
        }
        [XafDisplayName("Biển số")]
        public string BienSo
        {
            get => bienSo;
            set => SetPropertyValue(nameof(BienSo), ref bienSo, value);
        }
        [XafDisplayName("Mầu sơn")]
        public MauSon MauSon
        {
            get => mauSon;
            set => SetPropertyValue(nameof(MauSon), ref mauSon, value);
        }
        [XafDisplayName("Sản xuất")]
        public QuocGia QuocGia
        {
            get => quocGia;
            set => SetPropertyValue(nameof(QuocGia), ref quocGia, value);
        }
        [XafDisplayName("Tên chủ xe")]
        public string TenChuXe
        {
            get => tenChuXe;
            set => SetPropertyValue(nameof(TenChuXe), ref tenChuXe, value);
        }
        [XafDisplayName("Giá thuê giờ")]
        public int GiaThueGio
        {
            get => giaThueGio;
            set => SetPropertyValue(nameof(GiaThueGio), ref giaThueGio, value);
        }
        [XafDisplayName("Giá thuê ngày")]
        public int GiaThueNgay
        {
            get => giaThueNgay;
            set => SetPropertyValue(nameof(GiaThueNgay), ref giaThueNgay, value);
        }
        [XafDisplayName("Giá thuê tháng")]
        public int GiaThueThang
        {
            get => giaThueThang;
            set => SetPropertyValue(nameof(GiaThueThang), ref giaThueThang, value);
        }
        
        [XafDisplayName("Trạng thái")]
        public TrangThaiXe TrangThaiXe
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if (ChoThue != null )
                    {
                        if(ChoThue.TrangThaiThue == TrangThaiThue.dangchothue)
                        {
                            return TrangThaiXe.dct;
                        }
                    }
                }
                return trangThaiXe;
            }
            set => SetPropertyValue(nameof(TrangThaiXe), ref trangThaiXe, value);
        }
        [XafDisplayName("Diễn giải")]
        [Size(SizeAttribute.Unlimited)]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
        private byte[] hinhAnh;
        [XafDisplayName("Hình ảnh")]
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] HinhAnh
        {
            get { return hinhAnh; }
            set { SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value); }
        }

        [Association("ChoThue-Xes")]
        [VisibleInDetailView(true)]
        [VisibleInListView(true)]
        public ChoThue  ChoThue
        {
            get => choThue;
            set => SetPropertyValue(nameof(ChoThue), ref choThue, value);
        }
        #endregion

        #region ChiTiet

        [XafDisplayName("Số chỗ")]
        public string SoCho
        {
            get => soCho;
            set => SetPropertyValue(nameof(SoCho), ref soCho, value);
        }
        [XafDisplayName("Dung tích")]
        public string DungTich
        {
            
            get
            {
                return dungTich;
            }
            set => SetPropertyValue(nameof(DungTich), ref dungTich, value);
        }
        [XafDisplayName("Số khung")]
        public string SoKhung
        {
            get => soKhung;
            set => SetPropertyValue(nameof(SoKhung), ref soKhung, value);
        }
        [XafDisplayName("Số máy")]
        public string SoMay
        {
            get => soMay;
            set => SetPropertyValue(nameof(SoMay), ref soMay, value);
        }
        [XafDisplayName("Đăng ký lần đầu")]
        public DateTime DangKyLanDau
        {
            get => dangKyLanDau;
            set => SetPropertyValue(nameof(DangKyLanDau), ref dangKyLanDau, value);
        }
        [XafDisplayName("Hết đăng kiểm")]
        public DateTime HetDangKiem
        {
            get => hetDangKiem;
            set => SetPropertyValue(nameof(HetDangKiem), ref hetDangKiem, value);
        }
        [XafDisplayName("Hết hạn bảo hiểm")]
        public DateTime? HetHanBaoHiem
        {
            get => hetHanBaoHiem;
            set => SetPropertyValue(nameof(HetHanBaoHiem), ref hetHanBaoHiem, value);
        }

        #endregion

        #region Association
        //[XafDisplayName("Hình xe")]
        //[Association("Xe-NhieuHinhs")]
        //public XPCollection<NhieuHinh> NhieuHinhs
        //{
        //    get
        //    {
        //        return GetCollection<NhieuHinh>(nameof(NhieuHinhs));
        //    }
        //}
        [XafDisplayName("Bảo dưỡng")]
        [Association("Xe-BaoDuongs")]
        public XPCollection<BaoDuong> BaoDuongs
        {
            get
            {
                return GetCollection<BaoDuong>(nameof(BaoDuongs));
            }
        }
        #endregion
    }
}