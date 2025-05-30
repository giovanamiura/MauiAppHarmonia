using SQLite;


namespace MauiAppHarmonia.Models
{
    public class Administrador
    {
        string _nome;
        string _matricula;
        string _login;
        string _senha;
        double _salario;

        [PrimaryKey]

        public int codigoAdmin { get; set; }
        public string Nome
        {
            get => _nome;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o nome");
                }
                _nome = value;
            }
        }

        public int codigoPessoa { get; set; }
        public string Matricula 
            
        {
            get => _matricula;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a matrícula");
                }
                _matricula = value;
            }
        }
    
        public string Login 
        {
            get => _login;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o login");
                }
                _login = value;
            }
        }

    

        public double Salario 
        {
            get => _salario;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o salário");
                }
                _salario = value;
            }
        }

        public string Senha
        {
            get => _senha;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a senha");
                }
                _senha = value;
            }
        }


    }
}
