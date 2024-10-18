using MauiApp1.Models;
//using AndroidX.ConstraintLayout.Core;
using System.Collections.Generic;
using MauiApp1.Controllers;

namespace MauiApp1.Views;

public partial class PageInit : ContentPage
{
    private List<Autores> listaAutores = new List<Autores>();

    public PageInit()
	{
		InitializeComponent();
	}

    private async void btnagregar_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(nombres.Text) && pais.SelectedItem != null)
        {
            var autor = new Models.Autores
            {
                Nombres = nombres.Text,
                Pais = pais.SelectedItem.ToString()
            };

            if (!listaAutores.Any(a => a.Nombres.Equals(autor.Nombres, StringComparison.OrdinalIgnoreCase) &&
                                 a.Pais.Equals(autor.Pais, StringComparison.OrdinalIgnoreCase)))
            {
                listaAutores.Add(autor);

                // Guarda el autor en BD
                var dbService = new DBServices();
                await dbService.biblioteca(autor);


                await DisplayAlert("Listo", "Autor agregado", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Este autor ya existe", "Ok");
            }
        }
        else
        {
            await DisplayAlert("Error", "Ingrese el nombre y seleccione un pais", "Ok");

        }
    }

    private async void btnautor_Clicked(object sender, EventArgs e)
    {
        var pagina = new Views.PageLista(listaAutores);
       // pagina.BindingContext = listaAutores;
        await Navigation.PushAsync(pagina);
    }
}