﻿using SenaiRH_G1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string cpf, string senha);
        Usuario BuscarUsuario(int id);
        List<Usuario> ListarFuncionarios();
        void AlterarSenha(int idUsuario, string senhaNova, string senhaAtual, string senhaConfirmacao);
        void AlterarSenhaRec(string email, string senhaNova, string senhaConfirmacao);
        bool VerificaSenha(string senha, int idUsuario);
        void EnviaEmailRecSenha(string email);
        bool VerificaRecSenha(int codigo);
    }
}
