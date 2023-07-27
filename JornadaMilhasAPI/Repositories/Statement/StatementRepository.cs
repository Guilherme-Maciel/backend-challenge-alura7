using Dapper;
using JornadaMilhasAPI.Models;
using MySql.Data.MySqlClient;

namespace JornadaMilhasAPI.Repositories.Statement
{
    public class StatementRepository : IStatementRepository
    {
        private readonly IConfiguration _config;
        public StatementRepository(IConfiguration config)
        {
            _config = config;
        }
        public void delete(int id)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                DELETE
                FROM depoimentos as dep
                WHERE dep.id = @Id;
            ";
            con.Execute(sql, new { Id = id });
        }

        public StatementModel get(int id)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                SELECT 
                    dep.id,
                    dep.testimony,
                    dep.pictureURL,
                    dep.personsName
                FROM depoimentos as dep
                WHERE dep.id = @Id;
            ";
            var result = con.Query<StatementModel>(sql, new { Id = id })?.FirstOrDefault();
            return result;
        }

        public IEnumerable<StatementModel> getHome()
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                SELECT 
                    dep.id,
                    dep.testimony,
                    dep.pictureURL,
                    dep.personsName
                FROM depoimentos as dep
                ORDER BY RAND()
                LIMIT 3;
            ";
            return con.Query<StatementModel>(sql);
        }

        public bool insert(StatementModel testimony)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                INSERT INTO depoimentos (testimony, pictureURL, personsName) 
                VALUES (@Testimony, @PictureURL, @PersonsName);
            ";
            var result = con.Execute(sql, new { Testimony = testimony.Testimony, PictureURL = testimony.PictureURL, PersonsName = testimony.PersonsName });
            return result > 0;
        }

        public void update(StatementModel testimony)
        {
            using MySqlConnection con = new MySqlConnection(_config.GetConnectionString("MySqlConnection"));
            con.Open();
            var sql = @"
                UPDATE depoimentos  SET testimony=@Testimony, pictureURL=@PictureURL, personsName=@PersonsName WHERE id=@Id;
            ";
            con.Execute(sql, new { Testimony = testimony.Testimony, PictureURL = testimony.PictureURL, PersonsName = testimony.PersonsName, Id = testimony.Id });



        }
    }
}
