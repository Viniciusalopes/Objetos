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
///     Estatísticas para municípios segundo o IBGE: https://www.ibge.gov.br/cidades-e-estados.html?view=municipio
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

namespace Objetos.Modelos.Ibge
{
    public class DadosIbge
    {
        public string GentilicoMunicipio { get; set; }
        public Prefeito PrefeitoMunicipio { get; set; }
        public AreaTerritorial AreaTerritorialMunicipio { get; set; }
        public PopulacaoEstimada PopulacaoEstimadaMunicipio { get; set; }
        public DensidadeDemografica DensidadeMunicipio { get; set; }
        public Escolarizacao6a14 Escolarizacao6a14Municipio { get; set; }
        public Idh IdhMunicipio { get; set; }
        public MortalidadeInfantil MortalidadeInfantilMunicipio { get; set; }
        public ReceitasRealizadas ReceitasRealizadasMunicipio { get; set; }
        public DespesasEmpenhadas DespesasEmpenhadasMunicipio { get; set; }
        public Pib PibPerCapitaMunicipio { get; set; }
    }
}
