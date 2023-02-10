using DevExpress.Xpo;
using DXApplication.Blazor.BusinessObjects;

namespace DXApplication.Blazor.Server.Models
{
    public partial class UserMessage 
    {
        

        public string Username { get; set; }
        public string Message { get; set; }
        public bool CurrentUser { get; set; }
        public DateTime DateSent { get; set; }
        public IList<ApplicationUser> Users { get; set; }

    }
}
