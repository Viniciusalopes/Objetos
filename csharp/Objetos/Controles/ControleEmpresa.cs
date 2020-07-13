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
///     Controller para Empresa.
///     Criação : Vovolinux
///     Data    : 05/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Modelos.Empresas;
using Objetos.Interfaces;
using System;
using System.Collections.Generic;
using Objetos.Persistencia.Arquivos;

namespace Objetos.Controles
{
    public class ControleEmpresa : ICRUD<Empresa>
    {

        #region ATRIBUTOS

        private PAEmpresa persistencia = null;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ControleEmpresa()
        {
            persistencia = new PAEmpresa();
        }

        #endregion CONSTRUTORES

        #region CREATE

        public long Incluir(Empresa empresa)
        {
            return persistencia.Incluir(empresa);
        }

        #endregion CREATE

        #region READ

        public Empresa Buscar(long idEmpresa)
        {
            return persistencia.Buscar(idEmpresa);
        }

        public List<Empresa> Consultar()
        {
            return persistencia.Consultar();
        }

        public List<Empresa> Consultar(object parametro, string atributo)
        {
            return persistencia.Consultar(parametro, atributo);
        }

        public Empresa ToObject(string texto)
        {
            return persistencia.ToObject(texto);
        }
        
        #endregion READ

        #region UPDATE

        public void Atualizar(Empresa empresa)
        {
            persistencia.Atualizar(empresa);
        }
        
        #endregion UPDATE

        #region DELETE

        public void Excluir(long idEmpresa)
        {
            persistencia.Excluir(idEmpresa);
        }
        
        #endregion DELETE
    }
}