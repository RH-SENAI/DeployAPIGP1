using Microsoft.AspNetCore.Http;
using SenaiRH_G1.Domains;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    public interface IAtividadeRepository
    {
        void CadastrarAtividade(Atividade atividade);
        void RemoverAtividade(Atividade atividade);
        MinhasAtividadesViewModel BuscarPorId(int id);
        Atividade BuscarUltima();
        List<Atividade> ListarTodas();
        List<Atividade> ListarObrigatorias();
        List<Atividade> ListarExtras();
        List<MinhasAtividadesViewModel> ListarMinhas(int id);
        List<MinhasAtividadesViewModel> ListarMinhasFinalizadas(int id);
        List<MinhasAtividadesViewModel> ListarMinhasExtras(int id);
        List<MinhasAtividadesViewModel> ListaValidar();

        void AssociarAtividade(int idUsuario, int idAtividade);
        void FinalizarAtividade(int idUsuario, int idAtividade, IFormFile arquivo);
        void ValidarAtividade(int idAtividade, int idUsuario);
        void RecusarAtividade(int idMinhasAtividades);
    }
}
