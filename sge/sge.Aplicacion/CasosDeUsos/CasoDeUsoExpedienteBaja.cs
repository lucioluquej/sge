namespace sge.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo,ITramiteRepositorio repoTramite)
{
    public void Ejecutar(int idExp,int id){
                repo.bajaExpediente(id,idExp);
                List<Tramite> trts= repoTramite.listarTramite();
                foreach (var trt in trts)
                {
                    if(trt.ExpedienteID() == idExp)
                        repoTramite.bajaTramite(trt.id());
                } 
}