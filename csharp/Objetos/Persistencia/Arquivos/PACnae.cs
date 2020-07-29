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
/////     Persistência em arquivo para CNAES de um CNPJ.
/////     Criação : Vovolinux
/////     Data    : 05/07/2020
/////     Projeto : Objetos genéricos para C#.
///// </summary>

//using static Objetos.Controles.ControleMensagem;
//using System;
//using System.Collections.Generic;
//using Objetos.Interfaces;
//using Objetos.Modelos.Documentos;
//using static Objetos.Constantes.EnumTipoCnae;
//using static Objetos.Constantes.EnumEntidade;
//using static Objetos.Constantes.ConstantesGerais;
//using Objetos.Utilitarios;

//namespace Objetos.Persistencia.Arquivos
//{
//    class PACnae : ICRUD<Cnae>
//    {
//        #region ATRIBUTOS

//        private Arquivo controleArquivo = null;

//        private Cnae cnae = null;
//        private List<Cnae> cnaes = null;

//        #endregion ATRIBUTOS

//        #region CONSTRUTORES

//        public PACnae()
//        {
//            controleArquivo = new Arquivo(Entidade.Cnae.ToString(), ExtensaoArquivoBd, "");
//        }
//        #endregion CONSTRUTORES


//        #region CREATE

//        public long Incluir(Cnae cnae)
//        {
//            try
//            {
//                cnae.IdCnae = GeradorID.getProximoID();
//                controleArquivo.IncluirLinha(cnae.ToString());
//                return cnae.IdCnae;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "001" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion CREATE

//        #region READ

//        public Cnae Buscar(long idCnae)
//        {
//            try
//            {
//                foreach (Cnae cnae in Consultar())
//                    if (cnae.IdCnae == idCnae)
//                        return cnae;

//                return null;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "002" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public List<Cnae> Consultar()
//        {
//            try
//            {
//                cnaes = new List<Cnae>();
//                string[] linhas = controleArquivo.LerLinhas();

//                foreach (string linha in linhas)
//                    cnaes.Add(ToObject(linha));

//                return cnaes;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "003" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public List<Cnae> Consultar(object parametro, string atributo)
//        {
//            try
//            {
//                cnaes = new List<Cnae>();
//                cnae = new Cnae();
//                bool retornar = false;
//                string texto = null;

//                #region ID DA PESSOA JURÍDICA

//                try { cnae.IdPessoa = (int)parametro; retornar = true; } catch (Exception) { retornar = false; }

//                if (retornar)
//                {
//                    foreach (Cnae oCnae in Consultar())
//                        if (oCnae.IdPessoa == (int)parametro)
//                            cnaes.Add(oCnae);

//                    return cnaes;
//                }

//                #endregion ID DA PESSOA JURÍDICA

//                #region CÓDIGO E DESCRIÇÃO

//                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

//                if (retornar)
//                {
//                    foreach (Cnae oCnae in Consultar())
//                        if (oCnae.CodigoCnae.Equals(texto) || oCnae.DescricaoCnae.Equals(texto))
//                            cnaes.Add(oCnae);

//                    return cnaes;
//                }

//                #endregion CÓDIGO E DESCRIÇÃO

//                #region TIPO DE CNAE

//                try { cnae.TipoCnae = (TipoCnae)parametro; retornar = true; } catch (Exception) { retornar = false; }

//                if (retornar)
//                {
//                    foreach (Cnae oCnae in Consultar())
//                        if (oCnae.TipoCnae.Equals((TipoCnae)parametro))
//                            cnaes.Add(oCnae);

//                    return cnaes;
//                }
//                #endregion TIPO DE CNAE

//                return cnaes;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "004" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        public Cnae ToObject(string texto)
//        {
//            try { 
//            string[] partes = texto.Split(SeparadorSplit);
//            return new Cnae(int.Parse(partes[0]), long.Parse(partes[1]), (TipoCnae)int.Parse(partes[2]), partes[3], partes[4]);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "005" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion READ

//        #region UPDATE

//        public void Atualizar(Cnae cnae)
//        {
//            try
//            {
//                foreach (Cnae oCnae in Consultar())
//                    if (oCnae.IdCnae == cnae.IdCnae)
//                    {
//                        controleArquivo.SubstituirLinha(oCnae.ToString(), cnae.ToString());
//                        break;
//                    }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "006" + SeparadorEnter + "Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion UPDATE

//        #region DELETE

//        public void Excluir(long idCnae)
//        {
//            try
//            {
//                foreach (Cnae cnae in Consultar())
//                    if (cnae.IdCnae == idCnae)
//                    {
//                        controleArquivo.ExcluirLinha(cnae.ToString());
//                        break;
//                    }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("cnae" + SeparadorTraco + "007Camada: Persistência-Arquivos" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
//            }
//        }

//        #endregion DELETE
//    }
//}
