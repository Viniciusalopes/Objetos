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
///     Persistência em arquivo para Endereco.
///     Criação : Vovolinux
///     Data    : 15/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Interfaces;
using Objetos.Modelos.Empresas;
using Objetos.Modelos.Enderecos;
using Objetos.Persistencia.Arquivos;
using static Objetos.Constantes.ConstantesGerais;

namespace Objetos.Persistencia.Arquivos
{
    public class PAEndereco : ICRUD<Endereco>
    {
        #region ATRIBUTOS

        private Arquivo controleArquivo = null;

        private Endereco endereco = null;
        private List<Endereco> enderecos = null;
        private List<Endereco> enderecosRetorno = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public PAEndereco()
        {
            controleArquivo = new Arquivo("Endereco", ExtensaoArquivoBd, "");
        }

        #endregion CONSTRUTORES


        public void Atualizar(Endereco objeto)
        {
            throw new NotImplementedException();
        }

        public Endereco Buscar(long id)
        {
            throw new NotImplementedException();
        }

        public List<Endereco> Consultar()
        {
            throw new NotImplementedException();
        }

        public List<Endereco> Consultar(object parametro, string atributo)
        {
            throw new NotImplementedException();
        }

        public void Excluir(long id)
        {
            throw new NotImplementedException();
        }

        public long Incluir(Endereco objeto)
        {
            throw new NotImplementedException();
        }

        public Endereco ToObject(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
