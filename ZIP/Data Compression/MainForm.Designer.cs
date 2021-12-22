namespace Data_Compression
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.compressButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.extractButton = new System.Windows.Forms.Button();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.algorithmGroupBox = new System.Windows.Forms.GroupBox();
            this.lzwRadioButton = new System.Windows.Forms.RadioButton();
            this.huffmanRadioButton = new System.Windows.Forms.RadioButton();
            this.shannonFanoRadioButton = new System.Windows.Forms.RadioButton();
            this.runLengthRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.compressSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.extractSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.existLabel = new System.Windows.Forms.Label();
            this.algorithmCheckBox = new System.Windows.Forms.CheckBox();
            this.jpegCheckBox = new System.Windows.Forms.CheckBox();
            this.waitLabel = new System.Windows.Forms.Label();
            this.algorithmGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(122, 76);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(524, 23);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Путь к файлу:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(661, 64);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(149, 45);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Обзор";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(117, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Просмотрите файлы / папки или перетащите их сюда.";
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(661, 226);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(149, 45);
            this.compressButton.TabIndex = 5;
            this.compressButton.Text = "Сжать";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(22, 148);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(84, 17);
            this.typeLabel.TabIndex = 7;
            this.typeLabel.Text = "Тип файла:";
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(661, 277);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(149, 45);
            this.extractButton.TabIndex = 8;
            this.extractButton.Text = "Извлечь";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(23, 190);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(102, 17);
            this.lengthLabel.TabIndex = 11;
            this.lengthLabel.Text = "Общая длина:";
            // 
            // algorithmGroupBox
            // 
            this.algorithmGroupBox.Controls.Add(this.lzwRadioButton);
            this.algorithmGroupBox.Controls.Add(this.huffmanRadioButton);
            this.algorithmGroupBox.Controls.Add(this.shannonFanoRadioButton);
            this.algorithmGroupBox.Controls.Add(this.runLengthRadioButton);
            this.algorithmGroupBox.Location = new System.Drawing.Point(27, 261);
            this.algorithmGroupBox.Name = "algorithmGroupBox";
            this.algorithmGroupBox.Size = new System.Drawing.Size(619, 138);
            this.algorithmGroupBox.TabIndex = 13;
            this.algorithmGroupBox.TabStop = false;
            this.algorithmGroupBox.Text = "Или выберите один";
            // 
            // lzwRadioButton
            // 
            this.lzwRadioButton.AutoSize = true;
            this.lzwRadioButton.Location = new System.Drawing.Point(287, 29);
            this.lzwRadioButton.Name = "lzwRadioButton";
            this.lzwRadioButton.Size = new System.Drawing.Size(300, 21);
            this.lzwRadioButton.TabIndex = 4;
            this.lzwRadioButton.Text = "Алгоритм Лемпеля — Зива — Велча (LZW)";
            this.lzwRadioButton.UseVisualStyleBackColor = true;
            // 
            // huffmanRadioButton
            // 
            this.huffmanRadioButton.AutoSize = true;
            this.huffmanRadioButton.Checked = true;
            this.huffmanRadioButton.Location = new System.Drawing.Point(25, 64);
            this.huffmanRadioButton.Name = "huffmanRadioButton";
            this.huffmanRadioButton.Size = new System.Drawing.Size(190, 21);
            this.huffmanRadioButton.TabIndex = 2;
            this.huffmanRadioButton.TabStop = true;
            this.huffmanRadioButton.Text = "Кодирование Хаффмана";
            this.huffmanRadioButton.UseVisualStyleBackColor = true;
            // 
            // shannonFanoRadioButton
            // 
            this.shannonFanoRadioButton.AutoSize = true;
            this.shannonFanoRadioButton.Location = new System.Drawing.Point(25, 29);
            this.shannonFanoRadioButton.Name = "shannonFanoRadioButton";
            this.shannonFanoRadioButton.Size = new System.Drawing.Size(219, 21);
            this.shannonFanoRadioButton.TabIndex = 1;
            this.shannonFanoRadioButton.Text = "Кодирование Шеннона-Фано";
            this.shannonFanoRadioButton.UseVisualStyleBackColor = true;
            // 
            // runLengthRadioButton
            // 
            this.runLengthRadioButton.AutoSize = true;
            this.runLengthRadioButton.Location = new System.Drawing.Point(287, 64);
            this.runLengthRadioButton.Name = "runLengthRadioButton";
            this.runLengthRadioButton.Size = new System.Drawing.Size(258, 21);
            this.runLengthRadioButton.TabIndex = 0;
            this.runLengthRadioButton.Text = "Кодирование длин серий/повторов";
            this.runLengthRadioButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // compressSaveFileDialog
            // 
            this.compressSaveFileDialog.Filter = "CDT files (*.cdt)|*.cdt|All files (*.*)|*.*";
            // 
            // existLabel
            // 
            this.existLabel.AutoSize = true;
            this.existLabel.ForeColor = System.Drawing.Color.Red;
            this.existLabel.Location = new System.Drawing.Point(117, 110);
            this.existLabel.Name = "existLabel";
            this.existLabel.Size = new System.Drawing.Size(199, 17);
            this.existLabel.TabIndex = 15;
            this.existLabel.Text = "Путь к файлу не существует!";
            this.existLabel.Visible = false;
            // 
            // algorithmCheckBox
            // 
            this.algorithmCheckBox.AutoSize = true;
            this.algorithmCheckBox.Location = new System.Drawing.Point(28, 226);
            this.algorithmCheckBox.Name = "algorithmCheckBox";
            this.algorithmCheckBox.Size = new System.Drawing.Size(324, 21);
            this.algorithmCheckBox.TabIndex = 16;
            this.algorithmCheckBox.Text = "Все алгоритмы (экспорт нескольких файлов)";
            this.algorithmCheckBox.UseVisualStyleBackColor = true;
            this.algorithmCheckBox.CheckedChanged += new System.EventHandler(this.algorithmCheckBox_CheckedChanged);
            // 
            // jpegCheckBox
            // 
            this.jpegCheckBox.AutoSize = true;
            this.jpegCheckBox.Checked = true;
            this.jpegCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jpegCheckBox.Location = new System.Drawing.Point(296, 147);
            this.jpegCheckBox.Name = "jpegCheckBox";
            this.jpegCheckBox.Size = new System.Drawing.Size(530, 21);
            this.jpegCheckBox.TabIndex = 17;
            this.jpegCheckBox.Text = "JPEG без потерь (рекомендуется для 24-битного растрового изображения)";
            this.jpegCheckBox.UseVisualStyleBackColor = true;
            this.jpegCheckBox.Visible = false;
            // 
            // waitLabel
            // 
            this.waitLabel.AutoSize = true;
            this.waitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLabel.Location = new System.Drawing.Point(640, 430);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(180, 17);
            this.waitLabel.TabIndex = 18;
            this.waitLabel.Text = "Пожалуйста, подождите...";
            this.waitLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 464);
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.jpegCheckBox);
            this.Controls.Add(this.algorithmCheckBox);
            this.Controls.Add(this.existLabel);
            this.Controls.Add(this.algorithmGroupBox);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Программа для сжатия данных";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.algorithmGroupBox.ResumeLayout(false);
            this.algorithmGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.GroupBox algorithmGroupBox;
        private System.Windows.Forms.RadioButton huffmanRadioButton;
        private System.Windows.Forms.RadioButton shannonFanoRadioButton;
        private System.Windows.Forms.RadioButton runLengthRadioButton;
        private System.Windows.Forms.RadioButton lzwRadioButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog compressSaveFileDialog;
        private System.Windows.Forms.SaveFileDialog extractSaveFileDialog;
        private System.Windows.Forms.Label existLabel;
        private System.Windows.Forms.CheckBox algorithmCheckBox;
        private System.Windows.Forms.CheckBox jpegCheckBox;
        private System.Windows.Forms.Label waitLabel;
    }
}

