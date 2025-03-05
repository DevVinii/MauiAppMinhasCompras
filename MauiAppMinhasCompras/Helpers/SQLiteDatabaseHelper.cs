using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        
        public SQLiteDatabaseHelper(string path) {

            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();

        }

        public Task <int> Insert(Produto p) {

            return _conn.InsertAllAsync(p);
           
        }

        public Task<List<Produto>> Update(Produto p) {


            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=?, WHERE Id=?;";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }

        public Task<int> Delete(int id) {

            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        
        }

        public Task<List<Produto>> GetAll() {

            _conn.Table<Produto>().ToListAsync();
        
        }

        public Task<List<Produto>> Search(String q) {

            string sql = "SELECT * WHERE  descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);

        }

    }
}
