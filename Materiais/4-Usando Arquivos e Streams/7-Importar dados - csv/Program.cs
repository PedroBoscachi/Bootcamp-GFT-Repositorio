using System;
using System.IO;
using System.Collections.Generic;

CreateCsv();

Console.WriteLine("\n\nPress enter to finish");
Console.ReadLine();

static void CreateCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory,
    "Saida"
    );

    var people = new List<Person>()
    {
        new Person()
        {
            Name = "José da Silva",
            Email = "js@gmail.com",
            Phone = 123456,
            Birth = new DateTime(year: 1970, month: 2, day: 14)
        },
        new Person()
        {
            Name = "Pedro Paiva",
            Email = "pp@gmail.com",
            Phone = 456789,
            Birth = new DateTime(year: 2002, month: 4, day: 20)
        },
        new Person()
        {
            Name = "Maria Antonia",
            Email = "ma@gmail.com",
            Phone = 123456,
            Birth = new DateTime(year: 1982, month: 12, day: 4)
        },
        new Person()
        {
            Name = "Carla Moraes",
            Email = "cms@gmail.com",
            Phone = 9987411,
            Birth = new DateTime(year: 2000, month: 7, day: 20)
        },
    };

    var di = new DirectoryInfo(path);
    if(!di.Exists)
    {
        di.Create();
        path = Path.Combine(path,"usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    sw.WriteLine("nome,email,telefone,nascimento");
    foreach(var person in people)
    {
        var line = $"{person.Name},{person.Email},{person.Phone},{person.Birth}";
        sw.WriteLine(line);
    }

}



static void ReadCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada",
    "usuarios-exportacao.csv");
    if(File.Exists(path))
    {
        using var sr = new StreamReader(path);
        var header = sr.ReadLine()?.Split(',');//o ? serve para caso o ReadLine retornar nulo nem ir para o comando Split
        while(true)
        {
            var record = sr.ReadLine()?.Split(',');
            if(record == null) break;
            if(header.Length != record.Length)
            {
                Console.WriteLine("File out of the pattern");
                break;
            }
            for(int i = 0; i < record.Length; i++)
            {
                Console.WriteLine($"{header?[i]}:{record[i]}");
            }
            Console.WriteLine("-----------------------");
        }
    }
    else
    {
        Console.WriteLine("This path doesn't exist");
    }
}

class Person
{
    public string Name {get; set;}
    public string Email {get; set;}
    public int Phone {get; set;}
    public DateTime Birth {get; set;}
}





