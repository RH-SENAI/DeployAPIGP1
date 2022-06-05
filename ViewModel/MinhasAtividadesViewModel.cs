using SenaiRH_G1.Domains;
using System;

namespace SenaiRH_G1.ViewModel
{
    public class MinhasAtividadesViewModel
    {
        public int IdAtividade { get; set; }
        public string NomeAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int RecompensaMoeda { get; set; }
        public int RecompensaTrofeu { get; set; }
        public string DescricaoAtividade { get; set; }
        public bool NecessarioValidar { get; set; }
        public string criador { get; set; }
        public int IdMinhasAtividades { get; set; }
        public byte IdSituacaoAtividade { get; set; }
        public byte IdSetor { get; set; }
        public int IdUsuario { get; set; }
        public string Anotacoes { get; set; }
        public string NomeFuncionario { get; set; }
    }
}
