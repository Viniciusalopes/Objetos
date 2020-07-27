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

/**
 * Características de dados.
 *
 * @criacao: Vovolinux
 * @data . : 28/06/2020
 * @projeto: Objetos genéricos para Java.
 */
public class Tupla {

    //--- ATRIBUTOS ----------------------------------------------------------->
    private long idTupla = 0;
    private String nomeTupla = "";
    private String aliasTupla = "";
    private String valorStrTupla = "";
    private int valorIntTupla = 0;
    private long valorLongTupla = 0;
    private float valorFloatTupla = 0;
    private double valorDoubleTupla = 0;
    private boolean valorBoolTupla = false;
    private Object valorObjectTupla = null;
    private int tamanhoMínimoTupla = 0;
    private int tamanhoMáximoTupla = 0;
    //--- FIM ATRIBUTOS -------------------------------------------------------|

    //--- CONSTRUTORES -------------------------------------------------------->
    public Tupla() {

    }

    public Tupla(long id, String nome, String valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = valor;
        valorIntTupla = 0;
        valorLongTupla = 0;
        valorFloatTupla = 0;
        valorDoubleTupla = 0;
        valorBoolTupla = false;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, int valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = valor;
        valorLongTupla = 0;
        valorFloatTupla = 0;
        valorDoubleTupla = 0;
        valorBoolTupla = false;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, long valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = 0;
        valorLongTupla = valor;
        valorFloatTupla = 0;
        valorDoubleTupla = 0;
        valorBoolTupla = false;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, float valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = 0;
        valorLongTupla = 0;
        valorFloatTupla = valor;
        valorDoubleTupla = 0;
        valorBoolTupla = false;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, double valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = 0;
        valorLongTupla = 0;
        valorFloatTupla = 0;
        valorDoubleTupla = valor;
        valorBoolTupla = false;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, boolean valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = 0;
        valorLongTupla = 0;
        valorFloatTupla = 0;
        valorDoubleTupla = 0;
        valorBoolTupla = valor;
        valorObjectTupla = null;
    }

    public Tupla(long id, String nome, Object valor, String alias) {
        idTupla = id;
        nomeTupla = nome;
        aliasTupla = alias;
        valorStrTupla = null;
        valorIntTupla = 0;
        valorLongTupla = 0;
        valorFloatTupla = 0;
        valorDoubleTupla = 0;
        valorBoolTupla = false;
        valorObjectTupla = valor;
    }
    //--- FIM CONSTRUTORES ----------------------------------------------------|

    //--- GET ----------------------------------------------------------------->
    public long getIdTupla() {
        return idTupla;
    }

    public String getNomeTupla() {
        return nomeTupla;
    }

    public String getAliasTupla() {
        return aliasTupla;
    }

    public String getValorStrTupla() {
        return valorStrTupla;
    }

    public int getValorIntTupla() {
        return valorIntTupla;
    }

    public long getValorLongTupla() {
        return valorLongTupla;
    }

    public float getValorFloatTupla() {
        return valorFloatTupla;
    }

    public double getValorDoubleTupla() {
        return valorDoubleTupla;
    }

    public boolean isValorBoolTupla() {
        return valorBoolTupla;
    }

    public Object getValorObjectTupla() {
        return valorObjectTupla;
    }

    public int getTamanhoMínimoTupla() {
        return tamanhoMínimoTupla;
    }

    public int getTamanhoMáximoTupla() {
        return tamanhoMáximoTupla;
    }
    //--- FIM GET -------------------------------------------------------------|

    //---SET ------------------------------------------------------------------>
    public void setIdTupla(long idTupla) {
        this.idTupla = idTupla;
    }

    public void setNomeTupla(String nomeTupla) {
        this.nomeTupla = nomeTupla;
    }

    public void setAliasTupla(String aliasTupla) {
        this.aliasTupla = aliasTupla;
    }

    public void setValorStrTupla(String valorStrTupla) {
        this.valorStrTupla = valorStrTupla;
    }

    public void setValorIntTupla(int valorIntTupla) {
        this.valorIntTupla = valorIntTupla;
    }

    public void setValorLongTupla(long valorLongTupla) {
        this.valorLongTupla = valorLongTupla;
    }

    public void setValorFloatTupla(float valorFloatTupla) {
        this.valorFloatTupla = valorFloatTupla;
    }

    public void setValorDoubleTupla(double valorDoubleTupla) {
        this.valorDoubleTupla = valorDoubleTupla;
    }

    public void setValorBoolTupla(boolean valorBoolTupla) {
        this.valorBoolTupla = valorBoolTupla;
    }

    public void setValorObjectTupla(Object valorObjectTupla) {
        this.valorObjectTupla = valorObjectTupla;
    }

    public void setTamanhoMínimoTupla(int tamanhoMínimoTupla) {
        this.tamanhoMínimoTupla = tamanhoMínimoTupla;
    }

    public void setTamanhoMáximoTupla(int tamanhoMáximoTupla) {
        this.tamanhoMáximoTupla = tamanhoMáximoTupla;
    }
    //--- FIM SET -------------------------------------------------------------|
}
