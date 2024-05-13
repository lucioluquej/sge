namespace sge.Repositorios;

using Microsoft.Win32.SafeHandles;
using sge.Aplicacion;
public class TramiteRepositorio(IServicioAutorizacion autorizacion, TramiteValidador validador) : ITramiteRepositorio
{
    public bool existe(int id)
    {

        using var sr = new StreamReader(_nombreArch);
        var tram = new Tramite();

        while (!sr.EndOfStream )
        {
             tram.id = int.Parse(sr.ReadLine() ?? "");
            Tramite.ExpedienteID = int.Parse(sr.ReadLine() ?? "");        //??
            tram.etiqueta = (EtiquetasTramites)Enum.Parse(typeof(EtiquetasTramites), sr.ReadLine() ?? "");
            tram.creacion = DateTime.Parse(sr.ReadLine() ?? "");
            tram.modificacion = DateTime.Parse(sr.ReadLine() ?? "");
            tram.idUltimoUser = int.Parse(sr.ReadLine() ?? "");
            tram.contenido = sr.ReadLine() ?? "";
           if(tram.id == id)
           {
            return true;
               }

        }
    return false;
    }
//RETORNAR TRAMITE POR ID

 public Tramite getTRAMporID(int id)
    {

        using var sr = new StreamReader(_nombreArch);
        var tram = new Tramite();

        while (!sr.EndOfStream )
        {
             tram.id = int.Parse(sr.ReadLine() ?? "");
            Tramite.ExpedienteID = int.Parse(sr.ReadLine() ?? "");        //??
            tram.etiqueta = (EtiquetasTramites)Enum.Parse(typeof(EtiquetasTramites), sr.ReadLine() ?? "");
            tram.creacion = DateTime.Parse(sr.ReadLine() ?? "");
            tram.modificacion = DateTime.Parse(sr.ReadLine() ?? "");
            tram.idUltimoUser = int.Parse(sr.ReadLine() ?? "");
            tram.contenido = sr.ReadLine() ?? "";
           if(tram.id == id)
           {
            return tram;
           }

        }
    return null;
    }
     string _nombreArch = "tramites.txt"; //deberia ser un archivo de texto o varios?
    
    

    public void agregarTramite(Tramite tram,int id)
    {
      if(autorizacion.poseeElPermiso(id,Permiso.TramiteAlta))
      {
            if(validador.Validar(tram, out string mensajeError))
            {
                using var sw = new StreamWriter(_nombreArch, true);
                sw.WriteLine(tram.id);
                sw.WriteLine(tram.idUltimoUser);
                sw.WriteLine(Tramite.ExpedienteID);
                sw.WriteLine(tram.creacion);
                sw.WriteLine(tram.modificacion);
                sw.WriteLine(tram.contenido);
                sw.WriteLine(tram.etiqueta.ToString());
                sw.WriteLine("");
            }
            else
                throw new ValidacionException();
      }
        else
            throw new AutorizacionException();

    }
    public List<Tramite> listarTramite()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = new Tramite();
            tramite.id = int.Parse(sr.ReadLine() ?? "");
            tramite.idUltimoUser= int.Parse(sr.ReadLine() ?? "");
            Tramite.ExpedienteID = int.Parse(sr.ReadLine() ?? "");
            tramite.creacion = DateTime.Parse(sr.ReadLine() ?? "");
            tramite.modificacion= DateTime.Parse(sr.ReadLine() ?? "");

            tramite.contenido=sr.ReadLine()??"";

            if (Enum.TryParse<EtiquetasTramites>(sr.ReadLine(), out EtiquetasTramites etiqueta))
            {
                tramite.etiqueta = etiqueta;
            }
            else
            {
                Console.WriteLine("ENUM no valido");
            }
            
            resultado.Add(tramite);
        }
        return resultado;
    }
    public void modificarTramite(int id,int idTram, string cont)
    {
    if(autorizacion.poseeElPermiso(id,Permiso.TramiteModificacion)){
        if(existe(idTram)){
            string _nombreArch2 = "tramitesNuevo.txt";
            using var sr = new StreamReader(_nombreArch);
            using var sw= new  StreamWriter(_nombreArch2);
            var tram = new Tramite();
            
            while (!sr.EndOfStream)
            {
                tram.id = int.Parse(sr.ReadLine() ?? "");
                Tramite.ExpedienteID = int.Parse(sr.ReadLine() ?? "");
                tram.etiqueta = (EtiquetasTramites)Enum.Parse(typeof(EtiquetasTramites), sr.ReadLine() ?? "");
                tram.creacion = DateTime.Parse(sr.ReadLine() ?? "");
                tram.modificacion = DateTime.Parse(sr.ReadLine() ?? "");
                tram.idUltimoUser = int.Parse(sr.ReadLine() ?? "");
                tram.contenido = sr.ReadLine() ?? "";
            if(tram.id != id)
            {
                //podria ser un metodo privado
                sw.WriteLine(tram.id);
                sw.WriteLine(tram.idUltimoUser);
                sw.WriteLine(Tramite.ExpedienteID);
                sw.WriteLine(tram.creacion);
                sw.WriteLine(tram.modificacion);
                sw.WriteLine(tram.contenido);
                sw.WriteLine(tram.etiqueta.ToString());
                sw.WriteLine("");
            }
            else
            {
                    sw.WriteLine(tram.id);
                    sw.WriteLine(tram.idUltimoUser);
                    sw.WriteLine(Tramite.ExpedienteID);
                    sw.WriteLine(tram.creacion);
                    sw.WriteLine(tram.modificacion);
                    sw.WriteLine(cont);
                    sw.WriteLine(tram.etiqueta.ToString());
                    sw.WriteLine("");
            }
            }
            string contenido= File.ReadAllText(_nombreArch2); //se guarda todo el contenido de sw
            File.WriteAllText(_nombreArch, contenido);//carga contenido en sr, reemplaza todo el contenido viejo?
        }
        else
           throw new RepositorioException();
    }
        else
            throw new AutorizacionException();
    }
    public void bajaTramite(int id,int idTram)
    {
        if(autorizacion.poseeElPermiso(id,Permiso.TramiteModificacion))
        {
            if(existe(idTram))
            {
                string _nombreArch2 = "tramitesNuevo.txt";
                using var sr = new StreamReader(_nombreArch);
                using var sw= new  StreamWriter(_nombreArch2);
                var tram = new Tramite();

                while (!sr.EndOfStream)
                {

                    tram.id = int.Parse(sr.ReadLine() ?? "");
                    Tramite.ExpedienteID = int.Parse(sr.ReadLine() ?? "");
                    tram.etiqueta = (EtiquetasTramites)Enum.Parse(typeof(EtiquetasTramites), sr.ReadLine() ?? "");
                    tram.creacion = DateTime.Parse(sr.ReadLine() ?? "");
                    tram.modificacion = DateTime.Parse(sr.ReadLine() ?? "");
                    tram.idUltimoUser = int.Parse(sr.ReadLine() ?? "");
                    tram.contenido = sr.ReadLine() ?? "";

                    if(tram.id != id)
                    {
                        //podria ser un metodo privado
                        sw.WriteLine(tram.id);
                        sw.WriteLine(tram.idUltimoUser);
                        sw.WriteLine(Tramite.ExpedienteID);
                        sw.WriteLine(tram.creacion);
                        sw.WriteLine(tram.modificacion);
                        sw.WriteLine(tram.contenido);
                        sw.WriteLine(tram.etiqueta.ToString());
                        sw.WriteLine("");
                    }
                }
                string contenido= File.ReadAllText(_nombreArch2); //se guarda todo el contenido de sw
                File.WriteAllText(_nombreArch, contenido);//carga contenido en sr
            } else throw new RepositorioException();
        } else
            throw new AutorizacionException();
    }       
}