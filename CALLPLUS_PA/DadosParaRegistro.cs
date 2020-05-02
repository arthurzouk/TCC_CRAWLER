using CALLPLUS_PA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALLPLUS_PA
{
    public class DadosParaRegistro
    {
        public int status;
        public string etapaDoProcesso;
        public string descricao;
        public string protocolo;
        public string autorizacao;
        public bool downgrade;
        public string cpfMarcado;
        public string rgMarcado;
        public string codigoBanco;
        public string bancoMarcado;
        public string agenciaMarcada;
        public string contaMarcada;
        public string faturaDigitalMarcada;
        public string planoMarcado;
        public string promocaoMarcada;
        public string vencimentoMarcado;
        public string nascimentoMarcado;
        public string nomeMaeMarcado;
        public string emailMarcado;
        public string smsNovidadeMarcado;
        public string cepMarcado;
        public string logradouro;
        public string logradouroMarcado;
        public string numeroMarcado;
        public string complementoMarcado;
        public string bairroMarcado;
        public string cidadeMarcada;
        public string telefoneContatoMarcado;
        public string enderecoCompletoMarcado;
        public string enderecoCompleto;
        public string bancoInformado;
        public string dadosBancarios;
        public string dadosBancariosMarcados;
        public string tipoPagamento;
        public string tipoLogradouro;
        public string COMTA;
        public string COMTAAcessado;
        public string tipoLogradouroMarcado;
        public string ServidorClaro;
        public string VersaoRobo;

        public DadosParaRegistro()
        {
            this.status = 1;
            this.etapaDoProcesso = "Limpando dados do registro para iniciar processo";
            this.descricao = "nenhum diagnostico atribuído a este erro.";
            this.protocolo = "Não foi gerado";
            this.autorizacao = "Não foi gerado";
            this.downgrade = false;
            this.cpfMarcado = "Não foi marcado";
            this.rgMarcado = "Não foi marcado";
            this.codigoBanco = "Não foi marcado";
            this.bancoMarcado = "Não foi marcado";
            this.agenciaMarcada = "Não foi marcada";
            this.contaMarcada = "Não foi marcada";
            this.faturaDigitalMarcada = "Não foi marcada";
            this.planoMarcado = "Não foi marcado";
            this.promocaoMarcada = "Não foi marcada";
            this.vencimentoMarcado = "Não foi marcado";
            this.nascimentoMarcado = "Não foi marcado";
            this.nomeMaeMarcado = "Não foi marcado";
            this.emailMarcado = "Não foi marcado";
            this.smsNovidadeMarcado = "Não foi marcado";
            this.cepMarcado = "Não foi marcado";
            this.logradouro = string.Empty;
            this.logradouroMarcado = "Não foi marcado";
            this.numeroMarcado = "Não foi marcado";
            this.complementoMarcado = "Não foi marcado";
            this.bairroMarcado = "Não foi marcado";
            this.cidadeMarcada = "Não foi marcado";
            this.telefoneContatoMarcado = "Não foi marcado";
            this.enderecoCompleto = string.Empty;
            this.enderecoCompletoMarcado = "Não foi Marcado";
            this.bancoInformado = string.Empty;
            this.dadosBancarios = string.Empty;
            this.dadosBancariosMarcados = "Não foram marcados";
            this.tipoPagamento = string.Empty;
            this.tipoLogradouro = string.Empty;
            this.COMTA = string.Empty;
            this.COMTAAcessado = string.Empty;
            this.tipoLogradouroMarcado = string.Empty;
            this.ServidorClaro = string.Empty;
            this.VersaoRobo = string.Empty;
        }

        public void DefinirDiagnostico(int status, string descricao, BuscarVendaParaRegistro_Result venda)
        {
            this.COMTA = venda.COMTA;
            this.COMTAAcessado = venda.COMTA;

            this.VersaoRobo = Program.version.ToString(); 

            this.status = status;
            this.descricao = downgrade ? (descricao != string.Empty ? "Downgrade | " + descricao : this.descricao) : (descricao != string.Empty ? descricao : this.descricao);

            if (logradouroMarcado != "Não foi marcado" || bairroMarcado != "Não foi marcado" || cidadeMarcada != "Não foi marcado")
            {
                enderecoCompleto = "Lg: " + venda.logradouro + " | N: " + venda.numero + " | Compl: " + venda.complemento + " | Bairro: " + venda.bairro + " | Cidade: " + venda.cidade;
                enderecoCompletoMarcado = "Lg: " + logradouroMarcado + " | N: " + numeroMarcado + " | Compl: " + complementoMarcado + " | Bairro: " + bairroMarcado + " | Cidade: " + cidadeMarcada;                
            }

            if (string.IsNullOrEmpty(venda.banco))
            {
                this.tipoPagamento = "Boleto";
            }
            else
            {
                bancoInformado = venda.banco;
                this.tipoPagamento = "Debito";
                dadosBancarios = bancoInformado + " | Ag: " + venda.agencia + " | CC: " + venda.conta;
                dadosBancariosMarcados = bancoMarcado + " | Ag: " + agenciaMarcada + " | CC: " + contaMarcada;
            }
        }
    }
}
