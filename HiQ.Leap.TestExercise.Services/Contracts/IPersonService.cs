using HiQ.Leap.TestExercise.Domain.Models;
using HiQ.Leap.TestExercise.Domain.RequestModels;

namespace HiQ.Leap.TestExercise.Services.Contracts;

public interface IPersonService
{
    void EditPerson(int id, PersonEditRequest person);

    Person GetPerson(int id);

    List<Person> GetPersons();

    Person SavePerson(PersonCreateRequest personRequest);

    void DeletePerson(int id);
}