using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class BookController: BaseController, IBaseController
{
    public void ViewItems()
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDataBase.LibraryItems.OfType<Book>();

        foreach (var book in books)
        {
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Name}[/]",
                $"[cyan]{book.Author}[/]",
                $"[cyan]{book.Category}[/]",
                $"[cyan]{book.Location}[/]",
                book.Pages.ToString()
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDataBase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayMessage("Book already exists!", "red");
        }
        else
        {
            var newBook = new Book(MockDataBase.LibraryItems.Count + 1, title, author, category, location ,pages);
            MockDataBase.LibraryItems.Add(newBook);
            DisplayMessage("Book added successfully!", "green");
        }      
        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDataBase.LibraryItems.OfType<Book>().Count() == 0)
        {
            DisplayMessage("No books available to delete.", "red");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
        new SelectionPrompt<Book>().Title("Select a [red]book[/] to delete:").UseConverter(b => $"{b.Name}").AddChoices(MockDataBase.LibraryItems.OfType<Book>()));

        if (ConfirmDeletion(bookToDelete.Name))
        {
            if (MockDataBase.LibraryItems.Remove(bookToDelete))
            {
                DisplayMessage("Book deleted succesfully!", "red");
            }
            else
            {
                DisplayMessage("Book not found.", "red");
            }
        }
        else
        {
            DisplayMessage("Deletion Cancelled", "yellow");
        }         

        DisplayMessage("Press Any Key to Continue.", "green");
        Console.ReadKey();
    }

}