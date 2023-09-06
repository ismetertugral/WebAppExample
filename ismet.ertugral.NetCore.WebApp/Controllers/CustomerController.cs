using WebApp.Filters;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var CustomerList = CustomerContext.Customers;
            return View(CustomerList);
        }

        public IActionResult Create()
        {
            return View(new CreateCustomer());
        }

        [HttpPost]
        [ValidLastName]
        public IActionResult Create(Customer customer)
        {
            ModelState.Remove("Id");
            if (customer.FirstName.ToLower() == "ismet")
            {
                ModelState.AddModelError("", $"FirstName {customer.FirstName} olamaz");
            }
            if (ModelState.IsValid)
            {
                Customer? lastCustomer = null;
                if (CustomerContext.Customers.Count > 0)
                {
                    lastCustomer = CustomerContext.Customers.Last();
                }
                customer.Id = 1;

                if (lastCustomer != null)
                {
                    customer.Id = lastCustomer.Id + 1;
                }
                CustomerContext.Customers.Add(customer);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Update(int id)
        {
            var updatedCustomer = CustomerContext.Customers.FirstOrDefault(x => x.Id == id);
            return View(updatedCustomer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var updatedCustomer = CustomerContext.Customers.FirstOrDefault(x => x.Id == customer.Id);

                if (updatedCustomer != null)
                {
                    updatedCustomer.FirstName = customer.FirstName;
                    updatedCustomer.LastName = customer.LastName;
                    updatedCustomer.Age = customer.Age;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Customer Bulunamadı!");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var deletedCustomer = CustomerContext.Customers.FirstOrDefault(x => x.Id == id);
            if (deletedCustomer != null)
            {

                CustomerContext.Customers.Remove(deletedCustomer);
            }
            return RedirectToAction("Index");
        }
    }
}
