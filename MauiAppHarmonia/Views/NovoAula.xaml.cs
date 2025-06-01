using MauiAppHarmonia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MauiAppHarmonia.Views
{

    public class ProfessorDisplayNovaAula 
    {
        public int CodigoProfessor { get; set; }
        public string NomeProfessorParaDisplay { get; set; }
    }


    public partial class NovaAula : ContentPage
    {
        List<ProfessorDisplayNovaAula> _professoresDisplayDisponiveis;
        List<Curso> _cursosDisponiveis; // Lista para os cursos

        public NovaAula()
        {
            InitializeComponent();
            datePickerDataAula.Date = DateTime.Today;
            timePickerHoraInicio.Time = new TimeSpan(8, 0, 0);
            timePickerHoraFim.Time = new TimeSpan(9, 0, 0);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarProfessoresParaPicker();
            await CarregarCursosParaPicker(); 

        }

        private async Task CarregarProfessoresParaPicker()
        {
            try
            {
                var professoresDoBanco = await App.Db.GetAllProfessores();
                _professoresDisplayDisponiveis = new List<ProfessorDisplayNovaAula>();

                foreach (var prof in professoresDoBanco)
                {
                    var pessoa = await App.Db.GetPessoaById(prof.codigoPessoa);
                    _professoresDisplayDisponiveis.Add(new ProfessorDisplayNovaAula
                    {
                        CodigoProfessor = prof.codigoProfessor,
                        NomeProfessorParaDisplay = pessoa != null ? $"{pessoa.Nome} ({prof.Login})" : $"Login: {prof.Login}"
                    });
                }

                pickerProfessor.ItemsSource = _professoresDisplayDisponiveis;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Não foi possível carregar os professores: {ex.Message}", "OK");
            }
        }


        private async Task CarregarCursosParaPicker() // NOVO MÉTODO
        {
            try
            {
                _cursosDisponiveis = await App.Db.GetAllCursos();
                pickerCurso.ItemsSource = _cursosDisponiveis;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Não foi possível carregar os cursos: {ex.Message}", "OK");
            }
        }

        private async void ToolbarItem_Clicked_SalvarAula(object sender, EventArgs e)
        {
            try
            {
                if (pickerProfessor.SelectedItem == null)
                {
                    await DisplayAlert("Atenção", "Selecione um professor.", "OK");
                    return;
                }
                var professorSelecionadoDisplay = (ProfessorDisplayNovaAula)pickerProfessor.SelectedItem;


                if (pickerCurso.SelectedItem == null) // Validação para curso obrigatório
                {
                    await DisplayAlert("Atenção", "Selecione um curso.", "OK");
                    return;
                }
                var cursoSelecionado = (Curso)pickerCurso.SelectedItem;

                DateTime dataAula = datePickerDataAula.Date;
                TimeSpan horaInicio = timePickerHoraInicio.Time;
                TimeSpan horaFim = timePickerHoraFim.Time;

                if (horaFim <= horaInicio)
                {
                    await DisplayAlert("Atenção", "A hora de fim deve ser posterior à hora de início.", "OK");
                    return;
                }

                Aula novaAula = new Aula
                {
                    CodigoProfessor = professorSelecionadoDisplay.CodigoProfessor,
                    CodigoCurso = cursoSelecionado.codigoCurso, // Salva o código do curso
                    DataAula = dataAula,
                    HoraInicio = horaInicio,
                    HoraFim = horaFim,
                    Observacoes = editorObservacoes.Text
                };

                int result = await App.Db.Insert(novaAula);

                if (result > 0)
                {
                    await DisplayAlert("Sucesso", "Aula cadastrada com sucesso!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível cadastrar a aula.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}