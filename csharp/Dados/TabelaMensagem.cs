/// <summary>
///     Tabela de mensagens para alertas.
/// </summary>
/// <remarks>
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
///     -----------------------------------------------------------------------------------------------------
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </remarks>

using System.Collections.Generic;

namespace Dados
{
    public static class TabelaMensagens
    {
        private static List<Tupla> tuplas;

        public static List<Tupla> Tuplas
        {
            get
            {
                tuplas = new List<Tupla>();
                tuplas.Add(new Tupla(1, "cpf#001", "O CPF deve ter 11 dígitos numéricos!"));
                tuplas.Add(new Tupla(2, "cpf#002", "CFP inválido!"));
                tuplas.Add(new Tupla(3, "cnpj#001", "CNPJ inválido!"));
                return tuplas;
            }
            set { tuplas = value; }
        }
    }
}
