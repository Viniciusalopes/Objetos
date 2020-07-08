/// <licença>
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
/// </licença>
/// <summary>
///     Objeto para pessoa física com documentos e outras informações pessoais.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using Objetos.Constantes;
using Objetos.Modelos.Documentos;
using Objetos.Modelos.Folha;
using static Objetos.Constantes.EnumEscolaridade;
using static Objetos.Constantes.EnumEstadoCivil;
using static Objetos.Constantes.EnumSexo;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumVinculoPessoa;
using static Objetos.Constantes.EnumTipoPessoa;

namespace Objetos.Modelos.Pessoas
{
    public class PessoaFisica : Pessoa
    {
        public string NomePessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string NomeConjuge { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public DocumentosPessoaFisica Documentos { get; set; }

        public PessoaFisica()
        {
            
        }

        public PessoaFisica(Colaborador colaborador)
        {
            IdPessoa = colaborador.IdPessoa;
            TipoPessoa = TipoPessoa.Física;
            Situacao = colaborador.Situacao;
            Vinculo = colaborador.Vinculo;
            NomePessoa = colaborador.NomePessoa;
            DataNascimento = colaborador.DataNascimento;
            Sexo = colaborador.Sexo;
            NomePai = colaborador.NomePai;
            NomeMae = colaborador.NomeMae;
            EstadoCivil = colaborador.EstadoCivil;
            NomeConjuge = colaborador.NomeConjuge;
            Escolaridade = colaborador.Escolaridade;
            Documentos = colaborador.Documentos;
        }

        public PessoaFisica(long idPessoa, string nome, DateTime dataNascimento, Sexo sexo,
            Situacao situacao = Situacao.Ativa, Vinculo vinculo = Vinculo.Nenhum,
            string nomePai = "", string nomeMae = "", EstadoCivil estadoCivil = EstadoCivil.Solteiro, string nomeConjuge = "",
            Escolaridade escolaridade = Escolaridade.EnsinoMédioCompleto, DocumentosPessoaFisica documentos = null)
        {
            IdPessoa = idPessoa;
            TipoPessoa = TipoPessoa.Física;
            Situacao = situacao;
            Vinculo = vinculo;
            NomePessoa = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            NomePai = nomePai;
            NomeMae = nomeMae;
            EstadoCivil = estadoCivil;
            NomeConjuge = nomeConjuge;
            Escolaridade = escolaridade;
            Documentos = documentos;
        }
        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return IdPessoa.ToString() + sep
                + (int)TipoPessoa + sep
                + (int)Situacao + sep
                + (int)Vinculo + sep
                + NomePessoa + sep
                + DataNascimento.ToString() + sep
                + (int)Sexo + sep
                + ((string.IsNullOrEmpty(NomePai)) ? "" : NomePai) + sep
                + ((string.IsNullOrEmpty(NomeMae)) ? "" : NomeMae) + sep
                + (int)EstadoCivil + sep
                + ((string.IsNullOrEmpty(NomeConjuge)) ? "" : NomeConjuge) + sep
                + Escolaridade + sep
                + (Sexo.Equals(EnumSexo.Sexo.Feminino) ? Documentos.ToStringFeminino() : Documentos.ToString());
        }
    }
}
