using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNA_Sequence_Alignment_Using_Dynamic_Programming_
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lists That Holds Alignments
            List<char> SeqAlign1 = new List<char>();
            List<char> SeqAlign2 = new List<char>();

            this.richTextBox1.Clear();
            // Each sequence begin with - to manage dynamic programming table to show the table in datagridview cell[0,0]
            string Seq1 = "-"+this.textBox1.Text;
            string Seq2 = "-"+this.textBox2.Text;
            // get parameters of alignment 
            // scale of Similarity
            int Sim = int.Parse(this.textBox3.Text);
            // scale of non Similarity
            int NonSim = int.Parse(this.textBox4.Text);
            // Scale of gap(Gap Penality)
            int Gap= int.Parse(this.textBox5.Text);
             //string Seq1 = "-GAATTCAGTTA";
             //string Seq2 = "-GGATCGA";
            //prepare Matrix for Computing optimal alignment
            Cell[,] Matrix = DynamicProgramming.Intialization_Step(Seq1, Seq2,Sim,NonSim,Gap);
            // prepare Datagridview to show result of Dynamic Programming Matrix
            this.dataGridView1.ColumnCount = Matrix.GetLength(1)+1;
            for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
            {
                this.dataGridView1.Columns[i].Width = 25;//18 for positive values
                
            }
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.RowCount = Matrix.GetLength(0)+1;
            //for (int j = 1; j < Matrix.GetLength(0) + 1; j++)
            //{

            //    this.dataGridView1.Rows[j].HeaderCell.Value= Seq2[j - 1];
               
            //}
            for (int j = 1; j < Matrix.GetLength(0)+1; j++)
            {
                
                this.dataGridView1.Rows[j].Cells[0].Value = Seq2[j-1];
            }
            for (int i = 1; i < Matrix.GetLength(1)+1; i++)
            {
                this.dataGridView1.Rows[0].Cells[i].Value = Seq1[i-1];
                //this.dataGridView1.Columns[i].HeaderText = Seq1[i-1].ToString();
            }
           
            for (int j = 1; j < Matrix.GetLength(0)+1; j++)
            {
                for (int i = 1; i < Matrix.GetLength(1)+1; i++)
                {
                   
                    this.dataGridView1.Rows[j].Cells[i].Value = Matrix[j-1, i-1].CellScore;

                }

            }


            // Trace back matrix from end cell that contains max score { from end cell [SeqAlign2.Count - 1,SeqAlign1.Count - 1] to initial cell [0,0]}
            DynamicProgramming.Traceback_Step(Matrix, Seq1, Seq2,SeqAlign1,SeqAlign2);

            // Display Result of alignments
            //note the trace in matrix done in reverse manner (trace back) 
            for (int j = SeqAlign1.Count - 1; j >= 0; j--)
            {
                this.richTextBox1.AppendText(SeqAlign1[j].ToString());

            }
            this.richTextBox1.AppendText('\n'.ToString());
            for (int f = SeqAlign2.Count - 1; f >= 0; f--)
            {
                this.richTextBox1.AppendText(SeqAlign2[f].ToString());
            }
        }
       

         private void richTextBox1_TextChanged(object sender, EventArgs e)
         {

         }

         private void label2_Click(object sender, EventArgs e)
         {

         }

         private void Form1_Load(object sender, EventArgs e)
         {
             // Default Values
             this.textBox1.Text = "GAATTCAGTTA";
             this.textBox2.Text = "GGATCGA";
             this.textBox3.Text = "1";
             this.textBox4.Text = "-1";
             this.textBox5.Text = "-2";
         }
    }
}

