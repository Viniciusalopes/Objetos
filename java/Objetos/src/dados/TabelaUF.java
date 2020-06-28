/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dados;

import enderecos.UF;
import constantes.EnumRegiao;
import java.util.ArrayList;

/**
 *
 * @author vovostudio
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
