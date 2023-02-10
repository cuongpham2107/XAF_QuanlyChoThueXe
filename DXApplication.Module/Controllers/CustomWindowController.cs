using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication.Module.Controllers
{
    public class CustomWindowController : WindowController
    {
        public SimpleAction MySimpleAction { get; private set; }
        public CustomWindowController() 
        { 
            MySimpleAction = new SimpleAction(this,nameof(MySimpleAction) , DevExpress.Persistent.Base.PredefinedCategory.Menu);
            MySimpleAction.Caption = "";
            MySimpleAction.ImageName = "chat";
            MySimpleAction.Execute += MySimpleAction_Execute;
        }
        private void MySimpleAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            
        }
    }
}
