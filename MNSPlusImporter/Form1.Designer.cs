namespace MNSPlusImporter {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            BrowseButton_1 = new Button();
            PathTextBox_1 = new TextBox();
            MNSplusSheetOpenDialog_1 = new OpenFileDialog();
            MSPlusSheetPathLabel = new Label();
            StudentDataPathLabel = new Label();
            PathTextBox_2 = new TextBox();
            BrowseButton_2 = new Button();
            Generate_Sheet = new Button();
            textBox1 = new TextBox();
            ProgressLabel = new Label();
            progress = new ProgressBar();
            SuspendLayout();
            // 
            // BrowseButton_1
            // 
            BrowseButton_1.Location = new Point(12, 37);
            BrowseButton_1.Name = "BrowseButton_1";
            BrowseButton_1.Size = new Size(112, 34);
            BrowseButton_1.TabIndex = 0;
            BrowseButton_1.Text = "Browse";
            BrowseButton_1.UseVisualStyleBackColor = true;
            BrowseButton_1.Click += button1_Click;
            // 
            // PathTextBox_1
            // 
            PathTextBox_1.Location = new Point(130, 40);
            PathTextBox_1.Name = "PathTextBox_1";
            PathTextBox_1.Size = new Size(472, 31);
            PathTextBox_1.TabIndex = 1;
            // 
            // MNSplusSheetOpenDialog_1
            // 
            MNSplusSheetOpenDialog_1.FileName = "openFileDialog1";
            // 
            // MSPlusSheetPathLabel
            // 
            MSPlusSheetPathLabel.AutoSize = true;
            MSPlusSheetPathLabel.Location = new Point(12, 9);
            MSPlusSheetPathLabel.Name = "MSPlusSheetPathLabel";
            MSPlusSheetPathLabel.Size = new Size(171, 25);
            MSPlusSheetPathLabel.TabIndex = 2;
            MSPlusSheetPathLabel.Text = "MNS+ Import-Datei";
            // 
            // StudentDataPathLabel
            // 
            StudentDataPathLabel.AutoSize = true;
            StudentDataPathLabel.Location = new Point(12, 74);
            StudentDataPathLabel.Name = "StudentDataPathLabel";
            StudentDataPathLabel.Size = new Size(123, 25);
            StudentDataPathLabel.TabIndex = 3;
            StudentDataPathLabel.Text = "Schüler-Daten";
            StudentDataPathLabel.Click += StudentDataPathLabel_Click;
            // 
            // PathTextBox_2
            // 
            PathTextBox_2.Location = new Point(130, 105);
            PathTextBox_2.Name = "PathTextBox_2";
            PathTextBox_2.Size = new Size(472, 31);
            PathTextBox_2.TabIndex = 5;
            // 
            // BrowseButton_2
            // 
            BrowseButton_2.Location = new Point(12, 102);
            BrowseButton_2.Name = "BrowseButton_2";
            BrowseButton_2.Size = new Size(112, 34);
            BrowseButton_2.TabIndex = 4;
            BrowseButton_2.Text = "Browse";
            BrowseButton_2.UseVisualStyleBackColor = true;
            BrowseButton_2.Click += button1_Click_1;
            // 
            // Generate_Sheet
            // 
            Generate_Sheet.BackColor = SystemColors.InactiveBorder;
            Generate_Sheet.Location = new Point(12, 330);
            Generate_Sheet.Name = "Generate_Sheet";
            Generate_Sheet.Size = new Size(590, 80);
            Generate_Sheet.TabIndex = 6;
            Generate_Sheet.Text = "Generiere Import-Tabelle";
            Generate_Sheet.UseVisualStyleBackColor = false;
            Generate_Sheet.Click += button1_Click_2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 207);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(590, 117);
            textBox1.TabIndex = 7;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Location = new Point(12, 139);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(92, 25);
            ProgressLabel.TabIndex = 8;
            ProgressLabel.Text = "Fortschritt";
            ProgressLabel.Click += label1_Click;
            // 
            // progress
            // 
            progress.Location = new Point(12, 167);
            progress.Name = "progress";
            progress.Size = new Size(590, 34);
            progress.TabIndex = 9;
            progress.Click += progressBar1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 428);
            Controls.Add(progress);
            Controls.Add(ProgressLabel);
            Controls.Add(textBox1);
            Controls.Add(Generate_Sheet);
            Controls.Add(PathTextBox_2);
            Controls.Add(BrowseButton_2);
            Controls.Add(StudentDataPathLabel);
            Controls.Add(MSPlusSheetPathLabel);
            Controls.Add(PathTextBox_1);
            Controls.Add(BrowseButton_1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "MNS+ Schüler-Import Generator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BrowseButton_1;
        private TextBox PathTextBox_1;
        private OpenFileDialog MNSplusSheetOpenDialog_1;
        private Label MSPlusSheetPathLabel;
        private Label StudentDataPathLabel;
        private TextBox PathTextBox_2;
        private Button BrowseButton_2;
        private Button Generate_Sheet;
        private TextBox textBox1;
        private Label ProgressLabel;
        private ProgressBar progress;
    }
}
