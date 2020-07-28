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
///     Persistencia em arquivo para Empresa.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Controles;
using Objetos.Interfaces;
using Objetos.Modelos.Empresas;
using Objetos.Utilitarios;
using System;
using System.Collections.Generic;
using static Objetos.Controles.ControleMensagem;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAEmpresa : ICRUD<Empresa>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private Empresa empresa = null;
        private List<Empresa> empresas = null;
        private List<Empresa> empresasRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAEmpresa()
        {
            controleArquivo = new Arquivo("Empresa", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(Empresa empresa)
        {
            try
            {
                empresa.IdEmpresa = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(empresa.ToString());
                return empresa.IdEmpresa;
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public Empresa Buscar(long idEmpresa)
        {
            try
            {
                foreach (Empresa empresa in Consultar())
                    if (empresa.IdEmpresa == idEmpresa)
                        return ToObject(empresa.ToString());

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Empresa> Consultar()
        {
            try
            {
                empresasRetorno = new List<Empresa>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    empresasRetorno.Add(ToObject(linha));

                return empresasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<Empresa> Consultar(object parametro, string atributo)
        {
            try
            {
                empresas = Consultar();
                empresasRetorno = new List<Empresa>();

                // Retorna vazio se não informar o atributo
                if (atributo.Trim().Length == 0)
                    return empresasRetorno;

                int inteiro = (int)parametro;

                foreach(Empresa empresa in empresas)
                    switch (atributo)
                    {
                        case "IdPessoa":
                            if (empresa.IdPessoa == inteiro)
                                empresasRetorno.Add(ToObject(empresa.ToString()));
                            break;

                        default:
                            break;
                    }

                return empresasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public Empresa ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                empresa = new Empresa(long.Parse(partes[0]), new PAPessoaJuridica().Buscar(long.Parse(partes[1])));
                empresa.Setores = new PASetor().Consultar(empresa.IdEmpresa, "IdEmpresa");
                return empresa;
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }
        #endregion READ

        #region UPDATE

        public void Atualizar(Empresa empresa)
        {
            try
            {
                foreach(Empresa oEmpresa in Consultar())
                    if(oEmpresa.IdEmpresa == empresa.IdEmpresa)
                    {
                        controleArquivo.SubstituirLinha(oEmpresa.ToString(), empresa.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE
        public void Excluir(long idEmpresa)
        {
            try
            {
                foreach (Empresa oEmpresa in Consultar())
                    if (oEmpresa.IdEmpresa == idEmpresa)
                    {
                        controleArquivo.ExcluirLinha(oEmpresa.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("emp" + SeparadorTraco + "007" + SeparadorEnter + "Camada: Persistencia-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
