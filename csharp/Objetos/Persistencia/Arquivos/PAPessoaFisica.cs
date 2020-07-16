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
///     Persistencia em arquivo para PessoaFisica.
///     Criação : Vovolinux
///     Data    : 29/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Interfaces;
using Objetos.Modelos.Pessoas;
using Objetos.Modelos.Documentos;
using Objetos.Constantes;
using Objetos.Controles;
using static Objetos.Constantes.EnumSexo;
using static Objetos.Constantes.EnumEstadoCivil;
using static Objetos.Constantes.EnumEscolaridade;
using static Objetos.Controles.ControleMensagem;
using Objetos.Utilitarios;
using static Objetos.Constantes.EnumTipoPessoa;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumVinculoPessoa;
using static Objetos.Constantes.EnumForcasArmadas;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAPessoaFisica : ICRUD<PessoaFisica>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private PessoaFisica pessoa = null;
        private List<PessoaFisica> pessoas = null;
        private List<PessoaFisica> pessoasRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        public PAPessoaFisica()
        {
            controleArquivo = new Arquivo("PessoaFisica", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(PessoaFisica pessoaFisica)
        {
            try
            {
                pessoaFisica.IdPessoa = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(pessoaFisica.ToString());
                return pessoaFisica.IdPessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }


        #endregion CREATE

        #region READ

        public PessoaFisica Buscar(long idPessoa)
        {
            try
            {
                foreach (PessoaFisica pessoa in Consultar())
                    if (pessoa.IdPessoa == idPessoa)
                        return pessoa;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<PessoaFisica> Consultar()
        {
            try
            {
                pessoasRetorno = new List<PessoaFisica>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    pessoasRetorno.Add(ToObject(linha));

                return pessoasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("pes" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<PessoaFisica> Consultar(object parametro, string atributo)
        {
            try
            {
                pessoas = Consultar();
                pessoasRetorno = new List<PessoaFisica>();
                pessoa = new PessoaFisica();

                switch (atributo)
                {
                    case "TipoPessoa":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.TipoPessoa.Equals((TipoPessoa)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    case "SituacaoPessoa":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.SituacaoPessoa.Equals((Situacao)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    case "Vinculo":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.Vinculo.Equals((Vinculo)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;
                    
                    case "NomePessoa":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.NomePessoa.Equals((string)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    case "Sexo":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.Sexo.Equals((Sexo)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;


                    default:
                        break;
                }
                return pessoasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public PessoaFisica ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                pessoa = new PessoaFisica();
                pessoa.IdPessoa = long.Parse(partes[0]);
                pessoa.TipoPessoa = (TipoPessoa)int.Parse(partes[1]);
                pessoa.SituacaoPessoa = (Situacao)int.Parse(partes[2]);
                pessoa.Vinculo = (Vinculo)int.Parse(partes[3]);
                pessoa.NomePessoa = partes[4];
                pessoa.Sexo = (Sexo)int.Parse(partes[6]);
                pessoa.Enderecos = new ControleEndereco().Consultar(pessoa.IdPessoa, "IdPessoa");
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(PessoaFisica pessoaFisica)
        {
            try
            {
                foreach (PessoaFisica pessoa in Consultar())
                    if (pessoa.IdPessoa == pessoaFisica.IdPessoa)
                    {
                        controleArquivo.SubstituirLinha(pessoa.ToString(), pessoaFisica.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idPessoa)
        {
            try
            {
                foreach (PessoaFisica pessoa in Consultar())
                    if (pessoa.IdPessoa == idPessoa)
                    {
                        controleArquivo.ExcluirLinha(pessoa.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "007Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
