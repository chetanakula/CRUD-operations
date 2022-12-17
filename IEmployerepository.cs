using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models;

namespace CRUD.repository
{
    public interface IEmployerepository
    {
       
            IEnumerable<Employess> GetAll();
            Employess GetById(int id);
            void Insert(Employess employee);
            void Update(Employess employee);
            void Delete(int id);
            void Save();
        
    }
}
