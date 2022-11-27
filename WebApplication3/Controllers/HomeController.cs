using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.UI.Helpers;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private IFriendService _friendService = null;
        private IPostService _postService = null;
        private IUserService _userService = null;
        private INotificationService _notiService = null;
        private IWebHostEnvironment _webhost;

        public HomeController(IPostService postService, IUserService userService, IFriendService friendService, IWebHostEnvironment webhost, INotificationService notiService)
        {
            _postService = postService;
            _userService = userService;
            _friendService = friendService;
            _webhost = webhost;
            _notiService = notiService;
        }
        static List<User> userss = null;
        static User users = null;
        List<Post> postsfr = new List<Post>();
        List<int> friendss = new List<int>();
        public async Task<IActionResult> IndexAsync()
        {
            var model = HelpStart();
            return View(model);
        }
        [HttpPost]
        public IActionResult NewPost(string post)
        {

            Post postn = new Post
            {
                User_Id = users.Id,
                Category_Id = 1,
                Comment_Count = 0,
                Like_Count = 0,

            };
            if (post.Contains("images/") || post.Contains("https") || post.Contains("www"))
            {
                var dd = post.Split(' ');
                for (int i = 0; i < dd.Length; i++)
                {
                    if (dd[i].Contains("images/") || dd[i].Contains("https") || post.Contains("www"))
                    {
                        postn.Path = dd[i];
                    }
                    else
                    {
                        postn.Post_Content += dd[i] + " ";
                    }
                }
            }
            else
            {
                postn.Post_Content = post;
            }
            _postService.Add(postn);
            return RedirectToAction("Index");
        }
        public IActionResult Stories()
        {

            var model = HelpStart();
            return View(model);
        }


        public IActionResult Groups()
        {

            var model = HelpStart();
            return View(model);
        }

        public IActionResult Accept(int id)
        {

            var model = HelpStart();
            var notification = model.Notifications.FirstOrDefault(p => p.User_Id == model.CurrentUserr.Id && p.User_Sended_Id == id);
            notification.Is_Read = true;
            notification.Is_Accepted = true;
            _friendService.AddFriend(new Friend { User_Friend_Id = model.Users.FirstOrDefault(p => p.Id == id).Id, User_Id = model.CurrentUserr.Id });

            return RedirectToAction("Index");

        }
        public IActionResult Decline(int id)
        {

            var model = HelpStart();
            var notification = model.Notifications.FirstOrDefault(p => p.User_Id == model.CurrentUserr.Id && p.User_Sended_Id == id);
            notification.Is_Read = true;
            notification.Is_Accepted = false;
            return RedirectToAction("Index");

        }
        public IActionResult Requestt(int id)
        {

            var model = HelpStart();
            var ist = model.Notifications.FirstOrDefault(p => p.User_Id == id && p.User_Sended_Id == model.CurrentUserr.Id);
            if (ist == null)
            {
                _notiService.Add(new Notification
                {
                    User_Id = id,
                    User_Sended_Id = model.CurrentUserr.Id,
                    Is_Read = false,
                    Is_Accepted = false
                });
            }
            return RedirectToAction("Index");

        }
        public IActionResult Profile()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult MailBox()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult Events()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult LiveStream()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult Settings()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult Account()
        {
            var model = HelpStart();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AccountAsync(UserViewModel user)
        {
            var helper = new ImageHelper(_webhost);
            user.ImageUrl = await helper.SaveFile(user.File);
            User the_user = new User
            {
                Id = user.Id,
                User_Id = user.User_Id,
                Email = user.Email,
                Addres = user.Addres,
                City = user.City,
                Description = user.Description,
                ImagePath = user.ImageUrl,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
            _userService.Update(the_user);

            return RedirectToAction("Account");
        }
        public IActionResult ChangePassword()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult Notifications()
        {
            var model = HelpStart();
            return View(model);
        }
        public IActionResult Chat()
        {
            var model = HelpStart();
            return View(model);
        }


        public SocialViewModel HelpStart()
        {

            var postss = _postService.GetAll();
            userss = _userService.GetAll();
            var notifications = _notiService.GetAll();
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            users = userss.FirstOrDefault(p => p.User_Id == currentUserID);

            var friends = _friendService.GetFriends(users.Id);
            var mine = _postService.GetByUser(users.Id);

            for (int k = 0; k < friends.Count; k++)
            {
                for (int i = 0; i < postss.Count; i++)
                {

                    if (postss[i].User_Id == friends[k].User_Id || postss[i].User_Id == friends[k].User_Friend_Id)
                    {
                        var tf = false;
                        for (int j = 0; j < postsfr.Count; j++)
                        {
                            if (postss[i].Id == postsfr[j].Id)
                            {
                                tf = true;
                                break;
                            }
                        }
                        if (!tf)
                        {

                            postsfr.Add(postss[i]);
                        }

                    }
                }
            }
            for (int i = 0; i < friends.Count; i++)
            {
                if (friends[i].User_Id != users.Id)
                {
                    friendss.Add(friends[i].User_Id);
                }
                else
                {
                    friendss.Add(friends[i].User_Friend_Id);

                }
            }

            return new SocialViewModel
            {
                Posts = postsfr,
                Notifications = notifications,
                Users = userss,
                Friends = friendss,
                CurrentUserr = users,
                User = new UserViewModel { 
                    Id = users.Id,
                    User_Id = currentUserID,
                    Email = users.Email,
                    Addres = users.Addres,
                    City = users.City,
                    Description = users.Description,
                    ImagePath = users.ImagePath,
                    Name = users.Name,
                    Surname = users.Surname,
                    Phone = users.Phone,
                    ZipCode = users.ZipCode }
                
            };
        }
    }
}
