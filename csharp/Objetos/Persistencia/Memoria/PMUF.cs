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
///     Persistêncie em memória para UF.
///     Criação : Vovolinux
///     Data    : 30/06/2020
///     Projeto : Objetos genéricos para C#.
/// </summary>

using System;
using System.Collections.Generic;
using Objetos.Interfaces;
using Objetos.Modelos.Enderecos;
using static Objetos.Constantes.EnumRegiao;

namespace Objetos.Persistencia.Memoria
{
    class PMUF : ICRUDMemoria<UF>
    {
        List<UF> ufs = null;

        #region READ

        public UF Buscar(int idUf)
        {
            try
            {
                foreach (UF uf in Consultar())
                {
                    if (uf.IdUf == idUf)
                        return uf;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("uf#001#Camada: Persistência-Memória#Erro: " + ex.Message);
            }
        }

        public List<UF> Consultar()
        {
            return TabelaUF.UFs;
        }

        public List<UF> Consultar(object parametro)
        {
            try
            {
                ufs = new List<UF>();
                UF pUf = new UF();
                bool retornar = false;
                string texto = null;

                #region SIGLA E NOME

                try { 
                    texto = (string)parametro;
                    pUf.SiglaUf = texto;
                    pUf.NomeUf = texto;
                    retornar = true;
                } catch (Exception) { 
                    retornar = false; 
                }
                
                if (retornar)
                {
                    foreach (UF uf in Consultar())
                        if (uf.SiglaUf.Equals(pUf.SiglaUf) || uf.NomeUf.Equals(pUf.NomeUf))
                            ufs.Add(uf);

                    return ufs;
                }

                #endregion SIGLA E NOME

                #region REGIÃO

                try { pUf.Regiao = (Regiao)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (UF uf in Consultar())
                        if (uf.Regiao.Equals(pUf.Regiao))
                            ufs.Add(pUf);

                    return ufs;
                }

                #endregion REGIÃO

                #region MUNICÍPIOS

                try { Municipio municipio = (Municipio)parametro; retornar = true; } catch (Exception) { retornar = false; }

                if (retornar)
                {
                    foreach (UF uf in Consultar())
                        if (uf.Municipios.IndexOf((Municipio)parametro) > -1)
                            ufs.Add(uf);

                    return ufs;
                }

                #endregion MUNICÍPIOS

                return ufs;
            }
            catch (Exception ex)
            {
                throw new Exception("uf#002#Camada: Persistência-Memória#Erro: " + ex.Message);
            }
        }

        #endregion READ
    }
}
