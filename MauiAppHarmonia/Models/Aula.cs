using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Aula
    {
        [PrimaryKey, AutoIncrement]
        public int IdAula { get; set; }

        public int CodigoProfessor { get; set; } // FK para Professor

        public int CodigoCurso { get; set; }     // FK para Curso


        public DateTime DataAula { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public string Observacoes { get; set; } // Pode ser nulo

        [Ignore]
        public string NomeProfessorParaDisplay { get; set; }

        [Ignore]
        public string NomeCursoParaDisplay { get; set; } // Para exibição, se necessário

        public bool IsHorarioValido() => HoraFim > HoraInicio;
    }
}