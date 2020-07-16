﻿
using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
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
///     Controller para Endereco.
///     Criação : Vovolinux
///     Data    : 15/07/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>
namespace Objetos.Controles
{
    public class ControleEndereco : ICRUD<Endereco>
    {
        public void Atualizar(Endereco objeto)
        {
            throw new System.NotImplementedException();
        }

        public Endereco Buscar(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<Endereco> Consultar()
        {
            throw new System.NotImplementedException();
        }

        public List<Endereco> Consultar(object parametro, string atributo)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(long id)
        {
            throw new System.NotImplementedException();
        }

        public long Incluir(Endereco objeto)
        {
            throw new System.NotImplementedException();
        }

        public Endereco ToObject(string texto)
        {
            throw new System.NotImplementedException();
        }
    }
}