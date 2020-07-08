
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
///     Persistência em arquivo para Colaboradores de um Setor.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>
using static Objetos.Controles.ControleMensagem;
using Objetos.Constantes;
using Objetos.Interfaces;
using Objetos.Modelos.Folha;
using Objetos.Utilitarios;
using System;
using System.Collections.Generic;

namespace Objetos.Persistencia.Arquivos
{
    public class PAColaboradoresSetor : ICRUD<ColaboradoresSetor>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        //private ColaboradoresSetor colaborador = null;
        private List<ColaboradoresSetor> colaboradores = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAColaboradoresSetor()
        {
            controleArquivo = new Arquivo("ColaboradoresSetor", "pho", "");
        }

        #endregion CONSTRUTORES

        public void Incluir(ColaboradoresSetor colaboradorSetor)
        {
            try
            {
                colaboradorSetor.IdColaboradorSetor = GeradorID.getProximoID();
                controleArquivo.IncluirLinha(colaboradorSetor.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "001#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #region READ

        public ColaboradoresSetor Buscar(long idColaborador)
        {
            try
            {
                foreach (ColaboradoresSetor colaboradorSetor in Consultar())
                    if (colaboradorSetor.IdColaborador == idColaborador)
                        return colaboradorSetor;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "002#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<ColaboradoresSetor> Consultar()
        {
            try
            {
                colaboradores = new List<ColaboradoresSetor>();
                string[] linhas = controleArquivo.LerLinhas();

                foreach (string linha in linhas)
                    colaboradores.Add(ToObject(linha));

                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "003#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public List<ColaboradoresSetor> Consultar(object idSetor)
        {
            try {
                colaboradores = new List<ColaboradoresSetor>();
                bool retornar = false;
                long id = 0;

                try { id = (long)idSetor; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (ColaboradoresSetor colaborador in Consultar())
                        if (colaborador.IdSetor == (long)idSetor)
                            colaboradores.Add(colaborador);

                    return colaboradores;
                }
                return colaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "004#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        public ColaboradoresSetor ToObject(string texto)
        {
            try
            {
                string[] partes = texto.Split(ConstantesGerais.SeparadorSplit);
                return new ColaboradoresSetor(long.Parse(partes[0]), long.Parse(partes[1]), long.Parse(partes[2]));
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "005#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion READ

        #region UPDATE

        public void Atualizar(ColaboradoresSetor colaboradorSetor)
        {
            try {
                foreach (ColaboradoresSetor colaborador in Consultar())
                    if(colaborador.IdColaboradorSetor == colaboradorSetor.IdColaboradorSetor)
                    {
                        controleArquivo.SubstituirLinha(colaborador.ToString(), colaboradorSetor.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "006#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }
        #endregion UPDATE

        #region DELETE

        public void Excluir(long idColaboradorSetor)
        {
            try
            {
                foreach (ColaboradoresSetor colaborador in Consultar())
                    if (colaborador.IdColaboradorSetor == idColaboradorSetor)
                    {
                        controleArquivo.ExcluirLinha(colaborador.ToString());
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("cos" + ConstantesGerais.SeparadorTraco + "007#Camada: Persistência-Arquivos#Erro: " + MensagemCompleta(ex.Message));
            }
        }

        #endregion DELETE
    }
}
