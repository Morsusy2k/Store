using MAPS.DataAccessLayer.Models;
using MAPS.RepositoryLayer.Interfaces;
using MAPS.RepositoryLayer.Repositories;
using System;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITemplateRepository _repository = new TemplateRepository();

            Template template = _repository.GetTemplateById(1);

            Console.WriteLine($"Id:{template.Id}\nProperty:{template.Property}\nNullableProperty:{template.NullableProperty}\nVersion:{template.Version.GetHashCode()}");
        }
    }
}
