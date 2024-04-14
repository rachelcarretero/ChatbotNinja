using AutoMapper;


namespace ChatbotNinja.Application.Services
{
    public class BaseService
    {
        public IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        // algo asi´en la clase base para realizar trazas y luego enviar a la web con la info de la excepción.
        //public BussinessException ManageException(Exception ex)
        //{
        //    //Solo gestionamos errores que NO controlados
        //    if (ex.GetType() == typeof(ExceptionPulsar))
        //        throw ex;

        //    //Obtenemos la información necesaria
        //    var sClassName = this.GetType().Name;
        //    var sParentMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().Name;

        //    //Diseñamos la traza
        //    var trace = new Trace(TypeTrace.Error, LevelTrace.Services,"", sClassName, sParentMethod, ex.StackTrace.ToString());

        //    //Guardamos
        //    DataBaseTracer.WriteTraceDB(trace);

        //    //Relanzamos la excepción
        //    return new BussinessException(trace.Comment);
        //}
    }
}