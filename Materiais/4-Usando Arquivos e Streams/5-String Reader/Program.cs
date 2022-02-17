using System;
using System.IO;
using System.Text;

var sb = new StringBuilder();
sb.AppendLine("First line to read");
sb.AppendLine("second line");
sb.AppendLine("end to pro");

//String reader possui IDisposable, então quando acabar o método
//a memória é descarregada e os recursos do computador são liberados
using var sr = new StringReader(sb.ToString());
//buffer é como se fosse um container que comporta uma grade quantidade de dados e quebra eles em pequenos pacotes de dados
var buffer = new char[10];//esse buffer suporta 10 bytes
//var pos = sr.Read(buffer);
//Console.WriteLine($"{string.Join("",buffer)}");
//Console.ReadLine();

var size = 0;
do
{
    buffer = new char[10];//limpa o buffer
    size = sr.Read(buffer);
    Console.WriteLine(string.Join("",buffer));
}while(size >= buffer.Length);

Console.ReadKey();