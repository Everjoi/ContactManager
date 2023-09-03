using ContactManager.Models;
using ContactManager.Repository.Interfaces;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactManager.Repository.Implementation
{
    public class PersonRepository:IPersonRepository
    {
        private ContactManagerDbContext _context;

        public PersonRepository() 
        {
            _context = new ContactManagerDbContext();
        }

        public async Task<bool> CreatePerson(List<Person> people,CancellationToken token)
        {
            using(_context)
            {
                try
                {
                    await _context.AddRangeAsync(people);
                    await _context.SaveChangesAsync(token);

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
               
            }
        }

        public  void DeletePerson(int personId)
        {
            using(_context)
            {
               _context.Remove( _context.Persons.Where(x=>x.Id == personId));
            }

        }

        public  IEnumerable<Person> GetPersons()
        {
            using (_context)
            {
                return  _context.Persons.ToList();
            }
        }

        public void UpdatePerson(int personId)
        {
            using(_context)
            {
                _context.Update(_context.Persons.Where(x=>x.Id == personId));
            }
        }
    }
}
