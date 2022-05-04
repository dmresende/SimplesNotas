using System.IO;

namespace BlocoDeNotas
{
    public partial class Form1 : Form
    {
        private OpenFileDialog abrirDialogo;
        private SaveFileDialog salvarDialogo;
        private FontDialog fonteDialogo;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fonteDialogo = new FontDialog();

        }

        private void criarNovo()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    this.Text = "Sem título";
                    this.richTextBox1.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Arquivo vazio!");
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }

        private void abrirArquivo()
        {
            try
            {
                abrirDialogo = new OpenFileDialog();

                if(abrirDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(abrirDialogo.FileName);
                    this.Text = abrirDialogo.FileName;
                }
            }
            catch(Exception ex)
            {
                abrirDialogo = null;
            }
            finally
            {

            }
        }

        private void salvarArquivo()
        {
            try
            {
                salvarDialogo = new SaveFileDialog();
                salvarDialogo.Filter = "Arquivo de Texto (*.txt | *.txt";

                if(salvarDialogo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(salvarDialogo.FileName, this.richTextBox1.Text);
                    this.Text = salvarDialogo.FileName;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }




        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            criarNovo();

        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abrirArquivo();

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(fonteDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fonteDialogo.Font;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}