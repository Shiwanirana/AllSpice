using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;
namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _ingredientsService;
    public RecipesController(RecipesService rs, IngredientsService gs)
    {
      _rs = rs;
      _ingredientsService = gs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> Get()
    {
      try{
      return Ok(_rs.GetAll());
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Recipe> GetAction(int id)
    {
      try{
        return Ok(_rs.GetById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/Ingredients")]
    public ActionResult<IEnumerable<Ingredient>> GetIngredients(int id)
    {
      try{
        IEnumerable<Ingredient> data = _ingredientsService.GetByRecipeId(id);
        return Ok(data);
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
    {
      try{
      return Ok(_rs.Create(newRecipe));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Recipe> Edit(int id,[FromBody] Recipe editRecipe)
    {
      try{
        editRecipe.Id = id;
        return Ok(_rs.Edit(editRecipe));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Recipe> Delete(int id)
    {
      try{
        return Ok(_rs.Delete(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}