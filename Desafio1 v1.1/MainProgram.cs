using Newtonsoft.Json;
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

namespace Desafio1_v1._1
{
    public partial class MainProgram : Form
    {
        private readonly string _infoPath = @"../../Info";
        public MainProgram()
        {
            InitializeComponent();
            tabControl1.Hide();
        }

        #region formUI
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            desirializeJson(_infoPath);
        }

        #endregion

        #region DataOutput

        private void dataOutput_one(string strDataFile)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDataFile + Environment.NewLine);
                datostxt1.Text = datostxt1.Text + strDataFile + Environment.NewLine;
                datostxt1.SelectionStart = datostxt1.TextLength;
                datostxt1.ScrollToCaret();
                
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        private void dataOutput_two(string strDataFile)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDataFile + Environment.NewLine);
                datostxt2.Text = datostxt2.Text + strDataFile + Environment.NewLine;
                datostxt2.SelectionStart = datostxt2.TextLength;
                datostxt2.ScrollToCaret();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        private void dataOutput_three(string strDataFile)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDataFile + Environment.NewLine);
                datostxt3.Text = datostxt3.Text + strDataFile + Environment.NewLine;
                datostxt3.SelectionStart = datostxt3.TextLength;
                datostxt3.ScrollToCaret();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region json

        private void desirializeJson(string strJson)
        {
            try
            {
                string jsonFile;
                //bool valid = false;
                using (var reader = new StreamReader(_infoPath))
                {
                    jsonFile = reader.ReadToEnd();
                }

                var jObject = JsonConvert.DeserializeObject<dynamic>(jsonFile);

                if (comboBox1.SelectedItem.ToString() == "Programas de Entretenimiento")
                {
                    tabControl1.Show();
                    foreach (var cats in jObject.Categoria1)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Serie1;
                        this.tabPage2.Text = cats.Serie2;
                        this.tabPage3.Text = cats.Serie3;
                        this.tabPage4.Text = "Popularidad";

                        foreach (var data in cats.DatosSerie1)
                        {
                            dataOutput_one(data.TituloenEspañol.ToString());

                        }
                        
                    }

                    chart1.Series["Popularidad"].Points.AddXY("Games of Thrones", 40);
                    chart1.Series["Popularidad"].Points.AddXY("Chernobyl", 34);
                    chart1.Series["Popularidad"].Points.AddXY("The Marvelous Mrs Maisel", 26);
                }
                else if (comboBox1.SelectedItem.ToString() == "Libros")
                {
                    tabControl1.Show();
                    foreach (var cats in jObject.Categoria2)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Libro1;
                        this.tabPage2.Text = cats.Libro2;
                        this.tabPage3.Text = cats.Libro3;
                        this.tabPage4.Text = "Popularidad";

                        foreach (var data in cats.DatosLibro1)
                        {
                            dataOutput_one(data.Autor.ToString());
                        }

                    }
                    chart1.Series["Popularidad"].Points.AddXY("Harry Potter", 44);
                    chart1.Series["Popularidad"].Points.AddXY("Goosebumps", 30);
                    chart1.Series["Popularidad"].Points.AddXY("PerryMason", 26);
                }
                else if (comboBox1.SelectedItem.ToString() == "Lenguajes de Programacion")
                {
                    tabControl1.Show();
                    foreach (var cats in jObject.Categoria3)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Lenguaje1;
                        this.tabPage2.Text = cats.Lenguaje2;
                        this.tabPage3.Text = cats.Lenguaje3;

                        foreach (var data in cats.DatosLenguaje1)
                        {
                            dataOutput_one(data.Desarrolladores.ToString());
                        }

                    }
                    chart1.Series["Popularidad"].Points.AddXY("Python", 47);
                    chart1.Series["Popularidad"].Points.AddXY("Java", 38);
                    chart1.Series["Popularidad"].Points.AddXY("JavaScript", 15);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message.ToString());
            }
        }

        #endregion
    }
}
