using MyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class PersonRepository
    {
        private static PersonRepository instance = null;
        private static readonly object padlock = new object();
        public BindingList<Person> People { get; set; }
        public PersonRepository()
        {
            People = new BindingList<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "Tasos",
                    LastName = "Zampelis"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Christina",
                    LastName = "Aivali"
                }
            };
        }

        public static PersonRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PersonRepository();
                    }
                    return instance;
                }
            }
        }
        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        public void RemovePerson(Person person)
        {
            People.Remove(person);
        }

        public void EditPerson(Person person)
        {
            var selectedPerson = People.Where(d => d.Id == person.Id).FirstOrDefault();
            if(selectedPerson != null)
            {
                selectedPerson.FirstName = person.FirstName;
                selectedPerson.LastName = person.LastName;
            }
        }
    }
}
