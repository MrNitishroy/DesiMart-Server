namespace DesiMart.Models
{
    public class ResponseModel
    {
        public string Message { get; }
        public bool Success { get; }
        public object Data { get; }

        public ResponseModel(string message, bool success, object data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
