using AspWebApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspWebApiCrud.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();
       
        // for get request 
        public ActionResult Index()
        {

            List<Employee> list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");

            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee>>();
                display.Wait();
                list = display.Result;
            }

            return View(list);
        }

         // for craete request 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");

            var response = client.PostAsJsonAsync<Employee>("CrudApi", emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View("Create");
        }
        // for details request
        public ActionResult Details(int id) {

            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id="+ id.ToString());         
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);     
        }

        // for edit request
        public ActionResult Edit(int id)
        {

            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee e) {


            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Index");   
            }
            return View("Edit");
        }


      
        public ActionResult Delete(int id)
        {
            Employee e = null;
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>(); 
                display.Wait(); 
                e = display.Result;                
            }
            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleteconfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44384/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString() );
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}