using System.ComponentModel.DataAnnotations;
using AllSpice.Models;

namespace AllSpice
{
  public class Ingredient
  {
    internal Recipe Recipe;

    [Required]
    public string Name {get;set;}
    
    [MaxLength(300)]
    public string Body {get;set;}
    public int Id {get;set;}
    public int RecipeId {get;set;}
  }
}