using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AYasinNorthwindWebServiceCs
{
    /// <summary>
    /// Summary description for CsCustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CsCustomerService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        KuzeyYeliDataContext context = new KuzeyYeliDataContext();
        [WebMethod]
        public List<Musteriler> GetCustomers()
        {
            return context.Customers.Select(c => new Musteriler
            {
                Address = c.Address,
                City = c.City,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                Country = c.Country,
                CustomerID = c.CustomerID,
                Phone = c.Phone,
            }).ToList();
        }
    }

    public class Musteriler
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
    }
}
