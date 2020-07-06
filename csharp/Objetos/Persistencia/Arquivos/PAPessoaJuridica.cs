﻿/// <licenca>
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
using Objetos.Interfaces;
using Objetos.Modelos;
using Objetos.Modelos.Documentos;
using Objetos.Modelos.Enderecos;
using Objetos.Modelos.Pessoas;
using static Objetos.Constantes.EnumRegiao;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumTipoCnae;
using static Objetos.Constantes.EnumTipoEnderecoTelefone;
using static Objetos.Constantes.EnumTipoEstabelecimento;


namespace Objetos.Persistencia.Arquivos
{
    public class PAPessoaJuridica : ICRUD<PessoaJuridica>
    {
        #region ATRIBUTOS
        private NomesDiretorios diretorios = null;
        private NomesArquivos arquivos = null;
        private Arquivo controleArquivo = null;

        private PessoaJuridica pessoa = null;
        private List<PessoaJuridica> pessoas = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAPessoaJuridica()
        {
            diretorios = new NomesDiretorios();
            diretorios.DirRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            diretorios.DirHome = "\\Objetos\\";
            diretorios.DirDados = diretorios.DirFull + "Dados\\";
            diretorios.DirRelatorios = diretorios.DirFull + "Relatorios\\";

            arquivos = new NomesArquivos();
            arquivos.ArquivoDeDados = "PessoaJuridica.bd";

            controleArquivo = new Arquivo(diretorios.DirDados, arquivos.ArquivoDeDados);
        }

        #endregion CONSTRUTORES

        #region CREATE
        public void Incluir(PessoaJuridica pessoaJuridica)
        {
            try
            {
                controleArquivo.IncluirLinha(pessoaJuridica.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("pej#001#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }
        #endregion CREATE

        #region READ
        public PessoaJuridica Buscar(int idPessoa)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.idPessoa == idPessoa)
                        return pessoa;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("pej#002#Camada: Persistência-Arquivos#Erro: " + ex.Message);
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
                throw new Exception("pej#003#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<PessoaJuridica> Consultar(object parametro)
        {
            try
            {
                pessoas = new List<PessoaJuridica>();
                pessoa = new PessoaJuridica();
                bool retornar = false;
                string texto = null;

                #region NOMES E DOCUMENTOS

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                    {
                        Cnpj oCnpj = pessoaJuridica.Documentos.oCnpj;

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
                            pessoas.Add(pessoaJuridica);
                    }
                    return pessoas;
                }

                #endregion NOMES E DOCUMENTOS

                #region TIPO DE ESTABELECIMENTO
                try { pessoa.Documentos.oCnpj.TipoEstabelecimento = (TipoEstabelecimento)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                        if (pessoaJuridica.Documentos.oCnpj.TipoEstabelecimento.Equals((TipoEstabelecimento)parametro))
                            pessoas.Add(pessoaJuridica);

                    return pessoas;
                }

                #endregion TIPO DE ESTABELECIMENTO

                #region SITUAÇÃO
                try { pessoa.Documentos.oCnpj.Situacao = (Situacao)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (PessoaJuridica pessoaJuridica in Consultar())
                        if (pessoaJuridica.Documentos.oCnpj.Situacao.Equals((Situacao)parametro))
                            pessoas.Add(pessoaJuridica);

                    return pessoas;
                }

                #endregion SITUAÇÃO

                return pessoas;
            }
            catch (Exception ex)
            {
                throw new Exception("pej#004#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public PessoaJuridica ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                pessoa = new PessoaJuridica();
                pessoa.idPessoa = long.Parse(partes[0]);
                pessoa.Documentos.oCnpj = new Cnpj(partes[1],
                    (TipoEstabelecimento)int.Parse(partes[2]),
                    DateTime.Parse(partes[3]),
                    partes[4],
                    partes[5],
                    partes[6],
                    new Cnae(
                        int.Parse(partes[7]),
                        long.Parse(partes[8]),
                        (TipoCnae)int.Parse(partes[9]),
                        partes[10],
                        partes[11]
                    ),
                    new Modelos.Enderecos.Endereco(
                        int.Parse(partes[12]),
                        partes[13],
                        int.Parse(partes[14]),
                        partes[15],
                        partes[16],
                        partes[17],
                        new Municipio(
                            int.Parse(partes[18]),
                            partes[19]),
                            new UF(
                                int.Parse(partes[20]),
                                partes[21],
                                (Regiao)int.Parse(partes[22]),
                                partes[23],
                                null
                            ),
                        (TipoEnderecoTelefone)int.Parse(partes[24])
                    ),
                    new NaturezaJuridica(partes[25], partes[26]),
                    partes[27],
                    new Telefone(int.Parse(partes[28]), partes[29], (TipoEnderecoTelefone)int.Parse(partes[30])),
                    partes[31],
                    (Situacao)int.Parse(partes[32]),
                    DateTime.Parse(partes[33]),
                    partes[34],
                    partes[35],
                    DateTime.Parse(partes[36])
                    );

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("pej#005#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion READ

        #region UPDATE
        public void Atualizar(PessoaJuridica pessoaJuridica)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.idPessoa == pessoaJuridica.idPessoa)
                    {
                        controleArquivo.SubstituirLinha(pessoa.ToString(), pessoaJuridica.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pej#006#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion UPDATE

        #region DELETE
       
        public void Excluir(int idPessoa)
        {
            try
            {
                foreach (PessoaJuridica pessoa in Consultar())
                    if (pessoa.idPessoa == idPessoa)
                    {
                        controleArquivo.ExcluirLinha(pessoa.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("pej#007Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }
        
        #endregion DELETE
    }
}