using MauiApp1.Models;
namespace MauiApp1.Views;

public partial class PageLista : ContentPage
{
    private List<Autores> autoresOriginal = new List<Autores>();
    public PageLista(List<Autores> listaAutores)
	{
        InitializeComponent();

        if (listaAutores != null)
        {
            autoresOriginal = listaAutores; 
        }
        listViewAutores.ItemsSource = autoresOriginal;
    }
    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            listViewAutores.ItemsSource = autoresOriginal;
        }
        else
        {
            // Busqueda
            listViewAutores.ItemsSource = autoresOriginal
                .Where(a => a.Nombres.IndexOf(e.NewTextValue, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
