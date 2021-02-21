using System.Collections.Generic;
using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Ingredient GetById(int id)
    {
      string sql = "SELECT * FROM ingredients WHERE id=@id";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new {id});
    }
    //Populating
    internal IEnumerable<Ingredient> GetByRecipeId(int id)
    {
      string sql = @"
      SELECT
      i.*,rec.*
      FROM ingredients i
      JOIN recipes rec
      ON i.RecipeId = rec.id
      WHERE RecipeId = @id;";
      return _db.Query<Ingredient,Recipe,Ingredient>(sql,(ingredient, recipe)=>
      {
        ingredient.Recipe = recipe;
        return ingredient;
      }, new{id}, splitOn: "id");
    }
    internal Ingredient Create(Ingredient newIngredient)
    {
      string sql = @"
      INSERT INTO ingredients
      (Name,Body,RecipeId)
      VALUES
      (@Name, @Body,@RecipeId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql,newIngredient);
      newIngredient.Id = id;
      return newIngredient;
    }
    internal Ingredient Edit(Ingredient editIngredient)
    {
      string sql = @"
      UPDATE ingredients
      SET
       Name =@Name,
       Body= @Body
       WHERE id=@Id";
       _db.Execute(sql, editIngredient);
       return editIngredient;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM ingredients WHERE id = @id LIMIT 1";
      _db.Execute(sql, new {id});
    }
  }
}