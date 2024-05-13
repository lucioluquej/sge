namespace sge.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo)
{
    public void Ejecutar(Tramite tramite,int id){
                repo.agregarTramite(tramite, id);
    }
}