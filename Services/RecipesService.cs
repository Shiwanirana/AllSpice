using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;
    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Recipe> GetAll()
    {
      return _repo.GetAll();
    }
    internal Recipe GetById(int id)
    {
      Recipe data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }
    internal Recipe Create(Recipe newData)
    {
     return _repo.Create(newData);
    }
    internal Recipe Edit(Recipe editRecipe)
    {
      Recipe data = GetById(editRecipe.Id);
      editRecipe.Name=editRecipe.Name!= null && editRecipe.Name.Length>2 ? editRecipe.Name:data.Name;
      editRecipe.Description = editRecipe.Description != null ? editRecipe.Description : data.Description;
      editRecipe.Image  = editRecipe.Image != null ? editRecipe.Image : data.Image;
      editRecipe.Price = editRecipe.Price > 0 ? editRecipe.Price : data.Price;
      return _repo.Edit(editRecipe);
    }
    internal string Delete(int id)
    {
      Recipe data = GetById(id);
      _repo.Delete(id);
      return "Deleted Permanently";
    }
  }
}