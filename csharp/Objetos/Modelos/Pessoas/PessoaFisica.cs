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

using static Objetos.Constantes.ConstantesGerais;
using static Objetos.Constantes.EnumSexo;
using static Objetos.Constantes.EnumSituacao;
using static Objetos.Constantes.EnumVinculoPessoa;
using static Objetos.Constantes.EnumTipoPessoa;

namespace Objetos.Modelos.Pessoas
{
    public class PessoaFisica : Pessoa
    {
        public string NomePessoa { get; set; }
        public Sexo Sexo { get; set; }

        public PessoaFisica()
        {

        }

        public PessoaFisica(PessoaFisica pessoaFisica)
        {
            IdPessoa = pessoaFisica.IdPessoa;
            TipoPessoa = TipoPessoa.Física;
            SituacaoPessoa = pessoaFisica.SituacaoPessoa;
            Vinculo = pessoaFisica.Vinculo;
            NomePessoa = pessoaFisica.NomePessoa;
            Sexo = pessoaFisica.Sexo;
        }

        public PessoaFisica(long idPessoa, Situacao situacaoPessoa, Vinculo vinculo, string nome, Sexo sexo)
        {
            IdPessoa = idPessoa;
            TipoPessoa = TipoPessoa.Física;
            SituacaoPessoa = situacaoPessoa;
            Vinculo = vinculo;
            NomePessoa = nome;
            Sexo = sexo;
        }

        public override string ToString()
        {
            char sep = SeparadorSplit;
            return IdPessoa.ToString()
                + sep + (int)TipoPessoa
                + sep + (int)SituacaoPessoa
                + sep + (int)Vinculo
                + sep + NomePessoa
                + sep + (int)Sexo;
        }
    }
}
