using System;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using System.Collections.Generic;

//ReadCSVWithDynamic()
//ReadCsvWithClass();
//ReadCsvWithAnotherDelimiter();
WriteCsv();

Console.ReadLine();

static void WriteCsv()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Saida");

    var di = new DirectoryInfo(path);

    if(!di.Exists)
    {
        di.Create();
    }

    path = Path.Combine(path,"usuarios.csv");

     var people = new List<Person>()
    {
        new Person()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
        },
        new Person()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 456789,
        },
        new Person()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 123456,
        },
        new Person()
        {
            Nome = "Carla Moraes",
            Email = "cms@gmail.com",
            Telefone = 9987411,

        },
    };

    using var sr = new StreamWriter(path);
    var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
    {
        Delimiter = "|"
    };
    using var csvWriter = new CsvWriter(sr, csvConfig);
    csvWriter.WriteRecords(people);

}

static void ReadCsvWithAnotherDelimiter()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "Livros-preco-com-virgula.csv");

    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"The file {path} doesn't exist");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"//define o ponto e virgula como separador no arqivo
    };
    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<BookMap>();

    var records = csvReader.GetRecords<Book>();

    foreach(var record in records)
    {
        Console.WriteLine($"Título:{record.Titulo}");
        Console.WriteLine($"Preço:{record.Preco}");
        Console.WriteLine($"Autor:{record.Autor}");
        Console.WriteLine($"Lançamento:{record.Lancamento}");
        Console.WriteLine("---------------------------");
    }
}

static void ReadCsvWithClass()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "novos-usuarios.csv");

    var fi = new FileInfo(path);

    if(!fi.Exists)
        throw new FileNotFoundException($"The file {path} doesn't exist");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var records = csvReader.GetRecords<User>();

    foreach(var record in records)
    {
        Console.WriteLine($"Nome:{record.Nome}");
        Console.WriteLine($"Email:{record.Email}");
        Console.WriteLine($"Telefone:{record.Telefone}");
        Console.WriteLine("---------------------------");
    }
}

static void ReadCSVWithDynamic()
{
    var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entrada",
    "Produtos.csv");

    var fi = new FileInfo(path);//cria novo FIleInfo no arquivo

    if(!fi.Exists)
        throw new FileNotFoundException($"The file {path} doesn't exist");

    using var sr = new StreamReader(fi.FullName);//StreamReader no arquivo
    var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
    //configuração para o arquivo
    using var csvReader = new CsvReader(sr, csvConfig);//instancia um CsvReader para o sr com as configurações escolhidas

    var records = csvReader.GetRecords<dynamic>();

    foreach(var record in records)
    {
        Console.WriteLine($"nome:{record.Produto}");
        Console.WriteLine($"marca:{record.Marca}");
        Console.WriteLine($"preço:{record.Preco}");
        Console.WriteLine("---------------------------");
    }
}