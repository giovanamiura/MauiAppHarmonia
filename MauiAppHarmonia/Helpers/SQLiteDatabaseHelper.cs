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
    }
}