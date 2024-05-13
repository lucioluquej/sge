namespace sge.Repositorios;

using sge.Aplicacion;

public class ExpedienteRepositorio(IServicioAutorizacion autorizacion, ExpedienteValidador validador): IExpedienteRepositorio
{
    public bool existe(int id)
    {

        using var sr = new StreamReader(_nombreArch);
        var exp = new Expediente();

        while (!sr.EndOfStream )
        {
            Expediente.idExp = int.Parse(sr.ReadLine() ?? "");
            exp.caratula = sr.ReadLine() ?? "";
            exp.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.fechaUltimaModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.idUsuario= int.Parse(sr.ReadLine() ?? "");
            exp.estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
           if(Expediente.idExp == id)
           {
            return true;
               }

        }
    return false;
    }

 public Expediente getEXPporID(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var exp = new Expediente();

        while (!sr.EndOfStream )
        {
            Expediente.idExp = int.Parse(sr.ReadLine() ?? "");
            exp.caratula = sr.ReadLine() ?? "";
            exp.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.fechaUltimaModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.idUsuario= int.Parse(sr.ReadLine() ?? "");
            exp.estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
           if(Expediente.idExp == id)
           {
            return exp;
           }

        }
    return null;
    }
    readonly string _nombreArch = "expedientes.txt";
    public void agregarExpediente(Expediente expediente, int id)
    {
	if(autorizacion.poseeElPermiso(id,Permiso.ExpedienteBaja)){
	if (!validador.Validar(expediente, out string mensajeError)){
 				throw new ValidacionException(mensajeError);
}
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(Expediente.idExp);
        sw.WriteLine(expediente.caratula);
        sw.WriteLine(expediente.fechaCreacion);
        sw.WriteLine(expediente.fechaUltimaModificacion);
        sw.WriteLine(expediente.estado.ToString());
        sw.WriteLine("");

   }     else
            throw new AutorizacionException();
}

 public void modificacionExpediente(int idExp, int id, string cont)
    {
        if(autorizacion.poseeElPermiso(id,Permiso.ExpedienteBaja)){
	    if(existe(idExp)){
        string _nombreArch2 = "expedientesNuevo.txt";
        using var sr = new StreamReader(_nombreArch);
        using var sw= new  StreamWriter(_nombreArch2);
        var exp = new Expediente();
         
        while (!sr.EndOfStream)
        {
            Expediente.idExp = int.Parse(sr.ReadLine() ?? "");
            exp.caratula = sr.ReadLine() ?? "";
            exp.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.fechaUltimaModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            exp.idUsuario= int.Parse(sr.ReadLine() ?? "");
            exp.estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
           if(Expediente.idExp != id)
           {
            //podria ser un metodo privado
            sw.WriteLine(Expediente.idExp);
            sw.WriteLine(exp.caratula);
            sw.WriteLine(exp.fechaCreacion);
            sw.WriteLine(exp.fechaUltimaModificacion);
            sw.WriteLine(exp.idUsuario);
            sw.WriteLine(exp.estado.ToString());
            sw.WriteLine("");
           }
           else
           {
                sw.WriteLine(Expediente.idExp);
                sw.WriteLine(exp.caratula);
                sw.WriteLine(exp.fechaCreacion);
                sw.WriteLine(exp.fechaUltimaModificacion);
                sw.WriteLine(exp.idUsuario);
                sw.WriteLine(exp.estado.ToString());
                sw.WriteLine("");
           }
        }
            string contenido= File.ReadAllText(_nombreArch2); //se guarda todo el contenido de sw en texto
            File.WriteAllText(_nombreArch, contenido);//carga contenido en sr, reemplaza todo el contenido viejo?

    }
 
           else
                throw new RepositorioException();
    }    else
            throw new AutorizacionException();
    }


 public void bajaExpediente(int id, int idExp)
    {
	
        if(autorizacion.poseeElPermiso(id,Permiso.ExpedienteBaja)){
	        if(existe(idExp)){
        	    string _nombreArch2 = "expedientesNuevo.txt";
        	    using var sr = new StreamReader(_nombreArch);
        	    using var sw= new  StreamWriter(_nombreArch2);
        	    var exp = new Expediente(); 
            	while (!sr.EndOfStream)
                	{
                		Expediente.idExp = int.Parse(sr.ReadLine() ?? "");
            	    	exp.caratula = sr.ReadLine() ?? "";
            	    	exp.fechaCreacion= DateTime.Parse(sr.ReadLine() ?? "");
            	    	exp.fechaUltimaModificacion= DateTime.Parse(sr.ReadLine() ?? "");
            	    	exp.idUsuario= int.Parse(sr.ReadLine() ?? "");
            	    	exp.estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
           		    if(Expediente.idExp != id)
           		        {
            			//podria ser un metodo privado
                			sw.WriteLine(Expediente.idExp);
                			sw.WriteLine(exp.caratula);
            	    		sw.WriteLine(exp.fechaCreacion);  								
                            sw.WriteLine(exp.fechaUltimaModificacion);
                            sw.WriteLine(exp.idUsuario);
                            sw.WriteLine(exp.estado.ToString());
                            sw.WriteLine("");
                        }
                    }           
                string contenido= File.ReadAllText(_nombreArch2); //se guarda todo el contenido de sw
                File.WriteAllText(_nombreArch, contenido);//carga contenido en sr
            }
        else
            throw new RepositorioException();
        }    
    else
        throw new AutorizacionException();
    }

    public List<Expediente> listarExpediente()
    {
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        var exped = new Expediente();
        while (!sr.EndOfStream)
        {
            
            Expediente.idExp = int.Parse(sr.ReadLine() ?? "");
            exped.caratula = (sr.ReadLine() ?? "");
            exped.fechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
            exped.fechaUltimaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
            exped.idUsuario = int.Parse(sr.ReadLine() ?? "");
            if (Enum.TryParse<EstadoExpediente>(sr.ReadLine(), out EstadoExpediente estado))//poner en chatGPT qué hace
            {
                exped.estado = estado;
            }
            else
            {
                Console.WriteLine("ENUM no valido");
            }
            resultado.Add(exped);
        }
        return resultado;
    }

}