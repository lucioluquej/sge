namespace sge.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo)
{
    public void Ejecutar(int idTram,int id)=>repo.bajaTramite(idTram,id); 
}