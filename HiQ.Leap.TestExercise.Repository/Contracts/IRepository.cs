using HiQ.Leap.TestExercise.Domain.Models;
using HiQ.Leap.TestExercise.Domain.RequestModels;

namespace HiQ.Leap.TestExercise.Repository.Contracts;

public interface IRepository
{
    Person Add(PersonCreateRequest person);

    List<Person> GetPersons();

    Person GetPerson(int id);

    void UpdatePerson(int id, PersonEditRequest request);

    void DeletePerson(int id);
}