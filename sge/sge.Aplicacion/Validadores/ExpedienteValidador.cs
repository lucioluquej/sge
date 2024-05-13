namespace sge.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente exp, out string mensajeError)
    {
    mensajeError = "";
    if (string.IsNullOrWhiteSpace(exp.caratula))
    {
        mensajeError = "La caratula del expediente no puede estar vacia.\n";
    }

     if(exp.idUsuario <= 0) //idUsuario es estático, por eso lo usamos así
        {
            mensajeError += "El id de usuario del expediente debe ser un valor mayor que cero. \n";
        }

        return mensajeError == "";
    }
}