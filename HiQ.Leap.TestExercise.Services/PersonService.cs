using HiQ.Leap.TestExercise.Domain.Exceptions;
using HiQ.Leap.TestExercise.Domain.Models;
using HiQ.Leap.TestExercise.Domain.RequestModels;
using HiQ.Leap.TestExercise.Repository.Contracts;
using HiQ.Leap.TestExercise.Services.Contracts;
using HiQ.Leap.TestExercise.Services.Helpers;

namespace HiQ.Leap.TestExercise.Services;

public class PersonService : IPersonService
{
    private readonly IRepository _repository;

    public PersonService(IRepository repository)
    {
        _repository = repository;
    }

    public void EditPerson(int id, PersonEditRequest request)
    {
        _repository.UpdatePerson(id, request);
    }

    public Person GetPerson(int id)
    {
        var person = _repository.GetPerson(id);
        return person;
    }

    public List<Person> GetPersons()
    {
        var persons = _repository.GetPersons();
        return persons;
    }

    public Person SavePerson(PersonCreateRequest personRequest)
    {
        if (!PersonNumberValidator.IsValidPersonNumber(personRequest.PersonNumber))
        {
            throw new PersonNumberNotValidException(personRequest.PersonNumber);
        }

        var createdPerson = _repository.Add(personRequest);
        return createdPerson;
    }

    public void DeletePerson(int id)
    {
        _repository.DeletePerson(id);
    }
}