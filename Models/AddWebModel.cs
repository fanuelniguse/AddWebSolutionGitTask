using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AddWebTask.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }

    }
    public class Exprience
    {
        public int id { get; set; }
        public int ownerId { get; set; }
        public string company { get; set; }
        public string FromDate { get; set; }
        public string toDate { get; set; }
        public string position { get; set; }
    }
    public class AddUserModel
    {
        public Users user { get; set; }
        public List<Exprience> expriences { get; set; }
    }

    public class AddWebModel:DbContext
    {
        public AddWebModel()
        {

        }
        
        public void addUser(Users user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
        public void addExperience(Exprience exp)
        {

            //exp.id = userId;
            this.Expriences.Add(exp);
            this.SaveChanges();
        }
        public void removeExperience(int expId)
        {
            Exprience exprience = new Exprience();
            exprience = this.Expriences.Where(e => e.id == expId).FirstOrDefault();
            this.Expriences.Remove(exprience);
            this.SaveChanges();
            
        }
        
     
        public DbSet<Users> Users { get; set; }
        public DbSet<Exprience> Expriences { get; set; }
    }
}