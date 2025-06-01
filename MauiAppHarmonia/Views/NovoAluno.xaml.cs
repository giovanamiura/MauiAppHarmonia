using MauiAppHarmonia.Models;
using System.Globalization;
using System.Linq;

namespace MauiAppHarmonia.Views
{
    public partial class NovoAluno : ContentPage
    {
        List<Pessoa> _pessoasDisponiveis;
        List<Curso> _cursosDisponiveis; // Nova lista para cursos

        public NovoAluno()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarDadosIniciais();
        }

        private async Task CarregarDadosIniciais()
        {
            try
            {
                _pessoasDisponiveis = await App.Db.GetAllPessoas();
                pickerPessoaAluno.ItemsSource = _pessoasDisponiveis;
                pickerPessoaResponsavel.ItemsSource = _pessoasDisponiveis;

                _cursosDisponiveis = await App.Db.GetAllCursos(); // Carrega cursos
                pickerCurso.ItemsSource = _cursosDisponiveis;   

                if (_pessoasDisponiveis != null && _pessoasDisponiveis.Any())
                {
                    pickerPessoaAluno.SelectedIndex = 0; 
                }
                if (_cursosDisponiveis != null && _cursosDisponiveis.Any())
                {
                    pickerCurso.SelectedIndex = 0; 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"N�o foi poss�vel carregar dados iniciais: {ex.Message}", "OK");
            }
        }

        private void LimparResponsavel_Clicked(object sender, EventArgs e)
        {
            pickerPessoaResponsavel.SelectedItem = null;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pickerPessoaAluno.SelectedItem == null)
                {
                    await DisplayAlert("Aten��o", "Por favor, selecione os dados pessoais do aluno.", "OK");
                    return;
                }
                var pessoaAlunoSelecionada = (Pessoa)pickerPessoaAluno.SelectedItem;

                Pessoa pessoaResponsavelSelecionada = pickerPessoaResponsavel.SelectedItem as Pessoa;

                if (pickerCurso.SelectedItem == null) // Valida��o para curso obrigat�rio
                {
                    await DisplayAlert("Aten��o", "Por favor, selecione um curso.", "OK");
                    return;
                }
                var cursoSelecionado = (Curso)pickerCurso.SelectedItem;


                // Valida��es e convers�es dos campos
                if (string.IsNullOrWhiteSpace(txt_matricula.Text))
                {
                    await DisplayAlert("Aten��o", "Por favor, preencha a matr�cula.", "OK");
                    return;
                }
                // ... (outras valida��es existentes para login, senha)
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


                var novoAluno = new Aluno
                {
                    codigoPessoa = pessoaAlunoSelecionada.codigoPessoa,
                    Matricula = txt_matricula.Text,
                    Login = txt_login.Text,
                    Senha = txt_senha.Text,
                    CodigoCurso = cursoSelecionado.codigoCurso, // Atribui o c�digo do curso selecionado
                    codigoResponsavel = pessoaResponsavelSelecionada?.codigoPessoa
                };

                await App.Db.Insert(novoAluno);

                await DisplayAlert("Sucesso", "Aluno cadastrado com sucesso!", "OK");
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