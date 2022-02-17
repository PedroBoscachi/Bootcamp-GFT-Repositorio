using System;
using static System.Console;

class Aula2
{
    static void Demo2()
    {
        var nomes = new string[]{"José","Maria","Ricardo","Alice","Pedro"};

        WriteLine($@"A lista de nomes:
        {string.Join(", \n",nomes)}
        ");
        
        WriteLine("Nome a ser substituido: ");
        var nome = ReadLine();
        WriteLine("Nome novo: ");
        var nomeNovo = ReadLine();

        AlterarNome(nomes, nome, nomeNovo);

        WriteLine($@"A lista de nomes alteradas é:
         {string.Join(", \n",nomes)}
        ");
    }
    
    static void Demo1()
    {
        int a = 5;
        Adicionar20(ref a);

        WriteLine($"Valor de a: {a}");
    }
    
    static void Adicionar20(ref int a)
    {
        a += 20;
    }

    static void AlterarNome(string[] nomes, string nome, string nomeNovo)
    {
        for (int i = 0; i < nomes.Length; i++)
        {
            if(nomes[i] == nome)
            {
                nomes[i] = nomeNovo;
            }
        }
    }

    static ref string LocalizarNome(string[] nomes, string nome)
    {
        for (int i = 0; i < nomes.Length; i++)
        {
           if(nomes[i] == nome)
           {
               return ref nomes[i];
           }
        }

        throw new Exception("Nome não encontrado");
    }
    
    static void Main()
    {
        var nomes = new string[]{"José","Maria","Ricardo","Alice","Pedro"};

        WriteLine($@"A lista de nomes:
        {string.Join(", \n",nomes)}
        ");
        
        WriteLine("Nome a ser substituido: ");
        var nome = ReadLine();
        WriteLine("Nome novo: ");
        var nomeNovo = ReadLine();

        ref var nomeAchado = ref LocalizarNome(nomes, nome);

        if(!string.IsNullOrWhiteSpace(nomeAchado))
        {
            nomeAchado = nomeNovo;

            WriteLine($@"A lista de nomes alteradas é:
              {string.Join(", \n",nomes)}
            ");
        }
        else
        {
            WriteLine("Nome não localizado");
        }
        
    }
}
