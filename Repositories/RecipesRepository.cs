using System.Collections.Generic;
using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Recipe> GetAll()
    {
      string sql = "SELECT * FROM recipes";
      return _db.Query<Recipe>(sql);
    }
    internal Recipe GetById(int id)
    {
      string sql = "SELECT *FROM recipes WHERE id= @id";
      return _db.QueryFirstOrDefault<Recipe>(sql, new {id});
    }
    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes
      (Name,Description,Price,Image) 
      VALUES
      (@Name,@Description,@Price,@Image);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      newRecipe.Id =id;
      return newRecipe;
    }
    internal Recipe Edit(Recipe editRecipe)
    {
      string sql = @"
      UPDATE recipes
      SET
       Name = @Name,
       Description= @Description,
       Price = @Price,
       Image= @Image
       WHERE id = @Id";
       _db.Execute(sql,editRecipe);
       return editRecipe;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      _db.Execute(sql, new{id});
    }
  }
}