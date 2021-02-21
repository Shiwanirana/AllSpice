using System;
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _service;
    public IngredientsController(IngredientsService gs)
    {
      _service = gs;
    }
    [HttpGet("{id}")]
    public ActionResult<Ingredient> GetById(int id)
    {
      try{
      return Ok(_service.GetById(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Ingredient> Create([FromBody] Ingredient newIngredient)
    {
      try{
        return Ok(_service.Create(newIngredient));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Ingredient> Edit(int id, [FromBody] Ingredient editIngredient)
    {
      try{
      editIngredient.Id = id;
      return Ok(_service.Edit(editIngredient));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Ingredient> Delete(int id)
    {
      try{
        return Ok(_service.Delete(id));
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}