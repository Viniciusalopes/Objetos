using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Objetos.Persistencia.Arquivos;
using static Objetos.Constantes.EnumTags;
using static Objetos.Constantes.EnumTipoAtributo;
using static Objetos.Utilitarios.StringUtils;
using static Objetos.Utilitarios.ArquivoUtils;
using System.Windows.Forms;
using Objetos.Modelos.Dados;

namespace GeradorDeObjetos
{
    public class ControleCsharp
    {
        #region ATRIBUTOS
        public string LocalDoProjeto { get; set; }
        public string LocalDaPersistencia { get; set; }
        public string LocalDosObjetos { get; set; }
        public List<string> ObjetosDoProjeto { get; set; }
        public string LocalPAPadrao { get; set; }
        public string LocalDoObjetoPadrao { get; set; }
        public string LocalDoObjetoGerado { get; set; }

        public string NomeDoObjeto { get; set; }
        public List<List<string>> DePara { get; set; }
        public List<List<string>> DeParaSimples { get; set; }
        public List<List<string>> DeParaComposta { get; set; }

        private List<string> LinhasPA { get; set; }
        private List<string> LinhasObjeto { get; set; }

        public List<string> LinhasPAPadrao { get; set; }
        public List<string> LinhasObjetoPadrao { get; set; }

        public char TagInicio { get; set; }
        public char TagFinal { get; set; }

        public List<Atributo> Atributos { get; set; }

        #endregion ATRIBUTOS

        #region CONSTRUTORES
        public ControleCsharp()
        {

        }

        public ControleCsharp(
            string localDoProjeto,
            string localDaPersistencia,
            string localDosObjetos,
            string localPAPadrao,
            string localObjetoPadrao,
            string localObjetoGerado,
            string tag,
            List<Atributo> atributos)
        {
            LocalDoProjeto = localDoProjeto;
            LocalDaPersistencia = localDaPersistencia;
            LocalDosObjetos = localDosObjetos;
            LocalPAPadrao = localPAPadrao;
            LocalDoObjetoPadrao = localObjetoPadrao;
            LocalDoObjetoGerado = localObjetoGerado;

            string[] partes = tag.Split();
            TagInicio = char.Parse(partes[0]);
            TagFinal = char.Parse(partes[1]);

            Atributos = atributos;

            DePara = new List<List<string>>(2);
            DeParaSimples = new List<List<string>>(2);

            popularObjetosDoProjeto();
            preencherDe();
            preencherPara();
            preencherDeParaSimples();
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        private void preencherDe()
        {

            DePara.Add(new List<string>());

            Arquivo paPadrao = new Arquivo(LocalPAPadrao);
            LinhasPA = paPadrao.ListaDeLinhas();
            incluirTagsDe(LinhasPA);

            Arquivo objetoPadrao = new Arquivo(LocalDoObjetoPadrao);
            LinhasObjeto = objetoPadrao.ListaDeLinhas();
            incluirTagsDe(LinhasObjeto);

            DePara[0].Sort();
        }

        private void incluirTagsDe(List<string> linhas)
        {
            string nomeTag = "";
            string tagRet = "";

            foreach (string linha in linhas)                            // Para cada linha do arquivo
            {
                string texto = linha;                                   // Variável com o texto da linha para manipular

                if (texto.Contains(TagInicio))                          // Se a linha tiver uma tagInicio
                {
                    for (int n = 0; n < texto.Length; n++)              // Para cada char da linha
                    {
                        if (texto[n].Equals(TagInicio))                 // Se o char da posição é uma tagInicio
                        {
                            texto = texto.Substring(n);                 // Retira o texto antes da tagInicio
                            for (int o = 0; o < texto.Length; o++)      // Para cada char do restante da linha
                            {
                                if (texto[o].Equals(TagFinal))          // Se o char da posicão é uma tagFinal
                                {
                                    nomeTag = texto.Substring(1, (o - 1)).Trim(); // Nome da tag

                                    if (nomeTag.Length > 0 && !nomeTag.All(char.IsDigit))   // Se não está vazia e não é um número
                                    {
                                        tagRet = TagInicio + nomeTag + TagFinal;    // Monta a tagRet
                                        texto = texto.Replace(tagRet, "");          // Retira a tagRet do texto
                                        n = 0;                                      // Reposiciona no início do texto
                                        if (!DePara[0].Contains(tagRet))            // Se a tagRet ainda não existe no retorno
                                            DePara[0].Add(tagRet);                  // Inclui a tagRet no retorno
                                    }
                                    break;                                          // Interrompe o laço da tagFinal
                                }
                            }
                        }
                    }
                }
            }
        }

        private void preencherPara()
        {
            DePara.Add(new List<string>());

            for (int i = 0; i < DePara[0].Count; i++)
            {
                string nomeTag = DePara[0][i].Replace(TagInicio.ToString(), "").Replace(TagFinal.ToString(), "");
                DePara[1].Add(SubstituirTag(nomeTag)[0]);
            }
        }

        public void preencherDeParaSimples()
        {
            DeParaSimples.Add(new List<string>());
            DeParaSimples.Add(new List<string>());

            for (int i = 0; i < DePara[0].Count; i++)
            {
                foreach (TagSimplesCsharp tag in Enum.GetValues(typeof(TagSimplesCsharp)))
                {
                    if (DePara[0][i].Equals(TagInicio + tag.ToString() + TagFinal))
                    {
                        DeParaSimples[0].Add(DePara[0][i]);
                        DeParaSimples[1].Add(DePara[1][i]);
                    }
                }
            }
        }

        public void PreencherLinhasObjetoPadrao()
        {
            LinhasObjetoPadrao = new List<string>();

            foreach (string linha in LinhasObjeto)
            {
                List<string> tagsEncontradas = new List<string>();

                string novaLinha = "";

                if (linha.Trim().Equals("/*") || linha.Trim().Equals("*/"))
                {
                    LinhasObjetoPadrao.Add(linha.Replace("/*", "").Replace("*/", ""));
                }
                else
                {
                    novaLinha = linha;
                    foreach (string tag in DePara[0])
                        if (linha.Contains(tag))
                            tagsEncontradas.Add(tag);

                    if (tagsEncontradas.Count == 0)
                        LinhasObjetoPadrao.Add(novaLinha);
                    else
                    {
                        bool simples = false;
                        bool composta = false;

                        foreach (string tag in tagsEncontradas)
                        {
                            // Atualiza somente se já não for true
                            simples = (simples) ? simples : tagSimples(tag);
                            composta = (composta) ? composta : !tagSimples(tag);
                        }

                        if (simples && composta)     // Linha tem tag simples e composta
                        {
                            foreach (string tag in tagsEncontradas)
                                if (tagSimples(tag))
                                    novaLinha = novaLinha.Replace(tag, SubstituirTag(tag)[0]);

                            incluirLinhasTagsCompostas(novaLinha, LinhasObjetoPadrao);

                        }
                        if (simples && !composta)    // Linha só tem tag simples
                        {
                            foreach (string tag in tagsEncontradas)
                                novaLinha = novaLinha.Replace(tag, SubstituirTag(tag)[0]);

                            LinhasObjetoPadrao.Add(novaLinha);
                        }
                        if (!simples && composta)    // Linha só tem tag composta
                        {
                            incluirLinhasTagsCompostas(novaLinha, LinhasObjetoPadrao);
                        }
                    }
                }
            }
        }

        public void preencherLinhasPAObjetoPadrao()
        {
            LinhasPAPadrao = new List<string>();

            foreach (string linha in LinhasPA)
            {
                List<string> tagsEncontradas = new List<string>();

                string novaLinha = "";

                if (linha.Trim().Equals("/*") || linha.Trim().Equals("*/"))
                {
                    LinhasPAPadrao.Add(linha.Replace("/*", "").Replace("*/", ""));
                }
                else
                {
                    novaLinha = linha;
                    foreach (string tag in DePara[0])
                        if (linha.Contains(tag))
                            tagsEncontradas.Add(tag);

                    if (tagsEncontradas.Count == 0)
                        LinhasPAPadrao.Add(novaLinha);
                    else
                    {
                        bool simples = false;
                        bool composta = false;

                        foreach (string tag in tagsEncontradas)
                        {
                            // Atualiza somente se já não for true
                            simples = (simples) ? simples : tagSimples(tag);
                            composta = (composta) ? composta : !tagSimples(tag);
                        }

                        if (simples && composta)     // Linha tem tag simples e composta
                        {
                            foreach (string tag in tagsEncontradas)
                                if (tagSimples(tag))
                                    novaLinha = novaLinha.Replace(tag, SubstituirTag(tag)[0]);

                            incluirLinhasTagsCompostas(novaLinha, LinhasPAPadrao);

                        }
                        if (simples && !composta)    // Linha só tem tag simples
                        {
                            foreach (string tag in tagsEncontradas)
                                novaLinha = novaLinha.Replace(tag, SubstituirTag(tag)[0]);

                            LinhasPAPadrao.Add(novaLinha);
                        }
                        if (!simples && composta)    // Linha só tem tag composta
                        {
                            incluirLinhasTagsCompostas(novaLinha, LinhasPAPadrao);
                        }
                    }
                }
            }
        }

        public List<string> SubstituirTag(string tag)
        {
            List<string> retorno = new List<string>();
            try
            {
                try
                {
                    retorno.Add(SubstituirTagSimples((TagSimplesCsharp)Enum.Parse(typeof(TagSimplesCsharp), tag.Replace(TagInicio + "", "").Replace(TagFinal + "", ""))));
                }
                catch (Exception)
                {
                    retorno = SubstituirTagComposta((TagCompostaCsharp)Enum.Parse(typeof(TagCompostaCsharp), tag.Replace(TagInicio + "", "").Replace(TagFinal + "", "")));
                }
            }
            catch (Exception)
            {
                retorno.Add(tag);
            }
            return retorno;
        }

        private string SubstituirTagSimples(TagSimplesCsharp tag)
        {
            string retorno = TagInicio + tag.ToString() + TagFinal;


            switch (tag)
            {
                case TagSimplesCsharp.Autor:
                    retorno = "Vovolinux";
                    break;

                case TagSimplesCsharp.DataCriacao:
                    retorno = DateTime.Now.ToString() + " - Gerado automaGicamente pelo Gerador de Objetos - Versão " + Application.ProductVersion;
                    break;

                case TagSimplesCsharp.DescricaoObjeto:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = "Objeto " + NomeDoObjeto + ".";
                    break;

                case TagSimplesCsharp.DescricaoPersistencia:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = "Persistência em arquivo para " + NomeDoObjeto + ".";
                    break;

                case TagSimplesCsharp.IdModeloAtributo:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = "Id" + NomeDoObjeto;
                    break;

                case TagSimplesCsharp.idModeloParametro:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = "id" + NomeDoObjeto;
                    break;

                case TagSimplesCsharp.Linguagem:
                    retorno = "C#";
                    break;

                case TagSimplesCsharp.Modelo:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = NomeDoObjeto;
                    break;

                case TagSimplesCsharp.modeloPlural:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = char.ToLower(NomeDoObjeto[0]) + NomeDoObjeto.Substring(1) + "s";
                    break;

                case TagSimplesCsharp.modeloSingular:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = char.ToLower(NomeDoObjeto[0]) + NomeDoObjeto.Substring(1);
                    break;

                case TagSimplesCsharp.NamespaceObjeto:
                    retorno = LocalDoObjetoGerado.Replace(LocalDoProjeto, "").Replace("\\", ".").Substring(1);
                    break;

                case TagSimplesCsharp.NamespacePersistencia:
                    retorno = LocalDaPersistencia.Replace(LocalDoProjeto, "").Replace("\\", ".").Substring(1);
                    break;

                case TagSimplesCsharp.oModeloSingular:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = "o" + NomeDoObjeto;
                    break;

                case TagSimplesCsharp.prefixoErro:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                        retorno = (NomeDoObjeto.Length <= 3) ? NomeDoObjeto : NomeDoObjeto.ToLower().Substring(0, 3);
                    break;

                default:
                    break;
            }


            return retorno;
        }

        private List<string> SubstituirTagComposta(TagCompostaCsharp tag)
        {
            List<string> retorno = new List<string>();
            retorno.Add(TagInicio + tag.ToString() + TagFinal);

            switch (tag)
            {
                case TagCompostaCsharp.AtribuicaoParametros:
                    if (Atributos.Count > 0)
                    {
                        retorno = new List<string>();
                        foreach (Atributo atributo in Atributos)
                            retorno.Add(atributo.NomeAtributo + " = " + char.ToLower(atributo.NomeAtributo[0]) + atributo.NomeAtributo.Substring(1) + ";");
                    }
                    break;

                case TagCompostaCsharp.Atributos:
                    if (Atributos.Count > 0)
                    {
                        retorno = new List<string>();
                        foreach (Atributo atributo in Atributos)
                        {
                            retorno.Add("public " + nomeTipoAtributo(atributo) + " " + atributo.NomeAtributo + " { get; set; }");
                        }
                    }
                    break;

                case TagCompostaCsharp.AtributosParametrosConstrutorUmaLinha:
                    if (Atributos.Count > 0)
                    {
                        retorno = new List<string>();
                        retorno.Add(""); // TagComposta mas na mesma linha
                        foreach (Atributo atributo in Atributos)
                        {
                            retorno[0] += ", " + nomeTipoAtributo(atributo) + " " + char.ToLower(atributo.NomeAtributo[0]) + atributo.NomeAtributo.Substring(1);
                        }
                        retorno[0] = retorno[0].Substring(2); // Para tirar a vírgula e o espaço do início
                    }
                    break;

                case TagCompostaCsharp.AtributosToObjectRecuar2aLinha:
                    break;

                case TagCompostaCsharp.AtributosToStringRecuar2aLinha:
                    if (Atributos.Count > 0)
                    {
                        retorno = new List<string>();
                        foreach (Atributo atributo in Atributos)
                        {
                            string complemento = "";

                            foreach (TipoAtributo tipo in Enum.GetValues(typeof(TipoAtributo)))
                                if (!atributo.TipoAtributo.Equals("string") && atributo.TipoAtributo.Equals(tipo.ToString().Substring(5)))
                                    complemento = ".ToString()";

                            if (!atributo.TipoAtributo.Equals("string") && complemento.Equals(""))
                                complemento = ".Id" + atributo.TipoAtributo + complemento;

                            retorno.Add("+ sep + " + atributo.NomeAtributo + complemento);
                        }
                        retorno[0] = retorno[0].Substring(8); // Para tirar o '+ sep + ' do início
                    }
                    break;

                case TagCompostaCsharp.CasesConsultar:
                    if (!string.IsNullOrEmpty(NomeDoObjeto))
                    {
                        retorno = new List<string>();
                        foreach (Atributo atributo in Atributos)
                        {
                            if (!atributo.NomeAtributo.Equals("Id" + NomeDoObjeto)) // Se não for o Id do objeto
                            {
                                string modeloSingular = SubstituirTag("modeloSingular")[0];
                                string modeloPlural = SubstituirTag("modeloPlural")[0];
                                string tipo = atributo.TipoAtributo;
                                string comparador = (tipo.Equals("int") || tipo.Equals("long") || tipo.Equals("float") || tipo.Equals("double"))
                                                    ? " == param)" : ".Equals(param))";

                                retorno.Add("    case \"" + atributo.NomeAtributo + "\":");
                                retorno.Add("        " + tipo + " param = (" + tipo + ")parametro;");
                                retorno.Add("        foreach (" + NomeDoObjeto + " " + modeloSingular + " in " + modeloPlural + ")");
                                retorno.Add("            if (" + modeloSingular + "." + atributo.NomeAtributo + comparador);
                                retorno.Add("                " + modeloPlural + "Retorno.Add(" + modeloSingular + ");");
                                retorno.Add("        break;");
                                retorno.Add("");
                            }
                        }
                    }
                    break;

                default:
                    break;
            }

            return retorno;
        }

        private bool tagSimples(string tag)
        {
            try
            {
                tag = tag.Replace(TagInicio + "", "").Replace(TagFinal + "", "");
                TagSimplesCsharp teste = (TagSimplesCsharp)Enum.Parse(typeof(TagSimplesCsharp), tag);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void incluirLinhasTagsCompostas(string linha, List<string> Linhas)
        {
            // Somente tagComposta agora
            List<string> tagsEncontradas = new List<string>();
            foreach (string tag in DePara[0])
                if (linha.Contains(tag))
                    if (!tagSimples(tag))
                        tagsEncontradas.Add(tag);

            if (tagsEncontradas.Count == 0)
                Linhas.Add(linha);
            else
            {
                string inicio = linha.Substring(0, linha.IndexOf(tagsEncontradas[0]));
                string tag = linha.Substring(linha.IndexOf(tagsEncontradas[0]), tagsEncontradas[0].Length);
                string final = linha.Substring(linha.IndexOf(tagsEncontradas[0]) + tagsEncontradas[0].Length);

                if (tag.Contains("UmaLinha"))
                {
                    string lin = inicio;
                    foreach (string sub in SubstituirTag(tag))
                        lin += sub;

                    lin += (final.Trim().Length > 0) ? final : "";

                    Linhas.Add(lin);
                }
                else
                {
                    List<string> subs = SubstituirTag(tag);
                    if (subs.Count == 0)
                    {
                        Linhas.Add(linha);
                        return;
                    }

                    if (subs.Count == 1)
                        Linhas.Add(inicio + subs[0] + final);
                    else
                    {
                        Linhas.Add(inicio + subs[0]);   // Primeiro na mesma linha

                        foreach (string sub in subs)
                        {
                            int indice = subs.IndexOf(sub);

                            if (indice > 0)
                                Linhas.Add(indentacao(linha, 4, (tag.Contains("Recuar2aLinha"))) + sub);

                            if (indice == subs.Count - 1)
                            {
                                Linhas[Linhas.Count - 1] += final;
                            }
                        }
                    }
                }
            }
        }

        private void popularObjetosDoProjeto()
        {
            ObjetosDoProjeto = new List<string>();

            foreach (FileInfo file in arquivosDoDiretorio(new DirectoryInfo(@"" + LocalDosObjetos + ""), null))
            {
                ObjetosDoProjeto.Add(file.Name.Replace(".cs", "").Replace(".java", "").Replace(".php", ""));
            }
        }

        private string nomeTipoAtributo(Atributo atributo)
        {
            string nome = atributo.TipoAtributo;

            if (atributo.TipoAtributo.Equals("List"))
                nome = atributo.TipoAtributo + "<" + ((atributo.ObjetoAtributo.Trim().Length == 0) ? "object" : atributo.ObjetoAtributo) + ">";

            return nome;
        }

        #endregion MÉTODOS
    }
}
