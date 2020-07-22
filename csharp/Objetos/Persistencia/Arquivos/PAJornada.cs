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
///     Persistencia em arquivo para Jornada de Trabalho.
///     Criação : Vovolinux
///     Data    : 20/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Interfaces;
using Objetos.Modelos.Folha;
using Objetos.Utilitarios;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAJornada : ICRUD<JornadaDeTrabalho>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private JornadaDeTrabalho jornada = null;
        private List<JornadaDeTrabalho> jornadas = null;
        private List<JornadaDeTrabalho> jornadasRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAJornada()
        {
            controleArquivo = new Arquivo("JornadaDeTrabalho", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(JornadaDeTrabalho jornadaDeTrabalho)
        {
            try
            {
                jornadaDeTrabalho.IdJornada = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(jornadaDeTrabalho.ToString());
                return jornadaDeTrabalho.IdJornada;
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion CREATE

        #region READ

        public JornadaDeTrabalho Buscar(long idJornada)
        {
            try
            {
                foreach (JornadaDeTrabalho jornadaDeTrabalho in Consultar())
                    if (jornadaDeTrabalho.IdJornada == idJornada)
                        return jornadaDeTrabalho;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<JornadaDeTrabalho> Consultar()
        {
            try
            {
                jornadasRetorno = new List<JornadaDeTrabalho>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    jornadasRetorno.Add(ToObject(linha));

                return jornadasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }
        public List<JornadaDeTrabalho> Consultar(object parametro, string atributo)
        {
            try
            {
                jornadas = Consultar();
                jornadasRetorno = new List<JornadaDeTrabalho>();
                jornada = new JornadaDeTrabalho();

                switch (atributo)
                {
                    case "atributo":
                        foreach (JornadaDeTrabalho jornadaDeTrabalho in jornadas)
                            if (jornadaDeTrabalho.atributo.Equals(parametro))
                                jornadasRetorno.Add(jornadaDeTrabalho);
                        break;

                    default:
                        break;
                }
                return jornadasRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public JornadaDeTrabalho ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(SeparadorSplit);
                jornada = new JornadaDeTrabalho();
                jornada.IdJornada = long.Parse(partes[0]);

                return jornada;
            }
            catch (Exception ex)
            {
                throw new Exception("pef" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(JornadaDeTrabalho jornadaDeTrabalho)
        {
            try
            {
                foreach (JornadaDeTrabalho jornada in Consultar())
                    if (jornada.IdJornada == jornadaDeTrabalho.IdJornada)
                    {
                        controleArquivo.SubstituirLinha(jornada.ToString(), jornadaDeTrabalho.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(long idJornada)
        {
            try
            {
                foreach (JornadaDeTrabalho jornadaDeTrabalho in Consultar())
                    if (jornadaDeTrabalho.IdJornada == idJornada)
                    {
                        controleArquivo.ExcluirLinha(jornadaDeTrabalho.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("ent" + SeparadorTraco + "007" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
