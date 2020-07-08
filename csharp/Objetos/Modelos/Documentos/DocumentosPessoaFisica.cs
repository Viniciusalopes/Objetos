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
///     Documentos comuns a uma Pessoa Física.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Constantes;
using static Objetos.Utilitarios.StringUtils;

namespace Objetos.Modelos.Documentos
{
    public class DocumentosPessoaFisica
    {
        public Cpf oCpf { get; set; }
        public string Rg { get; set; }
        public Cnh oCnh { get; set; }
        public Ctps oCtps { get; set; }
        public TituloEleitoral oTituloEleitoral { get; set; }
        public string PisNit { get; set; }
        public Cdi oCdi { get; set; }

        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return oCpf.getNumeroCpf() + sep
                + Rg + sep
                + oCnh.ToString() + sep
                + oCtps.ToString() + sep
                + oTituloEleitoral.ToString() + sep
                + PisNit + sep
                + oCdi.ToString();
        }

        /// <summary>
        ///     ToString sem o Cdi.
        /// </summary>
        /// <returns></returns>
        public string ToStringFeminino()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return oCpf.getNumeroCpf() + sep
                + Rg + sep
                + ((oCnh == null) ? repetir(sep + "", 11) : oCnh.ToString()) + sep
                + ((oCtps == null) ? repetir(sep + "", 6) : oCtps.ToString()) + sep
                + ((oTituloEleitoral == null) ? repetir(sep + "", 7) : oTituloEleitoral.ToString()) + sep
                + PisNit;
        }
    }
}
