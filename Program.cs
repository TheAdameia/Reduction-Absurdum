List<ProductTypeId> productTypeIds = new List<ProductTypeId>()
{
    new ProductTypeId()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductTypeId()
    {
        Id = 2,
        Name = "Potion"
    },
    new ProductTypeId()
    {
        Id = 3,
        Name = "Enchanted Object"
    },
    new ProductTypeId()
    {
        Id = 4,
        Name = "Wand"
    },
};

List<Inventory> inventories = new List<Inventory>()
{
    new Inventory()
    {
        Name = "Joe's robe of Schmoozing +3",
        Price = 11.11M,
        Available = true,
        ProductType = productTypeIds[0] //this is object oriented programming in a server side course, but I didn't want to iterate through it eleventy-seven different times
    },
};

void PressToContinue()
{
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}

void ViewAllProducts()
{
    foreach (Inventory inventory in inventories){
        Console.WriteLine($"{inventory.Name}, a {inventory.ProductType.Name} type product {(inventory.Available ? "was sold" : "is available") } for ${inventory.Price}");
    }
}

void AddProduct()
{
    string NewProductName = null;
    while (NewProductName == null)
    {
        try
        {
            NewProductName = Console.ReadLine().Trim();
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            Console.Write("Re-enter product name");
        }
    }

    Console.WriteLine("Enter price:");
    decimal NewProductPrice = decimal.Parse(Console.ReadLine().Trim());

    Console.WriteLine(@"Enter number for the product type:
                        1. Apparel
                        2. Potion
                        3. Enchanted Object
                        4. Wand");

    int NewProductType = -999;
    while(NewProductType == -999)
    {
        try
        {
            NewProductType =  int.Parse(Console.ReadLine().Trim()) - 1;
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            Console.Write("Enter a number corresponding to the product type:");
        }
    }

    Inventory NewProduct = new Inventory()
    {
        Name = NewProductName,
        Price = NewProductPrice,
        Available = true,
        ProductType = productTypeIds[NewProductType]
    };


}

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Options:
                        0. Exit program
                        1. View all products
                        2. Add a product
                        3. Delete a product
                        4. Update a product");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Program closing");
    }
    else if (choice == "1")
    {
        ViewAllProducts();
        PressToContinue();
    }
    else if (choice == "2")
    {
        throw new NotImplementedException();
    }
    else if (choice == "3")
    {
        throw new NotImplementedException();
    }
    else if (choice == "4")
    {
        throw new NotImplementedException();
    }
}