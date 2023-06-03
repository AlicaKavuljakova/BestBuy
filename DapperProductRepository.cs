using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection conn)
        {
            _connection = conn;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * from Products");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("Select * from products where ProductID=@id  ",new { id });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("update products"+
                "set Name =@name,"+
                "Price =@price,"+
                "CategoryID=@catID,"+
                "OnSale=@onSale,"+
                "StockLevel=@stock"+
                "where ProductID=@id;",
                new {id=product.ProductID,
                    name=product.Name,
                    price=product.Price,
                    catID=product.CategoryID,
                    onSale=product.OnSale,
                    stockLevel=product.StockLevel });
        }
    }
}
