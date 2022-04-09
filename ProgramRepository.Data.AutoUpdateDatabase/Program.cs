using System.Net;
using System.Security;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgrammSystem.BLL.Autofac;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Bll.Services.Interfaces;
using ProgramSystem.Bll.Services.Services;
using ProgramSystem.Data.Repository;
using ProgramSystem.Data.Repository.Factories;


//Console.WriteLine("Программа для установки миграций в бд запустилась");

//IRepositoryContextFactory repositoryContextFactory = new SqlRepositoryContextFactory();
//try
//{
//    var context = repositoryContextFactory.Create();

//    context.Database.Migrate();
//}
//catch (Exception e)
//{
//    Console.WriteLine($"Миграции завершились с ошибкой {e.Message}");
//    return;
//}
//Console.WriteLine("Миграции завершились успешно");

Console.WriteLine("Введите логин");

string login = Console.ReadLine();

Console.WriteLine("Введите пароль");

string password = Console.ReadLine();

var builderBase = new ContainerBuilder();
builderBase.RegisterModule(new ContextFactoriesModule());
builderBase.RegisterModule(new ServicesModule());

var containerBase = builderBase.Build();

var userBaseService = containerBase.Resolve<IUserBaseService>();
UserDTO? user = userBaseService.GetAccountByLoginPassword(login, password);

if (user == null)
{
    Console.WriteLine("Пользователь не найден!");
}
else
{
    Console.WriteLine($"Пользователь с логином {user.Login}, паролем {user.Password} и ролью {user.Role}");
    if (user.Role == "admin")
    {
        Console.WriteLine("Вход от админа");
    }
    else
    {
        Console.WriteLine("Вход от исследователя");
    }
}

Console.WriteLine();