using PrsLibrary;
using PrsLibrary.Controllers;
using PrsLibrary.Models;

Connection connection = new();

connection.connect();

ProductsController prodCtrl = new(connection);

IEnumerable<Product> products = prodCtrl.GetAll();
foreach(Product p in products)
{
    Console.WriteLine($"{p.PartNbr} | {p.Name} | {p.Price:C} | {p.Vendor}");
}






/*
VendorsController vendorCtrl = new(connection);

//Insert was not working, last thing I was working on
Vendor newVendor = new()
{
    Code = "Hardware",
    Name = "Home Depot",
    Address = "12 Main St",
    City = "Atlanta",
    State = "GA"
};
bool ok = vendorCtrl.Insert(newVendor);

*/

/*Delete Works
bool success = vendorCtrl.Delete(3);

*/


/* GetByPk() Works
Vendor? vendor = vendorCtrl.GetByPk(1);
if (vendor == null)
{
    Console.WriteLine("The User was not found");
}
else
{
    Console.WriteLine($"{vendor.Code},{vendor.Name}");
}

*/



/* GetAllVendors Works
IEnumerable<Vendor> vendors = vendorCtrl.GetAllVendors();     

foreach (Vendor V in vendors)
{
    Console.WriteLine($"{V.Name} . {V.Address}");
}
*/





/*
UsersController userCtrl = new(connection);

User? xx1user = userCtrl.GetByPk(3);
xx1user.Username = "yy";
xx1user.Password = "yy";
xx1user.Firstname = "yy";
xx1user.Lastname = "yy";
bool updated = userCtrl.Update(xx1user);

Vendor newVendor = new()
Code = "Hardware", Name = "Home Depot", Address = "12 Main St", City = "Atlanta", State="GA"
bool ok = vendorCtrl.Insert(newVendor)

User newUser = new()
{Username = "xwx", Password = "xxxx", Firstname = "asd", Lastname = "lsdf", Phone = 922019401234, 
    Email = "323@outlook.com", IsReviewer = true, IsAdmin = false };

//bool ok = userCtrl.Insert(newUser);

//bool success = userCtrl.Delete(2);


User? user = userCtrl.GetByPk(1);
if (user == null)
{
    Console.WriteLine("The User was not found");
}
else
{
    Console.WriteLine($"{user.Firstname},{user.Lastname}");
}

IEnumerable<User>  users = userCtrl.GetAllUsers();

foreach(User u in users)
{
    Console.WriteLine($"{u.Firstname}.{u.Lastname}");
}
*/


connection.disconnect();