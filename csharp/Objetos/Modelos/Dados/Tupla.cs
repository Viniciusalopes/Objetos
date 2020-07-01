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
///     Características de dados.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;

namespace Objetos.Modelos.Dados
{
    public class Tupla
    {
        #region ATRIBUTOS

        public long IdTupla { get; set; }
        public string NomeTupla { get; set; }
        public string AliasTupla { get; set; }
        public string ValorStrTupla { get; set; }
        public int ValorIntTupla { get; set; }
        public long ValorLongTupla { get; set; }
        public float ValorFloatTupla { get; set; }
        public double ValorDoubleTupla { get; set; }
        public bool ValorBoolTupla { get; set; }
        public Object ValorObjectTupla { get; set; }
        public int TamanhoMínimoTupla { get; set; }
        public int TamanhoMáximoTupla { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Tupla()
        {

        }
        public Tupla(long id, string nome, string valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = valor;
            ValorIntTupla = 0;
            ValorLongTupla = 0;
            ValorFloatTupla = 0;
            ValorDoubleTupla = 0;
            ValorBoolTupla = false;
            ValorObjectTupla = null;
        }
        public Tupla(long id, string nome, int valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = valor;
            ValorLongTupla = 0;
            ValorFloatTupla = 0;
            ValorDoubleTupla = 0;
            ValorBoolTupla = false;
            ValorObjectTupla = null;
        }
        public Tupla(long id, string nome, long valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = 0;
            ValorLongTupla = valor;
            ValorFloatTupla = 0;
            ValorDoubleTupla = 0;
            ValorBoolTupla = false;
            ValorObjectTupla = null;
        }
        public Tupla(long id, string nome, float valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = 0;
            ValorLongTupla = 0;
            ValorFloatTupla = valor;
            ValorDoubleTupla = 0;
            ValorBoolTupla = false;
            ValorObjectTupla = null;
        }
        public Tupla(long id, string nome, double valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = 0;
            ValorLongTupla = 0;
            ValorFloatTupla = 0;
            ValorDoubleTupla = valor;
            ValorBoolTupla = false;
            ValorObjectTupla = null;
        }
        public Tupla(long id, string nome, bool valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = 0;
            ValorLongTupla = 0;
            ValorFloatTupla = 0;
            ValorDoubleTupla = 0;
            ValorBoolTupla = valor;
            ValorObjectTupla = null;
        }

        public Tupla(long id, string nome, Object valor, string alias = "")
        {
            IdTupla = id;
            NomeTupla = nome;
            AliasTupla = alias;
            ValorStrTupla = null;
            ValorIntTupla = 0;
            ValorLongTupla = 0;
            ValorFloatTupla = 0;
            ValorDoubleTupla = 0;
            ValorBoolTupla = false;
            ValorObjectTupla = valor;
        }

        #endregion CONSTRUTORES
    }
}
