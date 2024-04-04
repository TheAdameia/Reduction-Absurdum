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
        Console.WriteLine($"{inventory.Name}, a {inventory.ProductType.Name} type product {(inventory.Available ? "is available" : "was sold") } for ${inventory.Price}");
    }
}

void ViewAllProductTypes()
{
    foreach (ProductTypeId productTypeId in productTypeIds)
    {
        Console.WriteLine($"{productTypeId.Id}. {productTypeId.Name}");
    }
}

void ProductForm(string InputForm, int ProductNumber)
{
    string NewProductName = null;
    Console.WriteLine("Enter product name:");
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

    if (InputForm == "add")
    {
        inventories.Add(NewProduct);
    }
    else if (InputForm == "update")
    {
        inventories[ProductNumber] = NewProduct;
    }
}

void AddProduct()
{
    string InputForm = "add";
    int ProductNumber = -999;
    ProductForm(InputForm, ProductNumber);
}

void DeleteProduct()
{
    ViewAllProducts();
    Console.WriteLine("Enter the number for the product to be deleted:");
    int ProductTBD = int.Parse(Console.ReadLine()) -1;
    inventories.RemoveAt(ProductTBD);
}

void UpdateProduct()
{
    ViewAllProducts();
    Console.WriteLine("Enter the number of the product to update:");
    int ProductNumber = int.Parse(Console.ReadLine()) - 1;
    string InputForm = "update";
    ProductForm(InputForm, ProductNumber);
}

void GetProductByType()
{
    List<Inventory> FilteredInventories = new List<Inventory>();
    ViewAllProductTypes();
    Console.WriteLine("Enter the type of the product to view:");
    int SelectedType = int.Parse(Console.ReadLine());

    foreach (Inventory inventory in inventories)
    {
        if (inventory.ProductType.Id == SelectedType)
        {
            FilteredInventories.Add(inventory);
        }
    }

    foreach (Inventory FilteredInventory in FilteredInventories)
    {
        Console.WriteLine($"{FilteredInventory.Name}, a {FilteredInventory.ProductType.Name} type product {(FilteredInventory.Available ? "is available" : "was sold") } for ${FilteredInventory.Price}");
    }
}

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Options:
                        0. Exit program
                        1. View all products
                        2. Add a product
                        3. Delete a product
                        4. Update a product
                        5. Get product by type");
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
        AddProduct();
        PressToContinue();
    }
    else if (choice == "3")
    {
        DeleteProduct();
        PressToContinue();
    }
    else if (choice == "4")
    {
        UpdateProduct();
        PressToContinue();
    }
    else if (choice == "5")
    {
        GetProductByType();
        PressToContinue();
    }
}