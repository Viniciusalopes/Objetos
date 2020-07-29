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
///     Persistência em arquivo genérica.
///     Criação : Vovolinux
///     Data    : 29/07/2020
///     Projeto : Objetos genéricos para C#.
///     Fonte: http://linhadecodigo.com.br/artigo/2980/utilizando-um-tipo-t-como-parametro-e-recuperando-seus-valores.aspx
/// </summary>

using System;
using Objetos.Utilitarios;
using static Objetos.Constantes.EnumEntidade;
using static Objetos.Constantes.ConstantesGerais;
using static Objetos.Controles.ControleMensagem;
using System.Collections.Generic;

namespace Objetos.Persistencia.Arquivos
{
    public class PersistenciaArquivo
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;
        private Entidade nomeEntidade;
        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PersistenciaArquivo(Entidade entidade, string dirRoot, bool criarNovo)
        {
            nomeEntidade = entidade;
            controleArquivo = new Arquivo(entidade, ExtensaoArquivoBd, dirRoot, criarNovo);
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir<T>(T entidade) where T : class, new()
        {
            try
            {
                long id = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(id.ToString() + entidade.GetType().ToString().Substring(1));
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(nomeEntidade + SeparadorTraco + "001" + SeparadorEnter
                    + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: "
                    + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        
        public T Buscar<T>(long id, Type tipoEntidade) where T : class, new()
        {
            try
            {
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    if (linha.Split(SeparadorSplit)[0].Equals(id.ToString()))
                        return (T)tipoEntidade.GetMethod("ToObject").Invoke(tipoEntidade, new object[] { linha });

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(nomeEntidade + SeparadorTraco + "002" + SeparadorEnter
                    + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: "
                    + MensagemCompleta(ex.Message));
            }
        }

        public List<T> Consultar<T>(T entidade) where T : class, new()
        {
            try
            {
                List<T> colecaoRetorno = new List<T>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    colecaoRetorno.Add((T)entidade.GetType().GetMethod("ToObject").Invoke(entidade, new object[] { linha }));

                return colecaoRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(nomeEntidade + SeparadorTraco + "003" + SeparadorEnter
                     + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: "
                     + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar<T>(T entidade, long id) where T : class, new()
        {
            try
            {
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    if (linha.Split(SeparadorSplit)[0].Equals(id.ToString()))
                    {
                        controleArquivo.SubstituirLinha(linha, entidade.ToString());
                        break;
                    }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(nomeEntidade + SeparadorTraco + "004" + SeparadorEnter
                    + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: "
                    + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE
        public void Excluir(long id)
        {
            try
            {
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    if (linha.Split(SeparadorSplit)[0].Equals(id.ToString()))
                    {
                        controleArquivo.ExcluirLinha(linha);
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(nomeEntidade + SeparadorTraco + "005" + SeparadorEnter
                     + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: "
                     + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE

    }
}
