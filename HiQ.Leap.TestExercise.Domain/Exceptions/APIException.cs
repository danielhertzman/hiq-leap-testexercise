using System.Net;

namespace HiQ.Leap.TestExercise.Domain.Exceptions;

public abstract class APIException : Exception
{
    protected APIException(string message)
        : base(message)
    {
    }

    public abstract HttpStatusCode StatusCode { get; }
}