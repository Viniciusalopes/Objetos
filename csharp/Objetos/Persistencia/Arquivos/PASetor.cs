

using Empresas;
using Objetos.Constantes;
using Objetos.Controles;
using Objetos.Interfaces;
using Objetos.Modelos.Folha;
using System;
using System.Collections.Generic;
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
///     Persistência em arquivo para Setor de Empresa.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>
namespace Objetos.Persistencia.Arquivos
{
    public class PASetor : ICRUD<Setor>
    {
        #region ATRIBUTOS

        private NomesDiretorios diretorios = null;
        private NomesArquivos arquivos = null;
        private Arquivo controleArquivo = null;
        private ControleColaborador controleColaborador = null;

        private Setor setor = null;
        private List<Setor> setores = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PASetor()
        {
            diretorios = new NomesDiretorios();
            diretorios.DirRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            diretorios.DirHome = "\\Objetos\\";
            diretorios.DirDados = diretorios.DirFull + "Dados\\";
            diretorios.DirRelatorios = diretorios.DirFull + "Relatorios\\";

            arquivos = new NomesArquivos();
            arquivos.ArquivoDeDados = "Setor.bd";

            controleArquivo = new Arquivo(diretorios.DirDados, arquivos.ArquivoDeDados);
        }
        #endregion CONSTRUTORES


        #region CREATE

        public void Incluir(Setor setor)
        {
            try
            {
                controleArquivo.IncluirLinha(setor.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("set#001#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion CREATE

        #region READ

        public Setor Buscar(int idSetor)
        {
            try
            {
                foreach (Setor setor in Consultar())
                    if (setor.IdSetor == idSetor)
                        return setor;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("set#002#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Setor> Consultar()
        {
            try
            {
                setores = new List<Setor>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    setores.Add(ToObject(linha));

                return setores;
            }
            catch (Exception ex)
            {
                throw new Exception("set#003#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public List<Setor> Consultar(object parametro)
        {
            try
            {
                setores = new List<Setor>();
                setor = new Setor();
                bool retornar = false;
                string texto = null;

                #region ID DA PESSOA JURÍDICA E ID DO RESPONSÁVEL

                try { setor.ResponsavelSetor.idPessoa = (int)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Setor oSetor in Consultar())
                        if (oSetor.ResponsavelSetor.idPessoa == setor.ResponsavelSetor.idPessoa)
                            setores.Add(oSetor);

                    return setores;
                }

                #endregion ID DA PESSOA JURÍDICA E ID DO RESPONSÁVEL

                #region NOME DO SETOR E RESPONSÁVEL

                try { texto = (string)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (Setor oSetor in Consultar())
                        if (oSetor.NomeSetor.Equals(texto) || oSetor.ResponsavelSetor.NomePessoa.Equals(texto))
                            setores.Add(oSetor);

                    return setores;
                }

                #endregion NOME DO SETOR E RESPONSÁVEL

                return setores;
            }
            catch (Exception ex)
            {
                throw new Exception("set#004#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        public Setor ToObject(string texto)
        {
            try
            {
                controleColaborador = new ControleColaborador();
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                return new Setor(int.Parse(partes[0]), long.Parse(partes[1]), partes[2], controleColaborador.Buscar(int.Parse(partes[3])), null);
            }
            catch (Exception ex)
            {
                throw new Exception("set#005#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(Setor setor)
        {
            try 
            {
                foreach (Setor oSetor in Consultar())
                    if(oSetor.IdSetor == setor.IdSetor)
                    {
                        controleArquivo.SubstituirLinha(oSetor.ToString(), setor.ToString());
                        break;
                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception("set#006#Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion UPDATE

        #region DELETE

        public void Excluir(int idSetor)
        {
            try
            {
                foreach (Setor setor in Consultar())
                    if (setor.IdSetor == idSetor)
                    {
                        controleArquivo.ExcluirLinha(this.setor.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("set#007Camada: Persistência-Arquivos#Erro: " + ex.Message);
            }
        }

        #endregion DELETE
    }
}
