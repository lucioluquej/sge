namespace sge.Aplicacion;

public interface IServicioAutorizacion
{
    bool poseeElPermiso(int id, Permiso permiso); //la clase Permiso es enum
}
