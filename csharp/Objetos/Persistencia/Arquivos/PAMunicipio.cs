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
///     Persistência em arquivo para Municipio.
///     Criação : Vovolinux
///     Data    : 29/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
using Objetos.Constantes;
using System;
using System.Collections.Generic;

namespace Objetos.Persistencia.Arquivos
{
    public class PAMunicipio : ICRUD<Municipio>
    {
        #region ATRIBUTOS

        private NomesDiretorios diretorios = null;
        private NomesArquivos arquivos = null;
        private Arquivo controleArquivo = null;

        private Municipio municipio = null;
        private List<Municipio> municipios = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        public PAMunicipio()
        {
            diretorios = new NomesDiretorios();
            diretorios.DirRoot = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            diretorios.DirHome = "\\Objetos\\";
            diretorios.DirDados = diretorios.DirFull + "Dados\\";
            diretorios.DirRelatorios = diretorios.DirFull + "Relatorios\\";

            arquivos = new NomesArquivos();
            arquivos.ArquivoDeDados = "Municipio.bd";

            controleArquivo = new Arquivo(diretorios.DirDados, arquivos.ArquivoDeDados);
        }
        #endregion CONSTRUTORES
        public void Atualizar(Municipio objeto)
        {
            throw new System.NotImplementedException();
        }

        public Municipio Buscar(int id)
        {
            string[] linhas = controleArquivo.LerLinhas();
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(ConstantesGerais.SeparadorSplit);
                int codigo = int.Parse(partes[0]);
                if(codigo == id)
                {
                    municipio = new Municipio(codigo, partes[1]);
                    return municipio;
                }
            }
            return null;
        }

        public Municipio Buscar(object objeto)
        {
            throw new System.NotImplementedException();
        }

        public Municipio Consultar()
        {
            throw new System.NotImplementedException();
        }

        public List<Municipio> Consultar(Municipio objeto)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Municipio objeto)
        {
            throw new System.NotImplementedException();
        }

        public Municipio ToObject(string texto)
        {
            throw new System.NotImplementedException();
        }

        public string ToString(Municipio objeto)
        {
            throw new System.NotImplementedException();
        }
    }
}
