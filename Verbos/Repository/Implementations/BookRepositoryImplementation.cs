using System;
using System.Collections.Generic;
using Verbos.Repository;
using Verbos.Models;
using System.Threading;
using Verbos.Models.Context;
using System.Linq;
namespace Verbos.Repository.Implementations
{
    public class BookRepositoryImplementation
    {
      
        private Contexto _Contexto;

        public BookRepositoryImplementation(Contexto contexto){
            _Contexto = contexto;
        }

        //como se tivess num banco e tivesse persistindo e retornando sempre um Id maior (mockar um id)
        private volatile int count;

        public List<Book> FindAllBook (){
          return  _Contexto.Books.ToList();         
        }


        public Book FindByIdBook (long id){            
            {
                return _Contexto.Books.SingleOrDefault(p => p.Id.Equals(id) );
            };
        }  


        public Book CreateBook (Book book){
            try{
                _Contexto.Add(book);
                _Contexto.SaveChanges();
            }
            catch(Exception ){ throw ;}
            return book;
        }



        public Book UpdateBook (Book book){
            if (!ExistsBook(book.Id)) return null;

            var result = _Contexto.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

            if (result != null){
                try{
                    _Contexto.Entry(result).CurrentValues.SetValues(book);
                    _Contexto.SaveChanges();
                }
                catch(Exception){throw;}
            }
           return book;
           
        }



        public void DeleteBook (long id){
            var result = _Contexto.Books.SingleOrDefault(p => p.Id.Equals(id));    
            if(result != null){
                try{
                    _Contexto.Books.Remove(result);
                    _Contexto.SaveChanges();
                }
                catch(Exception){throw;}

            }   
        }

 
        public bool ExistsBook(long id){
            return _Contexto.Books.Any(p => p.Id.Equals(id));
        }

        private long IncrementAndGet(){
            //a variável abaixo "count" foi definida no início dessa classe
            return Interlocked.Increment(ref count);
            
        }  
    }
}