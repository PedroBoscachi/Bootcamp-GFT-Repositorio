using System;
using System.IO;

string path = @"D:\Pedro\BOOTCAMP GFT .NET\Bootcamp-GFT-Repositorio\Materiais\4-Usando Arquivos e Streams\2-Diretórios\globo";

//o SystemWatcher monitora alguma estrutura de pastas escolhida
using var fsw = new FileSystemWatcher(path);//tem o IDisposable
fsw.Created += OnCreated;
fsw.Deleted += OnDeleted;
fsw.Renamed += OnRenamed;

fsw.EnableRaisingEvents = true;
fsw.IncludeSubdirectories = true;//para não englobar apenas a pasta globo, e sim suas subpastas tbm

Console.ReadLine();

void OnCreated(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File {e.Name} created");
}


void OnRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File {e.OldName} renamed to {e.Name}");
}



void OnDeleted(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File {e.Name} deleted");
}