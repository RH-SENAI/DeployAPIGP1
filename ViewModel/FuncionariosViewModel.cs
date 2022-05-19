using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.ViewModel
{
    public class FuncionariosViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int SaldoMoeda { get; set; }
        public int Trofeus { get; set; }
        public string CaminhoFotoPerfil { get; set; }
    }
}
