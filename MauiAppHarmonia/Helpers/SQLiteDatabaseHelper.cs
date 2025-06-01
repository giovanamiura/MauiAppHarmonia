using MauiAppHarmonia.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppHarmonia.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Administrador>().Wait();
            _conn.CreateTableAsync<Pessoa>().Wait();
            _conn.CreateTableAsync<Professor>().Wait();
            _conn.CreateTableAsync<Aluno>().Wait();
            _conn.CreateTableAsync<Curso>().Wait();
            _conn.CreateTableAsync<Instrumento>().Wait();
            _conn.CreateTableAsync<Aula>().Wait();

        }

        public Task<int> Insert(Administrador a)
        {
            return _conn.InsertAsync(a);
        }

        public Task<List<Administrador>> Update(Administrador a)
        {
            string sql = "UPDATE Administrador SET Nome=?, Matricula=?, Salario=?, Login=?, Senha=? WHERE codigoAdmin=?";

            return _conn.QueryAsync<Administrador>(
                sql, a.Nome, a.Matricula, a.Salario, a.Login, a.Senha, a.codigoAdmin);
        }

        public Task<int> Delete(int codigoAdmin) 
        {
            return _conn.Table <Administrador>().DeleteAsync(i => i.codigoAdmin == codigoAdmin);   //i = intens da tabela
        }

        public Task<List<Administrador>> GetAll()
        {
           return _conn.Table<Administrador>().ToListAsync(); //retorna como lista
        }

        public Task<List<Administrador>> Search(string q)  //realiza busca
        {
            string sql = "SELECT * FROM Administrador WHERE Nome LIKE '%" + q + "%'";

            return _conn.QueryAsync<Administrador>(
                sql);
        }

        public Task<int> Insert(Pessoa p)
        {
            return _conn.InsertAsync(p);
        }


        public Task<List<Pessoa>> GetAllPessoas()
        {
            return _conn.Table<Pessoa>().ToListAsync();
        }

        public Task<int> Insert(Professor p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> Insert(Aluno p)
        {
            return _conn.InsertAsync(p);
        }
        public Task<int> Insert(Curso c)
        {
            return _conn.InsertAsync(c);
        }

        public Task<List<Curso>> GetAllCursos()
        {
            return _conn.Table<Curso>().ToListAsync();
        }

        public Task<Curso> GetCursoById(int id)
        {
            return _conn.Table<Curso>().FirstOrDefaultAsync(c => c.codigoCurso == id);
        }
        public Task<int> Insert(Instrumento i)
        {
            return _conn.InsertAsync(i);
        }

        public Task<List<Instrumento>> GetAllInstrumentos()
        {
            return _conn.Table<Instrumento>().ToListAsync();
        }

        public Task<Instrumento> GetInstrumentoById(int id)
        {
            return _conn.Table<Instrumento>().FirstOrDefaultAsync(i => i.codigoInstrumento == id);
        }

        public Task<int> Update(Instrumento i)
        {
            return _conn.UpdateAsync(i);
        }

        public Task<int> DeleteInstrumento(int id)
        {
            return _conn.Table<Instrumento>().DeleteAsync(i => i.codigoInstrumento == id);
        }
        public Task<int> Insert(Aula a)
        {
            return _conn.InsertAsync(a);
        }

        public Task<List<Aula>> GetAllAulas()
        {
            return _conn.Table<Aula>().ToListAsync();
        }

        public Task<Aula> GetAulaById(int id)
        {
            return _conn.Table<Aula>().FirstOrDefaultAsync(a => a.IdAula == id);
        }

        public Task<int> Update(Aula a)
        {
            return _conn.UpdateAsync(a);
        }

        public Task<int> DeleteAula(int id)
        {
            return _conn.Table<Aula>().DeleteAsync(a => a.IdAula == id);
        }
        public Task<Pessoa> GetPessoaById(int codigoPessoa)
        {
            return _conn.Table<Pessoa>().FirstOrDefaultAsync(p => p.codigoPessoa == codigoPessoa);
        }
        public Task<List<Professor>> GetAllProfessores()
        {
            return _conn.Table<Professor>().ToListAsync();
        }
    }
}