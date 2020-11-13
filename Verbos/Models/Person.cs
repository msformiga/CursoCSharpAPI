using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verbos.Models
{
    //como os nomes dos campos no mysql estão diferentes dos definidos no model,  colocamos essas informações para conectarmos com os nomes de lá
    //dessa forma as entidades são mapeadas
    //Para a utilização desses itens é necessário "using System.ComponentModel.DataAnnotations.Schema;"
    [Table("Persons")]
    public class Person
    {

        [Column("id")]
        public long Id {get;set;}

        [Column("first_name")]
        public string FirstName {get;set;}

        [Column("last_name")]
        public string LastName{get;set;}

        [Column("address")]
        public string Address {get;set;}

        [Column("gender")]
        public string Gender{get;set;}
    }
}