using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using System.Net.Http;
using AddWebTask.Models;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace AddWebTask.Controllers
{
    public class HomeController : Controller
    {
        public System.Web.Mvc.ActionResult Index()
        {
            return View();
        }
        public System.Web.Mvc.ActionResult Details()
        {
            return View("Detail");
        }

        [System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult Detail()
        {
            if (Request.Form.Keys.Count > 0)
            {
                int id = int.Parse(Request.Form.Keys[0]);
                AddUserModel user = new AddUserModel();
                AddWebModel dbContext = new AddWebModel();
                user.expriences= dbContext.Expriences.Where(u => u.ownerId == id ).ToList<Exprience>();
                user.user= dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
                ViewBag.detailUser = user;

                return RedirectToActionPermanent("Details");

            }
            return View("Detail");
        }
        public System.Web.Mvc.ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("addUser")]
        public System.Web.Mvc.ActionResult addUser()
        {
            if (Request.Form.Keys.Count > 0)
            {
                Users addedUser = new Users();
                addedUser.Fname = Request.Form.Keys[0];
                addedUser.Lname = Request.Form.Keys[1];
                string apiUrl = ConfigurationSettings.AppSettings["apiUrl"];
                AddUserModel newUser = new AddUserModel();
                newUser.user = new Users();
                newUser.user = addedUser;
               
           //     
                if (TempData.Peek("sessionExp") != null)
                {
                    List<Exprience> expList = JsonConvert.DeserializeObject<List<Exprience>>(TempData.Peek("sessionExp").ToString());
                    
                    if (expList.Count > 0)
                    {
                        newUser.expriences = new List<Exprience>();
                        newUser.expriences = expList;
                        apiUrl = ConfigurationSettings.AppSettings["apiUrl"];
             //           HttpClient client1 = new HttpClient();
               //         HttpResponseMessage response1 = client.PostAsJsonAsync<String>(apiUrl, JsonConvert.SerializeObject(expList).ToString()).Result;
                 //       if (response1.IsSuccessStatusCode)
                   //     {
                     //       response1b = true;
                       // }
                    }
                }


                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsJsonAsync<String>(apiUrl,JsonConvert.SerializeObject(newUser) ).Result;
              
                if (response.IsSuccessStatusCode )
                {
                    return View("About");
                }

            }
            return View("About");
        }   
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("addExperience")]
       

        public Microsoft.AspNetCore.Mvc.NoContentResult addExperience()            
        {
            if (Request.Form.Keys.Count > 3)
            {

                Exprience exp = new Exprience();
                exp.company = Request.Form.Keys[0];
                exp.position = Request.Form.Keys[1];
                exp.FromDate =Request.Form.Keys[2];
                exp.toDate = Request.Form.Keys[3];
                
                
                List<Exprience> expList = new List<Exprience>();
                
                if (TempData.Peek("sessionExp") == null)
                {
                    expList.Add(exp);
                    TempData["sessionExp"] = JsonConvert.SerializeObject(expList);
                }
                else
                {
                    expList = JsonConvert.DeserializeObject<List<Exprience>>(TempData.Peek("sessionExp").ToString());
                    expList.Add(exp);
                    TempData["sessionExp"] = JsonConvert.SerializeObject(expList);
                }
            }
            
            
            
            //expList.Add(exp);
          //  TempData["tempExp"] = JsonConvert.SerializeObject(expList);
            return new NoContentResult();
        }
        public System.Web.Mvc.ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string apiUrl = ConfigurationSettings.AppSettings["apiUrl"];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            List<AddUserModel> users = new List<AddUserModel>();
            if (response.IsSuccessStatusCode)   
            {
                users = response.Content.ReadAsAsync<List<AddUserModel>>().Result;
              
            }
            ViewBag.Message = "Your contact page.";
            ViewBag.users = users;
            
            

            return View();
        }

    }
}