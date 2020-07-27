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
package mensagens;

import dados.Tupla;
import java.util.ArrayList;

/**
 * Objeto para composição de mensagens.
 *
 * @criacao: Vovolinux
 * @data . : 28/06/2020
 * @projeto: Objetos genéricos para Java.
 */
public class Mensagem {

    //--- ATRIBUTOS ----------------------------------------------------------->
    private long idMensagem = 0;
    private String codigoMensagem = "";
    private String siglaMensagem = "";
    private String numeroMensagem = "";
    private String textoMensagem = "";
    private String complementoMensagem = "";
    private ArrayList<Tupla> tuplas = null;

    //--- FIM ATRIBUTOS -------------------------------------------------------|
    //--- GET ----------------------------------------------------------------->
    public long getIdMensagem() {
        return idMensagem;
    }

    public String getCodigoMensagem() {
        return codigoMensagem;
    }

    public String getSiglaMensagem() {
        return siglaMensagem;
    }

    public String getNumeroMensagem() {
        return numeroMensagem;
    }

    public String getTextoMensagem() {
        return textoMensagem;
    }

    public String getComplementoMensagem() {
        return complementoMensagem;
    }

    public ArrayList<Tupla> getTuplas() {
        return tuplas;
    }
    //--- FIM GET -------------------------------------------------------------|

    //--- SET ----------------------------------------------------------------->
    public void setIdMensagem(long idMensagem) {
        this.idMensagem = idMensagem;
    }

    public void setCodigoMensagem(String codigoMensagem) {
        this.codigoMensagem = codigoMensagem;
    }

    public void setSiglaMensagem(String siglaMensagem) {
        this.siglaMensagem = siglaMensagem;
    }

    public void setNumeroMensagem(String numeroMensagem) {
        this.numeroMensagem = numeroMensagem;
    }

    public void setTextoMensagem(String textoMensagem) {
        this.textoMensagem = textoMensagem;
    }

    public void setComplementoMensagem(String complementoMensagem) {
        this.complementoMensagem = complementoMensagem;
    }

    public void setTuplas(ArrayList<Tupla> tuplas) {
        this.tuplas = tuplas;
    }
    //--- FIM SET -------------------------------------------------------------|
}
