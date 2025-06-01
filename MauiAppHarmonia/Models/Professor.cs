using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Professor
    {
        string _login;
        string _senha;
        decimal _salario;
        int _numeroAulas;
        int _codigoCurso; 

        [PrimaryKey, AutoIncrement]
        public int codigoProfessor { get; set; }

        public int codigoPessoa { get; set; }

        public int CodigoCurso
        {
            get => _codigoCurso;
            set
            {
                _codigoCurso = value;
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o login.");
                _login = value;
            }
        }

        public string Senha
        {
            get => _senha;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a senha.");
                _senha = value;
            }
        }

        public decimal Salario
        {
            get => _salario;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Salario), "Salário não pode ser negativo.");
                _salario = value;
            }
        }

        public int NumeroAulas
        {
            get => _numeroAulas;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(NumeroAulas), "Número de aulas não pode ser negativo.");
                _numeroAulas = value;
            }
        }
    }
}