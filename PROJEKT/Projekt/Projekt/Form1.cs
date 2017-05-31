using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void otworz_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg;
            dlg = new OpenFileDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                FileStream fs;
                fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr;
                sr = new StreamReader(fs);

                lista.Items.Clear();

                string sLine;
                sLine = sr.ReadLine();
                int i = 1;
                while (sLine != null)
                {
                    string sWspolrzedne = sLine.Substring(sLine.IndexOf(' ') + 1);

                    char[] chSep = new char[] { ' ' };
                    string[] sWspolArr = sWspolrzedne.Split(chSep, StringSplitOptions.RemoveEmptyEntries);

                                      
                    lista.Items.Add(sWspolrzedne);

                        sLine = sr.ReadLine();
                        i = i + 1;
                    }

                    sr.Close();

                }
            }
        }
    }
