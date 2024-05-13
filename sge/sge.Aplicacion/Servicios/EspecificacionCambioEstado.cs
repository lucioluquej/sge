namespace sge.Aplicacion;
public class EspecificacionCambioEstado
{
    public static void Especificar(EstadoExpediente estado_expediente, Expediente expediente) => expediente.estado = estado_expediente;
}