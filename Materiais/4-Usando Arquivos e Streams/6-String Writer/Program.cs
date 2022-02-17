using System;
using System.IO;

string textReaderText = "...As imensas dunas se compõem de minúsculos grãos de areia..." +
"O mais belo livro do mundo foi escrito letra por letra." +
"As mais belas canções são compostas por pequenas notas...\n\n" +
"Pra se viver de verdade, não é necessário fazer ou passar por grandes feitos," +"espetáculos ou grandes demostrações. A vida é feita dos pequenos gestos, das\n\n" +"pequenas atitudes. Um olhar, um sorriso, um abraço ou uma palavra, podem fazer" +"toda a diferença.\n\n";

Console.WriteLine("Original text: " + textReaderText);
string line, paragraph = null;
var sr = new StringReader(textReaderText);//instancia um StringReader no texto

while(true)//loop infinito
{
    line = sr.ReadLine();
    if(line != null)//se a  linha não tiver conteudo
    {
        paragraph += line + " ";//adiciona essa linha no paragrafo e da um espaço
    }
    else//se a linha não tiver conteudo da um enter no paragrafo e quebra o loop
    {
        paragraph += '\n';
        break;
    }
}

Console.WriteLine($"Modified Text: {paragraph}");
int readCharacter;
char convertedCharacter;

var sw = new StringWriter();//cria um StringWriter
sr = new StringReader(paragraph);//instancia um novo StringReader no sr com o texto modificado

while(true)
{
    readCharacter = sr.Read();//o Read() le o caractere e transforma em seu valor decimal, logo, se esse não existir o valor é -1
    if(readCharacter == -1)
    {
        break;
    }

    convertedCharacter = Convert.ToChar(readCharacter);//o Convert.ToChar pega esse número decimal e converte para seu caractere correspondente na tabela ASCII

    if(convertedCharacter == '.')//se o caractere convertido foi um . da dois enter e consome os dois espaços que vem depois do ponto com os sr.Read()
    {
        sw.Write("\n\n");

        sr.Read();
        sr.Read();
    }
    else
    {
        sw.Write(convertedCharacter);//senão escreve o caractere convertido
    }
}

Console.WriteLine($"Stored text in the StringWriter: {sw.ToString()}");
Console.ReadLine();