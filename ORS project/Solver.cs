using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ORS_project
{
    class Solver
    {
        string filename = "Input.txt";// text file name
        double[,] Value = new double[4, 7];

        public void Reader()//Text file reader
        {
            string[] values = new string[4];

            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);// opening the file and reading it
            StreamReader streamReader = new StreamReader(fs);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = streamReader.ReadLine();
            }

            string[] row0 = values[0].Split();
            string[] row1 = values[1].Split();
            string[] row2 = values[2].Split();
            string[] row3 = values[3].Split();
            string maxormin = row0[0];// Maximization or Minimization decider

            if (maxormin.ToLower() == "max")
            {

                Value[0, 1] = double.Parse(row0[1]);
                Value[0, 2] = double.Parse(row0[2]);

                Value[0, 0] = 1;
                Value[0, 1] = Value[0, 1] * -1;
                Value[0, 2] = Value[0, 2] * -1;
                //r1
                Value[1, 1] = double.Parse(row1[0]);
                Value[1, 2] = double.Parse(row1[1]);
                Value[1, 3] = 1;
                Value[1, 6] = double.Parse(row1[3]);
                //r2
                Value[2, 1] = double.Parse(row2[0]);
                Value[2, 2] = double.Parse(row2[1]);
                Value[2, 4] = 1;
                Value[2, 6] = double.Parse(row2[3]);
                //r3
                Value[3, 1] = double.Parse(row3[0]);
                Value[3, 2] = double.Parse(row3[1]);
                Value[3, 5] = 1;
                Value[3, 6] = double.Parse(row3[3]);


            }
            else if (maxormin.ToLower() == "min")
            {
                Value[0, 1] = double.Parse(row0[1]);
                Value[0, 2] = double.Parse(row0[2]);

                Value[0, 0] = -1;
                Value[0, 1] = Value[0, 1] * -1;
                Value[0, 2] = Value[0, 2] * -1;

                Value[1, 1] = double.Parse(row1[0]);
                Value[1, 2] = double.Parse(row1[1]);
                Value[1, 3] = 1;
                Value[1, 6] = double.Parse(row1[3]);
                //r2
                Value[2, 1] = double.Parse(row2[0]);
                Value[2, 2] = double.Parse(row2[1]);
                Value[2, 4] = 1;
                Value[2, 6] = double.Parse(row2[3]);
                //r3
                Value[3, 1] = double.Parse(row3[0]);
                Value[3, 2] = double.Parse(row3[1]);
                Value[3, 5] = 1;
                Value[3, 6] = double.Parse(row3[3]);
            }

            streamReader.Close();
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////READING TEXT FILE ENDS
        /// </summary>

        public void SubSolver()
        {
            // ratio tests variables
            double rt1 = 0;
            double rt2 = 0;
            double rt3 = 0;

            if (Value[0, 1] < Value[0, 2] && Value[0, 1] < 0 && Value[0, 2] < 0)
            {
                //check the ratio test
                rt1 = Value[1, 6] / Value[1, 1];
                rt2 = Value[2, 6] / Value[2, 1];
                rt3 = Value[3, 6] / Value[3, 1];

                if (rt1 < rt2 && rt1 < rt3 && rt1 >= 0)
                {
                    double something = Value[1, 1];
                    for (int i = 0; i < 7; i++)
                    {

                        Value[1, i] = Value[1, i] / something;
                    }

                    //solving row 0
                    something = Value[0, 1];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }

                        Value[0, some] = Value[0, some] - something * Value[1, some];
                    }

                    // solving row 2
                    something = Value[2, 1];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }
                        Value[2, some] = Value[2, some] - something * Value[1, some];
                    }

                    //solving row 3
                    something = Value[3, 1];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }
                        Value[3, some] = Value[3, some] - something * Value[1, some];
                    }
                }
                if (rt2 < rt1 && rt2 < rt3 && rt2 >= 0)
                {

                    double something = Value[2, 1];
                    for (int i = 0; i < 7; i++)
                    {

                        Value[2, i] = Value[2, i] / something;
                    }
                    //solving row 0
                    something = Value[0, 1];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 4)
                        {
                            t++;

                        }

                        Value[0, t] = Value[0, t] - something * Value[2, t];
                    }

                    something = Value[1, 1];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 4)
                        {
                            some++;

                        }
                        Value[1, some] = Value[1, some] - something * Value[2, some];
                    }
                    //solving row 3
                    something = Value[3, 1];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 4)
                        {
                            some++;
                        }
                        Value[3, some] = Value[3, some] - something * Value[2, some];
                    }
                }

                if (rt3 < rt1 && rt3 < rt2 && rt3 >= 0)
                {
                    double something = Value[3, 1];
                    for (int i = 0; i < 7; i++)
                    {

                        Value[3, i] = Value[3, i] / something;
                    }

                    //solving row 0
                    something = Value[0, 1];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 2)
                        {
                            t++;
                            t++;
                        }

                        Value[0, t] = Value[0, t] - something * Value[3, t];
                    }
                    //row 1 solver
                    something = Value[1, 1];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 2)
                        {
                            t++;
                            t++;
                        }
                        Value[1, t] = Value[1, t] - something * Value[3, t];
                    }
                    // row 2 solver
                    something = Value[2, 1];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 2)
                        {
                            t++;
                            t++;
                        }
                        Value[2, t] = Value[2, t] - something * Value[3, t];
                    }
                }
            }
        }

        public void SolverCal()
        {
            double rt1 = 0, rt2 = 0, rt3 = 0;

            if (Value[0, 2] < Value[0, 1] && Value[0, 2] < 0)
            {
                rt1 = Value[1, 6] / Value[2, 2];
                rt2 = Value[2, 6] / Value[2, 2];
                rt3 = Value[3, 6] / Value[2, 2];

                if (rt1 < rt2 && rt1 < rt2 && rt1 >= 0)// ratio testing 
                {
                    double something = Value[1, 2];
                    for (int i = 0; i < 7; i++)
                    {
                        Value[1, i] = Value[1, i] / something;
                    }

                    // row 0 solving
                    something = Value[0, 2];
                    for (int d = 0; d < 7; d++)
                    {
                        if (d == 3)
                        {
                            d++;
                        }

                        Value[0, d] = Value[0, d] - something * Value[1, d];
                    }

                    // row 2 solving
                    something = Value[2, 2];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 3)
                        {
                            t++;

                        }
                        Value[2, t] = Value[2, t] - something * Value[1, t];
                    }
                    // row 3 solving
                    something = Value[3, 2];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 3)
                        {
                            t++;

                        }
                        Value[3, t] = Value[3, t] - something * Value[1, t];
                    }

                }
                else if (rt2 < rt1 && rt2 < rt3 && rt2 >= 0)
                {

                    double something = Value[2, 2];
                    for (int i = 0; i < 7; i++)
                    {

                        Value[2, i] = Value[2, i] / something;
                    }

                    something = Value[1, 2];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 3)
                        {
                            t++;
                            t++;

                        }

                        Value[1, t] = Value[1, t] - something * Value[2, t];
                    }

                    something = Value[0, 2];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 3)
                        {
                            t++;
                            t++;

                        }

                        Value[0, t] = Value[0, t] - something * Value[2, t];
                    }

                    something = Value[3, 2];
                    for (int t = 0; t < 7; t++)
                    {
                        if (t == 3)
                        {
                            t++;
                            t++;

                        }
                        Value[3, t] = Value[3, t] - something * Value[2, t];
                    }

                }

                else if (rt3 < rt1 && rt3 < rt2 && rt3 >= 0)
                {

                    double something = Value[3, 2];
                    for (int i = 0; i < 7; i++)
                    {

                        Value[3, i] = Value[3, i] / something;
                    }

                    //solving row 1
                    something = Value[1, 2];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }

                        Value[1, some] = Value[1, some] - something * Value[3, some];
                    }

                    //solving row 2
                    something = Value[2, 2];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }

                        Value[2, some] = Value[2, some] - something * Value[3, some];
                    }
                    // solving row 3
                    something = Value[0, 2];
                    for (int some = 0; some < 7; some++)
                    {
                        if (some == 3)
                        {
                            some++;
                            some++;
                        }

                        Value[0, some] = Value[0, some] - something * Value[3, some];
                    }
                }
            }
        }

        public void Display(string outputFile)// displaying the answers
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string output = outputFile + ".txt";
            FileStream filas = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fila = new StreamWriter(filas);

            fila.WriteLine(@"
                    SOLUTION FOUND:
                                    X1 = {0} 
                                    X2 = {1}
                                 MAX Z = {2}
                    ------------------------------------------------
                    ", Value[3, 6], Value[1, 6], Value[0, 6]);

            fila.Close();
        }
    }
}
