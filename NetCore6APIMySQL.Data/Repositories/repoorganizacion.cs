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
    public class repoorganizacion : rorganizacion
    {
        private readonly MySQLConfiguration _connectionString;
        public repoorganizacion(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM organizacion WHERE id= @id";

            var result = await db.ExecuteAsync (sql, new {Id = organizacion.id } );

            return result > 0;


        }

        public async Task<IEnumerable<organizacion>> GetAllOrganizacions()
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, foto, descripcion, mision, vision, valores from organizacion";

            return await db.QueryAsync<organizacion>(sql, new {});
        }

        public async Task<organizacion> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, foto, descripcion, mision, vision, valores
                        from organizacion 
                        WHERE id= @id ";

            return await db.QueryFirstOrDefaultAsync<organizacion>(sql, new {Id = id});
        }

        public async Task<bool> InsertOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO organizacion ( nombre, foto, descripcion, mision, vision, valores)
                        VALUES (@nombre, @foto, @descripcion, @mision, @vision, @valores) ";

            var result = await db.ExecuteAsync(sql, new 
                { organizacion.nombre, organizacion.foto, organizacion.descripcion, organizacion.mision, organizacion.vision, organizacion.valores});

            return result > 0;
        }

        public async Task<bool> UpdateOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @" UPDATE organizacion 
                        SET 
                            nombre=@nombre,
                            foto=@foto,
                            descripcion=@descripcion,
                            mision=@mision,
                            vision=@vision,
                            valores=@valores
                            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            { organizacion.nombre, organizacion.foto, organizacion.descripcion, organizacion.mision, organizacion.vision, organizacion.valores, organizacion.id });

            return result > 0;
        }
    }
}
