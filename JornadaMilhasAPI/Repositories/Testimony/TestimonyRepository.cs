using Dapper;
using JornadaMilhasAPI.Models;
using MySql.Data.MySqlClient;

namespace JornadaMilhasAPI.Repositories.Testimony
{
    public class TestimonyRepository : ITestimonyRepository
    {
        private readonly IConfiguration _config;
        public TestimonyRepository(IConfiguration config)
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

        public TestimonyModel get(int id)
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
            var result = con.Query<TestimonyModel>(sql, new { Id = id })?.FirstOrDefault();
            return result;
        }

        public IEnumerable<TestimonyModel> getHome()
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
            return con.Query<TestimonyModel>(sql);
        }

        public bool insert(TestimonyModel testimony)
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

        public void update(TestimonyModel testimony)
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
