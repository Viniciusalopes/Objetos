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
///     Endereço.
///     Criação : Vovolinux
///     Data    : 28/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using static Objetos.Constantes.ConstantesGerais;
using static Objetos.Constantes.EnumTipoEnderecoTelefoneEmail;

namespace Objetos.Modelos.Enderecos
{
    public class Endereco
    {
  
        public long IdEndereco { get; set; }
        public long IdPessoa { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Cep { get; set; }
        public string SetorBairroDistrito { get; set; }
        public Municipio oMunicipio { get; set; }
        public UF oUF { get; set; }
        public TipoEnderecoTelefoneEmail TipoEndereco { get; set; }

        public Endereco()
        {
            oMunicipio = new Municipio();
            oUF = new UF();
        }

        public Endereco(
            long idEndereco,
            long idPessoa,
            string logradouro,
            int numero,
            string complementoEndereco,
            string cep,
            string setorBairroDistrito,
            Municipio municipio,
            UF uf,
            TipoEnderecoTelefoneEmail tipoEndereco
            )
        {
            IdEndereco = idEndereco;
            IdPessoa = idPessoa;
            Logradouro = logradouro;
            Numero = numero;
            ComplementoEndereco = complementoEndereco;
            Cep = cep;
            SetorBairroDistrito = setorBairroDistrito;
            oMunicipio = municipio;
            oUF = uf;
            TipoEndereco = tipoEndereco;
        }

        public override string ToString()
        {
            char sep = SeparadorSplit;
            return IdEndereco.ToString()
                + sep + IdPessoa + sep
                + sep + ((string.IsNullOrEmpty(Logradouro)) ? "" : Logradouro)
                + sep + Numero
                + sep + ((string.IsNullOrEmpty(ComplementoEndereco)) ? "" : ComplementoEndereco)
                + sep + ((string.IsNullOrEmpty(Cep)) ? "" : Cep)
                + sep + ((string.IsNullOrEmpty(SetorBairroDistrito)) ? "" : SetorBairroDistrito)
                + sep + ((oMunicipio == null) ? "" : oMunicipio.CodigoMunicipio.ToString())
                + sep + ((oUF == null) ? "" : oUF.IdUf.ToString())
                + sep + (int)TipoEndereco;
        }
    }
}
