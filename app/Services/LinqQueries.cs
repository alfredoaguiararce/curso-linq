using app.models;
using System.Text.Json;

namespace app.Services;

internal class LinqQueries 
{

    private List<Book>? books = new List<Book>();

    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.books = JsonSerializer
                        .Deserialize<List<Book>>(json,
                                                    new JsonSerializerOptions() 
                                                    { PropertyNameCaseInsensitive = true }
                                                    );
        }

        if( books is null ) throw new InvalidOperationException("Problem retrieving data");
    }

    public IEnumerable<Book>? GetBooks()
    {
        return this.books;
    }
}


