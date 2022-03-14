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
using Editor.AppCore.IServices;
using Editor.Domain.Interfaces;
using Editor.Domain.Entities;

namespace BlocdeNotas
{
    public partial class FormBloc : Form
    {
        IArchivoService archivo1;
        ICarpetaService carpeta1;
        public FormBloc(IArchivoService archivoService,ICarpetaService carpetaService)
        {
            archivo1 = archivoService;
            carpeta1 = carpetaService;
            InitializeComponent();
        }
        public string name="";
        public FormBloc(string a)
        {
            name = a;
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            return;
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
                ArchivoTexto archivo = new ArchivoTexto()
                {
                    Texto = richTextBox1.Text,
                };
                archivo1.Add(archivo);
            }
            catch(IOException io)
            {
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
            ArchivoTexto archivo = new ArchivoTexto()
            {
                Texto = richTextBox1.Text,
                Ruta = mySave.FileName,
            };
            archivo1.GuardarComo(archivo);
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }
        private TreeNode CrearArbol(DirectoryInfo directoryInfo)
        {
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
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.Description = "Selecciona la carpeta con la que se ejecutara el programa";
                folder.ShowDialog();
                path = folder.SelectedPath;
                tvFile.Nodes.Clear();
                if (path == string.Empty)
                {
                    Environment.Exit(0);
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                tvFile.Nodes.Add(CrearArbol(directoryInfo));
                tvFile.ContextMenuStrip = ctmsOptions;
            }
            catch (IOException)
            {
            }
        }

        private void tvFile_DoubleClick(object sender, EventArgs e)
        {
            ArchivoTexto archivo = new ArchivoTexto()
            {
                Ruta= tvFile.SelectedNode.Tag.ToString() + "\\" + tvFile.SelectedNode.Text,
            };
            string s = richTextBox1.Text;
            archivo1.DoubleClick(archivo,ref s);
            richTextBox1.Text = s;

        }
        
        private void tvFile_Click(object sender, EventArgs e)
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
            ArchivoTexto archivo = new ArchivoTexto()
            {
                Ruta= tvFile.SelectedNode.Tag.ToString() + "\\" + name + ".txt",
                Texto=richTextBox1.Text,
                Nombre=name,
            };
            archivo1.Create(archivo);
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
            Carpeta carpeta = new Carpeta()
            {
                Ruta= tvFile.SelectedNode.Tag.ToString() + "\\" + name,
            };
            carpeta1.Add(carpeta);
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvFile.SelectedNode.Text.Contains(".txt"))
            {
                ArchivoTexto archivo = new ArchivoTexto()
                {
                    Ruta = tvFile.SelectedNode.Tag.ToString() + "\\" + tvFile.SelectedNode.Text,
                };
                archivo1.Delete(archivo);
                richTextBox1.Text = "";
            }
            else
            {
                //Directory.Delete(tvFile.SelectedNode.Tag.ToString());
                Carpeta carpeta = new Carpeta()
                {
                    Ruta= tvFile.SelectedNode.Tag.ToString(),
                };
                carpeta1.Delete(carpeta);
            }
            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ruta1 = tvFile.SelectedNode.Tag.ToString() + "\\" +tvFile.SelectedNode.Text;
        }

        private void archivoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog myopen = new OpenFileDialog();
            myopen.Title = "Abrir Archivo";
            myopen.Filter = "Archivos de texto(.txt)|*.txt|Todos los archivos (*.*)|*.*";
            myopen.ShowDialog();
            if (myopen.FileName == "")
            {
                return;
            }
            myopen.OpenFile();

                ArchivoTexto archivo = new ArchivoTexto()
                {
                    Ruta = myopen.FileName,
                };
                string s = richTextBox1.Text;
                archivo1.Open(archivo, ref s);
                richTextBox1.Text = s;
        }

        private void carpetaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Selecciona la carpeta";
            folder.ShowDialog();
            path = folder.SelectedPath;
            tvFile.Nodes.Clear();
            if (path == string.Empty)
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
            tvFile.ContextMenuStrip = ctmsOptions;
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void borrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void horaYFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            richTextBox1.Text += fecha.ToString();
        }
    }
}
