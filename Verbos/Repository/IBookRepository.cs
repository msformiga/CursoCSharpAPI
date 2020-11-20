using System.Collections.Generic;
using Verbos.Models;

namespace Verbos.Repository
{
    public interface IBookRepository
    {
         Book CreateBook(Book book);
         Book FindByIdBook(long id);
         Book UpdateBook(Book book);
         List<Book> FindAllBook();
         void DeleteBook (long id);

         bool ExistsBook (long id);
    }
}