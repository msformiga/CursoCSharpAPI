using System.Collections.Generic;
using Verbos.Models;

namespace Verbos.Business
{
    public interface IPersonBusiness
    {
         Person Create(Person person);
         Person FindById(long id);
         Person Update(Person person);
         List<Person> FindAll();
         void Delete (long id);
    }
}