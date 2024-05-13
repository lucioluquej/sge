namespace sge.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo,ITramiteRepositorio repoTram,IServicioAutorizacion autorizacion)
{

    public void Ejecutar(int expId,int id){
                Expediente exp = repo.getEXPporID(expId);//redudante si se hace tambien check booleano
                List<Expediente> trams= new List<Expediente>();
                foreach (var item in repoTram.listarTramite())
                {
                    if(item.id == expId)
                        trams.Add(item);
                } 
            }
}//retorna un expediente y una lista de tramites o los imprime?