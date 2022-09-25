using System.Collections.Generic;
using HiQ.Leap.TestExercise.Domain.Models;
using HiQ.Leap.TestExercise.Domain.RequestModels;
using HiQ.Leap.TestExercise.Services.Contracts;

namespace HiQ.Leap.TestExercise.Tests.IntegrationTests.Stubs;

public class PersonServiceStub : IPersonService
{
    public void EditPerson(int id, PersonEditRequest person)
    {
    }

    public Person GetPerson(int id)
    {
        return new Person()
        {
            Id = 0,
            PersonNumber = "FakePersonNumber",
            GivenName = "Stub",
            SurName = "Fake"
        };
    }

    public List<Person> GetPersons()
    {
        return new List<Person>()
        {
            new()
            {
                Id = 0,
                PersonNumber = "FakePersonNumber",
                GivenName = "Stub",
                SurName = "Fake"
            }
        };
    }

    public Person SavePerson(PersonCreateRequest personRequest)
    {
        return new Person()
        {
            Id = 0,
            PersonNumber = "FakePersonNumber",
            GivenName = "Stub",
            SurName = "Fake"
        };
    }

    public void DeletePerson(int id)
    {
    }
}