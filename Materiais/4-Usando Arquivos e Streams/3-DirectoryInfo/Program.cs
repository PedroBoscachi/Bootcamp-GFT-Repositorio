using System;
using System.IO;

var path = @"D:\Pedro\BOOTCAMP GFT .NET\Bootcamp-GFT-Repositorio\Materiais\4-Usando Arquivos e Streams\2-Diretórios\globo";
//ReadDirectory(path);
ReadFiles(path);
Console.ReadLine();

static void ReadFiles(string path)
{
    var files = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
    foreach(var file in files)
    {
        var fileInfo = new FileInfo(file);
        Console.WriteLine($"[Name]: {fileInfo.Name}");
        Console.WriteLine($"[Length]: {fileInfo.Length}");
        Console.WriteLine($"[Last acess]: {fileInfo.LastAccessTime}");
        Console.WriteLine($"[Folder]: {fileInfo.DirectoryName}");
        Console.WriteLine("-----------------------------");
    }
}

static void ReadDirectory(string path)
{
    if(Directory.Exists(path))
    {
        var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

        foreach(var dir in directories)
        {
            var dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"[Name]: {dirInfo.Name}");
            Console.WriteLine($"[Root]: {dirInfo.Root}");
            if(dirInfo.Parent != null)
            {
                Console.WriteLine($"[Parent]: {dirInfo.Parent.Name}");
            }

            Console.WriteLine("------------------------------------------");
        }
    }
    else
    {
        Console.WriteLine("The directory doesn't exist");
    }
}