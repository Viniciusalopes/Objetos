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
///     Objeto para endereço de E-mail.
///     Criação : Vovolinux
///     Data    : 14/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Constantes.ConstantesGerais;
using static Objetos.Constantes.EnumTipoEnderecoTelefoneEmail;

namespace Objetos.Modelos
{
    public class Email
    {
        #region ATRIBUTOS

        public long IdEmail { get; set; }
        public string EnderecoEmail { get; set; }
        public TipoEnderecoTelefoneEmail TipoEmail { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        
        public Email()
        {

        }

        public Email(long idEmail, string enderecoEmail, TipoEnderecoTelefoneEmail tipoEmail)
        {
            IdEmail = idEmail;
            EnderecoEmail = enderecoEmail;
            TipoEmail = tipoEmail;
        }

        #endregion CONSTRUTORES

        #region GET

        public override string ToString()
        {
            char sep = SeparadorSplit;
            return IdEmail 
                + sep + EnderecoEmail 
                + sep + TipoEmail;
        }

        #endregion GET
    }
}
