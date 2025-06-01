using MauiAppHarmonia.Models;

namespace MauiAppHarmonia.Views
{
    public partial class NovoPessoa : ContentPage
    {
        public NovoPessoa()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var novaPessoa = new Pessoa
                {
                    Nome = txt_nome.Text,
                    DataNascimento = dp_dataNascimento.Date,
                    Rua = txt_rua.Text,
                    Numero = txt_numero.Text,
                    Bairro = txt_bairro.Text,
                    Cep = txt_cep.Text,
                    Cidade = txt_cidade.Text,
                    Estado = txt_estado.Text,
                    Rg = txt_rg.Text,
                    CelularNumero = txt_celularNumero.Text,
                    Cpf = txt_cpf.Text
                };

                await App.Db.Insert(novaPessoa);

                await DisplayAlert("Sucesso", "Pessoa cadastrada com sucesso!", "OK");
                await Navigation.PopAsync(); // volta à tela anterior
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
