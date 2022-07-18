using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddWebTask.Models;
using Newtonsoft.Json;
namespace AddWebTask.Controllers
{
    public class AddWebApiController : ApiController
    {
        private AddWebModel dbContext = new AddWebModel();

        // GET api/<controller>
        public List<AddUserModel> Get()
        {
            List<Users> us = dbContext.Users.ToList<Users>();
            List<AddUserModel> users = new List<AddUserModel>();
             for(int i=0; i<us.Count; i++)
            {
                AddUserModel tmp = new AddUserModel();
                tmp.user = us[i];
                int x = us[i].Id;
                tmp.expriences = dbContext.Expriences.Where(e => e.ownerId == x).ToList<Exprience>();
                users.Add(tmp);
            }
            return users;
            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            AddUserModel addedUser = new AddUserModel();

            addedUser = JsonConvert.DeserializeObject<AddUserModel>(value);
            // addedUser.dob = Convert.ToDateTime(addedUser.dob);
            //addedUser.Id = 1;
            dbContext.Users.Add(addedUser.user);
            dbContext.SaveChanges();
            //dbContext.Users.Add(addedUser);
            for(int i=0; i< addedUser.expriences.Count; i++)
            {
                int x = dbContext.Users.Count();
                List<Users> users = new List<Users>();
                users = dbContext.Users.ToList<Users>();

                addedUser.expriences[i].ownerId = users.Last().Id;
                dbContext.Expriences.Add(addedUser.expriences[i]);
            }

            dbContext.SaveChanges();
            //dbContext.addUser(addedUser);
            
        }
        

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}