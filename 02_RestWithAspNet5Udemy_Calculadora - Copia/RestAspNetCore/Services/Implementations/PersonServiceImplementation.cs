using RestAspNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAspNetCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

        private volatile int count;
        public Person Create(Person person)
        {
            // Acesso a base!

            return person;
        }

        public void Delete(long id)
        {
            // Por ora, nada...
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Thiago",
                LastName = "Rodrigues",
                Address = "Cataguases, MG, BR",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            // Ações de DB

            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person LastName" + i,
                Address = "Adress" + i,
                Gender = "Masculino"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
