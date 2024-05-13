namespace sge.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente, int id)
     {
             repo.agregarExpediente(expediente,id);
     }
}