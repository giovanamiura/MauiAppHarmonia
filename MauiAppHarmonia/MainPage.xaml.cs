using MauiAppHarmonia.Views;

namespace MauiAppHarmonia;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnPessoaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoPessoa());
    }
    private async void OnAdministradorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoAdministrador());
    }

    private async void OnProfessorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoProfessor());
    }

    private async void OnAlunoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoAluno());
    }
    private async void OnCursoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoCurso());
    }
    private async void OnInstrumentoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoInstrumento());
    }
    private async void OnAulaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovaAula());
    }
}
