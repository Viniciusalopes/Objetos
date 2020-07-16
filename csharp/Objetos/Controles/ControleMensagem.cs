/// <licenca>
///     Licença MIT
///     Copyright(c) 2020 Viniciusalopes Tecnologia
///     
///     A permissão é concedida, gratuitamente, a qualquer pessoa que obtenha uma cópia deste software e dos 
///     arquivos de documentação associados (o "Software"), para negociar no Software sem restrições, 
///     incluindo, sem limitação, os direitos de uso, cópia, modificação, fusão, publicar, distribuir, 
///     sublicenciar e/ou vender cópias do Software e permitir que as pessoas a quem o Software é fornecido 
///     o façam, sob as seguintes condições:
///     
///     O aviso de direitos autorais acima e este aviso de permissão devem ser incluídos em todas as cópias 
///     ou partes substanciais do Software.
///     
///     O SOFTWARE É FORNECIDO "TAL COMO ESTÁ", SEM GARANTIA DE QUALQUER TIPO, EXPRESSA OU IMPLÍCITA, 
///     INCLUINDO MAS NÃO SE LIMITANDO A GARANTIAS DE COMERCIALIZAÇÃO, ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA 
///     E NÃO INFRAÇÃO. EM NENHUM CASO OS AUTORES OU TITULARES DE DIREITOS AUTORAIS SERÃO RESPONSÁVEIS POR 
///     QUALQUER REIVINDICAÇÃO, DANOS OU OUTRA RESPONSABILIDADE, SEJA EM AÇÃO DE CONTRATO, TORT OU OUTRA 
///     FORMA, PROVENIENTE, FORA OU EM CONEXÃO COM O SOFTWARE OU O USO, OU OUTROS ACORDOS NOS PROGRAMAS.
/// </licenca>
/// <summary>
///     Controller para Mensagem.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Constantes.ConstantesGerais;
using Objetos.Modelos;
using Objetos.Persistencia.Memoria;
using System;

namespace Objetos.Controles
{
    public static class ControleMensagem
    {
        #region ATRIBUTOS
        
        private static char traco = SeparadorTraco;
        private static char enter = SeparadorEnter;
        private static Mensagem mensagemRetorno = new Mensagem(0, "sys" + SeparadorTraco + "000", "", "");

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        #endregion CONSTRUTORES

        #region CREATE
        #endregion CREATE

        #region READ
        public static Mensagem Buscar(long idMensagem)
        {
            foreach (Mensagem mensagem in TabelaMensagens.Mensagens)
                if (mensagem.IdMensagem == idMensagem)
                    return mensagem;

            return null;
        }

        public static Mensagem Buscar(string codigoMensagem)
        {
            if (codigoMensagem.Contains(traco + ""))
            {
                string[] partes = codigoMensagem.Split(enter);
                mensagemRetorno.SiglaMensagem = partes[0].Split(traco)[0];
                mensagemRetorno.NumeroMensagem = partes[0].Split(traco)[1];

                if (partes.Length > 1)
                    for (int i = 1; i < partes.Length; i++)
                        mensagemRetorno.ComplementoMensagem += partes[i] + Environment.NewLine;
                else
                    mensagemRetorno.ComplementoMensagem = "";

                foreach (Mensagem mensagem in TabelaMensagens.Mensagens)
                    if (mensagem.CodigoMensagem == (mensagemRetorno.SiglaMensagem + traco + mensagemRetorno.NumeroMensagem))
                    {
                        mensagemRetorno.IdMensagem = mensagem.IdMensagem;
                        mensagemRetorno.CodigoMensagem = mensagem.CodigoMensagem;
                        mensagemRetorno.TextoMensagem = mensagem.TextoMensagem;
                        break;
                    }
            }
            else
            {
                mensagemRetorno.SiglaMensagem = "sys";
                mensagemRetorno.NumeroMensagem = "000";
                mensagemRetorno.CodigoMensagem = mensagemRetorno.SiglaMensagem + traco + mensagemRetorno.NumeroMensagem;
                mensagemRetorno.TextoMensagem = codigoMensagem;
                mensagemRetorno.ComplementoMensagem = "";
            }
            return mensagemRetorno;
        }

        public static string MensagemCompleta(string codigoMensagem)
        {
            mensagemRetorno = Buscar(codigoMensagem);
            return Environment.NewLine + "[" + mensagemRetorno.CodigoMensagem + "] "
                + mensagemRetorno.TextoMensagem.Replace(enter + "", Environment.NewLine + "")
                + Environment.NewLine + mensagemRetorno.ComplementoMensagem.Replace(enter + "", Environment.NewLine + "");
        }
        
        #endregion READ

        #region UPDATE
        #endregion UPDATE

        #region DELETE
        #endregion DELETE





    }
}
