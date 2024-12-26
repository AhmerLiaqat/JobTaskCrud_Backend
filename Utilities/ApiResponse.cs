namespace JobTaskCrud.Utilities
{
    public class ApiResponse<T>
    {
        public string? message { get; set; }
        public string? status { get; set; }
        public string? error { get; set; }
        public T? payload { get; set; }
        public static ApiResponse<T> Success(T payload, string message)
        {
            return new ApiResponse<T>
            {
                error = null,
                status = "Success",
                message = message,
                payload = payload
            };
        }
        public static ApiResponse<T> Success(T payload)
        {
            return new ApiResponse<T>
            {
                error = null,
                status = "Success",
                payload = payload,
            };
        }
        public static ApiResponse<T> Failure(string error)
        {
            return new ApiResponse<T>
            {
                error = error,
                status = "Fail",
            };
        }

        public static ApiResponse<T> Failure(T payload, string message, string error)
        {
            return new ApiResponse<T>
            {
                error = error,
                status = "Fail",
                message = message,
                payload = payload
            };
        }
    }

}
