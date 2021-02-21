using System;
using System.Collections.Generic;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }
    internal Ingredient GetById(int id)
    {
      Ingredient data = _repo.GetById(id);
      if(data==null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal IEnumerable<Ingredient> GetByRecipeId(int id)
    {
      IEnumerable<Ingredient> data = _repo.GetByRecipeId(id);
      return data;
    }
    internal Ingredient Create(Ingredient newIngredient)
    {
      return _repo.Create(newIngredient);
    }
    internal Ingredient Edit(Ingredient editIngredient)
    {
      Ingredient data= GetById(editIngredient.Id);
      editIngredient.Name = editIngredient.Name !=null ? editIngredient.Name : data.Name;
      editIngredient.Body = editIngredient.Body!=null ? editIngredient.Body : data.Body;
      return _repo.Edit(editIngredient);
    }
    internal string Delete(int id)
    {
      GetById(id);
      _repo.Delete(id);
      return "Deleted Permanently";
    }
  }
}