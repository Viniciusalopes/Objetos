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

using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
using Objetos.Constantes;
using System;
using System.Collections.Generic;

namespace Objetos.Persistencia.Arquivos
{
    public class PAMunicipio : ICRUD<Municipio>
    {
        #region ATRIBUTOS

        private NomesDiretorios diretorios = null;
        private NomesArquivos arquivos = null;
        private Arquivo controleArquivo = null;

        private Municipio municipio = null;
        private List<Municipio> municipios = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAMunicipio()
        {
            diretorios = new NomesDiretorios();
            diretorios.DirRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            diretorios.DirHome = "\\Objetos\\";
            diretorios.DirDados = diretorios.DirFull + "Dados\\";
            diretorios.DirRelatorios = diretorios.DirFull + "Relatorios\\";

            arquivos = new NomesArquivos();
            arquivos.ArquivoDeDados = "Municipio.bd";

            controleArquivo = new Arquivo(diretorios.DirDados, arquivos.ArquivoDeDados);
        }

        #endregion CONSTRUTORES

        #region CREATE

        public void Incluir(Municipio municipio)
        {
            try
            {
                controleArquivo.IncluirLinha(municipio.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("mun#001#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion CREATE

        #region READ

        public Municipio Buscar(int codigoMunicipio)
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
                throw new Exception("mun#002#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Municipio> Consultar()
        {
            try
            {
                municipios = new List<Municipio>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    municipios.Add(ToObject(linha));

                return municipios;
            }
            catch (Exception ex)
            {
                throw new Exception("mun#003#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }

        }

        public List<Municipio> Consultar(object nomeMunicipio)
        {
            try
            {
                municipios = new List<Municipio>();

                foreach (Municipio municipio in Consultar())
                {
                    if (municipio.NomeMunicipio.Equals((string)nomeMunicipio))
                        municipios.Add(municipio);
                }
                return municipios;
            }
            catch (Exception ex)
            {
                throw new Exception("mun#004#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Municipio> Consultar(UF uf)
        {
            try
            {
                municipios = new List<Municipio>();

                foreach (Municipio municipio in Consultar())
                {
                    if (municipio.CodigoMunicipio.ToString().Substring(0,2).Equals(uf.IdUf.ToString()))
                        municipios.Add(municipio);
                }
                return municipios;
            }
            catch (Exception ex)
            {
                throw new Exception("mun#008#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public Municipio ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                return new Municipio(int.Parse(partes[0]), partes[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("mun#005#Camada: Persistência-Arquivos#Erro: " + ex.Message);
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
                throw new Exception("mun#006#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(int codigoMunicipio)
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
                throw new Exception("mun#007Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion DELETE
    }
}
