namespace MenphisSI;

public class SGValidationException : Exception
{
    public string ValidationError { get; }
    public SGValidationException(string validationError) : base(validationError)
    {
        ValidationError = validationError;
    }
}
