using MauiAppHarmonia.Models;

namespace MauiAppHarmonia.Views
{
    public partial class NovoInstrumento : ContentPage
    {
        public NovoInstrumento()
        {
            InitializeComponent();

        }

        private async void ToolbarItem_Clicked_SalvarInstrumento(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeInstrumento.Text))
                {
                    await DisplayAlert("Atenção", "O nome do instrumento é obrigatório.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text) || !int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
                {
                    await DisplayAlert("Atenção", "A quantidade deve ser um número inteiro não negativo.", "OK");
                    return;
                }

                Instrumento novoInstrumento = new Instrumento
                {
                    Nome = txtNomeInstrumento.Text,
                    Quantidade = quantidade
                };

                int result = await App.Db.Insert(novoInstrumento);

                if (result > 0)
                {
                    await DisplayAlert("Sucesso", "Instrumento cadastrado com sucesso!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível cadastrar o instrumento.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}