/// <licenca>
///     Licença MIT
///     Copyright © 2020 Viniciusalopes Tecnologia
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
///     [DescricaoPersistencia]
///     Criação : [Autor]
///     Data    : [DataCriacao]
///     Projeto : Objetos genéricos para [Linguagem].
/// </summary>
/*
using System;
using System.Collections.Generic;
using Objetos.Interfaces;
using Objetos.Utilitarios;
using [NamespaceObjeto];
using static Objetos.Constantes.ConstantesGerais;
using static Objetos.Controles.ControleMensagem;

namespace [NamespacePersistencia]
{

    public class PA[Modelo] : ICRUD<[Modelo]>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private [Modelo] [modeloSingular] = null;
        private List<[Modelo]> [modeloPlural] = null;
        private List<[Modelo]> [modeloPlural]Retorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PA[Modelo] ()
        {
            controleArquivo = new Arquivo("[Modelo]", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir([Modelo] [modeloSingular])
        {
            try
            {
                [modeloSingular].[IdModeloAtributo] = GeradorID.getProximoID();
                controleArquivo.IncluirLinha([modeloSingular].ToString());
                return [modeloSingular].[IdModeloAtributo];
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public [Modelo] Buscar(long [idModeloParametro])
        {
            try
            {
                foreach ([Modelo] [modeloSingular] in Consultar())
                    if ([modeloSingular].[IdModeloAtributo] == [idModeloParametro])
                        return [modeloSingular];

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<[Modelo]> Consultar()
        {
            try
            {
                [modeloPlural] = new List<[Modelo]>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    [modeloPlural].Add(ToObject(linha));

                return [modeloPlural];
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }
        public List<[Modelo]> Consultar(object parametro, string atributo)
        {
            try
            {
                [modeloPlural] = Consultar();
                [modeloPlural]Retorno = new List<[Modelo]>();

                // Retorna vazio se não informar o atributo
                if (atributo.Trim().Length == 0)
                    return [modeloPlural]Retorno;

                switch (atributo)
                {
                    [CasesConsultar]
                    default:
                        break;
                }
                return [modeloPlural]Retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public [Modelo] ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                [modeloSingular] = new [Modelo]();
                [AtributosToObject]
                
                return [modeloSingular];
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar([Modelo] [modeloSingular])
        {
            try
            {
                foreach ([Modelo] [oModeloSingular] in Consultar())
                    if ([oModeloSingular].[IdModeloAtributo] == [modeloSingular].[IdModeloAtributo])
                    {
                        controleArquivo.SubstituirLinha([oModeloSingular].ToString(), [modeloSingular].ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long [idModeloParametro])
        {
            try
            {
                foreach ([Modelo] [oModeloSingular] in Consultar())
                    if ([oModeloSingular].[IdModeloAtributo] == [idModeloParametro])
                    {
                        controleArquivo.ExcluirLinha([oModeloSingular].ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("[prefixoErro]" + SeparadorTraco + "007" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
*/