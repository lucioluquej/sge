namespace sge.Aplicacion;

public interface ITramiteRepositorio
{
    public void agregarTramite(Tramite tramite, int idUsuario);
    public List<Tramite> listarTramite();
    public void modificarTramite(int idUsuario, int idTramite, string contenido);
    public void bajaTramite( int id, int idUsuario);
}
