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
                    await DisplayAlert("Aten��o", "O nome do instrumento � obrigat�rio.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text) || !int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
                {
                    await DisplayAlert("Aten��o", "A quantidade deve ser um n�mero inteiro n�o negativo.", "OK");
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
                    await DisplayAlert("Erro", "N�o foi poss�vel cadastrar o instrumento.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}