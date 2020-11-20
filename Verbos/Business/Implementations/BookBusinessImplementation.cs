using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verbos.Models;
using Verbos.Repository;
using System.Threading;

namespace Verbos.Business.Implementations
{
    public class BookBusinessImplementation: IBookBusiness
    {
         //private Contexto _Repository; (substituído pela linha abaixo)
        private readonly IBookRepository _Repository;

        public BookBusinessImplementation(IBookRepository repository){
            _Repository = repository;
        }

        //como se tivess num banco e tivesse persistindo e retornando sempre um Id maior (mockar um id)
        private volatile int count;

        public List<Book> FindAllBook (){
          return  _Repository.FindAllBook();          
        }


        public Book FindByIdBook (long id){            
            {
                return _Repository.FindByIdBook(id);
            };
        }  


        public Book CreateBook (Book book){
            return _Repository.CreateBook(book);
        }



        public Book UpdateBook (Book book){
            return _Repository.UpdateBook(book);
        }



        public void DeleteBook (long id){
            _Repository.DeleteBook (id);
        }

 
        private long IncrementAndGet(){
            //a variável abaixo "count" foi definida no início dessa classe
            return Interlocked.Increment(ref count);
            
        } 
    }
}