using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CRUD.Models;
using CRUD.repository;

namespace CRUD.repository
{
    public class Employerepository:IEmployerepository
    {
        private readonly APIEntities _context;
        public Employerepository()
        {
            _context = new APIEntities();
        }
        public Employerepository(APIEntities context)
        {
            _context = context;
        }
        public IEnumerable<Employess> GetAll()
        {
            return _context.Employesses.ToList();
        }
        public Employess GetById(int id)
        {
            return _context.Employesses.Find(id);
        }
        public void Insert(Employess employess)
        {
            _context.Employesses.Add(employess);
        }
        public void Update(Employess employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Employess employee = _context.Employesses.Find(id);
            _context.Employesses.Remove(employee);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
    
