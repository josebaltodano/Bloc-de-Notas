using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocdeNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            StreamReader mylectura = null;
            myopen.Title = "Abrir Archivo";
            myopen.Filter = "Archivos de texto(.txt)|*.txt|Todos los archivos (*.*)|*.*";
            myopen.ShowDialog();
            string Abrir = myopen.FileName;
            mylectura = File.OpenText(Abrir);
            richTextBox1.Text = mylectura.ReadToEnd();

        }

        private void guadarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "SIn titulo.txt";
            var save = saveFileDialog1.ShowDialog();
            if(save == DialogResult.OK)
            {
                using (var savefile = new StreamWriter(saveFileDialog1.FileName))
                {
                    savefile.WriteLine(saveFileDialog1.FileName);
                }
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void colorDeFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var color = colorDialog1.ShowDialog();
            if (color == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formato = fontDialog1.ShowDialog();
            if (formato == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;

            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
    }
}
