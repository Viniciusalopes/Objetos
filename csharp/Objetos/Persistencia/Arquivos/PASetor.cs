///// <licenca>
/////     Licença MIT
/////     Copyright(c) 2020 Viniciusalopes Tecnologia
/////     
/////     A permissão é concedida, gratuitamente, a qualquer pessoa que obtenha uma cópia deste software e dos 
/////     arquivos de documentação associados (o "Software"), para negociar no Software sem restrições, 
/////     incluindo, sem limitação, os direitos de uso, cópia, modificação, fusão, publicar, distribuir, 
/////     sublicenciar e/ou vender cópias do Software e permitir que as pessoas a quem o Software é fornecido 
/////     o façam, sob as seguintes condições:
/////     
/////     O aviso de direitos autorais acima e este aviso de permissão devem ser incluídos em todas as cópias 
/////     ou partes substanciais do Software.
/////     
/////     O SOFTWARE É FORNECIDO "TAL COMO ESTÁ", SEM GARANTIA DE QUALQUER TIPO, EXPRESSA OU IMPLÍCITA, 
/////     INCLUINDO MAS NÃO SE LIMITANDO A GARANTIAS DE COMERCIALIZAÇÃO, ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA 
/////     E NÃO INFRAÇÃO. EM NENHUM CASO OS AUTORES OU TITULARES DE DIREITOS AUTORAIS SERÃO RESPONSÁVEIS POR 
/////     QUALQUER REIVINDICAÇÃO, DANOS OU OUTRA RESPONSABILIDADE, SEJA EM AÇÃO DE CONTRATO, TORT OU OUTRA 
/////     FORMA, PROVENIENTE, FORA OU EM CONEXÃO COM O SOFTWARE OU O USO, OU OUTROS ACORDOS NOS PROGRAMAS.
///// </licenca>
///// <summary>
/////     Persistência em arquivo para Setor de Empresa.
/////     Criação : Vovolinux
/////     Data    : 05/07/2020
/////     Projeto : Objetos genéricos para C#.
///// </summary>

//using Objetos.Modelos.Empresas;
//using Objetos.Constantes;
//using Objetos.Controles;
//using Objetos.Interfaces;
//using System;
//using System.Collections.Generic;
//using Objetos.Utilitarios;
//using static Objetos.Controles.ControleMensagem;
//using static Objetos.Constantes.ConstantesGerais;
//using Objetos.Modelos.Folha;

//namespace Objetos.Persistencia.Arquivos
//{
//    class PASetor : ICRUD<Setor>
//    {
//        #region ATRIBUTOS

//        private Arquivo controleArquivo = null;

//        private Setor setor = null;
//        private List<Setor> setores = null;
//        private List<Setor> setoresRetorno = null;

//        #endregion ATRIBUTOS

//        #region CONSTRUTORES

//        public PASetor()
//        {
//            controleArquivo = new Arquivo("Setor", ExtensaoArquivoBd, "");
//        }
//        #endregion CONSTRUTORES


//        #region CREATElong

//        public long Incluir(Setor setor)
//        {
//            try
//            {
//                setor.IdSetor = GeradorID.getProximoID();
//                controleArquivo.IncluirLinha(setor.ToString());
//                return setor.IdSetor;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion CREATE

//        #region READ

//        public Setor Buscar(long idSetor)
//        {
//            try
//            {
//                foreach (Setor setor in Consultar())
//                    if (setor.IdSetor == idSetor)
//                        return setor;

//                return null;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public List<Setor> Consultar()
//        {
//            try
//            {
//                setoresRetorno = new List<Setor>();
//                string[] linhas = controleArquivo.LerLinhas();

//                foreach (string linha in linhas)
//                    setoresRetorno.Add(ToObject(linha));

//                return setoresRetorno;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public List<Setor> Consultar(object parametro, string atributo)
//        {
//            try
//            {
//                setores = Consultar();
//                setoresRetorno = new List<Setor>();

//                // Retorna vazio se não informar o atributo
//                if (atributo.Trim().Length == 0)
//                    return setoresRetorno;

//                string texto = null;
//                long id = 0;

//                switch (atributo)
//                {
//                    case "IdEmpresa":
//                        id = (long)parametro;
//                        foreach (Setor setor in setores)
//                            if (setor.IdEmpresa == id)
//                                setoresRetorno.Add(setor);

//                        break;

//                    case "NomeSetor":
//                        texto = (string)parametro;
//                        foreach (Setor setor in setores)
//                            if (setor.NomeSetor.Equals(texto))
//                                setoresRetorno.Add(setor);
                        
//                        break;

//                    case "idResponsavelSetor":
//                        id = (long)parametro;
//                        foreach (Setor setor in setores)
//                            if (setor.ResponsavelSetor.IdColaborador == id)
//                                setoresRetorno.Add(setor);

//                        break;

//                    case "nomeResponsavelSetor":
//                        texto = (string)parametro;
//                        foreach (Setor setor in setores)
//                            if (setor.ResponsavelSetor.NomePessoa.Equals(texto))
//                                setoresRetorno.Add(setor);

//                        break;

//                    default:
//                        break;
//                }

//                return setoresRetorno;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public Setor ToObject(string texto)
//        {
//            try
//            {
//                string[] partes = texto.Split(SeparadorSplit);
//                long idSetor = long.Parse(partes[0]);
//                PAColaborador paColaborador = new PAColaborador();
//                List<Colaborador> colaboradores = paColaborador.Consultar(idSetor, "IdSetor");
//                return new Setor(idSetor, long.Parse(partes[1]), partes[2], paColaborador.Buscar(long.Parse(partes[3])), colaboradores);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion READ

//        #region UPDATE

//        public void Atualizar(Setor setor)
//        {
//            try
//            {
//                foreach (Setor oSetor in Consultar())
//                    if (oSetor.IdSetor == setor.IdSetor)
//                    {
//                        controleArquivo.SubstituirLinha(oSetor.ToString(), setor.ToString());
//                        break;
//                    }

//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion UPDATE

//        #region DELETE

//        public void Excluir(long idSetor)
//        {
//            try
//            {
//                foreach (Setor setor in Consultar())
//                    if (setor.IdSetor == idSetor)
//                    {
//                        controleArquivo.ExcluirLinha(this.setor.ToString());
//                        break;
//                    }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("set" + SeparadorTraco + "007Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion DELETE
//    }
//}
