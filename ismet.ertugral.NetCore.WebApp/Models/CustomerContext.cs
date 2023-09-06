namespace WebApp.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new(){
            new Customer { Id = 1, FirstName = "İsmet", LastName = "ERTUĞRAL", Age = 30},
            new Customer { Id = 2, FirstName = "FirstNameExample", LastName = "LastNameExample", Age = 20 }
        };
    }
}