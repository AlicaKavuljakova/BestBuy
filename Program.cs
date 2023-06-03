// See https://aka.ms/new-console-template for more information
using BestBuy;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);
#region Department region

var departmentRepo = new DapperDepartmentRepository(conn);
var departments=departmentRepo.GetAllDepartments();
foreach(var i in  departments)
{
    Console.WriteLine("Department name:");
    Console.WriteLine(i.Name);
    Console.WriteLine("Department ID:");
    Console.WriteLine(i.DepartmentID);
}

#endregion
var productsRepo= new DapperProductRepository(conn);
var products=productsRepo.GetAllProducts();
productsRepo.DeleteProduct(941);
productsRepo.DeleteProduct(942);
productsRepo.DeleteProduct(943);
productsRepo.DeleteProduct(944);
productsRepo.DeleteProduct(945);
/*
var productToUpdate= productsRepo.GetProduct(940);
productToUpdate.Name = "UPDATED PRODUCT";
productToUpdate.Price = 99.99;
productToUpdate.OnSale = false;
productToUpdate.StockLevel = 55;
*/
foreach (var product in products)
{
    Console.WriteLine("Name of product:");
    Console.WriteLine(product.Name);
    Console.WriteLine("Price:");
    Console.WriteLine(product.Price);
    Console.WriteLine("Is on sale:");
    Console.WriteLine(  product.OnSale);
    Console.WriteLine("Product ID:");
    Console.WriteLine(product.ProductID);
    Console.WriteLine("Stock level:"+product.StockLevel);

}