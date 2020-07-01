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
///     Cadastro de Pessoas Físicas - CPF.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;

namespace Objetos.Modelos.Documentos
{
    public class Cpf
    {
        #region ATRIBUTOS

        private string numeroCpf = "";

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Cpf()
        {

        }

        public Cpf(string numeroCpf)
        {
            setNumeroCpf(numeroCpf);
        }

        #endregion CONSTRUTORES

        #region GET

        public string getNumeroCpf()
        {
            return numeroCpf;
        }

        #endregion GET

        #region SET
        public void setNumeroCpf(string numeroCpf)
        {
            validarNumero(numeroCpf);
            this.numeroCpf = numeroCpf;
        }
        #endregion SET

        #region VALIDAÇÃO
        
        /// <summary>
        ///     Valida um número de CPF.
        /// </summary>
        /// <param name="numeroCpf"></param>
        /// <remarks>
        ///     FONTE: http://www.devmedia.com.br/articles/viewcomp_forprint.asp?comp=3950
        /// </remarks>
        private void validarNumero(string numeroCpf)
        {
            string valor = numeroCpf.Replace(".", "").Replace("-", "");

            if (valor.Length != 11)
                throw new Exception("cpf#001"); //Número do CPF não tem 11 dígitos numéricos.

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                throw new Exception("cpf#002");

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    throw new Exception("cpf#002");
            }
            else if (numeros[9] != 11 - resultado)
                throw new Exception("cpf#002");

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    throw new Exception("cpf#002");
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                    throw new Exception("cpf#002");
            }
        }
        
        #endregion VALIDAÇÃO
    }
}
