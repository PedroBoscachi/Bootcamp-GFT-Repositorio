using CsvHelper.Configuration;
using System.Globalization;

public class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Map(x => x.Titulo).Name("titulo");
        Map(x => x.Preco)
            .Name("preço")
            .TypeConverterOption.CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
        Map(x => x.Autor).Name("autor");
        Map(x => x.Lancamento)
        .Name("lançamento")
        .TypeConverterOption
        .Format(new [] {"dd/MM/yyyy"});
    }
}
