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
///     Gerador de ID único para persistência em arquivos.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Constantes;
using Objetos.Persistencia.Arquivos;
using System;
using static Objetos.Constantes.EnumEntidade;
using static Objetos.Controles.ControleMensagem;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Utilitarios
{
    public static class GeradorID
    {

        //package utilidades;
        //import controle.ControleArquivoTXT;
        //import enumeradores.EnumArquivosBd;
        //import interfaces.IArquivoTXT;
        //import telas.Vai;
        //import static utilidades.StringUtil.soTemNumeros;


        private static long id = 0;
        private static long maior = 0;
        private static string entidade = "";
        private static Arquivo controleArquivo = null;
        public static long getProximoID()
        {
            try
            {
                controleArquivo = new Arquivo("ID", ExtensaoArquivoBd, "");
                string[] linhas = controleArquivo.LerLinhas();

                if (linhas.Length == 0)
                    ReindexarTabelas(); // ReindexarTabelas() já atribui valor ao id.
                else
                    id = long.Parse(linhas[0].Split(SeparadorSplit)[0]);
                
                controleArquivo = new Arquivo("ID", ExtensaoArquivoBd, "");
                controleArquivo.EscreverLinhas(new string[] { id + 1 + "" });

                return id + 1;  // Retorna o próximo ID único não utilizado, ou o id do arquivo.

            }
            catch (Exception ex)
            {
                throw new Exception("ger" + SeparadorTraco + "001#Objeto: " + entidade + "" + SeparadorEnter + "Erro: " + MensagemCompleta(ex.Message));
            }
        }

        private static long ReindexarTabelas()
        {
            foreach (string objeto in Enum.GetNames(typeof(Entidade)))                                     // Para cada arqivo de dados
            {
                if (!objeto.Equals("Todas"))
                {
                    entidade = objeto;
                    controleArquivo = new Arquivo(objeto, ExtensaoArquivoBd, "");                                       // Controle de arquivo
                    foreach (string linha in controleArquivo.LerLinhas())                                   // Para cada linha do arquivo
                        if (linha.Trim().Length > 1 && linha.Contains(SeparadorSplit + ""))  // Verifica se o tem pelo menos uma coluna
                        {
                            string texto = linha.Split(SeparadorSplit)[0];                 // Armazena o texto com o ID do registro

                            if (texto.Trim().Length > 0)                                                    // Verifica se o texto não está vazio
                            {
                                bool numeral = long.TryParse(texto, out maior);                             // Converte o texto para inteiro
                                if (numeral)                                                                // Se o texto só tem números
                                {
                                    id = (maior > id) ? maior : id;                                         // Maior id encontrado
                                }
                            }
                        }
                }
            }
            return id;
        }
    }
}
