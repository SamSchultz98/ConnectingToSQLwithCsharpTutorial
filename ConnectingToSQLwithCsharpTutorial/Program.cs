using PrsLibrary;
using PrsLibrary.Controllers;
using PrsLibrary.Models;

Connection connection = new();

connection.connect();

UsersController userCtrl = new(connection);

User newUser = new()
{Username = "xx", Password = "xxxx", Firstname = "asd", Lastname = "lsdf", Phone = 922019401234, 
    Email = "323@outlook.com", IsReviewer = true, IsAdmin = false };

bool ok = userCtrl.Insert(newUser);

bool success = userCtrl.Delete(2);


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
connection.disconnect();