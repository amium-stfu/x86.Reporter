using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportExplorer
{
    internal class verification1066
    {
        public (List<double> Ref,
              List<double> Dut,
              double? a0,
              double? a1,
              double? SEE,
              double? xmin,
              double? r2,
              int? n,
              double? nmax,
              int SamplePoints
              ) Linearity;


        public (double? Noise, double? Accuracy, double? Repeatability, double? Precision, string Law, string Mode) ANR;

        public verification1066()
        {

            Linearity.Dut = new List<double>();
            Linearity.Ref = new List<double>();
            Linearity.SamplePoints = 0;
        }

        public void CalculateLinearity()
        {
            try
            {
                double sum = 0;
                Linearity.n = Linearity.Dut.Count();

                Console.WriteLine("n " + Linearity.n);
                if (Linearity.n < Linearity.SamplePoints)
                    return;

                foreach (double v in Linearity.Dut)
                    sum += v;

                double avrRead = sum / Linearity.Dut.Count();
                sum = 0;
                foreach (double v in Linearity.Ref)
                    sum += v;
                double avrRef = sum / Linearity.Dut.Count();

                int c = -1;
                double sumR1 = 0;
                foreach (double v in Linearity.Dut)
                {
                    c++;
                    double r = (Linearity.Dut[c] - avrRead) * (Linearity.Ref[c] - avrRef);
                    sumR1 += r;
                }

                c = -1;
                double sumR2 = 0;
                foreach (double v in Linearity.Dut)
                {
                    c++;
                    double r = (Linearity.Ref[c] - avrRef) * (Linearity.Ref[c] - avrRef);
                    sumR2 += r;
                }

                Linearity.a1 = sumR1 / sumR2;

                Linearity.a0 = avrRead - (Linearity.a1 * avrRef);



                c = -1;
                double? sumR3 = 0;
                foreach (double v in Linearity.Dut)
                {
                    c++;
                    double? r = (Linearity.Dut[c] - Linearity.a0) - (Linearity.a1 * Linearity.Ref[c]);
                    r = r * r;
                    sumR3 += r;
                }

                double sumR4 = 0;
                c = -1;
                foreach (double v in Linearity.Dut)
                {
                    c++;
                    double r = (Linearity.Dut[c] - avrRead);
                    r = r * r;
                    sumR4 += r;
                }

                double sy = Math.Sqrt(sumR4 / (Linearity.Dut.Count() - 1));

                Linearity.SEE = Math.Sqrt((double)sumR3 / (Linearity.Dut.Count() - 2));

                Linearity.r2 = 1 - sumR3 / sumR4;

                double readMin = Linearity.Dut.Min();
                double readMax = Linearity.Dut.Max();

                double refMin = Linearity.Ref.Min();
                double refMax = Linearity.Ref.Max();

                Linearity.xmin = Math.Abs(readMin * ((double)Linearity.a1 - 1) + (double)Linearity.a0);

                Linearity.nmax = refMax;
            }
            catch (Exception ex) 
            { 
            Console.WriteLine(ex.Message);
            }

        }


        public void CalculateANR()
        {

        }

    }
}
