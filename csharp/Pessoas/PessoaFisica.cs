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
using Documentos;
using Constantes;

namespace Pessoas
{
    public class PessoaFisica
    {
        public long idPessoa { get; set; }
        public string NomePessoa { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnumSexo.Sexo Sexo { get; set; }
        public PessoaFisica Pai { get; set; }
        public PessoaFisica Mãe { get; set; }
        public EnumEstadoCivil.EstadoCivil EstadoCivil { get; set; }
        public PessoaFisica Conjuge { get; set; }
        public DocumentosPessoaFisica Documentos { get; set; }
        public EnumEscolaridade.Escolaridade Escolaridade { get; set; }
        
        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return idPessoa.ToString() + sep
                + NomePessoa + sep
                + Sexo + sep
                + Pai.idPessoa + sep
                + Mãe.idPessoa + sep
                + EstadoCivil + sep
                + Conjuge.idPessoa + sep
                + (Sexo.Equals(EnumSexo.Sexo.Feminino)? Documentos.ToStringFeminino() : Documentos.ToString())  + sep
                + Escolaridade;
        }
    }
}
