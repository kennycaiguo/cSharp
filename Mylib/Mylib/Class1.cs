using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mylib
{
    public class Class1
    {
        public void doWork(jobDelegate jbd) {
            jbd();

        }
        public void doTime(timeDelegate td)
        {
            td();
        }

        public void writeTime()
        {
            File.WriteAllText("time.txt", System.DateTime.Now.ToString());
        }
    }
    public delegate void jobDelegate();
    public delegate void timeDelegate();
}
