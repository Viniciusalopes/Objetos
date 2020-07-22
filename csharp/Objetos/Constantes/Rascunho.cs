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
///     Rascunho para criação de novas classes, interfaces, etc.
///     Criação : Vovolinux
///     Data    : 15/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System.Collections.Generic;
using Objetos.Persistencia.Arquivos;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Constantes
{
    class Rascunho
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        //private Entidade entidade = null;
        //private List<Entidade> entidades = null;
        //private List<Entidade> entidadesRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        //public PAEntidade()
        //{
        //    controleArquivo = new Arquivo("Entidade", ExtensaoArquivoBd, "");
        //}

        #endregion CONSTRUTORES

        #region GET/SET
        #endregion GET/SET

        #region GET
        #endregion GET

        #region SET
        #endregion SET

        #region VALIDAÇÃO
        #endregion VALIDAÇÃO

        #region CRUD

        //#region CREATE

        //public long Incluir(Entidade objeto)
        //{
        //    try
        //    {
        //        objeto.Id = GeradorID.getProximoID();
        //        controleArquivo.IncluirLinha(objeto.ToString());
        //        return objeto.Id;
        //    }
        //    catch(Exception ex)
        //    {
        //         throw new Exception("ent" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //    }
        //}

        //#endregion CREATE

        //#region READ

        //public Entidade Buscar(long id)
        //{
        //  try
        //  {
        //      foreach(Entidade entidade in Consultar())
        //          if(entidade.Id == id)
        //              return entidade;
        //
        //      return null;
        //  }
        //  catch(Exception ex)
        //  {
        //      throw new Exception("ent" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //  }
        //}

        //public List<Entidade> Consultar()
        //{
        //  try
        //  {
        //      entidades = new List<Entidade>();
        //      string[] linhas = controleArquivo.LerLinhas();
        //
        //      foreach (string linha in linhas)
        //      entidades.Add(ToObject(linha));
        //
        //      return entidades;
        //  }
        //      catch (Exception ex)
        //  {
        //        throw new Exception("ent" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //  }

        //public List<Entidade> Consultar(object parametro, string atributo)
        //{
        //  try
        //  {
        //      entidades = Consultar();
        //      entidadesRetorno = new List<Entidade>();
        //      entidade = new Entidade();
        //
        //      switch (atributo)
        //      {
        //          case "atributo":
        //              foreach (Entidade entidade in entidades)
        //                  if(entidade.atributo.Equals(parametro))
        //                      entidades.Add(entidade);
        //              break;
        //          
        //          default:
        //              break;
        //      }
        //      return entidades;
        //  }
        //  catch(Exception ex)
        //  {
        //      throw new Exception("ent" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //  }
        //}

        //public Entidade ToObject(string texto)
        //{
        //     try
        //     {
        //          string[] partes = texto.Split(SeparadorSplit);
        //          entidade = new Entidade();
        //          entidade.Id = long.Parse(partes[0]);
        //
        //          return pessoa;
        //      }
        //      catch (Exception ex)
        //      {
        //          throw new Exception("pef" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //      }
        //}

        //#endregion READ

        //#region UPDATE

        //public void Atualizar(Entidade objeto)
        //{
        //  try
        //  {
        //      foreach (Entidade entidade in Consultar())
        //          if (entidade.IdPessoa == objeto.Id)
        //              {
        //                  controleArquivo.SubstituirLinha(entidade.ToString(), objeto.ToString());
        //                  break;
        //              }
        //  }
        //  catch (Exception ex)
        //  {
        //      throw new Exception("ent" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //  }
        //}

        //#endregion UPDATE

        //#region DELETE

        //public void Excluir(long id)
        //{
        //  try
        //  {
        //      foreach (Entidade entidade in Consultar())
        //          if (entidade.IdPessoa == id)
        //              {
        //                  controleArquivo.ExcluirLinha(entidade.ToString());
        //                  break;
        //              }
        //  }
        //  catch (Exception ex)
        //  {
        //      throw new Exception("ent" + SeparadorTraco + "007" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
        //  }
        //}

        //#endregion DELETE

        #endregion CRUD

    }
}