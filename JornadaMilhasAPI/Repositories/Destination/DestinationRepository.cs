using Dapper;
using JornadaMilhasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace JornadaMilhasAPI.Repositories.Destination
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly IConfiguration _config;
        public DestinationRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public int DeleteById(int id)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                DELETE
                FROM destinos as des
                WHERE des.id = @Id;
            ";
            var rows = con.Execute(sql, new { Id = id });
            return rows;

        }

        public IEnumerable<DestinationModel> GetAll()
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                SELECT 
                    des.id,
                    des.name,
                    des.pictureURL,
                    des.price
                FROM destinos as des
            ";
            var result = con.Query<DestinationModel>(sql);
            return result;
        }

        public int Insert(DestinationModel destination)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                INSERT INTO destinos (name, pictureURL, price) 
                VALUES (@Name, @PictureURL, @Price);
            ";
            var result = con.Execute(sql, new { Name = destination.Name, PictureURL = destination.PictureURL, Price = destination.Price });
            return result;
        }

        public int UpdateById(DestinationModel destination)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                UPDATE destinos SET name=@Name, pictureURL=@PictureURL, price=@Price WHERE id=@Id;
            ";
            return con.Execute(sql, new { Name = destination.Name, PictureURL = destination.PictureURL, Price = destination.Price, Id = destination.Id });
        }
    }
}
