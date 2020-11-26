namespace ReHomeVirtualBackEnd.General.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Sucess { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Resource = resource;
            Sucess = true;
            Message = string.Empty;
        }

        public BaseResponse(string message)
        {
            Sucess = false;
            Message = message;
        }
    }
}
