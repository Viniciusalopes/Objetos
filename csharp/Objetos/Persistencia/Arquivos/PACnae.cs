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
///     Persistência em arquivo para CNAES de um CNPJ.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Constantes;
using Objetos.Interfaces;
using Objetos.Modelos.Documentos;
using static Objetos.Constantes.EnumTipoCnae;

namespace Objetos.Persistencia.Arquivos
{
    public class PACnae : ICRUD<Cnae>
    {
        #region ATRIBUTOS

        private NomesDiretorios diretorios = null;
        private NomesArquivos arquivos = null;
        private Arquivo controleArquivo = null;

        private Cnae cnae = null;
        private List<Cnae> cnaes = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PACnae()
        {
            diretorios = new NomesDiretorios();
            diretorios.DirRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            diretorios.DirHome = "\\Objetos\\";
            diretorios.DirDados = diretorios.DirFull + "Dados\\";
            diretorios.DirRelatorios = diretorios.DirFull + "Relatorios\\";

            arquivos = new NomesArquivos();
            arquivos.ArquivoDeDados = "Cnae.bd";

            controleArquivo = new Arquivo(diretorios.DirDados, arquivos.ArquivoDeDados);
        }
        #endregion CONSTRUTORES


        #region CREATE

        public void Incluir(Cnae cnae)
        {
            try
            {
                controleArquivo.IncluirLinha(cnae.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("cnae#001#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion CREATE

        #region READ

        public Cnae Buscar(int idCnae)
        {
            try
            {
                foreach (Cnae cnae in Consultar())
                    if (cnae.IdCnae == idCnae)
                        return cnae;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("cnae#002#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Cnae> Consultar()
        {
            try
            {
                cnaes = new List<Cnae>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    cnaes.Add(ToObject(linha));

                return cnaes;
            }
            catch (Exception ex)
            {
                throw new Exception("cnae#003#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Cnae> Consultar(object parametro)
        {
            try
            {
                cnaes = new List<Cnae>();
                cnae = new Cnae();
                bool retornar = false;
                string texto = null;

                #region ID DA PESSOA JURÍDICA

                try { cnae.IdPessoaJuridica = (int)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Cnae oCnae in Consultar())
                        if (oCnae.IdPessoaJuridica.Equals((int)parametro))
                            cnaes.Add(oCnae);

                    return cnaes;
                }

                #endregion ID DA PESSOA JURÍDICA

                #region CÓDIGO E DESCRIÇÃO

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Cnae oCnae in Consultar())
                        if (oCnae.CodigoCnae.Equals(texto) || oCnae.DescricaoCnae.Equals(texto))
                            cnaes.Add(oCnae);

                    return cnaes;
                }

                #endregion CÓDIGO E DESCRIÇÃO

                #region TIPO DE CNAE

                try { cnae.TipoCnae = (TipoCnae)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Cnae oCnae in Consultar())
                        if (oCnae.TipoCnae.Equals((TipoCnae)parametro))
                            cnaes.Add(oCnae);

                    return cnaes;
                }
                #endregion TIPO DE CNAE

                return cnaes;
            }
            catch (Exception ex)
            {
                throw new Exception("cnae#004#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public Cnae ToObject(string texto)
        {
            throw new System.NotImplementedException();
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(Cnae objeto)
        {
            throw new System.NotImplementedException();
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion DELETE
    }
}
