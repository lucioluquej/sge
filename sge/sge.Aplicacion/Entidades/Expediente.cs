using System.Data;

namespace sge.Aplicacion;

public class Expediente
{
    public static int idExp { get; set; }
    public string? caratula { get; set;}
    public DateTime fechaCreacion{
        get { return fechaCreacion; }
        set {
            if( fechaCreacion == DateTime.Now){
                fechaCreacion = DateTime.Now;
            }
        }
    }
    public DateTime fechaUltimaModificacion;
    public int idUsuario { get; set;}
    public EstadoExpediente estado;
    //public ITramiteRepositorio tramites;
    public Expediente()
    {

    }
    public Expediente(string? caratula, int idUsuario)
    {
        idExp++;
        this.caratula = caratula;
        fechaUltimaModificacion = fechaCreacion;
        this.idUsuario = idUsuario;
        estado = EstadoExpediente.RecienIniciado;
    }
}