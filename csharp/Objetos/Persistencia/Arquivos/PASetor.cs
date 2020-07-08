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
///     Persistência em arquivo para Setor de Empresa.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Modelos.Empresas;
using Objetos.Constantes;
using Objetos.Controles;
using Objetos.Interfaces;
using System;
using System.Collections.Generic;
using Objetos.Utilitarios;
using static Objetos.Controles.ControleMensagem;

namespace Objetos.Persistencia.Arquivos
{
    public class PASetor : ICRUD<Setor>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;
        private ControleColaborador controleColaborador = null;

        private Setor setor = null;
        private List<Setor> setores = null;
        private List<Setor> setoresRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PASetor()
        {
            controleArquivo = new Arquivo("Setor", "pho", "");
        }
        #endregion CONSTRUTORES


        #region CREATE

        public void Incluir(Setor setor)
        {
            try
            {
                setor.IdSetor = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(setor.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "001#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public Setor Buscar(long idSetor)
        {
            try
            {
                foreach (Setor setor in Consultar())
                    if (setor.IdSetor == idSetor)
                        return setor;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "002#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Setor> Consultar()
        {
            try
            {
                setoresRetorno = new List<Setor>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    setoresRetorno.Add(ToObject(linha));

                return setoresRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "003#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Setor> Consultar(object parametro)
        {
            try
            {
                setores = Consultar();
                setoresRetorno = new List<Setor>();
                bool retornar = false;
                string texto = null;
                long id = 0;

                #region ID DA PESSOA JURÍDICA E ID DO RESPONSÁVEL

                try { id = (long)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Setor oSetor in setores)
                    {
                        if (oSetor.IdEmpresa == id)
                            setoresRetorno.Add(oSetor);
                        else
                        {
                            if (oSetor.ResponsavelSetor != null)
                                if (oSetor.ResponsavelSetor.IdPessoa == id)
                                    setoresRetorno.Add(oSetor);
                        }
                    }

                    return setoresRetorno;
                }

                #endregion ID DA PESSOA JURÍDICA E ID DO RESPONSÁVEL

                #region NOME DO SETOR E RESPONSÁVEL

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Setor oSetor in setores)
                        if (oSetor.NomeSetor.Equals(texto))
                            setoresRetorno.Add(oSetor);
                        else
                        {
                            if (oSetor.ResponsavelSetor != null)
                                if (oSetor.ResponsavelSetor.NomePessoa.Equals(texto))
                                    setoresRetorno.Add(oSetor);

                            return setoresRetorno;
                        }
                }
                #endregion NOME DO SETOR E RESPONSÁVEL

                return setoresRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "004#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public Setor ToObject(string texto)
        {
            try
            {
                controleColaborador = new ControleColaborador();
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                return new Setor(long.Parse(partes[0]), long.Parse(partes[1]), partes[2], controleColaborador.Buscar(long.Parse(partes[3])), null);
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "005#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(Setor setor)
        {
            try
            {
                foreach (Setor oSetor in Consultar())
                    if (oSetor.IdSetor == setor.IdSetor)
                    {
                        controleArquivo.SubstituirLinha(oSetor.ToString(), setor.ToString());
                        break;
                    }

            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "006#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idSetor)
        {
            try
            {
                foreach (Setor setor in Consultar())
                    if (setor.IdSetor == idSetor)
                    {
                        controleArquivo.ExcluirLinha(this.setor.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("set" + ConstantesGerais.SeparadorTraco + "007Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
