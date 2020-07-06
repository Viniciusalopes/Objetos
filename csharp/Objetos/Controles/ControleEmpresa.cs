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

using Empresas;
using Objetos.Interfaces;
using System;
using System.Collections.Generic;

namespace Objetos.Controles
{
    public class ControleEmpresa : ICRUD<Empresa>
    {
        public void Atualizar(Empresa empresa)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Atualizar)");
        }

        public Empresa Buscar(int idEmpresa)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Buscar)");
        }

        public List<Empresa> Consultar()
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Consultar)");
        }

        public List<Empresa> Consultar(object parametro)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Consultar)");
        }

        public void Excluir(int idEmpresa)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Excluir)");
        }

        public void Incluir(Empresa empresa)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-Incluir)");
        }

        public Empresa ToObject(string texto)
        {
           throw new Exception(new System.NotImplementedException().Message + " (ControleEmpresa-ToObject)");
        }
    }
}
