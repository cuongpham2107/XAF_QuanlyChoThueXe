using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.Controllers
{
   
    public partial class ChoThueController : ObjectViewController<DetailView, ChoThue>
    {
       
        public ChoThueController()
        {
            InitializeComponent();
            Btn_ChoThue();
            NhanXe();
            
        }
        public void NhanXe()
        {
            var actionNhanXe = new PopupWindowShowAction(this, $"{nameof(NhanXe)}", "Edit")
            {
                Caption = "Nhận xe",
                ImageName = "rental",
                TargetViewNesting = Nesting.Root,
                TargetViewType = ViewType.DetailView,
                TargetObjectType = typeof(ChoThue),
                TargetObjectsCriteria = "[TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,dangchothue#",
                ConfirmationMessage = "Xác nhận nhận xe",
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject,
            };
            actionNhanXe.CustomizePopupWindowParams += btn_NhanXe_CustomizePopupWindowParams;
            actionNhanXe.Execute += btn_NhanXe;
        }
        public void btn_NhanXe_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(NhanXeParameter));
            os.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = e.Application.CreateDetailView(os, os.CreateObject<NhanXeParameter>());
        }
        public void btn_NhanXe(object s, PopupWindowShowActionExecuteEventArgs e)
        {
            ChoThue choThue = (ChoThue)View.CurrentObject;
            var parameter = ((NhanXeParameter)e.PopupWindowViewCurrentObject);
            choThue.TienDenBu = parameter.DenBu;
            choThue.PhuThu = parameter.PhuThu;
            choThue.GhiChuNhanHang = parameter.GhiChuNhanHang;
            choThue.TrangThaiThue = Blazor.Common.Enums.TrangThaiThue.datraxe;
            this.ObjectSpace.CommitChanges();
            if (((DetailView)ObjectSpace.Owner).CurrentObject is ChoThue ct)
            {

                GiaoDichTien gdt = ObjectSpace.CreateObject<GiaoDichTien>();
                var _chothue = ObjectSpace.GetObject(ct);
                gdt.Ngay = _chothue.NgayThue;
                if(_chothue.PhaiThu != 0)
                {
                    gdt.Thu = _chothue.PhaiThu;
                }
                else
                {
                    gdt.Thu = 0;
                }
                if (_chothue.PhaiTra != 0)
                {
                    gdt.Chi = _chothue.PhaiTra;
                }
                else
                {
                    gdt.Chi = 0;
                }
                gdt.LyDo = Blazor.Common.Enums.LyDo.khachHangTraTienThue;
                gdt.ChoThue = ct;
                this.ObjectSpace.CommitChanges();
            }

            Application.ShowViewStrategy.ShowMessage("Cập nhật thành công");
        }
       
        public void Btn_ChoThue()
        {
            var action = new SimpleAction(this, $"{nameof(Btn_ChoThue)}", "Edit")
            {
                Caption = "Cho Thuê",
                ImageName = "rental-car",
                TargetViewNesting = Nesting.Root,
                TargetViewType = ViewType.DetailView,
                TargetObjectType = typeof(ChoThue),
                TargetObjectsCriteria = "[TrangThaiThue] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiThue,luutam#",
                ConfirmationMessage = "Xác nhận cho thuê",
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject,
            };
            action.Execute += (s, e) =>
            {
                ChoThue choThue = (ChoThue)View.CurrentObject;
                choThue.TrangThaiThue = Blazor.Common.Enums.TrangThaiThue.dangchothue;
                this.ObjectSpace.CommitChanges();
                if(((DetailView)ObjectSpace.Owner).CurrentObject is ChoThue ct)
                {

                    GiaoDichTien gdt = ObjectSpace.CreateObject<GiaoDichTien>();
                    var _chothue = ObjectSpace.GetObject(ct);
                    gdt.Ngay = _chothue.NgayThue;
                    gdt.Thu = _chothue.PhaiThu;
                    gdt.LyDo = Blazor.Common.Enums.LyDo.thuTienTamUng;
                    gdt.Chi = 0;
                    gdt.ChoThue = ct;
                    this.ObjectSpace.CommitChanges();
                }
                Application.ShowViewStrategy.ShowMessage("Cập nhật thành công");
            };
        }
        protected override void OnActivated()
        {
            base.OnActivated();
           
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            
        }
        protected override void OnDeactivated()
        {
            
            base.OnDeactivated();
        }
    }
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
}
