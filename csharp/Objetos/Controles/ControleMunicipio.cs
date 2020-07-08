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
///     Controller para Municipio.
///     Criação : Vovolinux
///     Data    : 30/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
using Objetos.Persistencia.Arquivos;
using System;
using System.Collections.Generic;

namespace Objetos.Controles
{
    public class ControleMunicipio : ICRUD<Municipio>
    {
        #region ATRIBUTOS

        private PAMunicipio persistencia = null;
        
        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ControleMunicipio()
        {
            persistencia = new PAMunicipio();
        }

        #endregion CONSTRUTORES

        #region CREATE
  
        public void Incluir(Municipio municipio)
        {
            persistencia.Incluir(municipio);
        }
        
        #endregion CREATE

        #region READ
        
        public Municipio Buscar(long codigoMunicipio)
        {
            return persistencia.Buscar(codigoMunicipio);
        }

        public List<Municipio> Consultar()
        {
            return persistencia.Consultar();
        }

        public List<Municipio> Consultar(object parametro)
        {
            return persistencia.Consultar(parametro);
        }

        public Municipio ToObject(string texto)
        {
            return persistencia.ToObject(texto);
        }
        
        #endregion READ

        #region UPDATE
        
        public void Atualizar(Municipio municipio)
        {
            persistencia.Atualizar(municipio);
        }
        
        #endregion UPDATE

        #region DELETE
        
        public void Excluir(long codigoMunicipio)
        {
            persistencia.Excluir(codigoMunicipio);
        }
        
        #endregion DELETE



        
    }
}
