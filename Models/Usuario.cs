namespace tl2_tp10_2023_LucasAli18;
public class Usuario {
  int id;
  string? nombreUsuario;
  string? contrasenia;
  Rol rol;


    public int Id { get => id; set => id = value; }
    public string? NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    public string? Contrasenia { get => contrasenia; set => contrasenia = value; }
    public Rol Rol { get => rol; set => rol = value; }
}

public enum Rol{
  operador, 
  admin 
}