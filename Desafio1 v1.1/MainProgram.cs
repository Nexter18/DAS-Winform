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
                    datostxt1.Clear();
                    datostxt2.Clear();
                    datostxt3.Clear();
                    tabControl1.Show();
                    chart1.Series["Popularidad"].Points.Clear();
                    foreach (var cats in jObject.Categoria1)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Serie1;
                        this.tabPage2.Text = cats.Serie2;
                        this.tabPage3.Text = cats.Serie3;
                        this.tabPage4.Text = "Popularidad";

                        foreach (var data in cats.DatosSerie1)
                        {
                            dataOutput_one("Titulo en Español: " + data.TituloenEspañol.ToString());
                            dataOutput_one("Creado por: " + data.Creadopor.ToString());
                            dataOutput_one("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_one("Pais de Origen: " + data.PaisdeOrigen.ToString());
                            dataOutput_one("Temporadas: " + data.Temporadas.ToString());
                            dataOutput_one("Episodios: " + data.Episodios.ToString());
                            dataOutput_one("Sinopsis: " + data.Sinopsis.ToString());
                        }
                        foreach (var data in cats.DatosSerie2)
                        {
                            dataOutput_two("Titulo en Español: " + data.TituloenEspañol.ToString());
                            dataOutput_two("Creado por: " + data.Creadopor.ToString());
                            dataOutput_two("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_two("Pais de Origen: " + data.PaisdeOrigen.ToString());
                            dataOutput_two("Temporadas: " + data.Temporadas.ToString());
                            dataOutput_two("Episodios: " + data.Episodios.ToString());
                            dataOutput_two("Sinopsis: " + data.Sinopsis.ToString());
                        }
                        foreach (var data in cats.DatosSerie3)
                        {
                            dataOutput_three("Titulo en Español: " + data.TituloenEspañol.ToString());
                            dataOutput_three("Creado por: " + data.Creadopor.ToString());
                            dataOutput_three("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_three("Pais de Origen: " + data.PaisdeOrigen.ToString());
                            dataOutput_three("Temporadas: " + data.Temporadas.ToString());
                            dataOutput_three("Episodios: " + data.Episodios.ToString());
                            dataOutput_three("Sinopsis: " + data.Sinopsis.ToString());
                        }

                    }
                    chart1.Series["Popularidad"].Points.AddXY("Games of Thrones", 40);
                    chart1.Series["Popularidad"].Points.AddXY("Chernobyl", 34);
                    chart1.Series["Popularidad"].Points.AddXY("The Marvelous Mrs Maisel", 26);
                }
                else if (comboBox1.SelectedItem.ToString() == "Libros")
                {
                    datostxt1.Clear();
                    datostxt2.Clear();
                    datostxt3.Clear();
                    tabControl1.Show();
                    chart1.Series["Popularidad"].Points.Clear();
                    foreach (var cats in jObject.Categoria2)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Libro1;
                        this.tabPage2.Text = cats.Libro2;
                        this.tabPage3.Text = cats.Libro3;
                        this.tabPage4.Text = "Popularidad";

                        foreach (var data in cats.DatosLibro1)
                        {
                            dataOutput_one("Autor: " + data.Autor.ToString());
                            dataOutput_one("Genero: " + data.Genero.ToString());
                            dataOutput_one("Subgenero: " + data.Subgenero.ToString());
                            dataOutput_one("#Paginas: " + data.Paginas.ToString());
                            dataOutput_one("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_one("Antagonistas: " + data.Antagonistas.ToString());
                            dataOutput_one("Argumento: " + data.Argumento.ToString());
                        }
                        foreach (var data in cats.DatosLibro2)
                        {
                            dataOutput_two("Autor: " + data.Autor.ToString());
                            dataOutput_two("Genero: " + data.Genero.ToString());
                            dataOutput_two("Subgenero: " + data.Subgenero.ToString());
                            dataOutput_two("#Paginas: " + data.Paginas.ToString());
                            dataOutput_two("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_two("Antagonistas: " + data.Antagonistas.ToString());
                            dataOutput_two("Argumento: " + data.Argumento.ToString());
                        }
                        foreach (var data in cats.DatosLibro3)
                        {
                            dataOutput_three("Autor: " + data.Autor.ToString());
                            dataOutput_three("Genero: " + data.Genero.ToString());
                            dataOutput_three("Subgenero: " + data.Subgenero.ToString());
                            dataOutput_three("#Paginas: " + data.Paginas.ToString());
                            dataOutput_three("Protagonistas: " + data.Protagonistas.ToString());
                            dataOutput_three("Antagonistas: " + data.Antagonistas.ToString());
                            dataOutput_three("Argumento: " + data.Argumento.ToString());
                        }

                    }
                    chart1.Series["Popularidad"].Points.AddXY("Harry Potter", 44);
                    chart1.Series["Popularidad"].Points.AddXY("Goosebumps", 30);
                    chart1.Series["Popularidad"].Points.AddXY("PerryMason", 26);
                }
                else if (comboBox1.SelectedItem.ToString() == "Lenguajes de Programacion")
                {
                    datostxt1.Clear();
                    datostxt2.Clear();
                    datostxt3.Clear();
                    tabControl1.Show();
                    chart1.Series["Popularidad"].Points.Clear();
                    foreach (var cats in jObject.Categoria3)
                    {
                        this.titleLabel.Text = cats.Titulo;
                        this.tabPage1.Text = cats.Lenguaje1;
                        this.tabPage2.Text = cats.Lenguaje2;
                        this.tabPage3.Text = cats.Lenguaje3;

                        foreach (var data in cats.DatosLenguaje1)
                        {
                            dataOutput_one("Desarrolladores: " + data.Desarrolladores.ToString());
                            dataOutput_one("Extensiones: " + data.Extensiones.ToString());
                            dataOutput_one("Aparecio en: " + data.Aparecioen.ToString());
                            dataOutput_one("Sistema Operativo: " + data.SistemaOperativo.ToString());
                            dataOutput_one("Paradigma: " + data.Paradigma.ToString());
                            dataOutput_one("Ultima Version: " + data.UltimaVersion.ToString());
                            dataOutput_one("Licencia: " +data.Licencia.ToString());
                        }
                        foreach (var data in cats.DatosLenguaje2)
                        {
                            dataOutput_two("Desarrolladores: " + data.Desarrolladores.ToString());
                            dataOutput_two("Extensiones: " + data.Extensiones.ToString());
                            dataOutput_two("Aparecio en: " + data.Aparecioen.ToString());
                            dataOutput_two("Sistema Operativo: " + data.SistemaOperativo.ToString());
                            dataOutput_two("Paradigma: " + data.Paradigma.ToString());
                            dataOutput_two("Ultima Version: " + data.UltimaVersion.ToString());
                            dataOutput_two("Licencia: " + data.Licencia.ToString());
                        }
                        foreach (var data in cats.DatosLenguaje3)
                        {
                            dataOutput_three("Desarrolladores: " + data.Desarrolladores.ToString());
                            dataOutput_three("Extensiones: " + data.Extensiones.ToString());
                            dataOutput_three("Aparecio en: " + data.Aparecioen.ToString());
                            dataOutput_three("Sistema Operativo: " + data.SistemaOperativo.ToString());
                            dataOutput_three("Paradigma: " + data.Paradigma.ToString());
                            dataOutput_three("Ultima Version: " + data.UltimaVersion.ToString());
                            dataOutput_three("Licencia: " + data.Licencia.ToString());
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
