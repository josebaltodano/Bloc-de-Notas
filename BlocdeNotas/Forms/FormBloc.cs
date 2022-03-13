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
using BlocdeNotas.Forms;

namespace BlocdeNotas
{
    public partial class FormBloc : Form
    {
        public FormBloc()
        {
            InitializeComponent();
        }
        public string name="";
        public FormBloc(string a)
        {
            name = a;
            InitializeComponent();
        }
        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

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



        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            StreamReader mylectura = null;
            myopen.Title = "Abrir Archivo";
            myopen.Filter = "Archivos de texto(.txt)|*.txt|Todos los archivos (*.*)|*.*";
            myopen.ShowDialog();
            myopen.OpenFile();
            string Abrir = myopen.FileName;
            mylectura = File.OpenText(Abrir);
            richTextBox1.Text = mylectura.ReadToEnd();
        }

        private void nuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ruta1 = string.Empty;
            richTextBox1.Clear();
        }
        string ruta1 = null;
        private void guadarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (ruta1 != string.Empty && ruta1 != null)
                {
                StreamWriter streamWriter;
                using (FileStream fileStream = new FileStream(ruta1, FileMode.Append, FileAccess.Write))
                {
                    streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(richTextBox1.Text);
                    streamWriter.Close();
                }
            }
                
            }catch(IOException io)
            {
                MessageBox.Show("si");
                return;
            }
        }

        private void cerrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void copiarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySave = new SaveFileDialog();
            mySave.Filter = "Archivos de texto(.txt)|*.txt|Todos los archivos (*.*)|*.*";
            mySave.Title = "Guardar como: ";
            mySave.ShowDialog();
            string ruta = mySave.FileName;
            StreamWriter streamWriter;
            using (FileStream fileStream = new FileStream(ruta, FileMode.Append, FileAccess.Write))
            {
                streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(richTextBox1.Text);
                ruta1 = ruta;
                streamWriter.Close();
            }
        }
        private TreeNode CrearArbol(DirectoryInfo directoryInfo)
        {
            //TreeNode treeNode = new TreeNode(directoryInfo.Name);
            if(directoryInfo == null)
            {
                return null; 
            }
            TreeNode treeNode = new TreeNode { Text = directoryInfo.Name, Tag = directoryInfo.FullName };
            foreach(var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(CrearArbol(item));
            }
            foreach(var item in directoryInfo.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode { Text = item.Name,Tag = directoryInfo.FullName }) ;
            }
            return treeNode;
        }
        string path = "";
        private void FormBloc_Load(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Selecciona la carpeta con la que se ejecutara el programa";
            folder.ShowDialog();
            path=folder.SelectedPath;
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }

        private void tvFile_DoubleClick(object sender, EventArgs e)
        {
            string ruta = tvFile.SelectedNode.Text;
            StreamReader mylectura = null;
            mylectura = File.OpenText(tvFile.SelectedNode.Tag.ToString()+"\\" + ruta);
            richTextBox1.Text = mylectura.ReadToEnd();
        }
        
        private void tvFile_Click(object sender, EventArgs e)
        {
            /*if (tvFile.ContextMenuStrip.)//.Items.Contains(menu))
            {
                string carpeta = tvFile.SelectedNode.FullPath+@"\Carpeta";
                Directory.CreateDirectory(carpeta);
            }*/
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tvFile_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void archivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormName form = new FormName();
            form.ShowDialog();
            name = form.b;
            if (name == string.Empty)
            {
                return;
            }
            StreamWriter streamWriter;
            using (FileStream fileStream = new FileStream(tvFile.SelectedNode.Tag.ToString()+ "\\" + name+".txt", FileMode.Append, FileAccess.Write))
            {
                streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(richTextBox1.Text);
                streamWriter.Close();
            }
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;

        }

        private void carpetaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormName form = new FormName();
            form.ShowDialog();
            name = form.b;
            if (name == string.Empty)
            {
                return;
            }
            Directory.CreateDirectory(tvFile.SelectedNode.Tag.ToString() + "\\"+name);
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvFile.SelectedNode.Text.Contains(".txt"))
            {
                File.Delete(tvFile.SelectedNode.Tag.ToString() + "\\" + tvFile.SelectedNode.Text);
            }
            else
            {
                Directory.Delete(tvFile.SelectedNode.Tag.ToString());
            }
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }
    }
}
