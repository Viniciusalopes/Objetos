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
///     Colaborador de uma empresa, do ponto de vista da Folha de Pagamento.
///     Criação : Vovolinux
///     Data    : 29/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Constantes;
using Objetos.Modelos.Pessoas;
using System;
using System.Collections.Generic;

namespace Objetos.Modelos.Folha
{
    public class Colaborador : PessoaFisica
    {
        public long IdColaborador { get; set; }
        public long IdEmpresa { get; set; }
        public long IdSetor { get; set; }
        public int MatriculaColaborador { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public JornadaDeTrabalho JornadaColaborador { get; set; }
        public List<FolhaDePonto> FolhasDePontoColaborador { get; set; }
        public List<Ferias> FeriasColaborador { get; set; }
        public List<Afastamento> AfastamentosColaborador { get; set; }
        public List<Licenca> LicencasColaborador { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(
            long idColaborador,
            long idPessoa,
            long idEmpresa,
            long idSetor,
            int matriculaColaborador,
            DateTime dataAdmissao,
            DateTime dataDemissao,
            JornadaDeTrabalho jornadaColaborador
            )
        {
            IdColaborador = idColaborador;
            IdPessoa = idPessoa;
            IdEmpresa = idEmpresa;
            IdSetor = idSetor;
            MatriculaColaborador = matriculaColaborador;
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
            JornadaColaborador = jornadaColaborador;
        }

        public override string ToString()
        {
            char sep = ConstantesGerais.SeparadorSplit;
            return IdColaborador.ToString() + sep
                + IdPessoa + sep
                + IdEmpresa + sep
                + IdSetor + sep
                + MatriculaColaborador + sep
                + DataAdmissao.ToString() + sep
                + DataDemissao.ToString() + sep
                + ((JornadaColaborador == null) ? sep+"" : JornadaColaborador.IdJornada.ToString());
        }
    }
}
