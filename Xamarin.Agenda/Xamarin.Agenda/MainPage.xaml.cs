using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Agenda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            using (var dados = new AcessoDados())
            {
                this.Lista.ItemsSource = dados.Listar();
            }


            this.Salvar.Clicked += delegate(object sender, EventArgs args)
            {
                var contato = new Contato()
                {Email = Email.Text, Telefone = Telefone.Text, Nome = Nome.Text};


                using (var dados = new AcessoDados())
                {
                    dados.Insert(contato);
                    this.Lista.ItemsSource = dados.Listar();
                }
            };
        }
    }
}
