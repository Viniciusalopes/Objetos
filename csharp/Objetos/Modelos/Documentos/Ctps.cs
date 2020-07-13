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
///     Carteira de Trabalho e Previdência Social - CTPS.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Constantes;
using Objetos.Modelos.Enderecos;
using System;

namespace Objetos.Modelos.Documentos
{
    public class Ctps
    {
        public int NumeroCtps { get; set; }
        public string SerieCtps { get; set; }
        public string TipoCtps { get; set; }
        public DateTime DataEmissaoCtps { get; set; }
        public Municipio MunicipioCtps { get; set; }
        public UF UfCtps { get; set; }


        public Ctps()
        {

        }

        public Ctps(int numeroCtps, string serieCtps, string tipoCtps, DateTime dataEmissaoCtps, Municipio municipioCtps, UF ufCtps)
        {
            NumeroCtps = numeroCtps;
            SerieCtps = serieCtps;
            TipoCtps = tipoCtps;
            DataEmissaoCtps = dataEmissaoCtps;
            MunicipioCtps = municipioCtps;
            UfCtps = ufCtps;
        }

        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return NumeroCtps.ToString() + sep
                + SerieCtps + sep
                + TipoCtps + sep
                + DataEmissaoCtps + sep
                + MunicipioCtps.CodigoMunicipio + sep
                + UfCtps.IdUf;
        }
    }
}
