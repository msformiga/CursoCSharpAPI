using System.Collections.Generic;
using Verbos.Models;

namespace Verbos.Repository
{
    public interface IPersonRepository
    {
         Person Create(Person person);
         Person FindById(long id);
         Person Update(Person person);
         List<Person> FindAll();
         void Delete(long id);

         bool Exists (long id);
    }
}