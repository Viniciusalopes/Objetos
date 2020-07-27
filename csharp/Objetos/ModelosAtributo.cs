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
///     Objeto Atributo.
///     Criação : Vovolinux
///     Data    : 27/07/2020 02:59:37 - Gerado automaGicamente pelo Gerador de Objetos - Versão 1.0.0.0
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class Atributo
    {
        #region ATRIBUTOS
        
        public long IdAtributo { get; set; }
        public string NomeAtributo { get; set; }
        public string TipoAtributo { get; set; }
        public string ObjetoAtributo { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        
        public Atributo()
        {

        }

        public Atributo(long idAtributo, string nomeAtributo, string tipoAtributo, string objetoAtributo)
        {
            IdAtributo = idAtributo;
            NomeAtributo = nomeAtributo;
            TipoAtributo = tipoAtributo;
            ObjetoAtributo = objetoAtributo;
        }

        #endregion CONSTRUTORES
        
        #region GET

        public override string ToString()
        {
            char sep = SeparadorSplit;
            return IdAtributo.ToString()
                + sep + NomeAtributo
                + sep + TipoAtributo
                + sep + ObjetoAtributo;
        }

        #endregion GET
    }
}

