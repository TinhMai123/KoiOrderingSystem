using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiOrderingSystem_Web.Pages.Customer
{
    public class ProfileModel : AuthPageModel
    {
        public User Profile { get; set; }  
        public void OnGet()
        {
            var user = JsonUtils.FromJson<User>(HttpContext.Session.GetString("User"));
            Profile = user;
        }
    }
}
