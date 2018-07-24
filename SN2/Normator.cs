using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN2
{
    class Normator
    {
        double[][] lambds;
        double[][] fluxes;
        double[] lambds_temp = null;
        double[] intes_temp = null;
        double[] intes_interp;
        double[] coeff = null;
        double[][] cont;
        int ord_o, ord_x;
        double max_flux;
        LinInterpolator li = null;
        int n_orders;
        int n_pixels;
        double[][] mask;

        public Normator(double[][] lambs, double[][] flxs, double[] lambs_t, double[] intes_t, double[][] mask)
        {
            this.lambds = lambs;
            this.fluxes = flxs;
            this.lambds_temp = lambs_t;
            this.intes_temp = intes_t;
            this.mask = mask;
        }

        public Normator(double[][] lambs, double[][] flxs, double[][] mask)
        {
            this.lambds = lambs;
            this.fluxes = flxs;
            this.mask = mask;
        }

        public void Norm1(int oo, int ox, int iterMax)
        {
            ord_x = ox;
            ord_o = oo;

            n_orders = this.lambds.Length;
            n_pixels = this.lambds[0].Length;

            if (this.lambds_temp != null)
                li = new LinInterpolator(lambds_temp, intes_temp);

            double[] fluxes_norm = new double[n_orders * n_pixels];
            double[] sigmas = new double[n_orders * n_pixels];
            
            double[][] xx = new double[n_orders * n_pixels][];
            for (int i = 0; i < xx.Length; i++) xx[i] = new double[2];

            max_flux = this.fluxes[0][0];
            for (int i = 0; i < n_orders; i++)
                for (int j = 0; j < n_pixels; j++)
                    if (max_flux < fluxes[i][j]) max_flux = fluxes[i][j];

            // Removing regions in observed spectra according the mask;
            int k = 0;
            for (int n = 0; n < n_orders; n++)
            {
                for (int i = 0; i < n_pixels; i++)
                {
                    bool notInMask = true;
                    for (int s = 0; s < mask.Length; s++)
                    {
                        if (lambds[n][i] >= mask[s][0] && lambds[n][i] <= mask[s][1]) notInMask = false;
                    }
                    if (notInMask)
                    {
                        fluxes_norm[k] = fluxes[n][i] / max_flux;
                        if (fluxes_norm[k] > 0) sigmas[k] = Math.Sqrt(fluxes_norm[k]);
                        else sigmas[k] = 1e20;
                        xx[k][0] = (double)n / n_orders;
                        xx[k][1] = (double)i / n_pixels;
                        k++;
                    }
                }
            }

            Array.Resize(ref xx, k);
            Array.Resize(ref fluxes_norm, k);

            // Fitting the model spectra to observed spectra;
            FitSVD.fit_finctions_md func = new FitSVD.fit_finctions_md(Pars);

            FitSVD fitter = new FitSVD(xx, fluxes_norm, sigmas, func, 1e-20);

            double stderror;
            int rejected_poins_number = 0;
            for (int i = 0; i < 1; i++)
            {
                fitter.fit();
                coeff = fitter.FittedCoeffs;
                stderror = 0;
                //for (int j = 0; j < points_number; j++)
                //{
                //    stderror += Math.Pow(point_lambda[j] - Surface(coeff, point_order[j], point_pixel[j], oo, ox), 2);
                //}
                //stderror = Math.Sqrt(stderror / points_number);
                //double diff;
                //int k = 0;
                //for (int j = 0; j < points_number; j++)
                //{
                //    diff = Math.Abs(point_lambda[j] - Surface(coeff, point_order[j], point_pixel[j], oo, ox));
                //    if (diff < cutLimit * stderror)
                //    {
                //        point_lambda[k] = point_lambda[j];
                //        point_order[k] = point_order[j];
                //        point_pixel[k] = point_pixel[j];
                //        k++;
                //    }
                //    else
                //    {
                //        rejected_poins_number++;
                //    }
                //}
                //points_number = k;
            }

            cont = new double[n_orders][];
            for (int i = 0; i < cont.Length; i++) cont[i] = new double[n_pixels];


            for (int i = 0; i < n_orders; i++)
            {
                for (int j = 0; j < n_pixels; j++)
                {
                    cont[i][j] = Surface(coeff, (double)i / n_orders, 
                        (double)j / n_pixels, oo, ox) * max_flux;
                }
            }
        }

        private double[] Pars(double[] xy)
        {
            double[] pars = new double[(ord_o + 1) * (ord_x + 1)];
            double r = 1;
            if (this.li != null)
            {
                r = li.InterpUni(
                    lambds[(int)Math.Round(xy[0] * n_orders, 0)][(int)Math.Round(xy[1] * n_pixels, 0)]);
            }
            int k = 0;
            for (int i = 0; i <= ord_o; i++)
            {
                for (int j = 0; j <= ord_x; j++ )
                {
                    pars[k] = r * Math.Pow(xy[0], i) * Math.Pow(xy[1], j);
                    k++;
                }
            }
            return pars;
        }

        private static double Surface(double[] coeff, double order, double pix, int ox, int oy)
        {
            int k = 0;
            double sum = 0;
            for (int i = 0; i <= ox; i++)
            {
                for (int j = 0; j <= oy; j++)
                {
                    sum += coeff[k] * Math.Pow(order, i) * Math.Pow(pix, j);
                    k++;
                }
            }
            return sum;
        }

        public double[][] GetContinum
        {
            get { return this.cont; }
        }

        private static double[] Fitting(double[] x, double[] y, double[] f, int ox, int oy)
        {
            int g_col_count;
            int g_row_count;
            g_col_count = (ox + 1) * (oy + 1);
            g_row_count = f.Length;
            double[,] g_matrix = new double[g_row_count, g_col_count];
            double[,] g_matrix_tr = new double[g_col_count, g_row_count];
            double[,] ggtr = new double[g_col_count, g_col_count];
            double[] gf = new double[g_col_count];
            double[] coeff;


            for (int p = 0; p < g_row_count; p++)
            {
                int k = 0;
                for (int i = 0; i <= ox; i++)
                {
                    for (int j = 0; j <= oy; j++)
                    {
                        g_matrix[p, k] = Math.Pow(x[p], i) * Math.Pow(y[p], j);
                        k++;
                    }
                }
            }

            for (int i = 0; i < g_col_count; i++)
            {
                for (int j = 0; j < g_row_count; j++)
                {
                    g_matrix_tr[i, j] = g_matrix[j, i];
                }
            }

            for (int i = 0; i < g_col_count; i++)
            {
                for (int j = 0; j < g_col_count; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < g_row_count; k++)
                    {
                        sum += g_matrix_tr[i, k] * g_matrix[k, j];
                    }
                    ggtr[i, j] = sum;
                }
            }

            for (int i = 0; i < g_col_count; i++)
            {
                double sum = 0;
                for (int j = 0; j < g_row_count; j++)
                {
                    sum += g_matrix_tr[i, j] * f[j];
                }
                gf[i] = sum;
            }

            coeff = SolveWithGaussMethod(ggtr, gf);

            return coeff;
        }

        static public double[] SolveWithGaussMethod(double[,] m, double[] l)
        {
            int N = l.Length;

            double[] x = new double[N];

            // Приведение матрицы m к треугольному виду
            for (int s = 0; s <= N - 2; s++)
            {
                double k1 = m[s, s];

                for (int c = s; c <= N - 1; c++)
                {
                    m[s, c] = m[s, c] / k1;
                }

                l[s] = l[s] / k1;
                for (int s1 = s + 1; s1 <= N - 1; s1++)
                {
                    double k2 = m[s1, s];
                    for (int c1 = s; c1 <= N - 1; c1++)
                    {
                        m[s1, c1] = -m[s, c1] * k2 + m[s1, c1];
                    }
                    l[s1] = -l[s] * k2 + l[s1];
                }
            }
            // обратный ход
            x[N - 1] = l[N - 1] / m[N - 1, N - 1];
            for (int i = N - 2; i >= 0; i--)
            {
                double w = 0;
                for (int j = N - 1; j > i; j--)
                {
                    w = w + x[j] * m[i, j];
                }
                x[i] = (l[i] - w);
            }
            return x;
        }
    }
}
