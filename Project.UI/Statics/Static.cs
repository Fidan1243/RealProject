using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using System.Linq;
using System.Security.Claims;

namespace Project.UI.Statics
{
    public static class Static
    {
        public static string Toilets = "Toilets";
        public static string Mirrors = "Mirrors";
        public static string SinkUnits = "Sink Units";
        public static string Showers = "Showers";
        public static string Marbles = "Marbles";
        public static string Decoration_Marbles = "Decoration Marbles";
        public static string Open = "Open";
        public static string Pending = "Pending";
        public static string Canceled = "Canceled";
        public static string Completed = "Completed";
        public static User UserStart(ControllerBase controllerBase, IUserService service)
        {
            ClaimsPrincipal currentUser = controllerBase.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return service.GetUsers().FirstOrDefault(ui => ui.User_Id == currentUserID);

        }
    }
}
