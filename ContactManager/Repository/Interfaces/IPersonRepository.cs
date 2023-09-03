using ContactManager.Models;

namespace ContactManager.Repository.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();

        Task<bool> CreatePerson(List<Person> people, CancellationToken token);

        void UpdatePerson(int person);

        void DeletePerson(int personId);

    }
}
