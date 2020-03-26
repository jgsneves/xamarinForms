using System;
using System.ComponentModel;
using Xamarin.Forms;
using xamarinForms.Servico;
using xamarinForms.Servico.Modelo;

namespace xamarinForms
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = Cep.Text.Trim();
            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

            Resultado.Text = string.Format("Endereço: {0}, {1}, {2}/{3}.", end.Logradouro, end.Bairro, end.Localidade, end.Uf);
        }
    }
}
