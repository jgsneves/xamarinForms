using System.Net;
using xamarinForms.Servico.Modelo;
using Newtonsoft.Json;

namespace xamarinForms.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;
        }
    }
}
