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
///     Tabela de mensagens para alertas.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System.Collections.Generic;
using Objetos.Modelos;
using Objetos.Modelos.Dados;

namespace Objetos.Persistencia.Memoria
{
    public static class TabelaMensagens
    {
        #region ATRIBUTOS

        private static List<Mensagem> mensagens = null;

        #endregion ATRIBUTOS

        #region GET/SET

        public static List<Mensagem> Tuplas
        {
            get
            {
                mensagens = new List<Mensagem>();
                int i = 0;

                // Persistencia > Arquivos > Arquivo.cs
                i++; mensagens.Add(new Mensagem(i, "arq#001", "Erro ao construir o objeto Arquivo pelo caminho completo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#002", "Erro ao construir o objeto Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#003", "Erro ao obter o caminho do Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#004", "Erro ao ler as linhas do Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#005", "Erro ao escrever as linhas no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#006", "Erro ao incluir a linha no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#007", "Erro ao substituir a linha no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq#008", "Erro ao excluir a linha do Arquivo!"));

                // Persistencia > Arquivos > PACnae.cs
                i++; mensagens.Add(new Mensagem(i, "cnae#001", "Erro ao incluir o CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#002", "Erro ao buscar o CNAE pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#003", "Erro ao consultar os CNAEs!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#004", "Erro ao consultar os CNAEs!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#005", "Erro ao converter texto para objeto CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#006", "Erro ao atualizar o CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae#007", "Erro ao excluir o CNAE!"));

                // Modelos > Documentos > Cnpj.cs
                i++; mensagens.Add(new Mensagem(i, "cnpj#001", "CNPJ inválido!"));

                // Modelos > Documentos > Cpf.cs
                i++; mensagens.Add(new Mensagem(i, "cpf#001", "O CPF deve ter 11 dígitos numéricos!"));
                i++; mensagens.Add(new Mensagem(i, "cpf#002", "CFP inválido!"));

                // Persistencia > Arquivos > PAMunicipio.cs
                i++; mensagens.Add(new Mensagem(i, "mun#001", "Erro ao incluir o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun#002", "Erro ao buscar o município pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "mun#003", "Erro ao consultar os municípios!"));
                i++; mensagens.Add(new Mensagem(i, "mun#004", "Erro ao consultar os municípios por nome!"));
                i++; mensagens.Add(new Mensagem(i, "mun#005", "Erro ao converter texto para objeto Município!"));
                i++; mensagens.Add(new Mensagem(i, "mun#006", "Erro ao atualizar o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun#007", "Erro ao excluir o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun#008", "Erro ao consultar os municípios por UF!"));

                // Persistencia > Arquivos > PAPessoaFisica.cs
                i++; mensagens.Add(new Mensagem(i, "pef#001", "Erro ao incluir a pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef#002", "Erro ao buscar a pessoa física pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "pef#003", "Erro ao consultar as pessoas físicas!"));
                i++; mensagens.Add(new Mensagem(i, "pef#004", "Erro ao consultar as pessoas físicas por nome!"));
                i++; mensagens.Add(new Mensagem(i, "pef#005", "Erro ao converter texto para objeto pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef#006", "Erro ao atualizar a pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef#007", "Erro ao excluir a pessoa física!"));

                // Persistencia > Arquivos > PAPessoaJuridica.cs
                i++; mensagens.Add(new Mensagem(i, "pef#001", "Erro ao incluir a pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pef#002", "Erro ao buscar a pessoa jurídica pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "pef#003", "Erro ao consultar as pessoas jurídicas!"));
                i++; mensagens.Add(new Mensagem(i, "pef#004", "Erro ao consultar as pessoas jurídicas por nome!"));
                i++; mensagens.Add(new Mensagem(i, "pef#005", "Erro ao converter texto para objeto pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pef#006", "Erro ao atualizar a pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pef#007", "Erro ao excluir a pessoa jurídica!"));

                // Modelos > Telefone.cs
                i++; mensagens.Add(new Mensagem(i, "tel#001", "O número do telefone precisa ter no mínimo 8 dígitos e no máximo 11 dígitos!"));

                // Persistencia > Memoria > PMUF.cs
                i++; mensagens.Add(new Mensagem(i, "uf#001", "Erro ao buscar a UF pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "uf#002", "Erro ao consultar os UFs por parâmetro!"));

                return mensagens;
            }
            set { mensagens = value; }
        }

        #endregion GET/SET
    }
}
