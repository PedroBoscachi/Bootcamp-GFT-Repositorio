using static System.Console;

Pessoa p1 = new Pessoa();

p1.Nome = "Pedro";
p1.Idade = 18;
p1.EnderecoPessoa = new Endereco()
{
    Logradouro = "Rua teste",
    CEP = "00000",
    Numero = 1234,
    Cidade = "São Paulo"
};

WriteLine("Fim");