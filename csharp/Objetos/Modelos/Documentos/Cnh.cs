﻿/// <licenca>
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
///     Carteira Nacional de Habilitação.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using Objetos.Modelos.Enderecos;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Modelos.Documentos
{
    public class Cnh
    {
        #region ATRIBUTOS

        public long NumeroCnh { get; set; }
        public bool PermissaoCnh { get; set; }
        public bool AccCnh { get; set; }
        public string CategoriaCnh { get; set; }
        public long NumeroRegistroCnh { get; set; }
        public DateTime DataValidadeCnh { get; set; }
        public DateTime DataPrimeiraHabilitacao { get; set; }
        public string ObservacoesCNH { get; set; }
        public Municipio MunicipioCnh { get; set; }
        public UF UfCnh { get; set; }
        public DateTime DataEmissaoCnh { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        public Cnh()
        {

        }

        public Cnh(long numero, bool permissao, bool acc, string categoria, long numeroRegistro,
            DateTime dataValidade, DateTime primeiraHabilitacao, string observacoes, Municipio municipio, UF uf, DateTime dataEmissao)
        {
            NumeroCnh = numero;
            PermissaoCnh = permissao;
            AccCnh = acc;
            CategoriaCnh = categoria;
            NumeroRegistroCnh = numeroRegistro;
            DataValidadeCnh = dataValidade;
            DataPrimeiraHabilitacao = primeiraHabilitacao;
            ObservacoesCNH = observacoes;
            MunicipioCnh = municipio;
            UfCnh = uf;
            DataEmissaoCnh = dataEmissao;
        }

        #endregion CONSTRUTORES
        public override string ToString()
        {
            char sep = SeparadorSplit;
            return NumeroCnh.ToString()
                + sep + PermissaoCnh.ToString()
                + sep + AccCnh.ToString()
                + sep + CategoriaCnh
                + sep + NumeroRegistroCnh.ToString()
                + sep + DataValidadeCnh.ToString()
                + sep + DataPrimeiraHabilitacao.ToString()
                + sep + ObservacoesCNH.ToString()
                + sep + MunicipioCnh.CodigoMunicipio
                + sep + UfCnh.IdUf
                + sep + DataEmissaoCnh;
        }
    }
}
