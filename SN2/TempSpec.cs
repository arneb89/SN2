using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SN2
{
    class TempSpec
    {
        private double[] cont = null;
        private double[] norm_intes = null;
        private double[] lambs = null;

        public TempSpec(string pathToFile)
        {
            StreamReader sr = new StreamReader(pathToFile);
            int n_lines = LinesNumber(pathToFile);

            this.cont = new double[n_lines];
            this.norm_intes = new double[n_lines];
            this.lambs = new double[n_lines];

            string line;
            string[] parts;

            for (int i = 0; i < n_lines; i++)
            {
                line = sr.ReadLine();
                parts = line.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                this.lambs[i] = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                this.norm_intes[i] = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                this.cont[i] = double.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture);
            }
            sr.Close();
        }

        public TempSpec(int length) 
        {
            this.cont = new double[length];
            this.norm_intes = new double[length];
            this.lambs = new double[length];
        }

        private int LinesNumber(string pathToFile)
        {
            StreamReader sr = new StreamReader(pathToFile);
            int num = 0;
            string str = sr.ReadLine();
            while (str != null && str != "" && str != "\n")
            {
                num++;
                str = sr.ReadLine();
            }
            sr.Close();
            return num;
        }

        public int Length { get { return this.lambs.Length; } }

        public double[] Lambdas { get { return this.lambs; } }

        public double[] NormFluxes { get { return this.norm_intes; } }

        public double[] ContFluxes { get { return this.cont; } }

        public TempSpec RVShift(double rv)
        {
            TempSpec specRes = new TempSpec(this.lambs.Length);
            double c = 299792.458;
            for (int i = 0; i < specRes.Length; i++)
            {
                specRes.lambs[i] = this.lambs[i] + this.lambs[i] * rv / c;
                specRes.norm_intes[i] = norm_intes[i];
                specRes.cont[i] = cont[i];
            }

            return specRes;
        }

        public static TempSpec Sum(TempSpec spec1, TempSpec spec2, double rv1, double rv2)
        {
            if (spec1.Length != spec2.Length) return null;

            TempSpec specSum = new TempSpec(spec1.Length);

            LinInterpolator li1 = new LinInterpolator(spec1.lambs, spec1.norm_intes);
            LinInterpolator li2 = new LinInterpolator(spec2.lambs, spec2.norm_intes);
            LinInterpolator liCont1 = new LinInterpolator(spec1.lambs, spec1.cont);
            LinInterpolator liCont2=new LinInterpolator(spec2.lambs, spec2.cont);

            double lambda1 = spec1.Lambdas[0];
            double lambda2 = spec1.Lambdas[spec1.Length-1];
            double dlambda = (lambda2 - lambda1) / spec1.Length;

            double c = 299792.458;
            double lambda, cont1, cont2;

            for (int i = 0; i < specSum.Length; i++)
            {
                lambda = lambda1 + i * dlambda;
                specSum.lambs[i] = lambda;
                cont1 = liCont1.InterpUni(lambda - lambda * rv1 / c);
                cont2 = liCont2.InterpUni(lambda - lambda * rv2 / c);
                specSum.cont[i] = cont1 + cont2;
                specSum.norm_intes[i] = (li1.InterpUni(lambda - lambda * rv1 / c) * cont1 +
                    li2.InterpUni(lambda - lambda * rv2 / c) * cont2) / specSum.cont[i];
            }

            return specSum;
        }
    }
}
