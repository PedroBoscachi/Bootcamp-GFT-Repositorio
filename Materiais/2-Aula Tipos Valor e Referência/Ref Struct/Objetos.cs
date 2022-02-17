public ref struct Pessoa//classe vai para a heap
{
    public int Idade { get; set; }
    public string Nome { get; set; }

    public Endereco EnderecoPessoa { get; set; }
}

public ref struct Endereco//ref struct não pode sair da stack
//confirmar que está na stack faz o compilador não passar o Garbage Collector,
//o que melhora o desempenho
{
    public int Numero { get; set; }
    public string Logradouro { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
}