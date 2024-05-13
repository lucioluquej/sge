using sge.Aplicacion;
using sge.Repositorio;

//dependencias
IRepositorioExpediente repo= new IRepositorioExpediente();

//caso de uso
var ExpedienteAlta= new CasoDeUsoExpedienteAlta(repo);
var ExpedienteBaja= new CasoDeUsoExpedienteBaja(repo);
var ExpedienteConsultaId= new CasoDeUsoExpedienteConsultaPorId(repo);
var ExpedienteConsultaTodos= new CasoDeUsoExpedienteConsultaTodos(repo);
var ExpedienteModificacion= new CasoDeUsoExpedienteModificacion(repo);
var TramiteAlta= new CasoDeUsoTramiteAlta();
var TramiteBaja= new CasoDeUsoTramiteBaja();
var TramiteConsultaEtiqueta= new CasoDeUsoTramiteConsultaPorEtiqueta();
var TramiteModificacion= new CasoDeUsoTramiteModificacion();//Que entra por param?
 
//ejecutar
try{
    ExpedienteAlta.Ejecutar(new Expendiente(){caratula='caratula1'});
    ExpedienteAlta.Ejecutar(new Expendiente(){caratula='caratula2'});
    var exps=ExpedienteConsultaTodos.Ejecutar();//lista con todos los expedientes
    var exp=ExpedienteConsultaId.Ejecutar(1);//expediente
    var exp2=ExpedienteConsultaId.Ejecutar(2); //expediente 2
    ExpedienteBaja.Ejecutar(exp);
    ExpedienteModificacion.Ejecutar(exp2);
    TramiteAlta.Ejecutar(New Tramite(){ExpendienteID=exp2.getId();, contenido=''});//usa id del expediente anterior, no se si esta bien
    TramiteAlta.Ejecutar(New Tramite(){ExpendienteID=exp2.getId();, contenido=''});
    var trams=TramiteConsultaEtiqueta.Ejecutar('Resolucion'); //devuelve lista
    TramiteModificacion.Ejecutar(1);
}
catch(Exception ex)//me huele que no es tan simple la excepcion pero si cualquiera de los casos de uso tira un excepcion esto lo va atrapar asi que capaz esta bien..?.
{
    Console.WriteLine(ex.Message);
}