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

namespace DXApplication.Module.Controllers
{
   
    public partial class XeController : ObjectViewController<ListView, Xe>
    {
        
        public XeController()
        {
            InitializeComponent();
            Btn_FileMau();
            
        }
        public void Btn_FileMau()
        {
            var action = new SimpleAction(this, $"{nameof(Btn_FileMau)}", "Edit")
            {
                Caption = "Tải File mẫu",
                TargetViewNesting = Nesting.Root,
                TargetObjectsCriteria = "",
                SelectionDependencyType = SelectionDependencyType.Independent,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(Xe),
              
            };
            action.Execute += (s, e) =>
            {
                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                string filePath = rootpath + "\\FileMau\\filemau.xlsx";

            };
        }
        
    }
   

}
