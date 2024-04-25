using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
namespace SynCart;
class Program 
{
    static List<CustomerDetails> customerList=new List<CustomerDetails>(); //Customers List
    static List<OrderDetails> orderList=new List<OrderDetails>();   //Order List
    static List<ProductDetails> productList=new List<ProductDetails>();       //Product List

    static bool isSet=true;

    static double deliveryCharge=50;
    public static void Main(string[] args)
    {
        DefaultValues();
        System.Console.WriteLine("-------------------------Welcome To SynCart---------------------------");
        string mainMenu="";
        do
        {
            System.Console.WriteLine("              Menu            ");
            System.Console.WriteLine("1. Customer Registration");
            System.Console.WriteLine("2. Login");
            System.Console.WriteLine("3. Exit");
            System.Console.WriteLine("Enter the option number from above: ");
            int newOption=int.Parse(Console.ReadLine());
            switch(newOption)
            {
                case 1:
                {
                    Registration();
                    System.Console.WriteLine("Do you want to continue: ");
                    mainMenu=Console.ReadLine();
                    break;
                }
                case 2:
                {
                    Login();
                    if(isSet)
                    {
                        System.Console.WriteLine("Do you want to continue: ");
                        mainMenu=Console.ReadLine();
                    }
                    mainMenu="yes";
                    break;
                }
                case 3:
                {
                    Environment.Exit(0);
                    break;
                }
            }

        } while (mainMenu=="yes");

    }

    public static void DefaultValues()
    {
        
        ProductDetails product=new ProductDetails("","Mobile (Samsung)   ",10   ,10000,3);
        ProductDetails product1=new ProductDetails("","Tablet (Lenovo)    ",5    ,15000,2);
        ProductDetails product2=new ProductDetails("","Camara (Sony)      ",3    ,20000,4);
        ProductDetails product3=new ProductDetails("","iPhone             ",5    ,50000,6);
        ProductDetails product4=new ProductDetails("","Laptop (Lenovo I3) ",3    ,40000,3);
        ProductDetails product5=new ProductDetails("","HeadPhone (Boat)   ",5    ,1000 ,2);
        ProductDetails product6=new ProductDetails("","Speakers (Boat)    ",4    ,500  ,2);
        productList.Add(product);
        productList.Add(product1);
        productList.Add(product2);
        productList.Add(product3);
        productList.Add(product4);
        productList.Add(product5);
        productList.Add(product6);
        
        CustomerDetails customer=new CustomerDetails("","Ravi","Chennai","9885858588",50000,"ravi@mail.com");
        CustomerDetails customer1=new CustomerDetails("","Baskaran","Chennai","9888475757",60000,"baskaran@mail.com");
        customerList.Add(customer);
        customerList.Add(customer1);


        OrderStatus orderStatus;
        Enum.TryParse<OrderStatus>("Ordered",true,out orderStatus);
        OrderDetails order=new OrderDetails("",customer.CustomerID,product.ProductID,20000,DateTime.Now,2,orderStatus);
        OrderStatus orderStatus1;
        Enum.TryParse<OrderStatus>("Ordered",true,out orderStatus1);
        OrderDetails order1=new OrderDetails("",customer1.CustomerID,product2.ProductID,40000,DateTime.Now,2,orderStatus1);
        orderList.Add(order);
        orderList.Add(order1);  
    }

    public static void Registration()
    {
        System.Console.WriteLine("Enter Your Name: ");
        string customerName=Console.ReadLine();
        System.Console.WriteLine("Enter your City: ");
        string customerCity=Console.ReadLine();
        System.Console.WriteLine("Enter your Number: ");
        string customerNumber=Console.ReadLine();
        System.Console.WriteLine("Enter your MailID: ");
        string customerMailID=Console.ReadLine();
        System.Console.WriteLine("Enter your Wallet Balance");
        double customerWalletBalance=double.Parse(Console.ReadLine());

        CustomerDetails customer=new CustomerDetails("",customerName,customerCity,customerNumber,customerWalletBalance,customerMailID);
        customerList.Add(customer);
        System.Console.WriteLine("Account created successfully. Your CustomerID is "+customer.CustomerID);

    }

    public static void Login()
    {
        System.Console.WriteLine("Enter your CustomerID to login: ");
        string customerID=Console.ReadLine();
        CustomerDetails customer=customerList.Find(x=>x.CustomerID==customerID);
        if(customer==null)
        {
            System.Console.WriteLine("Invalid customerID");
            return;
        }
        do
        {
            System.Console.WriteLine("a. Purchase");
            System.Console.WriteLine("b. Order History");
            System.Console.WriteLine("c. Cancel Order");
            System.Console.WriteLine("d. Wallet Balance");
            System.Console.WriteLine("e. Wallet Recharge");
            System.Console.WriteLine("f. Exit");
            char newOption=char.Parse(Console.ReadLine());
            switch(newOption)
            {
                case 'a':
                {
                    Purchase(customer);
                    isSet=true;
                    break;
                }
                case 'b':
                {
                    OrderHistory(customer);
                    isSet=true;
                    break;
                }
                case 'c':
                {
                    CancelOrder(customer);
                    isSet=true;
                    break;
                }
                case 'd':
                {
                    System.Console.WriteLine(customer.CustomerWalletBalance);
                    isSet=true;
                    break;
                }
                case 'e':
                {
                    System.Console.WriteLine("Do you want to recharge your Wallet: ");
                    string walletRecharge=Console.ReadLine();
                    if(walletRecharge=="yes")
                    {
                        customer.WalletRecharge();
                    }
                    else
                    {
                        return;
                    }
                    isSet=true;
                    break;
                }

                case 'f':
                {
                    isSet=false;
                    return;
                }
            }
        }
        while(true);

    }

    public static void Purchase(CustomerDetails customer)
    {
        System.Console.WriteLine("                  Product Details                         ");
        System.Console.WriteLine("ProductID     Product Name     Available stock quantity    Price per quantity     Shipping Duration");
        foreach(ProductDetails values in productList)
        {
            System.Console.WriteLine($"{values.ProductID}       {values.ProductName}    {values.ProductStock+" "}                        {values.ProductPrice+"  "}                   {values.ProductShippingDuration}");

        }
        System.Console.WriteLine("Enter the ProductID of the product you want to buy: ");
        string productID=Console.ReadLine();
        ProductDetails product=productList.Find(x=>x.ProductID==productID);
        if(product==null)
        {
            System.Console.WriteLine("Invalid ProductID");
            return;
        }
        System.Console.WriteLine("Enter the quantity you want to purchase: ");
        int quantity=int.Parse(Console.ReadLine());
        if(quantity>product.ProductStock)
        {
            System.Console.WriteLine($"Required count not available. Current availability is {product.ProductStock}");
            return;
        }
        
        double payableAmount=(quantity*product.ProductPrice)+deliveryCharge;
        if(payableAmount>customer.CustomerWalletBalance)
        {
            System.Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
            return;
        }
        customer.DeductAmount(payableAmount);
        product.ProductStock-=quantity;
        OrderStatus orderStatus;
        Enum.TryParse<OrderStatus>("Ordered",true,out orderStatus);
    
        OrderDetails order=new OrderDetails("",customer.CustomerID,product.ProductID,payableAmount,DateTime.Now,quantity,orderStatus);
        orderList.Add(order);
        System.Console.WriteLine("Order Placed Successfully. Order ID: "+order.OrderID);
    }

    public static void OrderHistory(CustomerDetails customer)
    {
        OrderDetails order=orderList.Find(x=>x.CustomerID==customer.CustomerID);
        if(order==null)
        {
            System.Console.WriteLine("No orders placed. Continue shopping");
            return;
        }
        System.Console.WriteLine("OrderID   CustomerID   ProductID   TotalPrice   PurchaseDate   Quantity   OrderStatus");
        foreach(OrderDetails values in orderList)
        {
            if(values.CustomerID==customer.CustomerID)
            {
                System.Console.WriteLine($"{values.OrderID}    {values.CustomerID}      {values.ProductID}      {values.TotalPrice}        {values.PurchaseDate.ToString("dd/MM/yyyy")}     {values.Quantity}           {values.OrderStatus}");
                
            }
            
        }

    }

    public static void CancelOrder(CustomerDetails customer)
    {
        OrderDetails order=orderList.Find(x=>x.CustomerID==customer.CustomerID);
        if(order==null)
        {
            System.Console.WriteLine("No orders placed to cancel.");
            return;
        }
        System.Console.WriteLine("OrderID   CustomerID   ProductID   TotalPrice   PurchaseDate   Quantity   OrderStatus");
        foreach(OrderDetails values in orderList)
        {
            if(values.CustomerID==customer.CustomerID)
            {
                System.Console.WriteLine($"{values.OrderID}    {values.CustomerID}      {values.ProductID}       {values.TotalPrice}       {values.PurchaseDate.ToString("dd/MM/yyyy")}       {values.Quantity}       {values.OrderStatus}");
            }
        }
        System.Console.WriteLine("Enter OrderID you want to cancel: ");
        string orderID=Console.ReadLine();
        OrderDetails anotherOrder=orderList.Find(x=>x.OrderID==orderID);
        if(anotherOrder==null)
        {
            System.Console.WriteLine("Invalid orderID");
            return;
        }
        ProductDetails product=productList.Find(x=>x.ProductID==order.ProductID);
        product.ProductStock+=order.Quantity;
        OrderStatus orderStatus;
        Enum.TryParse<OrderStatus>("Cancelled",true,out orderStatus);
        order.OrderStatus=orderStatus;
        customer.CustomerWalletBalance+=order.TotalPrice;
        System.Console.WriteLine($"Order :{order.OrderID} cancelled successfully");

    }

    
}