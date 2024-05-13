namespace sge.Aplicacion;
public class ServicioActualizacionEstado
{
    public void Actualizar(EtiquetasTramites etiqueta_tramite, Expediente expediente)
    {
        EstadoExpediente auxiliar = expediente.estado;
        switch (etiqueta_tramite)
        {
            case EtiquetasTramites.Resolucion:
                auxiliar = EstadoExpediente.ConResolucion;
                break;
            case EtiquetasTramites.PasaEstudio:
                auxiliar = EstadoExpediente.ParaResolver;
                break;
            case EtiquetasTramites.PaseAlArchivo:
                auxiliar = EstadoExpediente.Finalizado;
                break;
        }
        EspecificacionCambioEstado.Especificar(auxiliar, expediente);
    }
}