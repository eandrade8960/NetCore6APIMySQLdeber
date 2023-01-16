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
    public class repomensajes : rmensajes
    {
        private readonly MySQLConfiguration _connectionString;
        public repomensajes(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM mensaje WHERE id= @id";

            var result = await db.ExecuteAsync (sql, new {Id = mensajes.id} );

            return result > 0;


        }

        public async Task<IEnumerable<mensajes>> GetAllMensajes()
        {
            var db = dbConnection();

            var sql = @" SELECT id, remitente, telefono, asunto, mensaje, correo from mensaje";

            return await db.QueryAsync<mensajes>(sql, new {});
        }

        public async Task<mensajes> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, remitente, telefono, asunto, mensaje, correo 
                        from mensaje
                        WHERE id= @id ";

            return await db.QueryFirstOrDefaultAsync<mensajes>(sql, new {Id = id});
        }

        public async Task<bool> InsertMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO mensaje (correo, remitente, telefono, asunto, mensaje )
                        VALUES ( @correo, @remitente, @telefono, @asunto, @Mensaje ) ";

            var result = await db.ExecuteAsync(sql, new
            { mensajes.correo, mensajes.remitente, mensajes.telefono, mensajes.asunto, mensajes.Mensaje});

            return result > 0;
        }

        public async Task<bool> UpdateMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @" UPDATE mensaje 
                        SET remitente=@remitente,
                            telefono=@telefono,
                            asunto=@asunto,
                            mensaje=@Mensaje,
                            correo=@correo
                            WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new
            { mensajes.remitente, mensajes.telefono, mensajes.asunto, mensajes.Mensaje, mensajes.id, mensajes.correo });

            return result > 0;
        }

       
    }
}
