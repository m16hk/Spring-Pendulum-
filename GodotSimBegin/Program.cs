//============================================================================
// Program to integrate differential equations.
//============================================================================
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        double t = 0.0;    // time
        double tEnd = 20.0; // ending time
        double dt = 0.02;  // time step

        int n = 2;   // number of ODEs to be integrated
        double[] x = new double[n];
        double[] f = new double[n];

        int i;
        string s = t.ToString();
        // for(i=0;i<n;++i)
        // {
        //     x[i] = 0.0;    // set initial condition to zero
        //     s += "," + x[i].ToString();
        // }
        //s+= "," + x[0].ToString();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();  // start the stopwatch

        for(int k = 0;k<1000;++k){
            t = 0.0;

        //Pendulum initial condition
        x[0] = 1.0;
        x[1] = 0.0;
        s += "," + x[0].ToString() + "," + x[1].ToString();

        //time loop
        //Console.WriteLine(s);
        while(t < tEnd - dt*0.5)
        {
            s = (t+dt).ToString();
            //RhsFunc(x,t,f);
            RhsFuncPend(x,t,f);
            for(i=0;i<n;++i)
            {
                x[i] += f[i] * dt;
                s+= "," + x[i].ToString();
            }
            t = t + dt;
            //double sol = 20.0*(1.0-Math.Exp(-0.9*t));
            //s+= "," + sol.ToString();
            //Console.WriteLine(s);
        }
        }
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        string elapsedTime = 
            String.Format("{0:00}:{1:00}.{2:000}",ts.Minutes,
            ts.Seconds,ts.Milliseconds);
        Console.WriteLine("Running time: " + elapsedTime);
    }

    //------------------------------------------------------------------------
    // RhsFunc: Calculates the right side of the differential equation
    //------------------------------------------------------------------------
    static void RhsFunc(double[] st,double t,double[] f)
    {
        double k = 0.9;
        double Teq = 20.0;

        f[0] = k*(Teq - st[0]);
    }

    //------------------------------------------------------------------------
    // RhsFuncPend: Calculates the right side of the differential equation
    //      for pendulum
    //------------------------------------------------------------------------
    static void RhsFuncPend(double[] st,double t,double[] f)
    {
        double g = 9.81;
        double L = 1.1;

        f[0] = st[1];
        f[1] = -g * Math.Sin(st[0])/L; 
    }
}