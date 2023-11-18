using Microsoft.VisualBasic.FileIO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections.Specialized;
using System.DirectoryServices;
using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using PdfSharp.Fonts;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Diagnostics;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;



namespace MNSPlusImporter {
    public partial class Form1 : Form {

        // Base MNS+ Workbook
        OpenFileDialog baseWorkbook;
        // Student Data
        OpenFileDialog studenDataSheet;
        // Random Passwort lines
        string[] lines = Properties.Resources.wordlist.Split('\n');
        // Passwords
        Dictionary<Student, String> passwords = new Dictionary<Student, String>();

        public Form1() {
            InitializeComponent();
            textBox1.Text = "Bereit";
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
        private void StudentDataPathLabel_Click(object sender, EventArgs e) {

        }
        private void Form1_Load(object sender, EventArgs e) {

        }

        // Get Base workbook to work with
        private void button1_Click(object sender, EventArgs e) {
            baseWorkbook = new OpenFileDialog {
                InitialDirectory = @"C:\",
                Title = "Wähle eine MNS+ Basis-Tabelle aus",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xls",
                Filter = "Excel Files (*.xls)|*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (baseWorkbook.ShowDialog() == DialogResult.OK) {
                PathTextBox_1.Text = baseWorkbook.FileName;
            }
        }

        // Get Student Data
        private void button1_Click_1(object sender, EventArgs e) {
            studenDataSheet = new OpenFileDialog {
                InitialDirectory = @"C:\",
                Title = "Wähle eine Schüler-daten Datei aus",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                Filter = "CSV Files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (studenDataSheet.ShowDialog() == DialogResult.OK) {
                PathTextBox_2.Text = studenDataSheet.FileName;
            }

        }

        // Represents a Student
        struct Student {

            public Student(
                string firstName,
                string lastName,
                string userName,
                string grade,
                string birthday
            ) {
                this.firstName = firstName;
                this.lastName = lastName;
                this.userName = userName;
                this.grade = grade;
                this.birtday = birthday;
            }

            public string firstName { get; }
            public string lastName { get; }
            public string userName { get; }
            public string grade { get; }
            public string birtday { get; }

            public override string ToString() => $"Student(firstName={firstName}, lastName={lastName}, userName={userName}, grade={grade}, birthday={birtday})";
        }

        private void button1_Click_2(object sender, EventArgs e) {
            textBox1.Clear();

            List<Student> students = ParseStudents();

            
            progress.Visible = true;
            progress.Minimum = 1;
            progress.Maximum = students.Count;
            progress.Value = 1;
            progress.Step = 1;

            textBox1.Text = "Generiere Passwörter";
            setPasswords(students);

            textBox1.Text = "Editiere Tabelle";
            progress.Value = 1;
            editExcel(students, passwords);

            textBox1.Text = "Generiere Info-Zettel";
            progress.Value = 1;

            genPrints(students, passwords);

            students.Clear();
            passwords.Clear();

            textBox1.Text = "Fertig";
        }

        private List<Student> ParseStudents() {

            List<Student> students = new List<Student>();

            using (TextFieldParser parser = new TextFieldParser(studenDataSheet.FileName)) {


                parser.TextFieldType = FieldType.Delimited;

                parser.SetDelimiters(",");


                while (!parser.EndOfData) {
                    string[] fields = parser.ReadFields();

                    students.Add(new Student(
                        fields[0],
                        fields[1],
                        fields[2],
                        fields[3],
                        fields[4]
                    ));
                }

                students.RemoveAt(0);
            }

            return students;
        }

        private void setPasswords(List<Student> students) {
            foreach (Student student in students) {
                progress.PerformStep();
                textBox1.Text = "Generiere Passwort für Schüler " + student.userName;
                passwords.Add(student, genPassword());
            }
        }

        private string genPassword() {
            Random random = new Random();
            return lines[random.Next(lines.Length)].Trim() + "-" + lines[random.Next(lines.Length)].Trim() + "-" + lines[random.Next(lines.Length)].Trim() + "-" + random.Next(99);
        }

        private void editExcel(List<Student> students, Dictionary<Student, String> passwords) {
            Excel.Application excel;
            Excel._Workbook workbook;
            Excel._Worksheet sheet;
            Excel.Range range;

            try {
                excel = new Excel.Application();
                excel.Visible = false;
                excel.UserControl = false;

                workbook = (Excel._Workbook)excel.Workbooks.Open(baseWorkbook.FileName);

                sheet = (Excel._Worksheet)workbook.ActiveSheet;

                sheet.Range["A2", "M2"].Clear();

                int count = 2;

                foreach (Student student in students) {

                    textBox1.Text = $"Importiere Schüler {student.userName}";
                    progress.PerformStep();
                    sheet.Cells[count, 1] = student.firstName;
                    sheet.Cells[count, 2] = student.lastName;
                    sheet.Cells[count, 3] = student.grade;
                    sheet.Cells[count, 4] = student.userName;
                    sheet.Cells[count, 10] = passwords[student];
                    sheet.Cells[count, 12] = "X"; // MNS+ Stupidery - This sets the Password not to be changed afterwards
                    sheet.Cells[count, 13] = student.birtday;
                    count++;
                }

                workbook.Save();
                workbook.Close();
                excel.Quit();

            } catch { }
        }

        private void genPrints(List<Student> students, Dictionary<Student, string> passwords) {
            GlobalFontSettings.FontResolver = new FailsafeFontResolver();

            Document document = new Document();

            Section section = document.AddSection();

            var style = document.Styles[StyleNames.Normal]!;
            style.Font.Name = "Calibri";

            textBox1.Clear();
          
            foreach (Student student in students) {
                textBox1.Text = "Generiere Info-Zettel für Schüler " + student.userName;
                progress.PerformStep();
                Paragraph paragraph = section.AddParagraph();
                paragraph.AddText($"Dein MNS+ Benutzername: {student.userName.Replace(" ", "")}\n");
                paragraph.AddText($"Dein MNS+ Passwort: {passwords[student].Replace(" ", "")}\n\n");
            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer { Document = document, PdfDocument = new PdfDocument() };

            pdfRenderer.RenderDocument();

            string fileName = IOHelper.CreateTemporaryPdfFileName("print");
            pdfRenderer.PdfDocument.Save(fileName);
            Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void progressBar1_Click(object sender, EventArgs e) {

        }
    }
}
