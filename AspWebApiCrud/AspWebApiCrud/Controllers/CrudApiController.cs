using AspWebApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace AspWebApiCrud.Controllers
{
    public class CrudApiController : ApiController
    {
        AspWebApiCrudEntities db = new AspWebApiCrudEntities();


        //Api for data retrieval
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee()
        {
             List<Employee> list = db.Employees.ToList();
            return Ok(list);

        }

        //Api for data insertion
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetInsert(Employee e)
        {

            db.Employees.Add(e);
            db.SaveChanges();

            return Ok();
        }

        //Api for data Details
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
           var emp =  db.Employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        //Api for row update
        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpadte(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


            // ya uper wala code likh lo ya neechay wala likh loo

            //var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();
            //if (emp != null)
            //{
            //    emp.id = e.id;
            //    emp.Name = e.Name;
            //    emp.gender = e.gender;
            //    emp.age = e.age;
            //    emp.designation = e.designation;
            //    emp.salary = e.salary;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();   
            //}

            return Ok();
        }

        // Api for delete method 

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Empdelete(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
