
using MauiAppHarmonia.Models;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace MauiAppHarmonia.Views;

public partial class ListaAdministrador : ContentPage
{
	ObservableCollection<Administrador> lista = new ObservableCollection<Administrador>();

	public ListaAdministrador()
	{
		InitializeComponent();

		lst_administradores.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
		try
		{
			lista.Clear();  //limpa a obsrvable collection e recarrega a lista

			List<Administrador> tmp = await App.Db.GetAll();
			tmp.ForEach(i => lista.Add(i));

		}
		catch (Exception ex)
		{
		await	DisplayAlert("Ops", ex.Message, "OK");
		}
    }


    private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Navigation.PushAsync(new Views.NovoAdministrador());   //faz ir para outra página

		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
	}

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)  // text changed faz que as informações da lista apareça enquantousuário digita na search bar
    {
		try
		{
			string q = e.NewTextValue;

			lista.Clear();    //apaga itens da lista para fazer a busca

			List<Administrador> tmp = await App.Db.Search(q);

			tmp.ForEach(i => lista.Add(i));
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}

    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			MenuItem selecionado = sender as MenuItem;
			Administrador a = selecionado.BindingContext as Administrador;

			bool confirm = await DisplayAlert("Você tem certeza?", $"Remover {a.Nome}?", "Sim", "Não");

			if (confirm)
			{
				await  App.Db.Delete(a.codigoAdmin);
				lista.Remove(a);
			}
		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}

    }

    private void lst_administradores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		try
		{
			Administrador a = e.SelectedItem as Administrador;

			Navigation.PushAsync(new Views.EditarAdministrador
			{
				BindingContext = a,
			});
		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}