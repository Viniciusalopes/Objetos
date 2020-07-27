/**
 * Licença MIT Copyright(c) 2020 Viniciusalopes Tecnologia
 *
 * A permissão é concedida, gratuitamente, a qualquer pessoa que obtenha uma
 * cópia deste software e dos arquivos de documentação associados (o
 * "Software"), para negociar no Software sem restrições, incluindo, sem
 * limitação, os direitos de uso, cópia, modificação, fusão, publicar,
 * distribuir, sublicenciar e/ou vender cópias do Software e permitir que as
 * pessoas a quem o Software é fornecido o façam, sob as seguintes condições:
 *
 * O aviso de direitos autorais acima e este aviso de permissão devem ser
 * incluídos em todas as cópias ou partes substanciais do Software.
 *
 * O SOFTWARE É FORNECIDO "TAL COMO ESTÁ", SEM GARANTIA DE QUALQUER TIPO,
 * EXPRESSA OU IMPLÍCITA, INCLUINDO MAS NÃO SE LIMITANDO A GARANTIAS DE
 * COMERCIALIZAÇÃO, ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA E NÃO INFRAÇÃO. EM
 * NENHUM CASO OS AUTORES OU TITULARES DE DIREITOS AUTORAIS SERÃO RESPONSÁVEIS
 * POR QUALQUER REIVINDICAÇÃO, DANOS OU OUTRA RESPONSABILIDADE, SEJA EM AÇÃO DE
 * CONTRATO, TORT OU OUTRA FORMA, PROVENIENTE, FORA OU EM CONEXÃO COM O SOFTWARE
 * OU O USO, OU OUTROS ACORDOS NOS PROGRAMAS.
 * -----------------------------------------------------------------------------
 */
package dados;

import enderecos.UF;
import constantes.EnumRegiao;
import java.util.ArrayList;

/**
 * Tabela de Unidades da Federação.
 *
 * @criacao: Vovolinux
 * @data . : 28/06/2020
 * @projeto: Objetos genéricos para Java.
 */
public class TabelaUF {

    private static ArrayList<UF> ufs = null;

    public static ArrayList<UF> getUfs() {
        ufs = new ArrayList<>();
        ufs.add(new UF(11, "RO", EnumRegiao.Norte, "Rondônia", null));
        ufs.add(new UF(12, "AC", EnumRegiao.Norte, "Acre", null));
        ufs.add(new UF(13, "AM", EnumRegiao.Norte, "Amazonas", null));
        ufs.add(new UF(14, "RR", EnumRegiao.Norte, "Roraima", null));
        ufs.add(new UF(15, "PA", EnumRegiao.Norte, "Pará", null));
        ufs.add(new UF(16, "AP", EnumRegiao.Norte, "Amapá", null));
        ufs.add(new UF(17, "TO", EnumRegiao.Norte, "Tocantins", null));
        ufs.add(new UF(21, "MA", EnumRegiao.Nordeste, "Maranhão", null));
        ufs.add(new UF(22, "PI", EnumRegiao.Nordeste, "Piauí", null));
        ufs.add(new UF(23, "CE", EnumRegiao.Nordeste, "Ceará", null));
        ufs.add(new UF(24, "RN", EnumRegiao.Nordeste, "Rio Grande do Norte", null));
        ufs.add(new UF(25, "PB", EnumRegiao.Nordeste, "Paraíba", null));
        ufs.add(new UF(26, "PE", EnumRegiao.Nordeste, "Pernambuco", null));
        ufs.add(new UF(27, "AL", EnumRegiao.Nordeste, "Alagoas", null));
        ufs.add(new UF(28, "SE", EnumRegiao.Nordeste, "Sergipe", null));
        ufs.add(new UF(29, "BA", EnumRegiao.Nordeste, "Bahia", null));
        ufs.add(new UF(31, "MG", EnumRegiao.Sudeste, "Minas Gerais", null));
        ufs.add(new UF(32, "ES", EnumRegiao.Sudeste, "Espírito Santo", null));
        ufs.add(new UF(33, "RJ", EnumRegiao.Sudeste, "Rio de Janeiro", null));
        ufs.add(new UF(35, "SP", EnumRegiao.Sudeste, "São Paulo", null));
        ufs.add(new UF(41, "PR", EnumRegiao.Sul, "Paraná", null));
        ufs.add(new UF(42, "SC", EnumRegiao.Sul, "Santa Catarina", null));
        ufs.add(new UF(43, "RS", EnumRegiao.Sul, "Rio Grande do Sul", null));
        ufs.add(new UF(50, "MS", EnumRegiao.Centro_Oeste, "Mato Grosso do Sul", null));
        ufs.add(new UF(51, "MT", EnumRegiao.Centro_Oeste, "Mato Grosso", null));
        ufs.add(new UF(52, "GO", EnumRegiao.Centro_Oeste, "Goiás", null));
        ufs.add(new UF(53, "DF", EnumRegiao.Centro_Oeste, "Distrito Federal", null));
        return ufs;
    }
}
