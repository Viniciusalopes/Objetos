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
///     Objeto para número de telefone.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Constantes;
using System;
using static Utilitarios.StringUtils;

namespace Telefones
{
    public class Telefone
    {
        #region ATRIBUTOS

        public long IdTelefone { get; set; }
        public int DddTelefone { get; set; }
        public int PrefixoTelefone { get; set; }
        public int NumeroTelefone { get; set; }

        private string numeroTelefoneFormatado = "";

        public string NumeroTelefoneFormatado
        {
            get
            {
                if (PrefixoTelefone.ToString().Length == 0)
                    throw new Exception("tel#001");


                numeroTelefoneFormatado =
                    (
                        (DddTelefone.ToString().Length > 0)
                        ? "(" + DddTelefone.ToString() + ") "
                        : ""
                    )
                    +
                    (
                        (PrefixoTelefone.ToString().Length == 5)
                        ? PrefixoTelefone.ToString().Substring(0, 1) + " " + PrefixoTelefone.ToString().Substring(1, 4)
                        : PrefixoTelefone.ToString()
                    )
                    + "-" + NumeroTelefone.ToString();

                return numeroTelefoneFormatado;
            }
        }

        public EnumTipoEnderecoTelefone.TipoEnderecoTelefone TipoTelefone { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Telefone()
        {

        }

        public Telefone(int idTelefone, string numeroTelefone, EnumTipoEnderecoTelefone.TipoEnderecoTelefone tipoTelefone)
        {
            IdTelefone = idTelefone;

            string numeros = somenteNumeros(numeroTelefone);
            validarTelefone(numeros);
            setNumeroTelefone(numeros);
            TipoTelefone = tipoTelefone;

        }
        #endregion CONSTRUTORES

        #region SET

        private void setNumeroTelefone(string numeros)
        {
            switch (numeros.Length)
            {
                case 8:
                    PrefixoTelefone = int.Parse(numeros.Substring(0, 4));
                    NumeroTelefone = int.Parse(numeros.Substring(4, 4));
                    break;

                case 9:
                    PrefixoTelefone = int.Parse(numeros.Substring(0, 5));
                    NumeroTelefone = int.Parse(numeros.Substring(5, 4));
                    break;

                case 10:
                    DddTelefone = int.Parse(numeros.Substring(0, 2));
                    PrefixoTelefone = int.Parse(numeros.Substring(2, 4));
                    NumeroTelefone = int.Parse(numeros.Substring(4, 4));
                    break;

                case 11:
                    DddTelefone = int.Parse(numeros.Substring(0, 2));
                    PrefixoTelefone = int.Parse(numeros.Substring(2, 5));
                    NumeroTelefone = int.Parse(numeros.Substring(5, 4));
                    break;
            }
        }

        #endregion SET

        #region GET

        #endregion GET

        #region VALIDAÇÃO

        private void validarTelefone(string numeroTelefone)
        {
            if (numeroTelefone.Length < 8 || numeroTelefone.Length > 11)
                throw new Exception("tel#001");
        }
        #endregion VALIDAÇÃO
    }
}
