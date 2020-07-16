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
///     Persistencia em arquivo para Colaborador.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Controles.ControleMensagem;
using Objetos.Constantes;
using Objetos.Interfaces;
using Objetos.Modelos.Folha;
using System;
using System.Collections.Generic;
using Objetos.Utilitarios;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAColaborador : ICRUD<Colaborador>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private Colaborador colaborador = null;
        private List<Colaborador> colaboradores = null;
        private List<Colaborador> colaboradoresRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAColaborador()
        {
            controleArquivo = new Arquivo("Colaborador", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(Colaborador colaborador)
        {
            try
            {
                colaborador.IdColaborador = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(colaborador.ToString());
                return colaborador.IdColaborador;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public Colaborador Buscar(long idColaborador)
        {
            try
            {
                foreach (Colaborador colaborador in Consultar())
                    if (colaborador.IdColaborador == idColaborador)
                        return colaborador;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Colaborador> Consultar()
        {
            try
            {
                colaboradoresRetorno = new List<Colaborador>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    colaboradoresRetorno.Add(ToObject(linha));

                return colaboradoresRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Colaborador> Consultar(object parametro, string atributo)
        {
            try
            {
                colaboradores = Consultar();
                colaboradoresRetorno = new List<Colaborador>();

                // Retorna vazio se não informar o atributo
                if (atributo.Trim().Length == 0)
                    return colaboradoresRetorno;

                int inteiro = (int)parametro;

                foreach (Colaborador colaborador in colaboradores)
                    switch (atributo)
                    {
                        case "IdPessoa":
                            if (colaborador.IdPessoa == inteiro)
                                colaboradoresRetorno.Add(colaborador);
                            break;

                        case "IdEmpresa":
                            if (colaborador.IdEmpresa == inteiro)
                                colaboradoresRetorno.Add(colaborador);
                            break;

                        case "IdSetor":
                            if (colaborador.IdSetor == inteiro)
                                colaboradoresRetorno.Add(colaborador);
                            break;

                        case "MartriculaColaborador":
                            if (colaborador.MatriculaColaborador == inteiro)
                                colaboradoresRetorno.Add(colaborador);
                            break;

                        default:
                            break;
                    }

                return colaboradoresRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public Colaborador ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                return new Colaborador(
                    long.Parse(partes[0]),
                    long.Parse(partes[1]),
                    long.Parse(partes[2]),
                    long.Parse(partes[3]),
                    int.Parse(partes[4]),
                    DateTime.Parse(partes[5]),
                    DateTime.Parse(partes[6]),
                    null);
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE
        public void Atualizar(Colaborador colaborador)
        {
            try
            {
                foreach (Colaborador oColaborador in Consultar())
                    if (oColaborador.IdColaborador == colaborador.IdColaborador)
                    {
                        controleArquivo.SubstituirLinha(oColaborador.ToString(), colaborador.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idEmpresa)
        {
            try
            {
                foreach (Colaborador oColaborador in Consultar())
                    if (oColaborador.IdColaborador == colaborador.IdColaborador)
                    {
                        controleArquivo.ExcluirLinha(oColaborador.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("col" + SeparadorTraco + "007" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
