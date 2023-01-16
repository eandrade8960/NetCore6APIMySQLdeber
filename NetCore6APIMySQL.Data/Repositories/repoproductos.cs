using Dapper;
using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public class repoproductos : rproductos
    {
        private readonly MySQLConfiguration _connectionString;
        public repoproductos(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM producto WHERE id= @id";

            var result = await db.ExecuteAsync (sql, new {Id = productos.id } );

            return result > 0;


        }

        public async Task<IEnumerable<productos>> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, codigo, descripcion, foto from producto";

            return await db.QueryAsync<productos>(sql, new {});
        }

        public async Task<productos> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, codigo, descripcion, foto 
                        from producto 
                        WHERE id= @id ";

            return await db.QueryFirstOrDefaultAsync<productos>(sql, new {Id = id});
        }

        public async Task<bool> InsertProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO producto ( nombre, codigo, descripcion, foto )
                        VALUES (@nombre, @codigo, @descripcion, @foto ) ";

            var result = await db.ExecuteAsync(sql, new 
                { productos.nombre, productos.codigo, productos.descripcion, productos.foto });

            return result > 0;
        }

        public async Task<bool> UpdateProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @" UPDATE producto 
                        SET nombre=@nombre,
                            codigo=@codigo,
                            descripcion=@descripcion,
                            foto=@foto
                            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            { productos.nombre, productos.codigo, productos.descripcion, productos.foto, productos.id});

            return result > 0;
        }

       
    }
}
