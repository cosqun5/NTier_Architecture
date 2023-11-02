
namespace Core.Utilities.Exceptions
{
	public class AlreadyIsExistsException:Exception
	{
        public AlreadyIsExistsException() : base("Entity already exists!") 
        {
            
        }
        public AlreadyIsExistsException(string message):base(message)
        {
            
        }
    }
}
