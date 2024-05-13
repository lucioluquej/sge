namespace sge.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo)
{

    public void Ejecutar(int idTram,int id,String mod){
 
                repo.modificarTramite(id, idTram, mod);
                ServicioActualizacionEstado serv= new ServicioActualizacionEstado();
                serv.??(repo.consultaId(idTram).etiqueta);
                //cambio etiqueta?
    }
}