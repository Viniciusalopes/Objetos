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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "001" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "002" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pes" + ConstantesGerais.SeparadorTraco + "003" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
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
                    case "Sexo":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.Sexo.Equals((Sexo)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    case "EstadoCivil":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.EstadoCivil.Equals((EstadoCivil)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    case "Escolaridade":
                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (pessoaFisica.Escolaridade.Equals((Escolaridade)parametro))
                                pessoasRetorno.Add(pessoaFisica);

                        break;

                    default:
                        string texto = (string)parametro; 

                        foreach (PessoaFisica pessoaFisica in pessoas)
                            if (atributo.Equals("NomePessoa") && pessoaFisica.NomePessoa.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("NomePai") && pessoaFisica.NomePai.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("NomeMae") && pessoaFisica.NomeMae.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("NomeConjuge") && pessoaFisica.NomeConjuge.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("Rg") && pessoaFisica.Documentos.Rg.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("Cpf") && pessoaFisica.Documentos.oCpf.getNumeroCpf().Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("NumeroCnh") && pessoaFisica.Documentos.oCnh.NumeroCnh.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);
                            else if (atributo.Equals("NumeroRegistroCnh") && pessoaFisica.Documentos.oCnh.NumeroRegistroCnh.Equals(texto))
                                pessoasRetorno.Add(pessoaFisica);

                        break;
                }
                return pessoasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "004" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public PessoaFisica ToObject(string texto)
        {
            try
            {
                controleMunicipio = new ControleMunicipio();
                controleUF = new ControleUF();

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
                pessoa.Documentos = new DocumentosPessoaFisica();
                pessoa.Documentos.oCpf = new Cpf(partes[12]);
                pessoa.Documentos.Rg = partes[13];
                pessoa.Documentos.oCnh = (partes[14].Trim().Length == 0) ? new Cnh() :
                                            new Cnh(
                                                long.Parse(partes[14]),
                                                bool.Parse(partes[15]),
                                                bool.Parse(partes[16]),
                                                partes[17],
                                                long.Parse(partes[18]),
                                                DateTime.Parse(partes[19]),
                                                DateTime.Parse(partes[20]),
                                                partes[21],
                                                controleMunicipio.Buscar(long.Parse(partes[22])),
                                                controleUF.Buscar(long.Parse(partes[23])),
                                                DateTime.Parse(partes[24])
                                            );
                pessoa.Documentos.oCtps = (partes[25].Trim().Length == 0) ? new Ctps() :

                                                new Ctps(
                                                    int.Parse(partes[25]),
                                                    partes[26],
                                                    partes[27],
                                                    DateTime.Parse(partes[28]),
                                                    controleMunicipio.Buscar(long.Parse(partes[29])),
                                                    controleUF.Buscar(long.Parse(partes[30]))
                                                );
                pessoa.Documentos.oTituloEleitoral = (partes[31].Trim().Length == 0) ? new TituloEleitoral() :
                                                        new TituloEleitoral(
                                                            bool.Parse(partes[31]),
                                                            partes[32],
                                                            int.Parse(partes[33]),
                                                            int.Parse(partes[34]),
                                                            controleMunicipio.Buscar(long.Parse(partes[35])),
                                                            controleUF.Buscar(long.Parse(partes[36])),
                                                            DateTime.Parse(partes[37])
                                                        );
                pessoa.Documentos.PisNit = partes[38];

                if (!pessoa.Sexo.Equals(Sexo.Feminino))
                {
                    pessoa.Documentos.oCdi = (partes[39].Trim().Length == 0) ? new Cdi() :
                                                new Cdi(
                                                    partes[39],
                                                    int.Parse(partes[40]),
                                                    DateTime.Parse(partes[41]),
                                                    partes[42],
                                                    (ForcaArmada)int.Parse(partes[43])
                                                );
                }

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "005" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "006" + ConstantesGerais.SeparadorEnter + "Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
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
                throw new Exception("pef" + ConstantesGerais.SeparadorTraco + "007Camada: Persistência-Arquivos" + ConstantesGerais.SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
