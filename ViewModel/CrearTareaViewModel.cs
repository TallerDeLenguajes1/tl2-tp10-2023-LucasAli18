using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_LucasAli18.Models;
namespace tl2_tp10_2023_LucasAli18.ViewModels;

public class CrearTareaViewModel
{
    public int id{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Id de la tarea")]
    public int idTablero{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Id del tablero para la tarea")]

    public string? nombre{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre de usuario")]
    public string? descripcion{get;set;}
    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Descripcion de la Tarea")]
    public int idUsuarioPropietario;
    public string? color{get;set;}
    public EstadoTarea estado{get;set;}
    public List<Tablero> tableros{get;set;}
    public List<Usuario> usuarios{get;set;}

  public CrearTareaViewModel(){}

  public CrearTareaViewModel(List<Tablero> tableros, List<Usuario> usuarios){
    this.tableros = tableros;
    this.usuarios = usuarios;
  }

}