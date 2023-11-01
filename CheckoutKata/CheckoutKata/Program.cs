// See https://aka.ms/new-console-template for more information

//In a normal supermarket, things are identified using Stock Keeping Units, or SKUs.In our shop, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multipriced: buy n of them, and they’ll cost you y pounds. For example, item ‘A’ might cost 50 pounds individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you 130. The current pricing and offers are as follows:

//SKU Unit Price	Special Price
//A	50	3 for 130
//B	30	2 for 45
//C	20	
//D	15	
//Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass in a set of pricing rules each time we start handling a checkout transaction.

using CheckoutKata.Library;

string? sku = null;
int? price = null;
(int, int)? specialPrice = null;

List<Product> products = new List<Product>();

Console.WriteLine("Welcome to the checkout, please enter the details for each product (Enter Q to exit):");

do
{
    Console.WriteLine("SKU: ");
    var stringSku = Console.ReadLine();
    if(stringSku == "Q")
    {
        break;
    }
    sku = stringSku;

    Console.WriteLine("Price: ");
    string stringPrice = Console.ReadLine();
    if (stringSku == "Q")
    {
        break;
    }
    price = Int32.Parse(stringPrice);

    Console.WriteLine("Special offer? 1/0: ");
    string sYesNo = Console.ReadLine();
    if (sYesNo == "0")
    {
        products.Add(new Product(sku, price.Value, null));
        continue;
    }


    Console.WriteLine("Special quantity: ");
    string sStringQuant = Console.ReadLine();
    if (sStringQuant == "Q")
    {
        break;
    }
    int sQuant = Int32.Parse(sStringQuant); 
    
    Console.WriteLine("Special price: ");
    string sStringPrice = Console.ReadLine();
    if (sStringPrice == "Q")
    {
        break;
    }
    int sPrice = Int32.Parse(sStringPrice);

    specialPrice = (sQuant, sPrice);

    products.Add(new Product(sku, price.Value, specialPrice));
} while (true);


ICheckout checkout = new Checkout(products);

Console.WriteLine("Enter the SKUs of the items that you wish to scan (Enter Q to exit):");

do
{
    Console.WriteLine("SKU: ");
    var stringSku = Console.ReadLine();
    if (stringSku == "Q")
    {
        break;
    }
    string scanSku = stringSku;

    checkout.Scan(scanSku);
} while (true);

var total = checkout.GetTotalPrice().ToString();

Console.WriteLine($"Your total is: {total}");

Console.WriteLine("Press any key to finish...");

Console.ReadKey();
