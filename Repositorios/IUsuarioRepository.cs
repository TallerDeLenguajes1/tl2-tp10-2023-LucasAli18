
namespace tl2_tp10_2023_LucasAli18;
public interface IUsuarioRepository
{
  public List<Usuario> GetAll();
  public Usuario GetById(int id);
  public void Create(Usuario usuario);
  public void Remove(int id);
  public void Update(Usuario usuario);

  public Usuario? validarUsuario (Usuario usuario);
}