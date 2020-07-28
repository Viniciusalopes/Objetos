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
///     Objeto para pessoa Jurídica com documentos.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>


using System;
using System.Collections.Generic;
using Objetos.Modelos.Documentos;
using Objetos.Modelos.Enderecos;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumTipoEstabelecimento;
using static Objetos.Constantes.EnumTipoPessoa;
using static Objetos.Constantes.EnumVinculoPessoa;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Modelos.Pessoas
{
    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public TipoEstabelecimento TipoEstabelecimento { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string PortePJ { get; set; }
        public List<Cnae> Cnaes { get; set; }
        public string CodigoNaturezaJuridica { get; set; }
        public string DescricaoNaturezaJuridica { get; set; }
        public string Efr { get; set; }
        public Situacao SituacaoCnpj { get; set; }
        public DateTime DataSituacaoCadastral { get; set; }
        public string MotivoSituacaoCadastral { get; set; }
        public string SituacaoEspecial { get; set; }
        public DateTime DataSituacaoEspecial { get; set; }
        
        public PessoaJuridica()
        {

        }

        public PessoaJuridica(
            long idPessoa,
            Situacao situacaoPessoa,
            Vinculo vinculo,
            string cnpj,
            TipoEstabelecimento tipoEstabelecimento,
            DateTime dataAbertura,
            string nomeEmpresarial,
            string nomeFantasia,
            string portePJ,
            string codigoNaturezaJuridica,
            string descricaoNaturezaJuridica,
            string efr,
            Situacao situacaoCnpj,
            DateTime dataSituacaoCadastral,
            string motivoSituacaoCadastral,
            string situacaoEspecial,
            DateTime dataSituacaoEspecial
            )
        {
            IdPessoa = idPessoa;
            TipoPessoa = TipoPessoa.Jurídica;
            SituacaoPessoa = situacaoPessoa;
            Vinculo = vinculo;
            Cnpj = cnpj;
            TipoEstabelecimento = tipoEstabelecimento;
            DataAbertura = dataAbertura;
            NomeEmpresarial = nomeEmpresarial;
            NomeFantasia = nomeFantasia;
            PortePJ = portePJ;
            CodigoNaturezaJuridica = codigoNaturezaJuridica;
            DescricaoNaturezaJuridica = descricaoNaturezaJuridica;
            Efr = efr;
            SituacaoCnpj = situacaoCnpj;
            DataSituacaoCadastral = dataSituacaoCadastral;
            MotivoSituacaoCadastral = motivoSituacaoCadastral;
            SituacaoEspecial = situacaoEspecial;
            DataSituacaoEspecial = dataSituacaoEspecial;
        }

        public PessoaJuridica(
            long idPessoa,
            Situacao situacaoPessoa,
            Vinculo vinculo,
            List<Endereco> enderecos,
            List<Telefone> telefones,
            List<Email> emails,
            string cnpj,
            TipoEstabelecimento tipoEstabelecimento,
            DateTime dataAbertura,
            string nomeEmpresarial,
            string nomeFantasia,
            string portePJ,
            List<Cnae> cnaes,
            string codigoNaturezaJuridica,
            string descricaoNaturezaJuridica,
            string efr,
            Situacao situacaoCnpj,
            DateTime dataSituacaoCadastral,
            string motivoSituacaoCadastral,
            string situacaoEspecial,
            DateTime dataSituacaoEspecial
            )
        {
            IdPessoa = idPessoa;
            TipoPessoa = TipoPessoa.Jurídica;
            SituacaoPessoa = situacaoPessoa;
            Vinculo = vinculo;
            Enderecos = enderecos;
            Telefones = telefones;
            Emails = emails;
            Cnpj = cnpj;
            TipoEstabelecimento = tipoEstabelecimento;
            DataAbertura = dataAbertura;
            NomeEmpresarial = nomeEmpresarial;
            NomeFantasia = nomeFantasia;
            PortePJ = portePJ;
            Cnaes = cnaes;
            CodigoNaturezaJuridica = codigoNaturezaJuridica;
            DescricaoNaturezaJuridica = descricaoNaturezaJuridica;
            Efr = efr;
            SituacaoCnpj = situacaoCnpj;
            DataSituacaoCadastral = dataSituacaoCadastral;
            MotivoSituacaoCadastral = motivoSituacaoCadastral;
            SituacaoEspecial = situacaoEspecial;
            DataSituacaoEspecial = dataSituacaoEspecial;
        }

        public override string ToString()
        {
            char sep = SeparadorSplit;

            return IdPessoa.ToString()
                + sep + (int)TipoPessoa
                + sep + (int)SituacaoPessoa
                + sep + (int)Vinculo + sep
                + sep + Cnpj
                + sep + (int)TipoEstabelecimento
                + sep + DataAbertura
                + sep + NomeEmpresarial
                + sep + NomeFantasia
                + sep + PortePJ
                + sep + CodigoNaturezaJuridica
                + sep + DescricaoNaturezaJuridica
                + sep + Efr
                + sep + (int)SituacaoCnpj
                + sep + DataSituacaoCadastral
                + sep + MotivoSituacaoCadastral
                + sep + SituacaoEspecial
                + sep + DataSituacaoEspecial;
        }
    }
}
