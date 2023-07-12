using ssoUM.DAL.Enums;

namespace ssoUM.Helpers {
    public class ServiceResponse<T> 
    {
        public T? result { get; set; }          
        public APIResponseStatus apiResponseStatus { get; set; }
        public string Message { get; set; }
    }

    
}