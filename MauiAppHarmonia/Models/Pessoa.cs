using SQLite;
using System;

namespace MauiAppHarmonia.Models
{
    public class Pessoa
    {
        string _nome;
        DateTime? _dataNascimento;
        string _rua;
        string _numero;
        string _bairro;
        string _cep;
        string _cidade;
        string _estado;
        string _rg;
        string _celularNumero;
        string _cpf;

        [PrimaryKey, AutoIncrement]
        public int codigoPessoa { get; set; }

        public string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o nome");
                _nome = value;
            }
        }

        public DateTime? DataNascimento
        {
            get => _dataNascimento;
            set
            {
                if (value == null)
                    throw new Exception("Por favor, preencha a data de nascimento");
                _dataNascimento = value;
            }
        }

        public string Rua
        {
            get => _rua;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a rua");
                _rua = value;
            }
        }

        public string Numero
        {
            get => _numero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o número");
                _numero = value;
            }
        }

        public string Bairro
        {
            get => _bairro;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o bairro");
                _bairro = value;
            }
        }

        public string Cep
        {
            get => _cep;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o CEP");
                _cep = value;
            }
        }

        public string Cidade
        {
            get => _cidade;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha a cidade");
                _cidade = value;
            }
        }

        public string Estado
        {
            get => _estado;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o estado");
                _estado = value;
            }
        }

        public string Rg
        {
            get => _rg;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o RG");
                _rg = value;
            }
        }

        public string CelularNumero
        {
            get => _celularNumero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o número de celular");
                _celularNumero = value;
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Por favor, preencha o CPF");
                _cpf = value;
            }
        }
    }
}
