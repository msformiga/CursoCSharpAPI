using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verbos.Models
{
    [Table("Books")]
    public class Book
    {
        
[Column("id")]        
public long Id {get;set;}

[Column("author")]
public string Author {get;set;}

[Column("launch_date")]
public DateTime Launch_date{get;set;}


[Column("price")]
public double Price {get;set;}

[Column("title")]
public string Title {get;set;}

    }
}