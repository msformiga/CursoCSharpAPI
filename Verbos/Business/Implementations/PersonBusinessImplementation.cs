using System;
using System.Collections.Generic;
using Verbos.Business;
using Verbos.Models;
using System.Threading;
using Verbos.Models.Context;
using System.Linq;
using Verbos.Repository;

namespace Verbos.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        //private Contexto _Repository; (substituído pela linha abaixo)
        private readonly IPersonRepository _Repository;

        public PersonBusinessImplementation(IPersonRepository repository){
            _Repository = repository;
        }

        //como se tivess num banco e tivesse persistindo e retornando sempre um Id maior (mockar um id)
        private volatile int count;

        public List<Person> FindAll (){
          return  _Repository.FindAll();          
        }


        public Person FindById (long id){            
            {
                return _Repository.FindById(id);
            };
        }  


        public Person Create (Person person){
            return _Repository.Create(person);
        }



        public Person Update (Person person){
            return _Repository.Update(person);
        }



        public void Delete (long id){
            _Repository.Delete (id);
        }

 
        private long IncrementAndGet(){
            //a variável abaixo "count" foi definida no início dessa classe
            return Interlocked.Increment(ref count);
            
        }


    }
}