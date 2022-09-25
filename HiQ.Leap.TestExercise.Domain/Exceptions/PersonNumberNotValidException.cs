using System.Net;

namespace HiQ.Leap.TestExercise.Domain.Exceptions
{
    public class PersonNumberNotValidException : APIException
    {
        public PersonNumberNotValidException(string personNumber)
            : base($"Person number '{personNumber}' is not valid")
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
