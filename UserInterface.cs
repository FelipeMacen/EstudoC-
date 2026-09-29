using Spectre.Console;
using TCSA.OOP.LibraryManagement.Controllers;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using static TCSA.OOP.LibraryManagementSystem.Enums;

namespace TCSA.OOP.LibraryManagementSystem;

internal class Userinterface
{
    private readonly BookController _booksController = new();
    private readonly MagazineController _magazinesController = new();
    private readonly NewspaperController _newspapersController = new();

    internal void MainMenu()
    {
        while (true)
        {  
            AnsiConsole.Clear();

            var actionchoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>().Title("What do you want next?").AddChoices(Enum.GetValues<MenuAction>()));

            var itemchoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>().Title("What do you want next?").AddChoices(Enum.GetValues<ItemType>()));
            
            switch (actionchoice)
                {
                    case MenuAction.ViewItems:
                        ViewItems(itemchoice);
                        break;

                    case MenuAction.AddItem:  
                        AddItem(itemchoice);
                        break;

                    case MenuAction.DeleteItem:
                        DeleteItem(itemchoice);
                        break;
                }
        }
    }

    private void ViewItems(ItemType itemchoice)
    {
        switch (itemchoice){
            case ItemType.Book:
                _booksController.ViewItems();
                break;

            case ItemType.Magazine:
                _magazinesController.ViewItems();
                break;

            case ItemType.Newspaper:
                _newspapersController.ViewItems();
                break;
        }
    }
    private void AddItem(ItemType itemchoice)
    {
        switch (itemchoice){
            case ItemType.Book:
                _booksController.AddItem();
                break;

            case ItemType.Magazine:
                _magazinesController.AddItem();
                break;

            case ItemType.Newspaper:
                _newspapersController.AddItem();
                break;
        }
    }

    private void DeleteItem(ItemType itemchoice)
    {
        switch (itemchoice){
            case ItemType.Book:
                _booksController.DeleteItem();
                break;

            case ItemType.Magazine:
                _magazinesController.DeleteItem();
                break;

            case ItemType.Newspaper:
                _newspapersController.DeleteItem();
                break;
        }
    }
}