using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;

namespace Xamarin.Agenda
{
    public class AcessoDados:IDisposable
    {
        private SQLite.Net.SQLiteConnection _connection;

        public AcessoDados()
        {
            var config = DependencyService.Get<IConfig>();

            _connection = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados.db3"));


            _connection.CreateTable<Contato>();

        }


        public void Insert(Contato contato)
        {
            _connection.Insert(contato);
        }

        public void Delete(Contato contato)
        {
            _connection.Insert(contato);
        }

        public void Update(Contato contato)
        {
            _connection.Insert(contato);
        }

        public Contato ObterPorID(int id)
        {
            return _connection.Table<Contato>().FirstOrDefault(c => c.Id == id);
        }

        public List<Contato> Listar()
        {
            return _connection.Table<Contato>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

    }
}
