using sge.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo,IServicioAutorizacion autorizacion)
{
    //var Permiso permiso;
    public List<Tramite> Ejecutar(EtiquetasTramites etiqueta,int id){
        if(autorizacion.poseeElPermiso(id,Permiso.TramiteBaja)){
                List<Tramite> lista = repo.listarTramite();
                List<Tramite> lNueva = new List<Tramite>();
                foreach(var elemento in lista){
                    if(elemento.etiqueta == etiqueta ){
                        lNueva.Add(elemento);
                    }
                }
                return lNueva;
        }
        else
            throw AutorizacionException();
    }
}