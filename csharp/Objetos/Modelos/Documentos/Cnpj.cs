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
///     Cadastro Nacional de Pessoas Jurídicas - CNPJ.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Constantes;
using Objetos.Modelos.Enderecos;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumTipoEstabelecimento;

namespace Objetos.Modelos.Documentos
{
    public class Cnpj
    {
        #region ATRIBUTOS

        private string numeroInscricao = null;
        public TipoEstabelecimento TipoEstabelecimento { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string PortePJ { get; set; }
        public Cnae CnaePrincipal { get; set; }
        public List<Cnae> CnaesSecundarios { get; set; }
        public Endereco oEndereco { get; set; }
        public NaturezaJuridica oNaturezaJuridica { get; set; }
        public string Email { get; set; }
        public Telefone oTelefone { get; set; }
        public string Efr { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime DataSituacaoCadastral { get; set; }
        public string MotivoSituacaoCadastral { get; set; }
        public string SituacaoEspecial { get; set; }
        public DateTime DataSituacaoEspecial { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Cnpj()
        {

        }

        public Cnpj(string numeroInscricao)
        {
            validarNumero(numeroInscricao);
            this.numeroInscricao = numeroInscricao;
        }

        public Cnpj(Cnpj oCnpj)
        {
            numeroInscricao = oCnpj.numeroInscricao;
            TipoEstabelecimento = oCnpj.TipoEstabelecimento;
            DataAbertura = oCnpj.DataAbertura;
            NomeEmpresarial = oCnpj.NomeEmpresarial;
            NomeFantasia = oCnpj.NomeFantasia;
            PortePJ = oCnpj.PortePJ;
            CnaePrincipal = oCnpj.CnaePrincipal;

            CnaesSecundarios = new List<Cnae>();
            foreach (Cnae cnae in oCnpj.CnaesSecundarios)
                CnaesSecundarios.Add(cnae);

            oEndereco = oCnpj.oEndereco;
            oNaturezaJuridica = oCnpj.oNaturezaJuridica;
            Email = oCnpj.Email;
            oTelefone = oCnpj.oTelefone;
            Efr = oCnpj.Efr;
            Situacao = oCnpj.Situacao;
            DataSituacaoCadastral = oCnpj.DataSituacaoCadastral;
            MotivoSituacaoCadastral = oCnpj.MotivoSituacaoCadastral;
            SituacaoEspecial = oCnpj.SituacaoEspecial;
            DataSituacaoEspecial = oCnpj.DataSituacaoEspecial;
        }

        public Cnpj(string numeroInscricao,
            TipoEstabelecimento tipoEstabelecimento,
            DateTime dataAbertura,
            string nomeEmpresarial,
            string nomeFantasia,
            string portePJ,
            Cnae cnaePrincipal,
            List<Cnae> cnaesSecundarios,
            Endereco endereco,
            NaturezaJuridica naturezaJuridica,
            string email,
            Telefone telefone,
            string efr,
            Situacao situacao,
            DateTime dataSituacaoCadastral,
            string motivoSituacaoCadastral,
            string situacaoEspecial,
            DateTime dataSituacaoEspecial
            )
        {
            this.numeroInscricao = numeroInscricao;
            TipoEstabelecimento = tipoEstabelecimento;
            DataAbertura = dataAbertura;
            NomeEmpresarial = nomeEmpresarial;
            NomeFantasia = nomeFantasia;
            PortePJ = portePJ;
            CnaePrincipal = cnaePrincipal;
            CnaesSecundarios = cnaesSecundarios;
            oEndereco = endereco;
            oNaturezaJuridica = naturezaJuridica;
            Email = email;
            oTelefone = telefone;
            Efr = efr;
            Situacao = situacao;
            DataSituacaoCadastral = dataSituacaoCadastral;
            MotivoSituacaoCadastral = motivoSituacaoCadastral;
            SituacaoEspecial = situacaoEspecial;
            DataSituacaoEspecial = dataSituacaoEspecial;
        }
        #endregion CONSTRUTORES

        #region GET

        public string getNumeroInscricao()
        {
            return numeroInscricao;
        }

        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return numeroInscricao + sep
                + (int)TipoEstabelecimento + sep
                + DataAbertura.ToString() + sep
                + NomeEmpresarial + sep
                + NomeFantasia + sep
                + PortePJ + sep
                + CnaePrincipal.IdCnae.ToString() + sep
                + oEndereco.IdEndereco.ToString() + sep
                + oNaturezaJuridica.ToString() + sep
                + Email + sep
                + oTelefone.IdTelefone.ToString() + sep
                + Efr + sep
                + (int)Situacao + sep
                + DataSituacaoCadastral.ToString() + sep
                + MotivoSituacaoCadastral + sep
                + SituacaoEspecial + sep
                + DataSituacaoEspecial.ToString();
        }
        #endregion GET

        #region SET

        public void setNumeroInscricao(string numeroInscricao)
        {
            validarNumero(numeroInscricao);
            this.numeroInscricao = numeroInscricao;
        }

        #endregion SET

        #region VALIDAÇÃO

        /// <summary>
        ///     Valida um número de CNPJ.
        /// </summary>
        /// <param name="numeroInscricao"></param>
        /// <remarks>
        ///     FONTE: http://www.devmedia.com.br/articles/viewcomp_forprint.asp?comp=3950
        /// </remarks>
        protected void validarNumero(string numeroInscricao)
        {

            string CNPJ = numeroInscricao.Replace(".", "").Replace("/", "").Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }



                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                if (!CNPJOk[0] || !CNPJOk[1])
                    throw new Exception("cnpj" + ConstantesGerais.SeparadorTraco + "001");
            }
            catch
            {
                throw new Exception("cnpj" + ConstantesGerais.SeparadorTraco + "001");
            }
        }

        #endregion VALIDAÇÃO
    }
}
