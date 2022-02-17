using System;
using System.IO;
using static System.Console;

CriarDiretoriosGlobo();
CriarArquivo();

var pathOrigin = Path.Combine(Environment.CurrentDirectory,"\\brasil.txt");
var pathDestiny = Path.Combine(Environment.CurrentDirectory,
"globo", 
"América do Sul",
"Argentina",
"argentina.txt");

//MoverArquivo(pathOrigin, pathDestiny);
CopiarArquivo(pathOrigin, pathDestiny);
ReadLine();

static void CopiarArquivo(string pathOrigin, string pathDestiny)
{
    if(!File.Exists(pathOrigin))
    {
        WriteLine("The origin file doesn't exist");
        return;
    }

    if(File.Exists(pathDestiny))
    {
        WriteLine("The file it's already in the destiny folder");
        return;
    }
   
    File.Copy(pathOrigin, pathDestiny);
}

static void MoverArquivo(string pathOrigin, string pathDestiny)
{
    if(!File.Exists(pathOrigin))
    {
        WriteLine("The origin file doesn't exist");
        return;
    }

    if(File.Exists(pathDestiny))
    {
        WriteLine("The file it's already in the destiny folder");
        return;
    }
   
    File.Move(pathOrigin, pathDestiny);
}

static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "\\brasil.txt");

    if(!File.Exists(path))
    {
        using var sw = File.CreateText(path);

        sw.WriteLine("População: 210MM");
        sw.WriteLine("IDH: 1,0");
        sw.WriteLine("Dados atualizados em 21/08/2020");
    }
}

static void CriarDiretoriosGlobo()
{
    var path = Path.Combine(Environment.CurrentDirectory,"globo");
    if(!Directory.Exists(path))
    {
        var dirGLobo = Directory.CreateDirectory(path);
        var dirAmNorte = dirGLobo.CreateSubdirectory("América do Norte");
        var dirAmCentral = dirGLobo.CreateSubdirectory("América Central");
        var dirAmSul = dirGLobo.CreateSubdirectory("América do Sul");

        dirAmNorte.CreateSubdirectory("USA");
        dirAmNorte.CreateSubdirectory("México");
        dirAmNorte.CreateSubdirectory("Canadá");

        dirAmCentral.CreateSubdirectory("Costa Rica");
        dirAmCentral.CreateSubdirectory("Panamá");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Paraguai");
    }
    
}


