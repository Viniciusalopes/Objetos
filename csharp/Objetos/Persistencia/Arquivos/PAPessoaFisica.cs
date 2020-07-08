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

namespace Objetos.Persistencia.Arquivos
{
    public class PAPessoaFisica : ICRUD<PessoaFisica>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private ControleMunicipio controleMunicipio = null;
        private ControleUF controleUF = null;

        private PessoaFisica pessoa = null;
        private List<PessoaFisica> pessoas = null;
        private List<PessoaFisica> pessoasRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        public PAPessoaFisica()
        {
            controleArquivo = new Arquivo("PessoaFisica", "pho", "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public void Incluir(PessoaFisica pessoaFisica)
        {
            try
            {
                pessoaFisica.IdPessoa = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(pessoaFisica.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "001#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "002#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pes" + ConstantesGerais.SeparadorTraco + "003#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<PessoaFisica> Consultar(object parametro)
        {
            try
            {
                pessoas = Consultar();
                pessoasRetorno = new List<PessoaFisica>();
                pessoa = new PessoaFisica();
                bool retornar = false;
                string texto = null;

                #region NOMES E DOCUMENTOS

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaFisica pessoaFisica in pessoas)
                        if (pessoaFisica.NomePessoa.Equals(texto)
                            || pessoaFisica.NomePai.Equals(texto)
                            || pessoaFisica.NomeMae.Equals(texto)
                            || pessoaFisica.NomeConjuge.Equals(texto)
                            || pessoaFisica.Documentos.Rg.Equals(texto)
                            || pessoaFisica.Documentos.oCpf.getNumeroCpf().Equals(texto)
                            || pessoaFisica.Documentos.oCnh.NumeroCnh.Equals(texto)
                            || pessoaFisica.Documentos.oCnh.NumeroRegistroCnh.Equals(texto)
                            )
                            pessoasRetorno.Add(pessoaFisica);

                    return pessoasRetorno;
                }

                #endregion NOMES E DOCUMENTOS

                #region SEXO

                try { pessoa.Sexo = (Sexo)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaFisica pessoaFisica in Consultar())
                        if (pessoaFisica.Sexo.Equals((Sexo)parametro))
                        {
                            pessoasRetorno.Add(pessoaFisica);
                        }

                    return pessoasRetorno;
                }

                #endregion SEXO

                #region ESTADO CIVIL

                try { pessoa.EstadoCivil = (EstadoCivil)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaFisica pessoaFisica in Consultar())
                        if (pessoaFisica.EstadoCivil.Equals((EstadoCivil)parametro))
                        {
                            pessoasRetorno.Add(pessoaFisica);
                        }

                    return pessoasRetorno;
                }

                #endregion ESTADO CIVIL

                #region ESCOLARIDADE

                try { pessoa.Escolaridade = (Escolaridade)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaFisica pessoaFisica in Consultar())
                        if (pessoaFisica.Escolaridade.Equals((Escolaridade)parametro))
                        {
                            pessoasRetorno.Add(pessoaFisica);
                        }

                    return pessoasRetorno;
                }

                #endregion ESCOLARIDADE

                return pessoasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "004#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public PessoaFisica ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                pessoa = new PessoaFisica();
                pessoa.IdPessoa = long.Parse(partes[0]);
                pessoa.TipoPessoa = (TipoPessoa)int.Parse(partes[1]);
                pessoa.Situacao = (Situacao)int.Parse(partes[2]);
                pessoa.Vinculo = (Vinculo)int.Parse(partes[3]);
                pessoa.NomePessoa = partes[4];
                pessoa.DataNascimento = DateTime.Parse(partes[5]);
                pessoa.Sexo = (Sexo)int.Parse(partes[6]);
                pessoa.NomePai = partes[7];
                pessoa.NomeMae = partes[8];
                pessoa.EstadoCivil = (EstadoCivil)int.Parse(partes[9]);
                pessoa.NomeConjuge = partes[10];
                pessoa.Escolaridade = (Escolaridade)int.Parse(partes[11]);
                pessoa.Documentos = new DocumentosPessoaFisica(
                    .oCnh = new Cnh(
                    long.Parse(partes[11]),
                    bool.Parse(partes[12]),
                    bool.Parse(partes[13]),
                    partes[14],
                    long.Parse(partes[15]),
                    DateTime.Parse(partes[16]),
                    DateTime.Parse(partes[17]),
                    partes[18],
                    controleMunicipio.Buscar(long.Parse(partes[19])),
                    controleUF.Buscar(long.Parse(partes[20])),
                    DateTime.Parse(partes[21])
                );

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "005#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "006#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "007Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
