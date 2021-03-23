using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace AYasinNorthwindWebServiceCs
{
    /// <summary>
    /// Summary description for CsUrunServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CsUrunServis : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World Cs";
        }
        KuzeyYeliDataContext dataContext = new KuzeyYeliDataContext();
        public Oturum Giris { get; set; }
        
        [WebMethod]
        [SoapHeader("Giris")]
        public List<UrunResult> GetProducts()
        {
            if (Giris.KullaniciAdi == "Admin" && Giris.Parola == "123")
            {
                return dataContext.Products.Select(x => new UrunResult
                {
                    ProductID = x.ProductID,
                    CategoryId = (int)x.CategoryID,
                    ProductName = x.ProductName,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock
                }).ToList();
            }
            else
            {
                return new List<UrunResult> {
                    new UrunResult { CategoryId = 0, ProductID = 0, ProductName = "YETKISIZ", QuantityPerUnit = "GIRIS", UnitPrice = 0, UnitsInStock = 0 },
                    new UrunResult { CategoryId = 0, ProductID = 0, ProductName = "ERISIM", QuantityPerUnit = "REDDEDILDI", UnitPrice = 0, UnitsInStock = 0 }
                };
            }
        }
    }

    public class Oturum : SoapHeader
    {
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
    }
    public class UrunResult
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
    }
}