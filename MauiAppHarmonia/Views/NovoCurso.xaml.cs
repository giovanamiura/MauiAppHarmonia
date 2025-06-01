using MauiAppHarmonia.Models;
// using MauiAppHarmonia.Helpers; 
using System.Collections.Generic; // Para List
using System.Linq; // Para .Any()

namespace MauiAppHarmonia.Views
{
    public partial class NovoCurso : ContentPage
    {
        List<Instrumento> _instrumentosDisponiveis;

        public NovoCurso()
        {
            InitializeComponent();
            // CarregarInstrumentos(); // Chamado em OnAppearing
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarInstrumentos();
        }

        private async Task CarregarInstrumentos()
        {
            try
            {
                _instrumentosDisponiveis = await App.Db.GetAllInstrumentos();
                pickerInstrumentoPrincipal.ItemsSource = _instrumentosDisponiveis;
                if (_instrumentosDisponiveis != null && _instrumentosDisponiveis.Any())
                {
                    pickerInstrumentoPrincipal.SelectedIndex = 0; 
                }
                else
                {
                     await DisplayAlert("Aviso", "Nenhum instrumento cadastrado. Cadastre instrumentos primeiro.", "OK");
                    pickerInstrumentoPrincipal.IsEnabled = false; 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Não foi possível carregar os instrumentos: {ex.Message}", "OK");
            }
        }

        private async void ToolbarItem_Clicked_SalvarCurso(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeCurso.Text))
                {
                    await DisplayAlert("Atenção", "O nome do curso é obrigatório.", "OK");
                    return;
                }

                if (pickerInstrumentoPrincipal.SelectedItem == null)
                {
                    await DisplayAlert("Atenção", "Por favor, selecione o instrumento principal do curso.", "OK");
                    return;
                }
                var instrumentoSelecionado = (Instrumento)pickerInstrumentoPrincipal.SelectedItem;

                Curso novoCurso = new Curso
                {
                    NomeCurso = txtNomeCurso.Text,
                    codigoInstrumentoPrincipal = instrumentoSelecionado.codigoInstrumento // Salva o ID do instrumento
                };

                int result = await App.Db.Insert(novoCurso);

                if (result > 0)
                {
                    await DisplayAlert("Sucesso", "Curso cadastrado com sucesso!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível cadastrar o curso.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}