namespace RadencyBooks.Application.Exceptions;

public class ProvidedSecretKeyIsNotValidException : Exception
{
    public ProvidedSecretKeyIsNotValidException(string secret):base($"Provided key is not valid, provided key - {secret}")
    {
        
    }
}