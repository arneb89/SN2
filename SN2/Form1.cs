using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPlot;

namespace SN2
{
    public partial class Form1 : Form
    {
        string dir;
        string[] files;
        double[][] lambds;
        double[][] fluxes;
        double[][] cont;
        int nn1, nn2;
        LinInterpolator li;
        Mask cutMask;
        Mask tellur;

        TempSpec tspec = null;
        TempSpec tspec1 = null;
        TempSpec tspec2 = null;

        public Form1()
        {
            InitializeComponent();
            lbOrders.SelectedIndexChanged += new EventHandler(DrawObsSpecGraphHandler);
            plot.MouseDoubleClick += new MouseEventHandler(plotTemplateSpectrum_MouseDoubleClick);
            this.cutMask = new Mask();
        }

        private void InitOrderBox()
        {
            for (int i = 0; i < lambds.Length; i++)
            {
                lbOrders.Items.Add(string.Format("ORDER {0}", i));
            }
        }

        private void LoadObsSpectra()
        {
            if (rbOneFile.Checked)
            {
                LoadObsSpectra2();
                return;
            }
            nn1 = int.Parse(txtNN1.Text.Replace(".", ","));
            nn2 = int.Parse(txtNN2.Text.Replace(".", ","));
            int n_orders;
            n_orders = nn2 - nn1 + 1;
            string mask = @txtFileMask.Text;
            dir = @txtDir.Text;
            files = Directory.GetFiles(dir, mask);

            int k = 0;

            for (int i = nn1; i <= nn2; i++)
            {
                files[k] = files[i];
                k++;
            }
            Array.Resize(ref files, n_orders);
            

            this.lambds = null;
            this.fluxes = null;
            lbOrders.Items.Clear();

            this.lambds = new double[n_orders][];
            this.fluxes = new double[n_orders][];

            string[] delims = new string[] { " ", "\t", "\r", "\n", "\r\n" };
            for (int i = 0; i < n_orders; i++)
            {
                StreamReader sr = new StreamReader(files[i]);
                string text = sr.ReadToEnd();
                string[] words = text.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                this.lambds[i] = new double[words.Length / 2];
                this.fluxes[i] = new double[words.Length / 2];

                int n = 0;

                for (int j = 0; j < words.Length / 2; j++)
                {
                    this.lambds[i][j] = double.Parse(words[n].Replace(".", ","));
                    this.fluxes[i][j] = double.Parse(words[n + 1].Replace(".", ","));
                    n = n + 2;
                    
                }
            }

            InitOrderBox();
        }

        private void SpectraThinning(int step)
        {

            for (int i = 0; i < this.lambds.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < this.lambds[i].Length; j = j + step)
                {
                    this.lambds[i][k] = this.lambds[i][j];
                    this.fluxes[i][k] = this.fluxes[i][j];
                    k++;
                }
                Array.Resize(ref this.lambds[i], k);
                Array.Resize(ref this.fluxes[i], k);
            }
        }

        private void LoadObsSpectra2()
        {
            nn1 = int.Parse(txtNN1.Text);
            nn2 = int.Parse(txtNN2.Text);
            int n_orders;
            n_orders = nn2 - nn1 + 1;
            string file = txtFileMask.Text;
            dir = @txtDir.Text;

            string str;
            string[] strMas;
            string[] delims = new string[] { " ", "\t" };

            StreamReader sr = new StreamReader(dir + file);


            int n_lines = NLines(dir + file);
            this.lambds = new double[n_orders][];
            this.fluxes = new double[n_orders][];
            for (int i = 0; i < lambds.Length; i++)
            {
                lambds[i] = new double[n_lines];
                fluxes[i] = new double[n_lines];
            }
            for (int i = 0; i < n_lines; i++)
            {
                str = sr.ReadLine();
                strMas = str.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n_orders; j++)
                {
                    lambds[j][i] = double.Parse(strMas[nn1 * 2 + j * 2], 
                        System.Globalization.CultureInfo.InvariantCulture);
                    fluxes[j][i] = double.Parse(strMas[nn1 * 2 + j * 2 + 1], 
                        System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            InitOrderBox();
        }

        private int NLines(string path)
        {
            StreamReader sr = new StreamReader(path);
            string str;
            int n=-1;
            do
            {
                n++;
                str = sr.ReadLine();
            } while (str!=null && str != "" && str != "\r\n");
            return n;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int oo, ox;

            try
            {
                oo = int.Parse(txtOrderO.Text.Replace(",", "."), 
                    System.Globalization.CultureInfo.InvariantCulture);
                ox = int.Parse(txtOrderX.Text.Replace(",", "."), 
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Some error in input parameters...", "Error...");
                return;
            }

            this.lambds = null;
            this.fluxes = null;
            this.cont = null;
            this.files = null;

            lbOrders.Items.Clear();
            LoadObsSpectra();

            if (rbCompTwo.Checked)
            {
                double rv1, rv2;
                try
                {
                    rv1 = double.Parse(txtRV1.Text.Replace(",", "."),
                        System.Globalization.CultureInfo.InvariantCulture);
                    rv2 = double.Parse(txtRV2.Text.Replace(",", "."),
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Some error in RV1 or RV2 fields...", "Error...");
                    return;
                }
                try
                {
                    tspec1 = new TempSpec(txtTemplate1.Text);
                }
                catch
                {
                    MessageBox.Show("Cannot load Template 1 file...", "Error...");
                    return;
                }
                try
                {
                    tspec2 = new TempSpec(txtTemplate2.Text);
                }
                catch
                {
                    MessageBox.Show("Cannot load Template 2 file...", "Error...");
                    return;
                }
                tspec = TempSpec.Sum(tspec1, tspec2, rv1, rv2);
            }
            else
            {
                double rv;
                try
                {
                    rv = double.Parse(txtRV1.Text.Replace(",", "."),
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Some error in RV1 field...", "Error...");
                    return;
                }
                try
                {
                    tspec1 = new TempSpec(txtTemplate1.Text);
                }
                catch
                {
                    MessageBox.Show("Cannot load Template 1 file...", "Error...");
                    return;
                }
                tspec = tspec1.RVShift(rv);
            }

            tellur = new Mask(Application.StartupPath + "\\telluric.txt");

            double[][] mask = new double[tellur.Size() + cutMask.Size()][];
            for (int i = 0; i < mask.Length; i++) mask[i] = new double[2];
            for (int i = 0; i < tellur.Size(); i++)
            {
                mask[i][0] = tellur.GetLeftBound(i);
                mask[i][1] = tellur.GetRightBound(i);
            }
            for (int i = 0; i < cutMask.Size(); i++)
            {
                mask[i + tellur.Size()][0] = cutMask.GetLeftBound(i);
                mask[i + tellur.Size()][1] = cutMask.GetRightBound(i);
            }

            SpectraThinning(3);

            Normator norm = new Normator(lambds, fluxes, tspec.Lambdas, tspec.NormFluxes, mask);
            norm.Norm1(oo, ox, 10);
            cont = norm.Continum;
        }

        private void DrawObsSpecGraphHandler(object sender, EventArgs e)
        {
            DrawObsSpecGraph();
        }

        private void DrawObsSpecGraph()
        {
            int n = lbOrders.SelectedIndex;

            double lam_min = lambds[n].First();
            double lam_max = lambds[n].Last();
            if (lam_min > lam_max)
            {
                double buff;
                buff = lam_max;
                lam_max = lam_min;
                lam_min = buff;
            }
            plot.Clear();
            for (int i = 0; i < tellur.Size(); i++)
            {
                if (tellur.GetLeftBound(i) > lam_min && tellur.GetRightBound(i) < lam_max)
                {
                    VerticalLine vl1 = new VerticalLine(tellur.GetLeftBound(i));
                    VerticalLine vl2 = new VerticalLine(tellur.GetRightBound(i));
                    FilledRegion fr = new FilledRegion(vl1, vl2);
                    fr.Brush = Brushes.LightBlue;
                    plot.Add(fr);
                }
            }
            for (int i = 0; i < cutMask.Size(); i++)
            {
                if (cutMask.GetLeftBound(i) > lam_min && cutMask.GetRightBound(i) < lam_max)
                {
                    VerticalLine vl1 = new VerticalLine(cutMask.GetLeftBound(i));
                    VerticalLine vl2 = new VerticalLine(cutMask.GetRightBound(i));
                    FilledRegion fr = new FilledRegion(vl1, vl2);
                    fr.Brush = Brushes.Coral;
                    plot.Add(fr);
                }
            }

            LinePlot lp = new LinePlot();
            lp.AbscissaData = this.lambds[n];
            lp.OrdinateData = this.fluxes[n];

            
            plot.Add(lp);

            if (this.cont != null)
            {
                int nums = lambds[0].Length;
                li = new LinInterpolator(tspec.Lambdas, tspec.NormFluxes);

                double[] ll = new double[nums];
                double[] ff = new double[nums];
                for (int i = 0; i < nums; i++)
                {
                    ll[i] = lambds[n][i];
                    ff[i] = li.InterpUni(ll[i]) * cont[n][i];
                }

                LinePlot lp0 = new LinePlot();
                lp0.AbscissaData = this.lambds[n];
                lp0.OrdinateData = this.cont[n];
                lp0.Color = Color.Green;

                LinePlot lp1 = new LinePlot();
                lp1.AbscissaData = ll;
                lp1.OrdinateData = ff;
                lp1.Color = Color.Red;

                plot.Add(lp0);
                plot.Add(lp1);
            }

            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            plot.XAxis1.Label = "Wavelength";
            plot.YAxis1.Label = "Flux";
            plot.Show();
            plot.Refresh();
        }

        /********************************************************************************/

        bool firstBound = true;
        double leftBound, rightBound;

        private void plotTemplateSpectrum_MouseDoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs eA = (MouseEventArgs)e;

            // Calculate data value
            Point here = new Point(eA.X, eA.Y);
            double x = this.plot.PhysicalXAxis1Cache.PhysicalToWorld(here, true);

            if (this.firstBound)
            {
                leftBound = x;
                this.firstBound = false;
            }
            else
            {
                rightBound = x;
                this.firstBound = true;
                if (leftBound > rightBound)
                {
                    double buff;
                    buff = rightBound;
                    rightBound = leftBound;
                    leftBound = buff;
                }
                this.cutMask.AddRange(this.leftBound, this.rightBound);
                this.RefreshMask();
            }
            if (firstBound == false)
            {
                DrawObsSpecGraph();
            }
        }

        private void RefreshMask()
        {
            lbRanges.Items.Clear();
            for (int i = 0; i < cutMask.Size(); i++)
            {
                lbRanges.Items.Add(string.Format("RANGE: {0:0000.000} --- {1:0000.000}",
                    this.cutMask.GetLeftBound(i),
                    this.cutMask.GetRightBound(i)));
            }
            this.DrawObsSpecGraph();
        }

        private void btnAddRange_Click(object sender, EventArgs e)
        {

        }

        private void btnDelRange_Click(object sender, EventArgs e)
        {
            int number;
            number = lbRanges.SelectedIndex;
            if (number == -1) return;
            cutMask.DeleteRange(number);
            this.RefreshMask();
        }

        private void btnSaveMask_Click(object sender, EventArgs e)
        {
            string path = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
            }
            this.cutMask.Write(path);
            this.RefreshMask();
        }

        private void btnCCMask_Click(object sender, EventArgs e)
        {
            this.cutMask.Clear();
            this.RefreshMask();
        }

        private void btnOpenMask_Click(object sender, EventArgs e)
        {
            string path;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            this.cutMask = new Mask(path);
            this.RefreshMask();
        }

        /********************************************************************************/

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cont == null) return;

            string file_path;
            StreamWriter sw;
            for (int i = 0; i < lambds.Length; i++)
            {
                file_path = files[i].Replace(".dat", "") + ".norm.dat";
                sw = new StreamWriter(file_path);
                if (lambds[i][0] < lambds[i][1])
                {
                    for (int n = 0; n < lambds[i].Length; n++)
                    {
                        sw.WriteLine(string.Format("{0:0000.0000}\t{1:0.000000}\t{2:0.000000}",
                            lambds[i][n], fluxes[i][n] / cont[i][n], cont[i][n]).Replace(",", "."));
                    }
                }
                else
                {
                    for (int n = lambds[i].Length-1; n >= 0; n--)
                    {
                        sw.WriteLine(string.Format("{0:0000.0000}\t{1:0.000000}\t{2:0.000000}",
                            lambds[i][n], fluxes[i][n] / cont[i][n], cont[i][n]).Replace(",", "."));
                    }
                }
                sw.Close();
            }
        }

        private void rbCompOne_CheckedChanged(object sender, EventArgs e)
        {
            txtTemplate2.ReadOnly = true;
            txtRV2.ReadOnly = true;
        }

        private void rbCompTwo_CheckedChanged(object sender, EventArgs e)
        {
            txtTemplate2.ReadOnly = false;
            txtRV2.ReadOnly = false;
        }
    }
}
