namespace sge.Aplicacion;

public interface IExpedienteRepositorio
{
    public Expediente getEXPporID(int id);
    public void agregarExpediente(Expediente exp, int idUsuario);
    public void bajaExpediente(int idExpediente, int idUsuario);
    public void modificacionExpediente(int idExpediente, int idUsuario, string mod);
    public List<Expediente> listarExpediente(Expediente exp);
}
