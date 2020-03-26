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
            if (isValidCEP(cep)) 
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {0}, {1}, {2}/{3}.", end.Logradouro, end.Bairro, end.Localidade, end.Uf);
                    } else
                    {
                        DisplayAlert("ERRO", string.Format("O CEP {0} não foi encontrado.", cep), "OK");
                    }
                    
                } catch (Exception e)
                {
                    DisplayAlert("ERRO DE SERVIÇO", e.Message, "OK");
                }
               
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro!", "CEP Inválido: o CEP deve conter oito caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro!", "CEP Inválido: o cep contém apenas números, sem hífem", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
