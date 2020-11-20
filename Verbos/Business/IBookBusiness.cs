using System.Collections.Generic;
using Verbos.Models;

namespace Verbos.Business
{
    public interface IBookBusiness
    {
        Book CreateBook(Book book);
         Book FindByIdBook(long id);
         Book UpdateBook(Book book);
         List<Book> FindAllBook();
         void DeleteBook (long id); 
    }
}