namespace tl2_tp10_2023_LucasAli18;
using System.ComponentModel.DataAnnotations;

public class CrearUsuarioViewModel
{
  public int Id { get; set; }
  [Required(ErrorMessage = "Este campo es requerido")]
  [Display(Name = "Nombre de usuario")]
  public string NombreUsuario { get; set; }

  [Required(ErrorMessage = "Este campo es requerido")]
  public Rol Rol { get; set; }

  [Display(Name = "Contraseña")]
  [MinLength(6, ErrorMessage = "Como minimo 6 caracteres")]
  public string Contrasenia { get ; set; }

  public CrearUsuarioViewModel() { }
  public CrearUsuarioViewModel(Usuario usuario)
  {
    Id = usuario.Id;
    NombreUsuario = usuario.NombreUsuario;
    Contrasenia = usuario.Contrasenia;
    Rol = usuario.Rol;
  }
}