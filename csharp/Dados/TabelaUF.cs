/// <summary>
///     Tabelas de Unidades da Federação.
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

using Constantes;
using Enderecos;
using System.Collections.Generic;

namespace Dados
{
    public static class TabelaUF
    {
        private static List<UF> ufs;

        public static List<UF> UFs
        {
            get
            {
                ufs = new List<UF>();
                ufs.Add(new UF(11, "RO", EnumRegiao.Regiao.Norte, "Rondônia", null));
                ufs.Add(new UF(12, "AC", EnumRegiao.Regiao.Norte, "Acre", null));
                ufs.Add(new UF(13, "AM", EnumRegiao.Regiao.Norte, "Amazonas", null));
                ufs.Add(new UF(14, "RR", EnumRegiao.Regiao.Norte, "Roraima", null));
                ufs.Add(new UF(15, "PA", EnumRegiao.Regiao.Norte, "Pará", null));
                ufs.Add(new UF(16, "AP", EnumRegiao.Regiao.Norte, "Amapá", null));
                ufs.Add(new UF(17, "TO", EnumRegiao.Regiao.Norte, "Tocantins", null));
                ufs.Add(new UF(21, "MA", EnumRegiao.Regiao.Nordeste, "Maranhão", null));
                ufs.Add(new UF(22, "PI", EnumRegiao.Regiao.Nordeste, "Piauí", null));
                ufs.Add(new UF(23, "CE", EnumRegiao.Regiao.Nordeste, "Ceará", null));
                ufs.Add(new UF(24, "RN", EnumRegiao.Regiao.Nordeste, "Rio Grande do Norte", null));
                ufs.Add(new UF(25, "PB", EnumRegiao.Regiao.Nordeste, "Paraíba", null));
                ufs.Add(new UF(26, "PE", EnumRegiao.Regiao.Nordeste, "Pernambuco", null));
                ufs.Add(new UF(27, "AL", EnumRegiao.Regiao.Nordeste, "Alagoas", null));
                ufs.Add(new UF(28, "SE", EnumRegiao.Regiao.Nordeste, "Sergipe", null));
                ufs.Add(new UF(29, "BA", EnumRegiao.Regiao.Nordeste, "Bahia", null));
                ufs.Add(new UF(31, "MG", EnumRegiao.Regiao.Sudeste, "Minas Gerais", null));
                ufs.Add(new UF(32, "ES", EnumRegiao.Regiao.Sudeste, "Espírito Santo", null));
                ufs.Add(new UF(33, "RJ", EnumRegiao.Regiao.Sudeste, "Rio de Janeiro", null));
                ufs.Add(new UF(35, "SP", EnumRegiao.Regiao.Sudeste, "São Paulo", null));
                ufs.Add(new UF(41, "PR", EnumRegiao.Regiao.Sul, "Paraná", null));
                ufs.Add(new UF(42, "SC", EnumRegiao.Regiao.Sul, "Santa Catarina", null));
                ufs.Add(new UF(43, "RS", EnumRegiao.Regiao.Sul, "Rio Grande do Sul", null));
                ufs.Add(new UF(50, "MS", EnumRegiao.Regiao.Centro_Oeste, "Mato Grosso do Sul", null));
                ufs.Add(new UF(51, "MT", EnumRegiao.Regiao.Centro_Oeste, "Mato Grosso", null));
                ufs.Add(new UF(52, "GO", EnumRegiao.Regiao.Centro_Oeste, "Goiás", null));
                ufs.Add(new UF(53, "DF", EnumRegiao.Regiao.Centro_Oeste, "Distrito Federal", null));
                return ufs;
            }
        }
    }
}
