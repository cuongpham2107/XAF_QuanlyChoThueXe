using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DXApplication.Module.BusinessObjects.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication.Module.Controllers
{
    
    public partial class BaoDuongController : ViewController
    {
        
        public BaoDuongController()
        {
            InitializeComponent();
            Btn_DuyetChot();
            
        }

        public void Btn_DuyetChot()
        {
            var action = new SimpleAction(this, $"{nameof(Btn_DuyetChot)}", "Edit")
            {
                Caption = "Duyệt & Chốt",
                ImageName = "Check",
                TargetViewNesting = Nesting.Nested,
                TargetViewType = ViewType.Any,
                TargetObjectType = typeof(BaoDuong),
                TargetObjectsCriteriaMode = TargetObjectsCriteriaMode.TrueAtLeastForOne,
                TargetObjectsCriteria = "[TrangThaiBaoDuong] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThaiBaoDuong,lt#",
                ConfirmationMessage = "Bạn có chắc duyệt dữ liệu này? Sau khi duyệt, bạn không thể chỉnh sửa được nữa",
                SelectionDependencyType = SelectionDependencyType.RequireSingleObject,
            };
            action.Execute += (s, e) =>
            {
                BaoDuong baoDuong = (BaoDuong)View.CurrentObject;
                baoDuong.TrangThaiBaoDuong = Blazor.Common.Enums.TrangThaiBaoDuong.dx;
                

                GiaoDichTien gdt = ObjectSpace.CreateObject<GiaoDichTien>();

                gdt.Ngay = baoDuong.Ngay;
                if(baoDuong.LoaiBaoDuong == Blazor.Common.Enums.LoaiBaoDuong.sc)
                {
                    gdt.LyDo = Blazor.Common.Enums.LyDo.baoDuongSuaChua;
                }
                else
                {
                    gdt.LyDo = Blazor.Common.Enums.LyDo.doXang;
                }

                gdt.Thu = 0;
                gdt.Chi = baoDuong.ThanhTien;
                gdt.BaoDuong = baoDuong;

                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Cập nhật thành công");
            };
        }
        
    }
   
}
