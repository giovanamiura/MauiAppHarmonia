using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Curso
    {
        string _nomeCurso;

        [PrimaryKey, AutoIncrement]
        public int codigoCurso { get; set; }

        public string NomeCurso
        {
            get => _nomeCurso;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o nome do curso.");
                _nomeCurso = value;
            }
        }
        public int codigoInstrumentoPrincipal { get; set; }

    }
}