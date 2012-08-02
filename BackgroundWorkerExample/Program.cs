using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BackgroundWorkerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            example.Print();
            Console.WriteLine("I am in Main****************");
            Console.WriteLine("I am in Main****************");
            Console.WriteLine("I am in Main****************");
            Console.ReadLine();
        }
    }

    public class Example
    {
        private BackgroundWorker _backgroundWorker1;

        public Example()
        {
            InitializeBackgroundWorker();

        }

        // Set up the BackgroundWorker object by 
        // attaching event handlers. 
        private void InitializeBackgroundWorker()
        {
            _backgroundWorker1 = new BackgroundWorker();
            _backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            _backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            _backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {

            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.

            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                Console.WriteLine("background worker 's job completed");
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            
            int i = 0;
            while (i < 80)
            {
                Console.WriteLine("background worker doing work!!!");
                i++;
            }
        }

        public void Print()
        {
            Console.WriteLine("print started");

            // Start the download operation in the background.
            this._backgroundWorker1.RunWorkerAsync();

            // Don't know what it means!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // shit, I know.. IsBusy means:  only this part of code will be running when the backgroundworker1 is busy. 
            while (this._backgroundWorker1.IsBusy)
            {
                Console.WriteLine("I am Main thread, while the background worker is busy ########### running ");
            }

            int i = 0;
            while (i < 40)
            {
                Console.WriteLine("I am in while loop ");
                i++;
            }

        }

    }
}
