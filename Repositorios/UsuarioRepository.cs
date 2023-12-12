using System.Data.SQLite;
namespace tl2_tp10_2023_LucasAli18;

public class UsuarioRepository : IUsuarioRepository

{
  private string cadenaConexion = "Data Source=BD/kanban.db;Cache=Shared";


  public List<Usuario> GetAll(){
    var queryString = @"SELECT * FROM usuario;";
    List<Usuario> usuarios = new List<Usuario>();
    using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
    {
      SQLiteCommand command = new SQLiteCommand(queryString, connection);
      connection.Open();

      using (SQLiteDataReader reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var usuario = new Usuario();
          usuario.Id = Convert.ToInt32(reader["id_usuario"]);
          usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
          usuarios.Add(usuario);
        }
      } 
      connection.Close();
    }
    return usuarios;
  }
  public Usuario GetById(int idUsuario){
    SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
    var usuario = new Usuario();
    SQLiteCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM usuario WHERE id_usuario= @idUsuario";
    command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
    connection.Open();

    using (SQLiteDataReader reader = command.ExecuteReader())
    {
      while (reader.Read())
      {
        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
        usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
      }
    }
    connection.Close();

    return (usuario);
  }
  public void Create(Usuario usuario){
    var query = $"INSERT INTO usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";
    using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
    {

      connection.Open();
      var command = new SQLiteCommand(query, connection);

      command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreUsuario));

      command.ExecuteNonQuery();

      connection.Close();
    }
  }
  public void Update(Usuario usuario)
  {

    using ( SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){

    connection.Open();
    SQLiteCommand command = connection.CreateCommand();
    command.CommandText = $"UPDATE Usuario SET nombre_de_usuario=@nombre  WHERE id_usuario= @idUsuario;";
    command.Parameters.Add(new SQLiteParameter("@idUsuario", usuario.Id));
    command.Parameters.Add(new SQLiteParameter("@nombre", usuario.NombreUsuario));


    command.ExecuteNonQuery();
    connection.Close();
   }
  }
  public void Remove(int idUsuario)
  {
    using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
      
    SQLiteCommand command = connection.CreateCommand();
    command.CommandText = $"DELETE FROM usuario WHERE id_usuario = @idUsuario;";
    command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));

    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
    }
  }

  public  Usuario? validarUsuario(Usuario usuarioAvalidar){
    SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
    var usuario = new Usuario();
    SQLiteCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM usuario WHERE nombre_de_usuario= @nombreUsuario AND contrasenia= @contrasenia";
    command.Parameters.Add(new SQLiteParameter("@nombreUsuario", usuarioAvalidar.NombreUsuario));
    command.Parameters.Add(new SQLiteParameter("@contrasenia", usuarioAvalidar.Contrasenia));

    connection.Open();

    using (SQLiteDataReader reader = command.ExecuteReader())
    {
      if (reader.Read())
      {
        // Se encontró una coincidencia
        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
        usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
        usuario.Contrasenia = reader["contrasenia"].ToString();
        usuario.Rol = (Rol)Convert.ToInt32(reader["rol"]); 
        return usuario;
      }
     
    };
      return null;
  }

}
