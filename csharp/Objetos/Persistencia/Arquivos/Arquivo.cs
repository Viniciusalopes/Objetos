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
///     Modelo de arquivo em disco.
///     Criação : Vovolinux
///     Data    : 30/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.IO;
using static Objetos.Utilitarios.ArquivoUtils;

namespace Objetos.Persistencia.Arquivos
{
    public class Arquivo
    {
        #region ATRIBUTOS

        private string caminhoArquivo = "";

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Arquivo()
        {

        }

        public Arquivo(string caminhoCompleto)
        {
            try
            {
                garantirArquivo(caminhoCompleto);
                this.caminhoArquivo = caminhoCompleto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Arquivo(string diretorioArquivo, string nomeArquivo)
        {
            try
            {
                garantirDiretorio(diretorioArquivo);
                garantirArquivo(diretorioArquivo + nomeArquivo);
                caminhoArquivo = diretorioArquivo + nomeArquivo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion CONSTRUTORES

        #region GET / SET
        public string CaminhoArquivo
        {
            get { return caminhoArquivo; }
            set
            {
                try
                {
                    garantirArquivo(value);
                    caminhoArquivo = value;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion GET / SET

        #region LEITOR

        public string[] LerLinhas()
        {
            try
            {
                garantirArquivo(caminhoArquivo);
                return File.ReadAllLines(caminhoArquivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion LEITOR


        #region ESCRITOR

        public void EscreverLinhas(string[] linhas)
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                    File.Delete(caminhoArquivo);

                // Converte o Array em string
                string texto = "";
                foreach (string linha in linhas)
                    texto += linha + Environment.NewLine;

                StreamWriter sw = File.CreateText(caminhoArquivo);
                sw.WriteLine(texto);
                sw.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IncluirLinha(string texto)
        {
            try
            {
                garantirArquivo(caminhoArquivo);
                StreamWriter sw = File.AppendText(caminhoArquivo);
                sw.WriteLine(texto);
                sw.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SubstituirLinha(string referencia, string novoValor)
        {
            try
            {
                string[] linhas = LerLinhas();
                string[] novasLinhas = new string[linhas.Length];

                for (int i = 0; i < linhas.Length; i++)
                {
                    novasLinhas[i] = (linhas[i].Contains(referencia)) ? (referencia + novoValor) : linhas[i];
                }

                File.WriteAllLines(caminhoArquivo, novasLinhas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExcluirArquivo()
        {
            try
            {
                if (File.Exists(caminhoArquivo))
                    File.Delete(caminhoArquivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion ESCRITOR

        #region VALIDAÇÃO

        private void garantirDiretorio(string caminho)
        {
            validarNomeDiretorio(caminho);
            criarDiretorio(caminho);
        }

        private void garantirArquivo(string caminhoArquivo)
        {
            validarNomeArquivo(caminhoArquivo);
            criarArquivo(caminhoArquivo);
        }

        #endregion VALIDAÇÃO
    }
}
