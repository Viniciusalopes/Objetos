using Objetos.Modelos.Dados;
using Objetos.Persistencia.Arquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Objetos.Constantes.EnumTags;
using static Objetos.Constantes.EnumTipoAtributo;
using static Objetos.Utilitarios.ArquivoUtils;

namespace GeradorDeObjetos
{
    public partial class FormGeradorDeObjetos : Form
    {
        private ControleCsharp controleCsharp = null;

        public FormGeradorDeObjetos()
        {
            InitializeComponent();

            ValoresIniciais();
            tabControlPrincipal.SelectedTab = tabPageObjeto;
        }

        private void ValoresIniciais()
        {
            #region TabConfiguracao

            textBoxLocalProjeto.Text = folderBrowserDialogLocalProjeto.SelectedPath;
            textBoxLocalPersistencia.Text = folderBrowserDialogLocalPersistencia.SelectedPath;
            textBoxLocalObjetos.Text = folderBrowserDialogLocalObjetos.SelectedPath;
            textBoxLocalEnum.Text = folderBrowserDialogLocalEnum.SelectedPath;
            textBoxPaPadrao.Text = openFileDialogLocalPAPadrao.FileName;
            textBoxObjetoPadrao.Text = openFileDialogLocalObjetoPadrao.FileName;
            textBoxLocalObjetoGerado.Text = folderBrowserDialogLocalObjetoGerado.SelectedPath;
            textBoxLocalPersistenciaGerada.Text = folderBrowserDialogLocalPersistenciaGerada.SelectedPath;
            comboBoxTag.SelectedIndex = 1;

            #endregion TabConfiguracao

            List<Atributo> atributos = new List<Atributo>();
            atributos.Add(new Atributo(0, "Id", "long", ""));

            controleCsharp = new ControleCsharp(
                textBoxLocalProjeto.Text,
                textBoxLocalPersistencia.Text,
                textBoxLocalObjetos.Text,
                textBoxLocalEnum.Text,
                textBoxPaPadrao.Text,
                textBoxObjetoPadrao.Text,
                textBoxLocalObjetoGerado.Text,
                textBoxLocalPersistenciaGerada.Text,
                comboBoxTag.SelectedItem.ToString(),
                atributos);

            #region TabObjeto
            string nomeObjeto = (textBoxNomeObjeto.Text.Trim().Length < 2) ? textBoxNomeObjeto.Text : char.ToUpper(textBoxNomeObjeto.Text[0]) + textBoxNomeObjeto.Text.Substring(1);
            controleCsharp.NomeDoObjeto = nomeObjeto;

            #region TabObjeto - Grid Atributos

            TipoDoAtributo.Items.Add("");
            foreach (TipoAtributo tipo in Enum.GetValues(typeof(TipoAtributo)))
            {
                string _tipo = tipo.ToString().Substring(5);
                TipoDoAtributo.Items.Add(_tipo);
                ObjetoDoAtributo.Items.Add(_tipo);
            }

            foreach (string _tipo in controleCsharp.ObjetosDoProjeto)
            {
                TipoDoAtributo.Items.Add(_tipo);
                ObjetoDoAtributo.Items.Add(_tipo);
            }

            TipoDoAtributo.Sorted = true;
            ObjetoDoAtributo.Sorted = true;

            dataGridViewAtributos.Rows.Add(1);
            dataGridViewAtributos[0, 0].ReadOnly = true;
            dataGridViewAtributos[0, 0].Value = controleCsharp.Atributos[0].NomeAtributo;
            dataGridViewAtributos[1, 0].Value = controleCsharp.Atributos[0].TipoAtributo;
            dataGridViewAtributos[2, 0].ReadOnly = true;

            #endregion TabObjeto - Grid Atributos

            #region TabObjeto - TabTags

            dataGridViewDePara.Rows.Add(Enum.GetValues(typeof(TagSimplesCsharp)).Length);
            for (int i = 0; i < controleCsharp.DeParaSimples[0].Count; i++)
            {
                dataGridViewDePara[1, i].Value = controleCsharp.DeParaSimples[0][i];
                dataGridViewDePara[2, i].Value = controleCsharp.DeParaSimples[1][i];
            }

            /*
            // Ver todos os parametros encontrados nos arquivos lidos
            dataGridViewDePara.Rows.Add(controleCsharp.DePara[0].Count);
            for (int i = 0; i < controleCsharp.DePara[0].Count; i++)
            {
                dataGridViewDePara[1, i].Value = controleCsharp.DePara[0][i];
                dataGridViewDePara[2, i].Value = controleCsharp.DePara[1][i];
            }
            */

            #endregion TabObjeto - TabTags

            #region TabObjeto - TabObjeto.cs

            textBoxLocalObjetoGerado.Text = controleCsharp.LocalDoObjetoGerado;

            controleCsharp.PreencherLinhasObjetoPadrao();
            listBoxObjeto.Items.Clear();
            foreach (string linha in controleCsharp.LinhasObjetoPadrao)
                listBoxObjeto.Items.Add(linha);

            #endregion TabObjeto - TabObjeto.cs

            #region TabObjeto - PAObjeto.cs

            textBoxLocalPersistenciaGerada.Text = controleCsharp.LocalDaPersistenciaGerada;

            controleCsharp.preencherLinhasPAObjetoPadrao();
            listBoxPersistencia.Items.Clear();
            foreach (string linha in controleCsharp.LinhasPAPadrao)
                listBoxPersistencia.Items.Add(linha);

            #endregion TabObjeto - PAObjeto.cs

            #endregion TabObjeto
        }

        private void tabPageObjeto_Enter(object sender, EventArgs e)
        {
            textBoxNomeObjeto.Focus();
        }

        private void atualizarGridTags()
        {
            foreach (DataGridViewRow row in dataGridViewDePara.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    string tag = row.Cells[1].Value.ToString();
                    row.Cells[2].Value = controleCsharp.SubstituirTag(tag)[0];
                }
            }
        }

        private void atualizarListBoxObjeto()
        {
            controleCsharp.PreencherLinhasObjetoPadrao();

            corrigirDiferencaDeLinhas(controleCsharp.LinhasObjetoPadrao, listBoxObjeto);

            for (int i = 0; i < listBoxObjeto.Items.Count; i++)
                listBoxObjeto.Items[i] = controleCsharp.LinhasObjetoPadrao[i];
        }

        private void atualizarListBoxPersistencia()
        {
            controleCsharp.preencherLinhasPAObjetoPadrao();

            corrigirDiferencaDeLinhas(controleCsharp.LinhasPAPadrao, listBoxPersistencia);

            for (int i = 0; i < listBoxPersistencia.Items.Count; i++)
                listBoxPersistencia.Items[i] = controleCsharp.LinhasPAPadrao[i];
        }

        private void corrigirDiferencaDeLinhas(List<string> colecao, ListBox listBox)
        {
            int diferenca = colecao.Count - listBox.Items.Count;

            if (diferenca > 0)
                for (int i = 0; i < diferenca; i++)
                    listBox.Items.Add("");
            else
                for (int i = 0; i > diferenca; i--)
                    listBox.Items.RemoveAt(listBox.Items.Count - 1);
        }

        private void checkBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDePara.Rows)
            {
                row.Cells[0].Value = (row.Cells[1].Value == null) ? false : checkBoxTodos.Checked;
            }
        }

        #region TabPages

        #region TabConfiguracao

        #region Botões Procurar

        private void buttonProcurarLocalProjeto_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalProjeto.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDoProjeto = folderBrowserDialogLocalProjeto.SelectedPath;
                textBoxLocalProjeto.Text = controleCsharp.LocalDoProjeto;
            }

        }
        private void buttonProcurarLocalPersistencia_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalPersistencia.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDaPersistencia = folderBrowserDialogLocalPersistencia.SelectedPath;
                textBoxLocalPersistencia.Text = controleCsharp.LocalDaPersistencia;
            }

        }
        private void buttonProcurarLocalObjetos_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalObjetos.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDosObjetos = folderBrowserDialogLocalObjetos.SelectedPath;
                textBoxLocalObjetos.Text = controleCsharp.LocalDosObjetos;
            }

        }
        private void buttonProcurarPersistenciaPadrao_Click(object sender, EventArgs e)
        {
            DialogResult ofd = openFileDialogLocalPAPadrao.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                controleCsharp.LocalPAPadrao = openFileDialogLocalPAPadrao.FileName;
                textBoxPaPadrao.Text = controleCsharp.LocalPAPadrao;
            }

        }
        private void buttonProcurarObjetoPadrao_Click(object sender, EventArgs e)
        {
            DialogResult ofd = openFileDialogLocalObjetoPadrao.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                controleCsharp.LocalDoObjetoPadrao = openFileDialogLocalObjetoPadrao.FileName;
                textBoxObjetoPadrao.Text = controleCsharp.LocalDoObjetoPadrao;
            }

        }

        private void buttonProcurarLocalEnum_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalEnum.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDosEnumeradores = folderBrowserDialogLocalEnum.SelectedPath;
                textBoxLocalEnum.Text = controleCsharp.LocalDosEnumeradores;
            }
        }

        #endregion Botões Procurar

        #endregion TabConfiguracao

        #region TabObjeto

        private void textBoxNomeObjeto_TextChanged(object sender, EventArgs e)
        {
            controleCsharp.NomeDoObjeto = char.ToUpper(textBoxNomeObjeto.Text[0]) + textBoxNomeObjeto.Text.Substring(1);
            atualizarTabPagePreviews();
        }

        private void dataGridViewAtributos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAtributos.CurrentRow.Cells[0].Value != null && dataGridViewAtributos.CurrentRow.Cells[1].Value != null)
            {
                atualizarAtributos();
                atualizarTabPagePreviews();

            }
        }

        private void dataGridViewAtributos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            atualizarAtributos();
            atualizarTabPagePreviews();
        }

        private void atualizarAtributos()
        {
            dataGridViewAtributos[0, 0].ReadOnly = true;
            dataGridViewAtributos[0, 0].Value = controleCsharp.SubstituirTag("IdModeloAtributo")[0];
            dataGridViewAtributos[2, 0].ReadOnly = true;

            controleCsharp.Atributos = new List<Atributo>();
            int id = 0;
            foreach (DataGridViewRow row in dataGridViewAtributos.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string tipo = row.Cells[1].Value.ToString();

                    row.Cells[2].ReadOnly = !tipo.Equals("List");

                    controleCsharp.Atributos.Add(new Atributo(
                        id,
                        row.Cells[0].Value.ToString(),
                        tipo,
                        (row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString()
                        )
                    );

                    id++;
                }
            }
        }

        private void atualizarTabPagePreviews()
        {
            atualizarAtributos();

            if (tabControlPrincipal.SelectedTab == tabPageObjeto)
            {
                if (tabControlPreview.SelectedTab == tabPageTags)
                {
                    atualizarGridTags();
                }
                else if (tabControlPreview.SelectedTab == tabPagePreviewObjeto)
                {
                    atualizarListBoxObjeto();
                }
                else if (tabControlPreview.SelectedTab == tabPagePreviewPersistencia)
                {
                    atualizarListBoxPersistencia();
                }
            }
        }

        #region TabObjeto - TabPreviewObjeto

        private void tabPagePreviewObjeto_Enter(object sender, EventArgs e)
        {
            atualizarListBoxObjeto();
        }

        private void buttonAlterarLocalObjetoGerado_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalObjetoGerado.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDoObjetoGerado = folderBrowserDialogLocalObjetoGerado.SelectedPath;
                textBoxLocalObjetoGerado.Text = controleCsharp.LocalDoObjetoGerado;
                atualizarListBoxObjeto();
            }
        }

        private void buttonGerarObjeto_Click(object sender, EventArgs e)
        {
            try
            {
                Arquivo arquivo = new Arquivo(controleCsharp.LocalDoObjetoGerado + "\\", controleCsharp.NomeDoObjeto + ".cs");
                arquivo.EscreverLinhas(listBoxObjeto.Items.OfType<string>().ToArray());
                MessageBox.Show("Objeto [" + controleCsharp.NomeDoObjeto + "] criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível criar o objeto [" + controleCsharp.NomeDoObjeto + "] !" + Environment.NewLine
                    + ex.Message, "Eita...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion TabObjeto - TabPreviewObjeto

        #region TabObjeto - TabPreviewPersistencia

        private void tabPagePreviewPersistencia_Enter(object sender, EventArgs e)
        {
            atualizarListBoxPersistencia();
        }

        private void buttonAlterarLocalPersistenciaGerada_Click(object sender, EventArgs e)
        {
            DialogResult fbd = folderBrowserDialogLocalPersistenciaGerada.ShowDialog();
            if (fbd == DialogResult.OK)
            {
                controleCsharp.LocalDaPersistenciaGerada = folderBrowserDialogLocalPersistenciaGerada.SelectedPath;
                textBoxLocalPersistenciaGerada.Text = controleCsharp.LocalDaPersistenciaGerada;
                atualizarListBoxObjeto();
            }
        }

        private void buttonGerarPersistencia_Click(object sender, EventArgs e)
        {
            try
            {
                Arquivo arquivo = new Arquivo(controleCsharp.LocalDaPersistenciaGerada + "\\", "PA" + controleCsharp.NomeDoObjeto + ".cs");
                arquivo.EscreverLinhas(listBoxPersistencia.Items.OfType<string>().ToArray());
                MessageBox.Show("Persistência [" + controleCsharp.NomeDoObjeto + "] criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível criar a persistência [" + controleCsharp.NomeDoObjeto + "] !" + Environment.NewLine
                    + ex.Message, "Eita...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion TabObjeto - TabPreviewPersistencia

        #endregion TabObjeto

        #endregion TabPages


    }
}
