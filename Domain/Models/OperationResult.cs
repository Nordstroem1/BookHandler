namespace Domain.Models
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }
        public T Data { get; private set; }

        public OperationResult(bool isSuccess, string errorMessage, T data)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Data = data;
        }

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>(true, string.Empty, data);
        }
        public static OperationResult<T> Fail(string errorMessage)
        {
            return new OperationResult<T>(false, errorMessage, default);
        }
    }
}