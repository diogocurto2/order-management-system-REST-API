using System.Runtime.Serialization;

namespace OrderManagement.UseCases
{
    [Serializable]
    public class NotFoundException : Exception
    {

        public NotFoundException(string? message) : base(message)
        {
        }

    }
}