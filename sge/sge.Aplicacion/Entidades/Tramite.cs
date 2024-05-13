namespace sge.Aplicacion;
public class Tramite
{
    private int _id = 0;
    public int id {
        get { return _id; }
        set { 
            if (_id == 0) {
                _id = value;
            }
        }
     }
    public static int ExpedienteID 
    {   get; 
        set;
    }
    public EtiquetasTramites etiqueta;
    public DateTime creacion{
        get { return creacion; }
        set {
            if( creacion == DateTime.Now){
                creacion = DateTime.Now;
            }
        }
    }
    public DateTime modificacion
    {
        get; set;
    }
    public int idUltimoUser
    {
        get; set;
    }
    public string? contenido
    {
        get; set;
    }
    public Tramite() 
    {
    }
    public Tramite(int EID,EtiquetasTramites ET,int idUser, string cont){
        idUltimoUser=idUser;
        ExpedienteID=EID;
        modificacion= DateTime.Now;
        contenido = cont;
    }
}