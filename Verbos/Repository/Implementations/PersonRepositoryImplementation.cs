using System;
using System.Collections.Generic;
using Verbos.Repository;
using Verbos.Models;
using System.Threading;
using Verbos.Models.Context;
using System.Linq;

namespace Verbos.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private Contexto _Contexto;

        public PersonRepositoryImplementation(Contexto contexto){
            _Contexto = contexto;
        }

        //como se tivess num banco e tivesse persistindo e retornando sempre um Id maior (mockar um id)
        private volatile int count;

        public List<Person> FindAll (){
          return  _Contexto.Persons.ToList();          
        }


        public Person FindById (long id){            
            {
                return _Contexto.Persons.SingleOrDefault(p => p.Id.Equals(id) );
            };
        }  


        public Person Create (Person person){
            try{
                _Contexto.Add(person);
                _Contexto.SaveChanges();
            }
            catch(Exception ){ throw ;}
            return person;
        }



        public Person Update (Person person){
            if (!Exists(person.Id)) return new Person();

            var result = _Contexto.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null){
                try{
                    _Contexto.Entry(result).CurrentValues.SetValues(person);
                    _Contexto.SaveChanges();
                }
                catch(Exception){throw;}
            }
           return person;
           
        }



        public void Delete (long id){
            var result = _Contexto.Persons.SingleOrDefault(p => p.Id.Equals(id));    
            if(result != null){
                try{
                    _Contexto.Persons.Remove(result);
                    _Contexto.SaveChanges();
                }
                catch(Exception){throw;}

            }   
        }

 
        public bool Exists(long id){
            return _Contexto.Persons.Any(p => p.Id.Equals(id));
        }

        private long IncrementAndGet(){
            //a variável abaixo "count" foi definida no início dessa classe
            return Interlocked.Increment(ref count);
            
        }


    }
}