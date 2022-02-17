using static System.Console;
using System.Collections.Generic;

public class Program
{

    static void Demo6()
    {
        int[] numeros = new int[]{0,2,4,6,8};
        WriteLine($"Digite o número que gostaria de encontrar: ");
        var numero = int.Parse(ReadLine());
        var idxEncontrado = EncontrarNumero(numeros, numero);

        if(idxEncontrado >= 0)
        {
            WriteLine($"O número digitado está na posição {idxEncontrado}");
        }
        else
        {
            WriteLine("O número digitado não foi encontrado");
        }    
    }
    
    static void Demo5()
    {
        int[] pares = new int[]{0,2,4,6,8};

        MudarParaImpar(pares);

        WriteLine($"Impares: {string.Join(",", pares)}");//join 
        //junta um array
    }
    
    static void Demo4()
    {
        string nome = "Pedro";

        TrocarNome(nome , "Peter");

        WriteLine($"Nome nome: {nome}");
    }
   
    static void Demo3()
    {
        StructPessoa p1 = new StructPessoa()//a struct fica tudo na stack
        {
            Documento = "1234",
            Idade = 19,
            Nome = "Pedro"
        };

        var p2 = p1;

        p1 = TrocarNome(p1, "Bruce");

        WriteLine($@"
        Nome p1: {p1.Nome}
        Nome p2: {p2.Nome}");
    }
    
    static void Demo2()
    {
        Pessoa p1 /*fica na stack*/= new Pessoa();//fica na heap
        p1.Nome = "Pedro";//heap
        p1.Idade = 18;//heap
        p1.Documento = "1234";//heap

        Pessoa p2 = p1.Clone();
        
        TrocarNome(p1, "Luke");

        WriteLine($@"
        Nome p1: {p1.Nome}
        Nome p2: {p2.Nome}");
    }

    static void TrocarNome(Pessoa p1, string nomeNovo)
    {
        p1.Nome = nomeNovo;
    }

    static StructPessoa TrocarNome(StructPessoa p1, string nomeNovo)
    {
        p1.Nome = nomeNovo;
        return p1;
    }

    static void TrocarNome(string nome, string nomeNovo)
    {
        nome = nomeNovo;//a string é reference type, mas seu 
        //comportamento é diferente, nesse caso é feito uma
        //cópia
    }

    static void MudarParaImpar(int[] pares)
    {
        for(int i = 0; i < pares.Length; i++)
        {
            pares[i] = pares[i] + 1;
        }
    }

    static int EncontrarNumero(int[] numeros, int numero)
    {
        for(int i = 0; i < numeros.Length; i++)
        {
            if(numeros[i] == numero)
                return i;
        }
        return -1;
    }

    static bool EncontrarPessoa(List<Pessoa> pessoas, Pessoa pessoa)
    {
        foreach (var item in pessoas)
        {
            if(item.Nome == pessoa.Nome)
            {
                return true;
            }
        }

        return false;
    }

    static bool EncontrarPessoa(List<StructPessoa> pessoas, StructPessoa pessoa)
    {
        foreach (var item in pessoas)
        {
            if(item.Equals(pessoa))
            {
                return true;
            }
        }

        return false;
    }

    public static void Main()
    {
        List<StructPessoa> pessoas = new List<StructPessoa>()
        {
            new StructPessoa(){Nome = "Pedro"},
            new StructPessoa(){Nome = "Felipe"},
            new StructPessoa(){Nome = "Luciana"},
            new StructPessoa(){Nome = "Igor"},
            new StructPessoa(){Nome = "Vasti"},
        };

        WriteLine("Digite o nome que quer encontrar: ");
        var nome = ReadLine();
        var pessoa = new StructPessoa(){Nome  = nome};
        var encontrado = EncontrarPessoa(pessoas, pessoa);
        if(encontrado)
        {
            WriteLine("Pessoa Localizada");
        }
        else
        {
            WriteLine("Pessoa não localizada");
        }

    }
}