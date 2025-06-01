using MauiAppHarmonia.Models;

namespace MauiAppHarmonia.Views;

    public partial class NovoAdministrador : ContentPage
    {
        List<Pessoa> pessoas;

        public NovoAdministrador()
        {
            InitializeComponent();
            CarregarPessoas();
        }

        private async void CarregarPessoas()
        {
        pessoas = await App.Db.GetAllPessoas();
        pickerPessoa.ItemsSource = pessoas;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pickerPessoa.SelectedItem == null)
                {
                    await DisplayAlert("Erro", "Selecione uma pessoa", "OK");
                    return;
                }

                var pessoaSelecionada = (Pessoa)pickerPessoa.SelectedItem;

                var admin = new Administrador
                {
                    codigoPessoa = pessoaSelecionada.codigoPessoa,
                    Matricula = txt_matricula.Text,
                    Login = txt_login.Text,
                    Senha = txt_senha.Text,
                    Salario = double.Parse(txt_salario.Text)
                };

                await App.Db.Insert(admin);

                await DisplayAlert("Sucesso", "Administrador cadastrado com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }