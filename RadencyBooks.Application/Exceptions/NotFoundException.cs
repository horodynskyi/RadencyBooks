namespace RadencyBooks.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string type, int id):base($"The entity {type} not found with id - {id}")
    {
        
    }
}