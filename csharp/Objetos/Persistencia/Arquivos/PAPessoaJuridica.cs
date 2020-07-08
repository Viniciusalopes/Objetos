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
///     Persistência em arquivo para PessoaJuridica.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Constantes;
using static Objetos.Controles.ControleMensagem;
using Objetos.Interfaces;
using Objetos.Modelos;
using Objetos.Modelos.Documentos;
using Objetos.Modelos.Enderecos;
using Objetos.Modelos.Pessoas;
using Objetos.Utilitarios;
using static Objetos.Constantes.EnumRegiao;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumTipoCnae;
using static Objetos.Constantes.EnumTipoEnderecoTelefone;
using static Objetos.Constantes.EnumTipoEstabelecimento;
using static Objetos.Constantes.EnumTipoPessoa;
using static Objetos.Constantes.EnumVinculoPessoa;
using Objetos.Controles;

namespace Objetos.Persistencia.Arquivos
{
    public class PAPessoaJuridica : ICRUD<PessoaJuridica>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private PessoaJuridica pessoa = null;
        private List<PessoaJuridica> pessoas = null;
        private List<PessoaJuridica> pessoasRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAPessoaJuridica()
        {
            controleArquivo = new Arquivo("PessoaJuridica", "pho", "");
        }

        #endregion CONSTRUTORES

        #region CREATE
        public void Incluir(PessoaJuridica pessoaJuridica)
        {
            try
            {
                pessoaJuridica.IdPessoa = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(pessoaJuridica.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "001#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }
        #endregion CREATE

        #region READ
        public PessoaJuridica Buscar(long idPessoa)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.IdPessoa == idPessoa)
                        return pessoa;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "002#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<PessoaJuridica> Consultar()
        {
            try
            {
                pessoas = new List<PessoaJuridica>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    pessoas.Add(ToObject(linha));

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "003#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<PessoaJuridica> Consultar(object parametro)
        {
            try
            {
                pessoas = Consultar();
                pessoasRetorno = new List<PessoaJuridica>();
                pessoa = new PessoaJuridica();
                bool retornar = false;
                string texto = null;

                #region NOMES E DOCUMENTOS

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                    {
                        Cnpj oCnpj = pessoaJuridica.Documentos.Cnpj;

                        if (pessoaJuridica.Documentos.InscricaoEstadual.Equals(texto)
                            || pessoaJuridica.Documentos.InscricaoMunicipal.Equals(texto)
                            || oCnpj.getNumeroInscricao().Equals(texto)
                            || oCnpj.NomeEmpresarial.Equals(texto)
                            || oCnpj.NomeFantasia.Equals(texto)
                            || oCnpj.PortePJ.Equals(texto)
                            || oCnpj.CnaePrincipal.CodigoCnae.Equals(texto)
                            || oCnpj.CnaePrincipal.DescricaoCnae.Equals(texto)
                            || oCnpj.oNaturezaJuridica.CodigoNaturezaJuridica.Equals(texto)
                            || oCnpj.oNaturezaJuridica.DescricaoNaturezaJuridica.Equals(texto)
                            || oCnpj.Email.Equals(texto)
                            || oCnpj.oTelefone.NumeroTelefoneFormatado.Equals(texto)
                            || oCnpj.Efr.Equals(texto)
                            || oCnpj.MotivoSituacaoCadastral.Equals(texto)
                            || oCnpj.Situacao.Equals(texto)
                            )
                            pessoasRetorno.Add(pessoaJuridica);
                    }
                    return pessoasRetorno;
                }

                #endregion NOMES E DOCUMENTOS

                #region TIPO DE ESTABELECIMENTO
                try { pessoa.Documentos.Cnpj.TipoEstabelecimento = (TipoEstabelecimento)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                        if (pessoaJuridica.Documentos.Cnpj.TipoEstabelecimento.Equals((TipoEstabelecimento)parametro))
                            pessoas.Add(pessoaJuridica);

                    return pessoas;
                }

                #endregion TIPO DE ESTABELECIMENTO

                #region SITUAÇÃO
                try { pessoa.Documentos.Cnpj.Situacao = (Situacao)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                        if (pessoaJuridica.Documentos.Cnpj.Situacao.Equals((Situacao)parametro))
                            pessoas.Add(pessoaJuridica);

                    return pessoas;
                }

                #endregion SITUAÇÃO

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "004#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public PessoaJuridica ToObject(string texto)
        {
            try
            {
                //                                                                            10                                                                                  
                // 0 1 2 3       4        5 6                  7             8              9  0 1 2 34                                                     
                // 1;2;2;4;22394709000151;1;07/07/2020 12:52:02;;Viniciusalopes Tecnologia;MEI;0;1;0;0101;Cnae;0;Logradouro;0;Complemento;77485-000;setor;5208707;Goiânia;52;GO;8;Goiás;2;0;Natureza Jurídica;suporte@viniciusalopes.com.br;0;(62) 9900-11;2;;2;07/07/2020 12:52:02;Situação Cadastral;2;07/07/2020 12:52:02;;
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);

                Cnae cnae = new Cnae(
                        int.Parse(partes[10]),
                        long.Parse(partes[11]),
                        (TipoCnae)int.Parse(partes[12]),
                        partes[13],
                        partes[14]);

                NaturezaJuridica naturezaJuridica = new NaturezaJuridica(partes[28], partes[29]);

                Telefone telefone = new Telefone(int.Parse(partes[31]), partes[32], (TipoEnderecoTelefone)int.Parse(partes[33]));

                Municipio municipio = new Municipio(
                            int.Parse(partes[21]),
                            partes[22]);

                UF uf = new UF(
                            int.Parse(partes[23]),
                            partes[24],
                            (Regiao)int.Parse(partes[25]),
                            partes[26]);

                Endereco endereco = new Endereco(
                        int.Parse(partes[15]),
                        partes[16],
                        int.Parse(partes[17]),
                        partes[18],
                        partes[19],
                        partes[20],
                        municipio,
                        uf,
                        (TipoEnderecoTelefone)int.Parse(partes[27]));

                pessoa = new PessoaJuridica();
                pessoa.IdPessoa = long.Parse(partes[0]);
                pessoa.TipoPessoa = (TipoPessoa)int.Parse(partes[1]);
                pessoa.Situacao = (Situacao)int.Parse(partes[2]);
                pessoa.Vinculo = (Vinculo)int.Parse(partes[3]);
                
                Cnpj cnpj = new Cnpj(
                    partes[4],
                    (TipoEstabelecimento)int.Parse(partes[5]),
                    DateTime.Parse(partes[6]),
                    partes[7],
                    partes[8],
                    partes[9],
                    cnae,
                    endereco,
                    naturezaJuridica,
                    partes[30],
                    telefone,
                    partes[34],
                    (Situacao)int.Parse(partes[35]),
                    DateTime.Parse(partes[36]),
                    partes[37],
                    partes[38],
                    DateTime.Parse(partes[39])
                    );
                pessoa.Documentos = new DocumentosPessoaJuridica(cnpj, "IE", "IM");

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "005#Camada: Persistência-Arquivos#Erro: " 
                    + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE
        public void Atualizar(PessoaJuridica pessoaJuridica)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.IdPessoa == pessoaJuridica.IdPessoa)
                    {
                        controleArquivo.SubstituirLinha(pessoa.ToString(), pessoaJuridica.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "006#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idPessoa)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.IdPessoa == idPessoa)
                    {
                        controleArquivo.ExcluirLinha(pessoa.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pej" + ConstantesGerais.SeparadorTraco + "007Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
