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
package enderecos;

import constantes.EnumRegiao;
import java.util.ArrayList;

/**
 * Unidades da Federação.
 *
 * @criacao: Vovolinux
 * @data . : 28/06/2020
 * @projeto: Objetos genéricos para Java.
 */
public class UF {

    //--- ATRIBUTOS ----------------------------------------------------------->
    private int idUf = 0;
    private String siglaUf = "";
    private EnumRegiao regiao = null;
    private String NomeUf = "";
    private ArrayList<Municipio> municipios = null;
    //--- FIM ATRIBUTOS -------------------------------------------------------|

    //--- CONSTRUTORES -------------------------------------------------------->
    public UF() {

    }

    public UF(int idUf, String siglaUf, EnumRegiao regiao, String nomeUf, ArrayList<Municipio> municipios) {
        this.idUf = idUf;
        this.siglaUf = siglaUf;
        this.regiao = regiao;
        this.NomeUf = nomeUf;
        this.municipios = municipios;
    }
    //--- FIM CONSTRUTORES ----------------------------------------------------|

    //--- GET ----------------------------------------------------------------->
    public int getIdUf() {
        return idUf;
    }

    public String getSiglaUf() {
        return siglaUf;
    }

    public EnumRegiao getRegiao() {
        return regiao;
    }

    public String getNomeUf() {
        return NomeUf;
    }

    public ArrayList<Municipio> getMunicipios() {
        return municipios;
    }
    //--- FIM GET -------------------------------------------------------------|

    //--- SET ----------------------------------------------------------------->
    public void setIdUf(int idUf) {
        this.idUf = idUf;
    }

    public void setSiglaUf(String siglaUf) {
        this.siglaUf = siglaUf;
    }

    public void setRegiao(EnumRegiao regiao) {
        this.regiao = regiao;
    }

    public void setNomeUf(String NomeUf) {
        this.NomeUf = NomeUf;
    }

    public void setMunicipios(ArrayList<Municipio> municipios) {
        this.municipios = municipios;
    }
    //--- FIM SET -------------------------------------------------------------|
}
