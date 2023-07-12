using ssoUM.DAL.Enums;

namespace ssoUM.Helpers {
    public class ApiResponse<T>
    {
        public Boolean success { get; set; }
        APIResponseCode code;
        string message;
        public T? data { get; set; }
        public string[]? error { get; set; }
    }
}
