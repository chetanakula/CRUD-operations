using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD.Controllers
{
    public class employeeController : ApiController
    {
       APIEntities db = new APIEntities();
        //post request
        public string POST(Employess employess)
        {
            db.Employesses.Add(employess);
            db.SaveChanges();
            return "employee added successfully";
        }
        //Get request
        public IEnumerable<Employess> Get()
        {
          return db.Employesses.ToList();
        }
        //Get single record
        public Employess Get(int id)
        {
            Employess employee = db.Employesses.Find(id);
            return employee;
        }
        //updating the record
        public string PUT(int id,Employess employess)
        {
            var employess_ = db.Employesses.Find(id);
            employess_.name = employess.name;
            employess_.salary = employess.salary;
            employess_.gender = employess.gender;

            db.Entry(employess_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "employee details are updated";

        }
        //deleting the record
        public string DELETE(int id)
        {
            Employess employee = db.Employesses.Find(id);
            db.Employesses.Remove(employee);
            db.SaveChanges();
             return "record deleted successfully";
        }
    }
}
