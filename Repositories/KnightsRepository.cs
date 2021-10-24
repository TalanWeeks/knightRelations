using System.Data;
using Dapper;
using knightRelations.Models;

namespace KnightRelations.Repositories
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;

    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Knight Create(Knight data)
    {
      var sql = @"
        INSTER INTO knights(
            name,
            weapon
            )
            VALUES (
              @Name,
              @Weapon
              );
              SELECT LAST_INSERT_ID();
              ";
            var id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
    }
    public List<Knight> Get()
    {
      return _db.Query<Knight>("SELECT * FROM knights").ToList();
    }
    public Knight Get(int id)
    {
      return _db.QueryFirstOrDefault<Knight>("SELECT FROM knights WHERE id = @id", new {id});
    }
    

  }
}