namespace VetTextShifo.Application.Exceptions;

public class CustomException : Exception
{
    private  readonly int code;
    public CustomException(int code,string message) : base(message)
    {
        this.code = code;
    }
}
