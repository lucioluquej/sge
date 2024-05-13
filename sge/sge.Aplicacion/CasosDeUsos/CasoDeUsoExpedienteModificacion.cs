namespace sge.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{

    public void Ejecutar(int expId,int id,string mod){
                repo.modificacionExpediente(expId,id,mod);//redundante si se hace tambien check booleano
                //ServicioActualizacionEstado serv= new ServicioActualizacionEstado();
                //serv.(repo.consultaId(expId).etiqueta)
    }
}//retorna un expediente y una lista de tramites o los imprime?