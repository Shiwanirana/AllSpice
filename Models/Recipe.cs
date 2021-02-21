using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
  public class Recipe
  {
    [Required]
    public string Name {get;set;}
    [Range(0,500)]
    public int Price {get;set;}
    [MaxLength(300)]
    public string Description {get;set;}
    public string Image {get;set;}
    public int Id {get;set;}
  }
}