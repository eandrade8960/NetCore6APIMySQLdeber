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
    public class repopersonal : rpersonal
    {
        private readonly MySQLConfiguration _connectionString;
        public repopersonal(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeletePersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM personal WHERE id= @id";

            var result = await db.ExecuteAsync (sql, new {Id = personal.id } );

            return result > 0;


        }

        public async Task<IEnumerable<personal>> GetAllPersonal()
        {
            var db = dbConnection();

            var sql = @" SELECT id, cedula, nombre, apellido, telefono, correo, rol from personal";

            return await db.QueryAsync<personal>(sql, new {});
        }

        public async Task<personal> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, cedula, nombre, apellido, telefono, correo, rol 
                        from personal 
                        WHERE id= @id ";

            return await db.QueryFirstOrDefaultAsync<personal>(sql, new {Id = id});
        }

        public async Task<bool> InsertPersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO personal (cedula, nombre, apellido, telefono, correo, rol )
                        VALUES (@cedula, @nombre, @apellido, @telefono, @correo, @rol ) ";

            var result = await db.ExecuteAsync(sql, new 
                { personal.cedula, personal.nombre, personal.apellido, personal.telefono, personal.correo, personal.rol});

            return result > 0;
        }

        public async Task<bool> UpdatePersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @" UPDATE personal 
                        SET cedula=@cedula,
                            nombre=@nombre,
                            apellido=@apellido,
                            telefono=@telefono,
                            correo=@correo,
                            rol=@rol
                            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            { personal.cedula, personal.nombre, personal.apellido, personal.telefono, personal.correo, personal.rol, personal.id });

            return result > 0;
        }

       
    }
}
