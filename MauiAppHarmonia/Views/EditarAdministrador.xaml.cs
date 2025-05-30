using MauiAppHarmonia.Models;

namespace MauiAppHarmonia.Views;

public partial class EditarAdministrador : ContentPage
{
	public EditarAdministrador()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Administrador administrador_anexado = BindingContext as Administrador;

            Administrador a = new Administrador
            {

                codigoAdmin = Convert.ToInt32(txt_codigoAdmin.Text),
                Nome = txt_nome.Text,
                Matricula = txt_matricula.Text,
                Salario = Convert.ToDouble(txt_salario.Text),
                Login = txt_login.Text,
                Senha = txt_senha.Text

            };

            await App.Db.Update(a);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();  //volta tela




        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    }
}