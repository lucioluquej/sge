﻿namespace sge.Aplicacion;

public class ServicioAutorizacionProvisorio
{
    public bool poseeElPermiso(int id, Permiso permiso) //id del usuario
    {
        return id==(int)permiso; 
    }

}