using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Instrumento
    {
        string _nome;

        [PrimaryKey, AutoIncrement]
        public int codigoInstrumento { get; set; }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("O nome do instrumento é obrigatório.");
                _nome = value;
            }
        }

        public DateTime? DataAquisicao { get; set; }

        public DateTime? UltimaManutencao { get; set; }

        public int Quantidade
        {
            get; set;

        }

    }
}