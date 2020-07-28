namespace GeradorDeObjetos
{
    partial class FormGeradorDeObjetos
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNomeObjeto = new System.Windows.Forms.TextBox();
            this.labelNomeObjeto = new System.Windows.Forms.Label();
            this.dataGridViewAtributos = new System.Windows.Forms.DataGridView();
            this.NomeDoAtributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDoAtributo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ObjetoDoAtributo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.labelGridAtributos = new System.Windows.Forms.Label();
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabPageConfiguracao = new System.Windows.Forms.TabPage();
            this.buttonProcurarLocalObjetos = new System.Windows.Forms.Button();
            this.labelLocalObjetos = new System.Windows.Forms.Label();
            this.textBoxLocalObjetos = new System.Windows.Forms.TextBox();
            this.labelModeloObjeto = new System.Windows.Forms.Label();
            this.buttonProcurarObjetoPadrao = new System.Windows.Forms.Button();
            this.textBoxObjetoPadrao = new System.Windows.Forms.TextBox();
            this.labelTag = new System.Windows.Forms.Label();
            this.labelLocalPersistencia = new System.Windows.Forms.Label();
            this.buttonProcurarLocalPersistencia = new System.Windows.Forms.Button();
            this.textBoxLocalPersistencia = new System.Windows.Forms.TextBox();
            this.textBoxLocalProjeto = new System.Windows.Forms.TextBox();
            this.labelLocalProjeto = new System.Windows.Forms.Label();
            this.buttonProcurarLocalProjeto = new System.Windows.Forms.Button();
            this.textBoxPaPadrao = new System.Windows.Forms.TextBox();
            this.buttonProcurarPersistenciaPadrao = new System.Windows.Forms.Button();
            this.labelPAPadrao = new System.Windows.Forms.Label();
            this.comboBoxTag = new System.Windows.Forms.ComboBox();
            this.tabPageObjeto = new System.Windows.Forms.TabPage();
            this.tabControlPreview = new System.Windows.Forms.TabControl();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.checkBoxTodos = new System.Windows.Forms.CheckBox();
            this.dataGridViewDePara = new System.Windows.Forms.DataGridView();
            this.Substituir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.De = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Para = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePreviewObjeto = new System.Windows.Forms.TabPage();
            this.labelLocalObjetoGerado = new System.Windows.Forms.Label();
            this.buttonGerarObjeto = new System.Windows.Forms.Button();
            this.buttonAlterarLocalObjetoGerado = new System.Windows.Forms.Button();
            this.textBoxLocalObjetoGerado = new System.Windows.Forms.TextBox();
            this.listBoxObjeto = new System.Windows.Forms.ListBox();
            this.tabPagePreviewPersistencia = new System.Windows.Forms.TabPage();
            this.listBoxPersistencia = new System.Windows.Forms.ListBox();
            this.folderBrowserDialogLocalProjeto = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogLocalPersistencia = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogLocalPAPadrao = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogLocalObjetoPadrao = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogLocalObjetos = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogLocalObjetoGerado = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonProcurarLocalEnum = new System.Windows.Forms.Button();
            this.labelLocalEnum = new System.Windows.Forms.Label();
            this.textBoxLocalEnum = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogLocalEnum = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtributos)).BeginInit();
            this.tabControlPrincipal.SuspendLayout();
            this.tabPageConfiguracao.SuspendLayout();
            this.tabPageObjeto.SuspendLayout();
            this.tabControlPreview.SuspendLayout();
            this.tabPageTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDePara)).BeginInit();
            this.tabPagePreviewObjeto.SuspendLayout();
            this.tabPagePreviewPersistencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNomeObjeto
            // 
            this.textBoxNomeObjeto.Location = new System.Drawing.Point(111, 14);
            this.textBoxNomeObjeto.Name = "textBoxNomeObjeto";
            this.textBoxNomeObjeto.Size = new System.Drawing.Size(214, 20);
            this.textBoxNomeObjeto.TabIndex = 0;
            this.textBoxNomeObjeto.TextChanged += new System.EventHandler(this.textBoxNomeObjeto_TextChanged);
            // 
            // labelNomeObjeto
            // 
            this.labelNomeObjeto.AutoSize = true;
            this.labelNomeObjeto.Location = new System.Drawing.Point(21, 17);
            this.labelNomeObjeto.Name = "labelNomeObjeto";
            this.labelNomeObjeto.Size = new System.Drawing.Size(84, 13);
            this.labelNomeObjeto.TabIndex = 1;
            this.labelNomeObjeto.Text = "Nome do Objeto";
            // 
            // dataGridViewAtributos
            // 
            this.dataGridViewAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeDoAtributo,
            this.TipoDoAtributo,
            this.ObjetoDoAtributo});
            this.dataGridViewAtributos.Location = new System.Drawing.Point(24, 62);
            this.dataGridViewAtributos.Name = "dataGridViewAtributos";
            this.dataGridViewAtributos.Size = new System.Drawing.Size(343, 202);
            this.dataGridViewAtributos.TabIndex = 2;
            this.dataGridViewAtributos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAtributos_CellEndEdit);
            this.dataGridViewAtributos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewAtributos_RowsRemoved);
            // 
            // NomeDoAtributo
            // 
            this.NomeDoAtributo.HeaderText = "Nome";
            this.NomeDoAtributo.Name = "NomeDoAtributo";
            this.NomeDoAtributo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TipoDoAtributo
            // 
            this.TipoDoAtributo.HeaderText = "Tipo";
            this.TipoDoAtributo.Name = "TipoDoAtributo";
            // 
            // ObjetoDoAtributo
            // 
            this.ObjetoDoAtributo.HeaderText = "Objeto";
            this.ObjetoDoAtributo.Name = "ObjetoDoAtributo";
            this.ObjetoDoAtributo.ReadOnly = true;
            this.ObjetoDoAtributo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // labelGridAtributos
            // 
            this.labelGridAtributos.AutoSize = true;
            this.labelGridAtributos.Location = new System.Drawing.Point(21, 46);
            this.labelGridAtributos.Name = "labelGridAtributos";
            this.labelGridAtributos.Size = new System.Drawing.Size(48, 13);
            this.labelGridAtributos.TabIndex = 3;
            this.labelGridAtributos.Text = "Atributos";
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabPageConfiguracao);
            this.tabControlPrincipal.Controls.Add(this.tabPageObjeto);
            this.tabControlPrincipal.Location = new System.Drawing.Point(12, 12);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(1135, 555);
            this.tabControlPrincipal.TabIndex = 5;
            // 
            // tabPageConfiguracao
            // 
            this.tabPageConfiguracao.Controls.Add(this.textBoxLocalEnum);
            this.tabPageConfiguracao.Controls.Add(this.labelLocalEnum);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarLocalEnum);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarLocalObjetos);
            this.tabPageConfiguracao.Controls.Add(this.labelLocalObjetos);
            this.tabPageConfiguracao.Controls.Add(this.textBoxLocalObjetos);
            this.tabPageConfiguracao.Controls.Add(this.labelModeloObjeto);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarObjetoPadrao);
            this.tabPageConfiguracao.Controls.Add(this.textBoxObjetoPadrao);
            this.tabPageConfiguracao.Controls.Add(this.labelTag);
            this.tabPageConfiguracao.Controls.Add(this.labelLocalPersistencia);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarLocalPersistencia);
            this.tabPageConfiguracao.Controls.Add(this.textBoxLocalPersistencia);
            this.tabPageConfiguracao.Controls.Add(this.textBoxLocalProjeto);
            this.tabPageConfiguracao.Controls.Add(this.labelLocalProjeto);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarLocalProjeto);
            this.tabPageConfiguracao.Controls.Add(this.textBoxPaPadrao);
            this.tabPageConfiguracao.Controls.Add(this.buttonProcurarPersistenciaPadrao);
            this.tabPageConfiguracao.Controls.Add(this.labelPAPadrao);
            this.tabPageConfiguracao.Controls.Add(this.comboBoxTag);
            this.tabPageConfiguracao.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfiguracao.Name = "tabPageConfiguracao";
            this.tabPageConfiguracao.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfiguracao.Size = new System.Drawing.Size(1127, 529);
            this.tabPageConfiguracao.TabIndex = 0;
            this.tabPageConfiguracao.Text = "Configuração";
            this.tabPageConfiguracao.UseVisualStyleBackColor = true;
            // 
            // buttonProcurarLocalObjetos
            // 
            this.buttonProcurarLocalObjetos.Location = new System.Drawing.Point(569, 72);
            this.buttonProcurarLocalObjetos.Name = "buttonProcurarLocalObjetos";
            this.buttonProcurarLocalObjetos.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurarLocalObjetos.TabIndex = 32;
            this.buttonProcurarLocalObjetos.Text = "Procurar";
            this.buttonProcurarLocalObjetos.UseVisualStyleBackColor = true;
            this.buttonProcurarLocalObjetos.Click += new System.EventHandler(this.buttonProcurarLocalObjetos_Click);
            // 
            // labelLocalObjetos
            // 
            this.labelLocalObjetos.AutoSize = true;
            this.labelLocalObjetos.Location = new System.Drawing.Point(67, 77);
            this.labelLocalObjetos.Name = "labelLocalObjetos";
            this.labelLocalObjetos.Size = new System.Drawing.Size(92, 13);
            this.labelLocalObjetos.TabIndex = 31;
            this.labelLocalObjetos.Text = "Local dos Objetos";
            // 
            // textBoxLocalObjetos
            // 
            this.textBoxLocalObjetos.Location = new System.Drawing.Point(165, 74);
            this.textBoxLocalObjetos.Name = "textBoxLocalObjetos";
            this.textBoxLocalObjetos.Size = new System.Drawing.Size(398, 20);
            this.textBoxLocalObjetos.TabIndex = 30;
            // 
            // labelModeloObjeto
            // 
            this.labelModeloObjeto.AutoSize = true;
            this.labelModeloObjeto.Location = new System.Drawing.Point(84, 203);
            this.labelModeloObjeto.Name = "labelModeloObjeto";
            this.labelModeloObjeto.Size = new System.Drawing.Size(75, 13);
            this.labelModeloObjeto.TabIndex = 29;
            this.labelModeloObjeto.Text = "Objeto Padrão";
            // 
            // buttonProcurarObjetoPadrao
            // 
            this.buttonProcurarObjetoPadrao.Location = new System.Drawing.Point(569, 198);
            this.buttonProcurarObjetoPadrao.Name = "buttonProcurarObjetoPadrao";
            this.buttonProcurarObjetoPadrao.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurarObjetoPadrao.TabIndex = 28;
            this.buttonProcurarObjetoPadrao.Text = "Procurar";
            this.buttonProcurarObjetoPadrao.UseVisualStyleBackColor = true;
            this.buttonProcurarObjetoPadrao.Click += new System.EventHandler(this.buttonProcurarObjetoPadrao_Click);
            // 
            // textBoxObjetoPadrao
            // 
            this.textBoxObjetoPadrao.Location = new System.Drawing.Point(165, 200);
            this.textBoxObjetoPadrao.Name = "textBoxObjetoPadrao";
            this.textBoxObjetoPadrao.Size = new System.Drawing.Size(398, 20);
            this.textBoxObjetoPadrao.TabIndex = 27;
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(133, 231);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(26, 13);
            this.labelTag.TabIndex = 26;
            this.labelTag.Text = "Tag";
            // 
            // labelLocalPersistencia
            // 
            this.labelLocalPersistencia.AutoSize = true;
            this.labelLocalPersistencia.Location = new System.Drawing.Point(49, 51);
            this.labelLocalPersistencia.Name = "labelLocalPersistencia";
            this.labelLocalPersistencia.Size = new System.Drawing.Size(108, 13);
            this.labelLocalPersistencia.TabIndex = 25;
            this.labelLocalPersistencia.Text = "Local da Persistencia";
            // 
            // buttonProcurarLocalPersistencia
            // 
            this.buttonProcurarLocalPersistencia.Location = new System.Drawing.Point(569, 46);
            this.buttonProcurarLocalPersistencia.Name = "buttonProcurarLocalPersistencia";
            this.buttonProcurarLocalPersistencia.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurarLocalPersistencia.TabIndex = 24;
            this.buttonProcurarLocalPersistencia.Text = "Procurar";
            this.buttonProcurarLocalPersistencia.UseVisualStyleBackColor = true;
            this.buttonProcurarLocalPersistencia.Click += new System.EventHandler(this.buttonProcurarLocalPersistencia_Click);
            // 
            // textBoxLocalPersistencia
            // 
            this.textBoxLocalPersistencia.Location = new System.Drawing.Point(165, 48);
            this.textBoxLocalPersistencia.Name = "textBoxLocalPersistencia";
            this.textBoxLocalPersistencia.Size = new System.Drawing.Size(398, 20);
            this.textBoxLocalPersistencia.TabIndex = 23;
            // 
            // textBoxLocalProjeto
            // 
            this.textBoxLocalProjeto.Location = new System.Drawing.Point(165, 22);
            this.textBoxLocalProjeto.Name = "textBoxLocalProjeto";
            this.textBoxLocalProjeto.Size = new System.Drawing.Size(398, 20);
            this.textBoxLocalProjeto.TabIndex = 17;
            // 
            // labelLocalProjeto
            // 
            this.labelLocalProjeto.AutoSize = true;
            this.labelLocalProjeto.Location = new System.Drawing.Point(75, 25);
            this.labelLocalProjeto.Name = "labelLocalProjeto";
            this.labelLocalProjeto.Size = new System.Drawing.Size(84, 13);
            this.labelLocalProjeto.TabIndex = 22;
            this.labelLocalProjeto.Text = "Local do Projeto";
            // 
            // buttonProcurarLocalProjeto
            // 
            this.buttonProcurarLocalProjeto.Location = new System.Drawing.Point(569, 20);
            this.buttonProcurarLocalProjeto.Name = "buttonProcurarLocalProjeto";
            this.buttonProcurarLocalProjeto.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurarLocalProjeto.TabIndex = 19;
            this.buttonProcurarLocalProjeto.Text = "Procurar";
            this.buttonProcurarLocalProjeto.UseVisualStyleBackColor = true;
            this.buttonProcurarLocalProjeto.Click += new System.EventHandler(this.buttonProcurarLocalProjeto_Click);
            // 
            // textBoxPaPadrao
            // 
            this.textBoxPaPadrao.Location = new System.Drawing.Point(165, 174);
            this.textBoxPaPadrao.Name = "textBoxPaPadrao";
            this.textBoxPaPadrao.Size = new System.Drawing.Size(398, 20);
            this.textBoxPaPadrao.TabIndex = 16;
            // 
            // buttonProcurarPersistenciaPadrao
            // 
            this.buttonProcurarPersistenciaPadrao.Location = new System.Drawing.Point(569, 174);
            this.buttonProcurarPersistenciaPadrao.Name = "buttonProcurarPersistenciaPadrao";
            this.buttonProcurarPersistenciaPadrao.Size = new System.Drawing.Size(75, 22);
            this.buttonProcurarPersistenciaPadrao.TabIndex = 18;
            this.buttonProcurarPersistenciaPadrao.Text = "Procurar";
            this.buttonProcurarPersistenciaPadrao.UseVisualStyleBackColor = true;
            this.buttonProcurarPersistenciaPadrao.Click += new System.EventHandler(this.buttonProcurarPersistenciaPadrao_Click);
            // 
            // labelPAPadrao
            // 
            this.labelPAPadrao.AutoSize = true;
            this.labelPAPadrao.Location = new System.Drawing.Point(58, 177);
            this.labelPAPadrao.Name = "labelPAPadrao";
            this.labelPAPadrao.Size = new System.Drawing.Size(101, 13);
            this.labelPAPadrao.TabIndex = 21;
            this.labelPAPadrao.Text = "Persistência Padrao";
            // 
            // comboBoxTag
            // 
            this.comboBoxTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTag.FormattingEnabled = true;
            this.comboBoxTag.Items.AddRange(new object[] {
            "( ) - Parênteses",
            "[ ] - Colchetes",
            "{ } - Chaves",
            "| | - Pipes",
            "_ _ - Underlines",
            "; ; - Ponto-e-vírgula"});
            this.comboBoxTag.Location = new System.Drawing.Point(165, 228);
            this.comboBoxTag.Name = "comboBoxTag";
            this.comboBoxTag.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTag.TabIndex = 20;
            // 
            // tabPageObjeto
            // 
            this.tabPageObjeto.Controls.Add(this.tabControlPreview);
            this.tabPageObjeto.Controls.Add(this.labelNomeObjeto);
            this.tabPageObjeto.Controls.Add(this.textBoxNomeObjeto);
            this.tabPageObjeto.Controls.Add(this.labelGridAtributos);
            this.tabPageObjeto.Controls.Add(this.dataGridViewAtributos);
            this.tabPageObjeto.Location = new System.Drawing.Point(4, 22);
            this.tabPageObjeto.Name = "tabPageObjeto";
            this.tabPageObjeto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageObjeto.Size = new System.Drawing.Size(1127, 529);
            this.tabPageObjeto.TabIndex = 1;
            this.tabPageObjeto.Text = "Objeto";
            this.tabPageObjeto.UseVisualStyleBackColor = true;
            this.tabPageObjeto.Enter += new System.EventHandler(this.tabPageObjeto_Enter);
            // 
            // tabControlPreview
            // 
            this.tabControlPreview.Controls.Add(this.tabPageTags);
            this.tabControlPreview.Controls.Add(this.tabPagePreviewObjeto);
            this.tabControlPreview.Controls.Add(this.tabPagePreviewPersistencia);
            this.tabControlPreview.Location = new System.Drawing.Point(373, 14);
            this.tabControlPreview.Name = "tabControlPreview";
            this.tabControlPreview.SelectedIndex = 0;
            this.tabControlPreview.Size = new System.Drawing.Size(748, 509);
            this.tabControlPreview.TabIndex = 5;
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.checkBoxTodos);
            this.tabPageTags.Controls.Add(this.dataGridViewDePara);
            this.tabPageTags.Location = new System.Drawing.Point(4, 22);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTags.Size = new System.Drawing.Size(740, 483);
            this.tabPageTags.TabIndex = 0;
            this.tabPageTags.Text = "Tags";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // checkBoxTodos
            // 
            this.checkBoxTodos.AutoSize = true;
            this.checkBoxTodos.Location = new System.Drawing.Point(64, 9);
            this.checkBoxTodos.Name = "checkBoxTodos";
            this.checkBoxTodos.Size = new System.Drawing.Size(56, 17);
            this.checkBoxTodos.TabIndex = 17;
            this.checkBoxTodos.Text = "Todos";
            this.checkBoxTodos.UseVisualStyleBackColor = true;
            this.checkBoxTodos.CheckedChanged += new System.EventHandler(this.checkBoxTodos_CheckedChanged);
            // 
            // dataGridViewDePara
            // 
            this.dataGridViewDePara.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDePara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDePara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Substituir,
            this.De,
            this.Para});
            this.dataGridViewDePara.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewDePara.Name = "dataGridViewDePara";
            this.dataGridViewDePara.Size = new System.Drawing.Size(731, 448);
            this.dataGridViewDePara.TabIndex = 16;
            // 
            // Substituir
            // 
            this.Substituir.HeaderText = "Substituir";
            this.Substituir.Name = "Substituir";
            this.Substituir.Width = 55;
            // 
            // De
            // 
            this.De.HeaderText = "De";
            this.De.Name = "De";
            this.De.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.De.Width = 136;
            // 
            // Para
            // 
            this.Para.HeaderText = "Para";
            this.Para.Name = "Para";
            this.Para.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Para.Width = 350;
            // 
            // tabPagePreviewObjeto
            // 
            this.tabPagePreviewObjeto.Controls.Add(this.labelLocalObjetoGerado);
            this.tabPagePreviewObjeto.Controls.Add(this.buttonGerarObjeto);
            this.tabPagePreviewObjeto.Controls.Add(this.buttonAlterarLocalObjetoGerado);
            this.tabPagePreviewObjeto.Controls.Add(this.textBoxLocalObjetoGerado);
            this.tabPagePreviewObjeto.Controls.Add(this.listBoxObjeto);
            this.tabPagePreviewObjeto.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreviewObjeto.Name = "tabPagePreviewObjeto";
            this.tabPagePreviewObjeto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreviewObjeto.Size = new System.Drawing.Size(740, 483);
            this.tabPagePreviewObjeto.TabIndex = 1;
            this.tabPagePreviewObjeto.Text = "Objeto.cs";
            this.tabPagePreviewObjeto.UseVisualStyleBackColor = true;
            this.tabPagePreviewObjeto.Enter += new System.EventHandler(this.tabPagePreviewObjeto_Enter);
            // 
            // labelLocalObjetoGerado
            // 
            this.labelLocalObjetoGerado.AutoSize = true;
            this.labelLocalObjetoGerado.Location = new System.Drawing.Point(6, 18);
            this.labelLocalObjetoGerado.Name = "labelLocalObjetoGerado";
            this.labelLocalObjetoGerado.Size = new System.Drawing.Size(82, 13);
            this.labelLocalObjetoGerado.TabIndex = 4;
            this.labelLocalObjetoGerado.Text = "Gerar objeto em";
            // 
            // buttonGerarObjeto
            // 
            this.buttonGerarObjeto.Location = new System.Drawing.Point(659, 13);
            this.buttonGerarObjeto.Name = "buttonGerarObjeto";
            this.buttonGerarObjeto.Size = new System.Drawing.Size(75, 23);
            this.buttonGerarObjeto.TabIndex = 3;
            this.buttonGerarObjeto.Text = "Gerar Objeto";
            this.buttonGerarObjeto.UseVisualStyleBackColor = true;
            this.buttonGerarObjeto.Click += new System.EventHandler(this.buttonGerarObjeto_Click);
            // 
            // buttonAlterarLocalObjetoGerado
            // 
            this.buttonAlterarLocalObjetoGerado.Location = new System.Drawing.Point(578, 13);
            this.buttonAlterarLocalObjetoGerado.Name = "buttonAlterarLocalObjetoGerado";
            this.buttonAlterarLocalObjetoGerado.Size = new System.Drawing.Size(75, 23);
            this.buttonAlterarLocalObjetoGerado.TabIndex = 2;
            this.buttonAlterarLocalObjetoGerado.Text = "Alterar Local";
            this.buttonAlterarLocalObjetoGerado.UseVisualStyleBackColor = true;
            this.buttonAlterarLocalObjetoGerado.Click += new System.EventHandler(this.buttonAlterarLocalObjetoGerado_Click);
            // 
            // textBoxLocalObjetoGerado
            // 
            this.textBoxLocalObjetoGerado.Location = new System.Drawing.Point(94, 15);
            this.textBoxLocalObjetoGerado.Name = "textBoxLocalObjetoGerado";
            this.textBoxLocalObjetoGerado.Size = new System.Drawing.Size(478, 20);
            this.textBoxLocalObjetoGerado.TabIndex = 1;
            // 
            // listBoxObjeto
            // 
            this.listBoxObjeto.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxObjeto.FormattingEnabled = true;
            this.listBoxObjeto.HorizontalScrollbar = true;
            this.listBoxObjeto.ItemHeight = 14;
            this.listBoxObjeto.Location = new System.Drawing.Point(3, 39);
            this.listBoxObjeto.Name = "listBoxObjeto";
            this.listBoxObjeto.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxObjeto.Size = new System.Drawing.Size(734, 438);
            this.listBoxObjeto.TabIndex = 0;
            // 
            // tabPagePreviewPersistencia
            // 
            this.tabPagePreviewPersistencia.Controls.Add(this.listBoxPersistencia);
            this.tabPagePreviewPersistencia.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreviewPersistencia.Name = "tabPagePreviewPersistencia";
            this.tabPagePreviewPersistencia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreviewPersistencia.Size = new System.Drawing.Size(740, 483);
            this.tabPagePreviewPersistencia.TabIndex = 2;
            this.tabPagePreviewPersistencia.Text = "PAObjeto.cs";
            this.tabPagePreviewPersistencia.UseVisualStyleBackColor = true;
            this.tabPagePreviewPersistencia.Enter += new System.EventHandler(this.tabPagePreviewPersistencia_Enter);
            // 
            // listBoxPersistencia
            // 
            this.listBoxPersistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPersistencia.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPersistencia.FormattingEnabled = true;
            this.listBoxPersistencia.HorizontalScrollbar = true;
            this.listBoxPersistencia.ItemHeight = 14;
            this.listBoxPersistencia.Location = new System.Drawing.Point(3, 3);
            this.listBoxPersistencia.Name = "listBoxPersistencia";
            this.listBoxPersistencia.Size = new System.Drawing.Size(734, 477);
            this.listBoxPersistencia.TabIndex = 0;
            // 
            // folderBrowserDialogLocalProjeto
            // 
            this.folderBrowserDialogLocalProjeto.Description = "Selecionar diretório do projeto";
            this.folderBrowserDialogLocalProjeto.SelectedPath = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp";
            // 
            // folderBrowserDialogLocalPersistencia
            // 
            this.folderBrowserDialogLocalPersistencia.Description = "Selecionar o diretório da persistência";
            this.folderBrowserDialogLocalPersistencia.SelectedPath = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Persistencia\\Arquivos";
            // 
            // openFileDialogLocalPAPadrao
            // 
            this.openFileDialogLocalPAPadrao.FileName = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Padroes\\PAPadrao.cs";
            this.openFileDialogLocalPAPadrao.Filter = "Todos (*.*)|*.*|C# (*.cs)|*.cs|Java (*.java)|*.java|Php (*.php)|*.php";
            this.openFileDialogLocalPAPadrao.FilterIndex = 2;
            this.openFileDialogLocalPAPadrao.RestoreDirectory = true;
            this.openFileDialogLocalPAPadrao.Title = "Selecionar o modelo da persistência";
            // 
            // openFileDialogLocalObjetoPadrao
            // 
            this.openFileDialogLocalObjetoPadrao.FileName = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Padroes\\ObjetoPadrao.cs";
            this.openFileDialogLocalObjetoPadrao.Filter = "Todos (*.*)|*.*|C# (*.cs)|*.cs|Java (*.java)|*.java|Php (*.php)|*.php";
            this.openFileDialogLocalObjetoPadrao.FilterIndex = 2;
            this.openFileDialogLocalObjetoPadrao.RestoreDirectory = true;
            this.openFileDialogLocalObjetoPadrao.Title = "Selecionar o modelo do objeto";
            // 
            // folderBrowserDialogLocalObjetos
            // 
            this.folderBrowserDialogLocalObjetos.Description = "Selecionar o diretório dos Objetos";
            this.folderBrowserDialogLocalObjetos.SelectedPath = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Modelos";
            // 
            // folderBrowserDialogLocalObjetoGerado
            // 
            this.folderBrowserDialogLocalObjetoGerado.Description = "Selecionar o diretório da geração do objeto";
            this.folderBrowserDialogLocalObjetoGerado.SelectedPath = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Modelos";
            // 
            // buttonProcurarLocalEnum
            // 
            this.buttonProcurarLocalEnum.Location = new System.Drawing.Point(569, 98);
            this.buttonProcurarLocalEnum.Name = "buttonProcurarLocalEnum";
            this.buttonProcurarLocalEnum.Size = new System.Drawing.Size(75, 23);
            this.buttonProcurarLocalEnum.TabIndex = 33;
            this.buttonProcurarLocalEnum.Text = "Procurar";
            this.buttonProcurarLocalEnum.UseVisualStyleBackColor = true;
            this.buttonProcurarLocalEnum.Click += new System.EventHandler(this.buttonProcurarLocalEnum_Click);
            // 
            // labelLocalEnum
            // 
            this.labelLocalEnum.AutoSize = true;
            this.labelLocalEnum.Location = new System.Drawing.Point(36, 103);
            this.labelLocalEnum.Name = "labelLocalEnum";
            this.labelLocalEnum.Size = new System.Drawing.Size(124, 13);
            this.labelLocalEnum.TabIndex = 34;
            this.labelLocalEnum.Text = "Local dos Enumeradores";
            // 
            // textBoxLocalEnum
            // 
            this.textBoxLocalEnum.Location = new System.Drawing.Point(166, 100);
            this.textBoxLocalEnum.Name = "textBoxLocalEnum";
            this.textBoxLocalEnum.Size = new System.Drawing.Size(397, 20);
            this.textBoxLocalEnum.TabIndex = 35;
            // 
            // folderBrowserDialogLocalEnum
            // 
            this.folderBrowserDialogLocalEnum.Description = "Selecionar o diretório dos Enumeradores";
            this.folderBrowserDialogLocalEnum.SelectedPath = "C:\\Users\\Vinicius\\projetos\\Objetos\\csharp\\Objetos\\Constantes";
            // 
            // FormGeradorDeObjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 579);
            this.Controls.Add(this.tabControlPrincipal);
            this.Name = "FormGeradorDeObjetos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Objetos - Vovolinux";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtributos)).EndInit();
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabPageConfiguracao.ResumeLayout(false);
            this.tabPageConfiguracao.PerformLayout();
            this.tabPageObjeto.ResumeLayout(false);
            this.tabPageObjeto.PerformLayout();
            this.tabControlPreview.ResumeLayout(false);
            this.tabPageTags.ResumeLayout(false);
            this.tabPageTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDePara)).EndInit();
            this.tabPagePreviewObjeto.ResumeLayout(false);
            this.tabPagePreviewObjeto.PerformLayout();
            this.tabPagePreviewPersistencia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeObjeto;
        private System.Windows.Forms.Label labelNomeObjeto;
        private System.Windows.Forms.DataGridView dataGridViewAtributos;
        private System.Windows.Forms.Label labelGridAtributos;
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabPageConfiguracao;
        private System.Windows.Forms.TabPage tabPageObjeto;
        private System.Windows.Forms.Label labelLocalPersistencia;
        private System.Windows.Forms.Button buttonProcurarLocalPersistencia;
        private System.Windows.Forms.TextBox textBoxLocalPersistencia;
        private System.Windows.Forms.TextBox textBoxLocalProjeto;
        private System.Windows.Forms.Label labelLocalProjeto;
        private System.Windows.Forms.Button buttonProcurarLocalProjeto;
        private System.Windows.Forms.TextBox textBoxPaPadrao;
        private System.Windows.Forms.Button buttonProcurarPersistenciaPadrao;
        private System.Windows.Forms.Label labelPAPadrao;
        private System.Windows.Forms.ComboBox comboBoxTag;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalProjeto;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalPersistencia;
        private System.Windows.Forms.OpenFileDialog openFileDialogLocalPAPadrao;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.TabControl tabControlPreview;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.CheckBox checkBoxTodos;
        private System.Windows.Forms.DataGridView dataGridViewDePara;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Substituir;
        private System.Windows.Forms.DataGridViewTextBoxColumn De;
        private System.Windows.Forms.DataGridViewTextBoxColumn Para;
        private System.Windows.Forms.TabPage tabPagePreviewObjeto;
        private System.Windows.Forms.ListBox listBoxObjeto;
        private System.Windows.Forms.TabPage tabPagePreviewPersistencia;
        private System.Windows.Forms.ListBox listBoxPersistencia;
        private System.Windows.Forms.Label labelModeloObjeto;
        private System.Windows.Forms.Button buttonProcurarObjetoPadrao;
        private System.Windows.Forms.TextBox textBoxObjetoPadrao;
        private System.Windows.Forms.OpenFileDialog openFileDialogLocalObjetoPadrao;
        private System.Windows.Forms.Button buttonProcurarLocalObjetos;
        private System.Windows.Forms.Label labelLocalObjetos;
        private System.Windows.Forms.TextBox textBoxLocalObjetos;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalObjetos;
        private System.Windows.Forms.Label labelLocalObjetoGerado;
        private System.Windows.Forms.Button buttonGerarObjeto;
        private System.Windows.Forms.Button buttonAlterarLocalObjetoGerado;
        private System.Windows.Forms.TextBox textBoxLocalObjetoGerado;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalObjetoGerado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeDoAtributo;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoDoAtributo;
        private System.Windows.Forms.DataGridViewComboBoxColumn ObjetoDoAtributo;
        private System.Windows.Forms.TextBox textBoxLocalEnum;
        private System.Windows.Forms.Label labelLocalEnum;
        private System.Windows.Forms.Button buttonProcurarLocalEnum;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocalEnum;
    }
}

