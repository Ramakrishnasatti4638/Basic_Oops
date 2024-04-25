using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    /// <summary>
    /// 
    /// This class is used to create product details
    /// 
    /// </summary>
    public class ProductDetails
    {
        private static int s_productID=100;
    

        public string ProductID { get;}
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public int ProductShippingDuration { get; set; }

        public ProductDetails(string productID,string productName,int productStock,double productPrice,int productShippingDuration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            ProductPrice=productPrice;
            ProductStock=productStock;
            ProductShippingDuration=productShippingDuration;

        }
    }
}