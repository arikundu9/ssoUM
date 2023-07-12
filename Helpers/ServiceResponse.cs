using ssoUM.DAL.Enums;

namespace ssoUM.Helpers {
    public class ApiResponse<T>
    {
        public Success success { get; set; }
        public T? data { get; set; }
        public Error[]? error { get; set; }
    }

    public class Error
    {
        APIResponseCode? code;
        string? message;
    }
    public class Success
    {
        APIResponseCode code;
        string? message;
    }
}
