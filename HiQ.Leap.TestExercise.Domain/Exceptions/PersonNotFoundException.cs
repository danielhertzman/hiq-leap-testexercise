﻿using System.Net;

namespace HiQ.Leap.TestExercise.Domain.Exceptions;

public class PersonNotFoundException : APIException
{
    public PersonNotFoundException(int personId) 
        : base($"Person with id '{personId}' was not found")
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}