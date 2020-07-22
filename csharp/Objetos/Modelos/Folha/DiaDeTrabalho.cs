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
///     Dia de trabalho da Jornada de um Colaborador de uma empresa, do ponto de vista da Folha de Pagamento.
///     Criação : Vovolinux
///     Data    : 19/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Constantes.EnumDiasDaSemana;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Modelos.Folha
{
    public class DiaDeTrabalho
    {
        public long IdDiaDeTrabalho { get; set; }
        public long IdJornada { get; set; }
        public DiaDaSemana DiaDaSemana { get; set; }

        public DiaDeTrabalho()
        {

        }

        public DiaDeTrabalho(long idDiaDeTrabalho, long idJornada, DiaDaSemana diaDaSemana)
        {
            IdDiaDeTrabalho = idDiaDeTrabalho;
            IdJornada = idJornada;
            DiaDaSemana = diaDaSemana;
        }

        public override string ToString()
        {
            return IdDiaDeTrabalho.ToString()
                + SeparadorSplit + IdJornada.ToString()
                + SeparadorSplit + (int)DiaDaSemana;
        }
    }
}
