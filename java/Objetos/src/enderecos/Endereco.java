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

import constantes.EnumTipoEnderecoTelefone;

/**
 * Endereço.
 *
 * @criacao: Vovolinux
 * @data . : 28/06/2020
 * @projeto: Objetos genéricos para Java.
 */
public class Endereco {

    //--- ATRIBUTOS ----------------------------------------------------------->
    private long idEndereco = 0;
    private String logradouro = "";
    private int numero = 0;
    private String complementoEndereco = "";
    private String cep = "";
    private String setorBairroDistrito = "";
    private Municipio municipio = null;
    private UF uf = null;
    private EnumTipoEnderecoTelefone tipoEndereco = null;
    //--- FIM ATRIBUTOS -------------------------------------------------------|
    //--- GET ----------------------------------------------------------------->

    public long getIdEndereco() {
        return idEndereco;
    }

    public String getLogradouro() {
        return logradouro;
    }

    public int getNumero() {
        return numero;
    }

    public String getComplementoEndereco() {
        return complementoEndereco;
    }

    public String getCep() {
        return cep;
    }

    public String getSetorBairroDistrito() {
        return setorBairroDistrito;
    }

    public Municipio getMunicipio() {
        return municipio;
    }

    public UF getUf() {
        return uf;
    }

    public EnumTipoEnderecoTelefone getTipoEndereco() {
        return tipoEndereco;
    }
    //--- FIM GET -------------------------------------------------------------|

    //--- SET ----------------------------------------------------------------->
    public void setIdEndereco(long idEndereco) {
        this.idEndereco = idEndereco;
    }

    public void setLogradouro(String logradouro) {
        this.logradouro = logradouro;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public void setComplementoEndereco(String complementoEndereco) {
        this.complementoEndereco = complementoEndereco;
    }

    public void setCep(String cep) {
        this.cep = cep;
    }

    public void setSetorBairroDistrito(String setorBairroDistrito) {
        this.setorBairroDistrito = setorBairroDistrito;
    }

    public void setMunicipio(Municipio municipio) {
        this.municipio = municipio;
    }

    public void setUf(UF uf) {
        this.uf = uf;
    }

    public void setTipoEndereco(EnumTipoEnderecoTelefone tipoEndereco) {
        this.tipoEndereco = tipoEndereco;
    }
    //--- FIM SET -------------------------------------------------------------|
}
