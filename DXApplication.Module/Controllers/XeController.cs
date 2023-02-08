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
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DataAccess.Native.Web;
using System.IO;
using System.Reflection;
using DevExpress.Persistent.BaseImpl;
using DXApplication.Module.BusinessObjects.Categories;

namespace DXApplication.Module.Controllers
{
   
    public partial class XeController : ObjectViewController<ListView, Xe>
    {
        
        public XeController()
        {
            InitializeComponent();

            Btn_ImportExcel();
        }
        public void Btn_ImportExcel()
        {
            var customUploadFileAction = new PopupWindowShowAction(this, $"{Btn_ImportExcel}", "Edit")
            {
                Caption = "Import Xe(File Excel)",
                ImageName = "AddFile",
                TargetViewNesting = Nesting.Root,
                TargetObjectType = typeof(Xe),
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            customUploadFileAction.Execute += ImportExcel;
            customUploadFileAction.CustomizePopupWindowParams += ImportExcel_CustomizePopupWindowParams;
        }
        public void ImportExcel_CustomizePopupWindowParams(object s, CustomizePopupWindowParamsEventArgs  e)
        {
            NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(UploadFileParameters));
            os.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = e.Application.CreateDetailView(os, os.CreateObject<UploadFileParameters>());
        }
        public void ImportExcel(object s, PopupWindowShowActionExecuteEventArgs e)
        {
            FileData fileData = ((UploadFileParameters)e.PopupWindowViewCurrentObject).File;

           
            using (var stream = new MemoryStream())
            {
                fileData.SaveToStream(stream);
                stream.Position = 0;

                var temp = Path.GetTempPath(); // Get %TEMP% path
                var file = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()); // Get random file name without extension
                var path = Path.Combine(temp, file + ".xlsx"); // Get random file path

                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    // Write content of your memory stream into file stream
                    stream.WriteTo(fs);
                }
                try
                {
                    var package = new ExcelPackage(new FileInfo(path));
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet"]; ;
                    for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        try
                        {
                            var xe = ObjectSpace.CreateObject<Xe>();
                            int j = 1;
                            var tenxe = workSheet.Cells[i, j++].Value;
                            if(tenxe != null)
                            {
                                xe.TenXe = tenxe.ToString();
                            }
                            else
                            {
                                xe.TenXe = null;
                            }

                            var loaixe = workSheet.Cells[i, j++].Value.ToString();
                            CriteriaOperator lCriteria = CriteriaOperator.Parse("Contains([TenLoaiXe], ?)", loaixe);
                            LoaiXe _lx = ObjectSpace.FindObject<LoaiXe>(lCriteria);
                            if(_lx != null)
                            {
                                xe.LoaiXe = _lx;
                            }
                            else
                            {
                                LoaiXe createLx = ObjectSpace.CreateObject<LoaiXe>();
                                createLx.TenLoaiXe = loaixe;
                                xe.LoaiXe = createLx;
                            } 
                            xe.DoiXe = workSheet.Cells[i, j++].Value.ToString();

                            xe.BienSo = workSheet.Cells[i, j++].Value.ToString();

                            var mauson = workSheet.Cells[i, j++].Value.ToString();
                            CriteriaOperator mCriteria = CriteriaOperator.Parse("Contains([MauSonXe], ?)", mauson);
                            MauSon _ms = ObjectSpace.FindObject<MauSon>(mCriteria);
                            if(_ms != null)
                            {
                                xe.MauSon= _ms;
                            }
                            else
                            {
                                MauSon createMs = ObjectSpace.CreateObject<MauSon>();
                                createMs.MauSonXe = mauson;
                                xe.MauSon = createMs;
                            }

                            var sanxuat = workSheet.Cells[i, j++].Value.ToString();
                            CriteriaOperator sxCriteria = CriteriaOperator.Parse("Contains([TenQuocGia], ?)", sanxuat);
                            QuocGia _sx = ObjectSpace.FindObject<QuocGia>(sxCriteria);
                            if (_sx != null)
                            {
                                xe.QuocGia = _sx;
                            }
                            else
                            {
                                QuocGia createSx = ObjectSpace.CreateObject<QuocGia>();
                                createSx.TenQuocGia = sanxuat;
                                xe.QuocGia = createSx;
                            }

                            var socho = workSheet.Cells[i, j++].Value;
                            if (socho != null)
                            {
                                xe.SoCho = socho.ToString();
                            }
                            else
                            {
                                xe.SoCho = null;
                            }
                            var tenchuxe = workSheet.Cells[i, j++].Value;
                            if(tenchuxe != null)
                            {
                                xe.TenChuXe = tenchuxe.ToString();
                            }
                            else
                            {
                                xe.TenChuXe = null;
                            }
                            

                            xe.GiaThueGio = int.Parse(workSheet.Cells[i, j++].Value.ToString());
                            xe.GiaThueNgay = int.Parse(workSheet.Cells[i, j++].Value.ToString());
                            xe.GiaThueThang = int.Parse(workSheet.Cells[i, j++].Value.ToString());
                            xe.TrangThaiXe = Blazor.Common.Enums.TrangThaiXe.kd;
                            
                            View.CollectionSource.Add(xe);
                            ObjectSpace.CommitChanges();
                            Application.ShowViewStrategy.ShowMessage("Nhập file excel thành công");

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    View.Refresh();
                }
                catch (Exception)
                {

                    throw;
                }
            }
           
        }
        
    }

    [DomainComponent]
    [XafDisplayName("Upload File Danh Sách Xe")]
    public class UploadFileParameters : NonPersistentObjectImpl
    {
        private FileData file;
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        [RuleRequiredField("Save", "File should be assigned")]
        [XafDisplayName("Chọn file")]
        public FileData File
        {
            get { return file; }
            set
            {
                SetPropertyValue(ref file, value);
            }
        }
    }
}
