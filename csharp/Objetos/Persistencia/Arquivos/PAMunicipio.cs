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
///     Persistência em arquivo para Municipio.
///     Criação : Vovolinux
///     Data    : 29/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Controles.ControleMensagem;
using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
using Objetos.Constantes;
using System;
using System.Collections.Generic;
using Objetos.Utilitarios;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAMunicipio : ICRUD<Municipio>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        //private Municipio municipio = null;
        private List<Municipio> municipios = null;
        private List<Municipio> municipiosRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAMunicipio()
        {
            controleArquivo = new Arquivo("Municipio", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(Municipio municipio)
        {
            try
            {
                municipio.IdMunicipio = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(municipio.ToString());
                return municipio.IdMunicipio;
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public Municipio Buscar(long codigoMunicipio)
        {
            try
            {
                foreach (Municipio municipio in Consultar())
                    if (municipio.CodigoMunicipio == codigoMunicipio)
                        return municipio;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Municipio> Consultar()
        {
            try
            {
                municipiosRetorno = new List<Municipio>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    municipiosRetorno.Add(ToObject(linha));

                return municipiosRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Municipio> Consultar(object parametro, string atributo)
        {
            try
            {
                municipios = Consultar();
                municipiosRetorno = new List<Municipio>();

                // Retorna vazio se não informar o atributo
                if (atributo.Trim().Length == 0)
                    return municipiosRetorno;

                string texto = "";
                int inteiro = 0;

                try { texto = (string)parametro; } catch (Exception) { inteiro = (int)parametro; }

                switch (atributo)
                {
                    case "CodigoMunicipio":
                        foreach (Municipio municipio in municipios)
                            if (municipio.CodigoMunicipio == inteiro)
                                municipiosRetorno.Add(municipio);
                        
                        break;

                    case "IdUf":
                        foreach (Municipio municipio in municipios)
                            if (municipio.CodigoMunicipio.ToString().Substring(0, 2).Equals(texto))
                                municipiosRetorno.Add(municipio);
                        
                        break;

                    case "NomeMunicipio":
                        foreach (Municipio municipio in municipios)
                            if (municipio.NomeMunicipio.Equals(texto))
                                municipiosRetorno.Add(municipio);
                        
                        break;

                    default:
                        break;
                }

                return municipiosRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public Municipio ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                return new Municipio(long.Parse(partes[0]), int.Parse(partes[1]), partes[2]);
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE
        public void Atualizar(Municipio municipio)
        {
            try
            {
                foreach (Municipio oMunicipio in Consultar())
                    if (oMunicipio.CodigoMunicipio == municipio.CodigoMunicipio)
                    {
                        controleArquivo.SubstituirLinha(oMunicipio.ToString(), municipio.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long codigoMunicipio)
        {
            try
            {
                foreach (Municipio municipio in Consultar())
                    if (municipio.CodigoMunicipio == codigoMunicipio)
                    {
                        controleArquivo.ExcluirLinha(municipio.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("mun" + SeparadorTraco + "007Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
