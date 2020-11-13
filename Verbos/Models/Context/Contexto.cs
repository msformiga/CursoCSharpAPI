using Microsoft.EntityFrameworkCore;



namespace Verbos.Models.Context
{
    public class Contexto: DbContext
    {
        public Contexto(){}
        public Contexto(DbContextOptions<Contexto> options ): base(options){}
        public DbSet<Person> Persons {get;set;}
    }
}