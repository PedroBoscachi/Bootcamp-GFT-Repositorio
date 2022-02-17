using System;
using System.IO;
using static System.Console;

WriteLine("Digite o nome do arquivo: ");
var nome = ReadLine();
nome = LimparNome(nome);


var path = Path.Combine(Environment.CurrentDirectory + $"\\{nome}.txt");

CriarArquivo(path);

WriteLine("Digite enter para finalizar...");
ReadLine();

static string LimparNome(string nome)
{
    foreach(var item in Path.GetInvalidFileNameChars())//lista de caracteres inválidos
    {
        nome = nome.Replace(item, '-');
    }
    return nome;
}

static void CriarArquivo(string path)
{
    try
    {
        using var sw = File.CreateText(path);
        //StreamWrite implementa a interface IDisposible, que permite a aplicação
        //encerrar de forma forçada, nesse caso deve-se usar o flush() quando quer
        //fechar o arquivo ou o using que fecha automaticamente

        sw.WriteLine("Linha 1 do arquivo");
        sw.WriteLine("Linha 2 do arquivo");
        sw.WriteLine("Linha 3 do arquivo");
    }
    catch
    {
        WriteLine("O nome do arquivo é inválido");
    }
}

