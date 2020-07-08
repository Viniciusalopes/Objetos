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
using Objetos.Constantes;
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

        public static List<Mensagem> Mensagens
        {
            get
            {
                char sep = ConstantesGerais.SeparadorTraco;
                mensagens = new List<Mensagem>();
                int i = 0;

                // Persistencia > Arquivos > Arquivo.cs
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "001", "Erro ao construir o objeto Arquivo pelo caminho completo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "002", "Erro ao construir o objeto Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "003", "Erro ao obter o caminho do Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "004", "Erro ao ler as linhas do Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "005", "Erro ao escrever as linhas no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "006", "Erro ao incluir a linha no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "007", "Erro ao substituir a linha no Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "008", "Erro ao excluir a linha do Arquivo!"));
                i++; mensagens.Add(new Mensagem(i, "arq" + sep + "009", "Erro ao construir o objeto Arquivo com configuração de persistência!"));

                // Persistencia > Arquivos > PACnae.cs
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "001", "Erro ao incluir o CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "002", "Erro ao buscar o CNAE pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "003", "Erro ao consultar os CNAEs!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "004", "Erro ao consultar os CNAEs!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "005", "Erro ao converter texto para objeto CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "006", "Erro ao atualizar o CNAE!"));
                i++; mensagens.Add(new Mensagem(i, "cnae" + sep + "007", "Erro ao excluir o CNAE!"));

                // Modelos > Documentos > Cnpj.cs
                i++; mensagens.Add(new Mensagem(i, "cnpj" + sep + "001", "CNPJ inválido!"));

                // Persistencia > Arquivos > PAColaboradoresSetor.cs
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "001", "Erro ao incluir o colaborador no setor!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "002", "Erro ao buscar o colaborador do setor pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "003", "Erro ao consultar os colaboradores do setor!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "004", "Erro ao consultar os colaboradores por setor!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "005", "Erro ao converter texto para objeto colaborador-do-setor!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "006", "Erro ao atualizar o colaborador do setor!"));
                i++; mensagens.Add(new Mensagem(i, "cos" + sep + "007", "Erro ao excluir o colaborador do setor!"));

                // Modelos > Documentos > Cpf.cs
                i++; mensagens.Add(new Mensagem(i, "cpf" + sep + "001", "O CPF deve ter 11 dígitos numéricos!"));
                i++; mensagens.Add(new Mensagem(i, "cpf" + sep + "002", "CFP inválido!"));

                // Persistencia > Arquivos > PAPessoaEmpresa.cs
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "001", "Erro ao incluir a empresa!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "002", "Erro ao buscar a empresa pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "003", "Erro ao consultar as empresas!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "004", "Erro ao consultar as empresas por CNPJ!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "005", "Erro ao converter texto para objeto empresa!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "006", "Erro ao atualizar a empresa!"));
                i++; mensagens.Add(new Mensagem(i, "emp" + sep + "007", "Erro ao excluir a empresa!"));

                // Utilitarios > GeradorID.cs
                i++; mensagens.Add(new Mensagem(i, "ger" + sep + "001", "Erro ao gerar o ID!"));

                // Persistencia > Arquivos > PAMunicipio.cs
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "001", "Erro ao incluir o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "002", "Erro ao buscar o município pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "003", "Erro ao consultar os municípios!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "004", "Erro ao consultar os municípios por nome!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "005", "Erro ao converter texto para objeto Município!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "006", "Erro ao atualizar o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "007", "Erro ao excluir o município!"));
                i++; mensagens.Add(new Mensagem(i, "mun" + sep + "008", "Erro ao consultar os municípios por UF!"));

                // Persistencia > Arquivos > PAPessoaFisica.cs
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "001", "Erro ao incluir a pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "002", "Erro ao buscar a pessoa física pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "003", "Erro ao consultar as pessoas físicas!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "004", "Erro ao consultar as pessoas físicas por nome!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "005", "Erro ao converter texto para objeto pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "006", "Erro ao atualizar a pessoa física!"));
                i++; mensagens.Add(new Mensagem(i, "pef" + sep + "007", "Erro ao excluir a pessoa física!"));

                // Persistencia > Arquivos > PAPessoaJuridica.cs
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "001", "Erro ao incluir a pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "002", "Erro ao buscar a pessoa jurídica pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "003", "Erro ao consultar as pessoas jurídicas!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "004", "Erro ao consultar as pessoas jurídicas por nome!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "005", "Erro ao converter texto para objeto pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "006", "Erro ao atualizar a pessoa jurídica!"));
                i++; mensagens.Add(new Mensagem(i, "pej" + sep + "007", "Erro ao excluir a pessoa jurídica!"));

                // Persistencia > Arquivos > PASetor.cs
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "001", "Erro ao incluir o setor!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "002", "Erro ao buscar o setor pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "003", "Erro ao consultar os setores!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "004", "Erro ao consultar os setores por nome!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "005", "Erro ao converter texto para objeto Setor!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "006", "Erro ao atualizar o setor!"));
                i++; mensagens.Add(new Mensagem(i, "set" + sep + "007", "Erro ao excluir o setor!"));

                // Modelos > Telefone.cs
                i++; mensagens.Add(new Mensagem(i, "tel" + sep + "001", "O número do telefone precisa ter no mínimo 8 dígitos e no máximo 11 dígitos!"));

                // Persistencia > Memoria > PMUF.cs
                i++; mensagens.Add(new Mensagem(i, "uf" + sep + "001", "Erro ao buscar a UF pelo id!"));
                i++; mensagens.Add(new Mensagem(i, "uf" + sep + "002", "Erro ao consultar os UFs por parâmetro!"));

                return mensagens;
            }
            set { mensagens = value; }
        }

        #endregion GET/SET
    }
}
