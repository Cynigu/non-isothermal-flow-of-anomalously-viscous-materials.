using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Repository;
using ProgramSystem.Data.Repository.Factories;


Console.WriteLine("Программа для установки миграций в бд запустилась");

IRepositoryContextFactory repositoryContextFactory = new SqlRepositoryContextFactory();
try
{
    var context = repositoryContextFactory.Create();

    context.Database.Migrate();
}
catch(Exception e)   
{
    Console.WriteLine($"Миграции завершились с ошибкой {e.Message}");
    return;
}
Console.WriteLine("Миграции завершились успешно");
