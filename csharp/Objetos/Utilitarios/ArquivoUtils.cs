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
///     Utilitários para manipulação de arquivos.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.IO;
using static Objetos.Constantes.ConstantesGerais;
namespace Objetos.Utilitarios
{
    public static class ArquivoUtils
    {
        public static void validarNomeDiretorio(string caminho)
        {
            if (caminho.Trim().Length < 3)
                throw new Exception("arq" + SeparadorTraco + "001");
        }
        public static void validarNomeArquivo(string nomeArquivo)
        {
            if (nomeArquivo.Trim().Length == 0)
                throw new Exception("arq" + SeparadorTraco + "002");
        }

        public static void criarDiretorio(string caminho)
        {
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);
        }

        public static void criarArquivo(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
                File.Create(caminhoArquivo).Close();
            
        }
        /// <summary>
        ///     Lista os arquivos do diretório e dos sub-diretórios.
        ///     FONTE: https://social.msdn.microsoft.com/Forums/pt-BR/3c784a0b-c5fb-4a27-b74f-54c05f90b9ab/ler-todos-os-arquivos-do-diretorio-selecionado?forum=vscsharppt
        /// </summary>
        /// <param name="dir"></param>
        /// <returns> Lista de FileInfo. </returns>
        public static List<FileInfo> arquivosDoDiretorio(DirectoryInfo dir, List<FileInfo> lista)
        {
            List<FileInfo> retorno = (lista == null) ? new List<FileInfo>() : lista;

            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
                retorno.Add(file);

            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
                arquivosDoDiretorio(subDir, retorno);

            return retorno;
        }
    }
}
