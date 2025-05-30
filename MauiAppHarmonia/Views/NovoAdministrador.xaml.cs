using MauiAppHarmonia.Models;

namespace MauiAppHarmonia.Views;

public partial class NovoAdministrador : ContentPage
{
	public NovoAdministrador()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Administrador a = new Administrador
			{
				codigoAdmin = Convert.ToInt32(txt_codigo.Text),
				Nome = txt_nome.Text,
				Matricula = txt_matricula.Text,
				Salario = Convert.ToDouble(txt_salario.Text),
				Login = txt_login.Text,
				Senha = txt_senha.Text

			};

			await App.Db.Insert(a);
			await DisplayAlert("Sucesso!", "Registro inserido", "OK");




		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}