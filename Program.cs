using System.Text.Json;

static void TestJSON()
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    string text = File.ReadAllText("config.json");
    var config = JsonSerializer.Deserialize<Config>(text, options);

    Console.WriteLine($"MimeMappings: {config.MimeTypes[".html"]}");
    Console.WriteLine($"INdexFiles: {config.IndexFiles[0]}");


}

static void TestJSON2()
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    string text = File.ReadAllText(@"json/books.json");
    var books = JsonSerializer.Deserialize<List<Book>>(text, options);


    Book book = books[4];
    Console.WriteLine($"title: {book.Title}");
    Console.WriteLine($"authors: {book.Authors[0]}");
}

static void TestServer()
{
    SimpleHTTPServer server = new SimpleHTTPServer("files", 8080);
    string helpMessage = @"Server started. You can try the following commands:
help - dislay this help message       
stop - stop the server
numreqs - display the number of requests
path - display the number of times each path was requested
";
    Console.WriteLine($"Server started!\n{helpMessage}");


    while (true)
    {
        Console.Write("> ");

        // read line from console
        String command = Console.ReadLine();
        if (command.Equals("stop"))
        {
            server.Stop();
            break;
        }
        else if (command.Equals("help"))
        {
            Console.WriteLine(helpMessage);
        }
        else if (command.Equals("numreqs"))
        {
            Console.WriteLine($"Number of Requests: {server.NumRequests}");

        }
        else if (command.Equals("paths"))// show how many time we requested the website by enter "path"
        {
            foreach (var path in server.PathsRequests)
            {
                Console.WriteLine($"{path.Key}:{path.Value}");
            }
        }
        else
        {
            Console.WriteLine($"Unknown command: {command}");
        }
    }
}

TestJSON();
//TestServer();
