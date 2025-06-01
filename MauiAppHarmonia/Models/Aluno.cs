using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Aluno
    {
        string _login;
        string _senha;
        string _matricula;
        int _codigoCurso;
        int? _codigoResponsavel; // Pode ser nulo se não houver responsável direto ou for o próprio

        [PrimaryKey, AutoIncrement]
        public int codigoAluno { get; set; }


        public int codigoPessoa { get; set; }

        [Unique] 
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

        [Unique] 
        public string Matricula
        {
            get => _matricula;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a matrícula.");
                _matricula = value;
            }
        }


        public int CodigoCurso
        {
            get => _codigoCurso;
            set => _codigoCurso = value;
        }

        public int? codigoResponsavel
        {
            get => _codigoResponsavel;
            set => _codigoResponsavel = value;
        }
    }
}