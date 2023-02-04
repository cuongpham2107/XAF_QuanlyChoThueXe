using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
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
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.Main
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuMain)]
    [DefaultProperty(nameof(TenNguoiThue))]
    //[ImageName("car")]
    [XafDisplayName("Cho thuê")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    [Appearance("PhaiThu",BackColor = "Blue",FontColor ="White", TargetItems = "PhaiThu", Context = "Any",Priority = 1)]
    [Appearance("PhaiTra", BackColor = "Gold", FontColor = "Black", TargetItems = "PhaiTra", Context = "Any", Priority = 2)]

    [Appearance("HideEdit", AppearanceItemType = "ViewItem", BackColor = "224,224,224", TargetItems = "*", Criteria = "[TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,dangchothue# Or [TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,datraxe#", Context = "Any", Enabled = false,Priority = 5)]
   
    [Appearance("Trangthaidangchothue", BackColor = "Gold", FontColor = "Black", TargetItems = "TrangThaiThue", Context = "Any",Priority = 3)]
    public class ChoThue : BaseObject
    { 
        public ChoThue(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        #region Property
        int phaiThu;
        byte[] cMNDS;
        byte[] cMNDT;
        string ghiChuNhanHang;
        string ghiChuNoiBo;
        int phaiTra;
        int phuThu;
        int tongPhi;
        int tienDenBu;
        int tienThue;
        int thang;
        DateTime? ngayTra;
        int soGioThue;
        string soPhieu;
        string dienGiai;
        int tamUng;
        DateTime ngayDuTinhTra;
        DateTime ngayCap;
        string noiCap;
        string soCMND;
        string soDienThoai;
        string tenNguoiThue;
        TrangThaiThue trangThaiThue;
        LoaiThue loaiThue;
        DateTime? ngayThue;
        [XafDisplayName("Ngày thuê")]
        public DateTime? NgayThue
        {
            get => ngayThue;
            set => SetPropertyValue(nameof(NgayThue), ref ngayThue, value);
        }
        [XafDisplayName("Loại thuê")]
        public LoaiThue LoaiThue
        {
            get => loaiThue;
            set => SetPropertyValue(nameof(LoaiThue), ref loaiThue, value);
        }
        [XafDisplayName("Trạng thái thuê")]
        public TrangThaiThue TrangThaiThue
        {
            get => trangThaiThue;
            set => SetPropertyValue(nameof(TrangThaiThue), ref trangThaiThue, value);
        }
        [XafDisplayName("Tên người thuê")]
        [RuleRequiredField("Bắt buộc phải có ChoThue.TenNguoiThue", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenNguoiThue
        {
            get => tenNguoiThue;
            set => SetPropertyValue(nameof(TenNguoiThue), ref tenNguoiThue, value);
        }
        [XafDisplayName("Số ĐT")]
        [RuleRequiredField("Bắt buộc phải có ChoThue.SoDienThoai", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        [XafDisplayName("Số CMND")]
        [RuleRequiredField("Bắt buộc phải có ChoThue.SoCMND", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string SoCMND
        {
            get => soCMND;
            set => SetPropertyValue(nameof(SoCMND), ref soCMND, value);
        }
        [XafDisplayName("Nơi cấp")]
        public string NoiCap
        {
            get => noiCap;
            set => SetPropertyValue(nameof(NoiCap), ref noiCap, value);
        }
        [XafDisplayName("Ngày cấp")]
        public DateTime NgayCap
        {
            get => ngayCap;
            set => SetPropertyValue(nameof(NgayCap), ref ngayCap, value);
        }
        
        [XafDisplayName("Tạm ứng")]
        public int TamUng
        {
            get => tamUng;
            set => SetPropertyValue(nameof(TamUng), ref tamUng, value);
        }
        [XafDisplayName("Diễn giải")]
        [Size(SizeAttribute.Unlimited)]
        public string DienGiai
        {
            get => dienGiai;
            set => SetPropertyValue(nameof(DienGiai), ref dienGiai, value);
        }
        [XafDisplayName("Số phiếu")]
        [ModelDefault("AllowEdit", "False")]
        public string SoPhieu
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (NgayThue != null && SoCMND != null)
                    {
                        return $"PT-{NgayThue?.Year}/{NgayThue?.Month}-{SoCMND}";
                    }
                }
                return null;
            }
            set => SetPropertyValue(nameof(SoPhieu), ref soPhieu, value);
        }
        [Appearance("HideGioThue", AppearanceItemType.ViewItem, "[LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,ngay# Or [LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,thang#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = true)]
        [XafDisplayName("Số giờ thuê")]
        public int SoGioThue
        {
            get => soGioThue;
            set => SetPropertyValue(nameof(SoGioThue), ref soGioThue, value);
        }
        [Appearance("HideNgayThue", AppearanceItemType.ViewItem, "[LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,gio# Or [LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,thang#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = true)]
        [XafDisplayName("Ngày trả")]
        public DateTime? NgayTra
        {
            get => ngayTra;
            set => SetPropertyValue(nameof(NgayTra), ref ngayTra, value);
        }

        [Appearance("HideNgayThang", AppearanceItemType.ViewItem, "[LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,gio# Or [LoaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+LoaiThue,ngay#", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = true)]
        [XafDisplayName("Thuê mấy tháng?")]
        public int Thang
        {
            get => thang;
            set => SetPropertyValue(nameof(Thang), ref thang, value);
        }

        [XafDisplayName("Tiền thuê")]
        [ModelDefault("AllowEdit", "False")]
        public int TienThue
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    int gia = 0;
                    switch (LoaiThue)
                    {
                        case LoaiThue.gio:
                            var giathuegio = this.Xes.Sum(i => i.GiaThueGio);
                            if (SoGioThue == 0)
                            {
                                gia = 0;
                            }
                            else
                            {
                                gia = giathuegio * SoGioThue;
                            }
                            break;
                        case LoaiThue.ngay:
                            var giathuengay = this.Xes.Sum(i => i.GiaThueNgay);
                            if (NgayTra != null && NgayThue != null)
                            {
                                TimeSpan time = (TimeSpan)(NgayTra - NgayThue);
                                int TongSoNgay = time.Days;

                                gia = giathuengay * TongSoNgay;
                            }
                            else
                            {
                                gia = 0;
                            }
                            break;
                        case LoaiThue.thang:
                            var giathuethang = this.Xes.Sum(i => i.GiaThueThang);
                            if (Thang == 0)
                            {
                                gia = 0;
                            }
                            else
                            {
                                gia = giathuethang * Thang;
                            }
                            break;
                    }
                    return gia;
                }
                return 0;

            }
            set => SetPropertyValue(nameof(TienThue), ref tienThue, value);
        }
        [XafDisplayName("Tiền đề bù")]
        [ModelDefault("AllowEdit", "False")]
        public int TienDenBu
        {
            get => tienDenBu;
            set => SetPropertyValue(nameof(TienDenBu), ref tienDenBu, value);
        }

        [XafDisplayName("Tổng phí")]
        [ModelDefault("AllowEdit", "False")]
        public int TongPhi
        {
            get
            {
                if (!IsSaving && !IsLoading)
                {
                    return TienThue + TienDenBu + PhuThu;
                }
                return 0;
            }
            set => SetPropertyValue(nameof(TongPhi), ref tongPhi, value);
        }

        [XafDisplayName("Phụ thu")]
        [ModelDefault("AllowEdit", "False")]
        public int PhuThu
        {
            get => phuThu;
            set => SetPropertyValue(nameof(PhuThu), ref phuThu, value);
        }    
        [XafDisplayName("Phải thu")]
        public int PhaiThu
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (TongPhi >= TamUng)
                    {
                        return TongPhi - TamUng;
                    }
                }
                return 0;
            }
            set => SetPropertyValue(nameof(PhaiThu), ref phaiThu, value);
        }
        [XafDisplayName("Tiền thừa")] 
        [ModelDefault("AllowEdit", "False")]
        public int PhaiTra
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(TongPhi <= TamUng)
                    {
                        return TamUng - TongPhi;
                    }
                }
                return 0;
            }
            set => SetPropertyValue(nameof(PhaiTra), ref phaiTra, value);
        }
        [XafDisplayName("Ghi chú nội bộ")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChuNoiBo
        {
            get => ghiChuNoiBo;
            set => SetPropertyValue(nameof(GhiChuNoiBo), ref ghiChuNoiBo, value);
        }
        [XafDisplayName("Ghi chú nhận hàng")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChuNhanHang
        {
            get => ghiChuNhanHang;
            set => SetPropertyValue(nameof(GhiChuNhanHang), ref ghiChuNhanHang, value);
        }
        [XafDisplayName("CMND Trước")]
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] CMNDT
        {
            get => cMNDT;
            set => SetPropertyValue(nameof(CMNDT), ref cMNDT, value);
        }
        [XafDisplayName("CMND Sau")]
        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] CMNDS
        {
            get => cMNDS;
            set => SetPropertyValue(nameof(CMNDS), ref cMNDS, value);
        }
        #endregion

        #region Association
        [Association("ChoThue-Xes")]
        [XafDisplayName("Chọn xe muốn thuê")]
        public XPCollection<Xe> Xes
        {
            get
            {
                return GetCollection<Xe>(nameof(Xes));
            }
        }
        #endregion

        #region Action
        [Action(Caption ="Cho thuê", ConfirmationMessage="Xác nhận cho thuê", TargetObjectsCriteria = "[TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,luutam#")]
        public void TrangThaiThueAction()
        {
            TrangThaiThue = TrangThaiThue.dangchothue;
        }
        [Action(Caption = "Nhận xe", AutoCommit = true,TargetObjectsCriteria = "[TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,dangchothue#")]
        public void NhanXeAction(NhanXeParameter parameter)
        {
            TienDenBu = parameter.DenBu;
            PhuThu = parameter.PhuThu;
            GhiChuNhanHang = parameter.GhiChuNhanHang;
            TrangThaiThue = TrangThaiThue.datraxe;
        }
        #endregion 
    }
    #region DomainComponent
    [DomainComponent]
    [XafDisplayName("Thông tin nhận xe")]
    public class NhanXeParameter
    {
        [XafDisplayName("Đền bù")]
        public int DenBu { get; set; }

        [XafDisplayName("Phụ thu")]
        public int PhuThu { get; set; }

        [XafDisplayName("Ghi chú nhận hàng")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChuNhanHang { get; set; }
    }
    #endregion
}