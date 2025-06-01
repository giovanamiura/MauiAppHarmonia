using MauiAppHarmonia.Models;
using System.Globalization;

namespace MauiAppHarmonia.Views
{
    public partial class NovoProfessor : ContentPage
    {
        List<Pessoa> _pessoasDisponiveis;
        List<Curso> _cursosDisponiveis; // Nova lista para cursos

        public NovoProfessor()
        {
            InitializeComponent();
            CarregarPessoas(); 
            CarregarCursos();  
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarPessoas();
            await CarregarCursos();
        }

        private async Task CarregarPessoas() 
        {
            try
            {
                _pessoasDisponiveis = await App.Db.GetAllPessoas();
                pickerPessoa.ItemsSource = _pessoasDisponiveis;
                if (_pessoasDisponiveis != null && _pessoasDisponiveis.Any())
                {
                    pickerPessoa.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"N�o foi poss�vel carregar as pessoas: {ex.Message}", "OK");
            }
        }

        private async Task CarregarCursos() // Novo m�todo para carregar cursos
        {
            try
            {
                _cursosDisponiveis = await App.Db.GetAllCursos();
                pickerCurso.ItemsSource = _cursosDisponiveis;
                if (_cursosDisponiveis != null && _cursosDisponiveis.Any())
                {
                    pickerCurso.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"N�o foi poss�vel carregar os cursos: {ex.Message}", "OK");
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pickerPessoa.SelectedItem == null)
                {
                    await DisplayAlert("Aten��o", "Por favor, selecione uma pessoa.", "OK");
                    return;
                }
                var pessoaSelecionada = (Pessoa)pickerPessoa.SelectedItem;

                if (pickerCurso.SelectedItem == null) // Valida��o para curso obrigat�rio
                {
                    await DisplayAlert("Aten��o", "Por favor, selecione um curso.", "OK");
                    return;
                }
                var cursoSelecionado = (Curso)pickerCurso.SelectedItem;


                // Valida��es e convers�es dos campos
                if (string.IsNullOrWhiteSpace(txt_login.Text))
                {
                    await DisplayAlert("Aten��o", "Por favor, preencha o login.", "OK");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_senha.Text))
                {
                    await DisplayAlert("Aten��o", "Por favor, preencha a senha.", "OK");
                    return;
                }

                decimal salario;
                if (!decimal.TryParse(txt_salario.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out salario))
                {
                    await DisplayAlert("Aten��o", "Sal�rio inv�lido. Use '.' como separador decimal.", "OK");
                    return;
                }

                int numeroAulas;
                if (!int.TryParse(txt_numero_aulas.Text, out numeroAulas))
                {
                    await DisplayAlert("Aten��o", "N�mero de aulas inv�lido.", "OK");
                    return;
                }

                var novoProfessor = new Professor
                {
                    codigoPessoa = pessoaSelecionada.codigoPessoa,
                    Login = txt_login.Text,
                    Senha = txt_senha.Text,
                    Salario = salario,
                    NumeroAulas = numeroAulas,
                    CodigoCurso = cursoSelecionado.codigoCurso // Atribui o c�digo do curso selecionado
                };

                await App.Db.Insert(novoProfessor);

                await DisplayAlert("Sucesso", "Professor cadastrado com sucesso!", "OK");
                await Navigation.PopAsync();
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                await DisplayAlert("Erro de Valida��o", argEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}