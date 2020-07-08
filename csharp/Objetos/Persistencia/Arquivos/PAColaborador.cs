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
///     Persistencia em arquivo para Colaborador
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

namespace Objetos.Persistencia.Arquivos
{
    public class PAColaborador : ICRUD<Colaborador>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private Colaborador colaborador = null;
        private List<Colaborador> colaboradores = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAColaborador()
        {
            controleArquivo = new Arquivo("Colaborador", "pho", "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public void Incluir(Colaborador colaborador)
        {
            try
            {
                controleArquivo.IncluirLinha(colaborador.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "001#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public Colaborador Buscar(long idPessoa)
        {
            try
            {
                foreach (Colaborador colaborador in Consultar())
                    if (colaborador.IdPessoa == idPessoa)
                        return colaborador;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "002#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Colaborador> Consultar()
        {
            try
            {
                colaboradores = new List<Colaborador>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    colaboradores.Add(ToObject(linha));

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "003#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Colaborador> Consultar(object parametro)
        {
            try
            {
                colaboradores = new List<Colaborador>();

                foreach (Colaborador colaborador in Consultar())
                {
                    if (colaborador.NomePessoa.Equals((string)parametro))
                        colaboradores.Add(colaborador);
                }
                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "004#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public Colaborador ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                return new Colaborador(
                    long.Parse(partes[0]),
                    long.Parse(partes[1]),
                    int.Parse(partes[2]),
                    DateTime.Parse(partes[3]),
                    DateTime.Parse(partes[4]),
                    null);
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "005#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE
        public void Atualizar(Colaborador colaborador)
        {
            try
            {
                foreach (Colaborador oColaborador in Consultar())
                    if (oColaborador.IdPessoa == colaborador.IdPessoa)
                    {
                        controleArquivo.SubstituirLinha(oColaborador.ToString(), colaborador.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "006#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idPessoa)
        {
            try
            {
                foreach (Colaborador oColaborador in Consultar())
                    if (oColaborador.IdPessoa == colaborador.IdPessoa)
                    {
                        controleArquivo.ExcluirLinha(oColaborador.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("col" + ConstantesGerais.SeparadorTraco + "007Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
