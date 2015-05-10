using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThetaMessager
{
    static class Program
    {
        private static MainForm _MainForm;
        private delegate void ExceptionDelegate(Exception x);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _MainForm = new MainForm();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);
            Application.Run(_MainForm);
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception;

            exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                // this is an unmanaged exception, you may want to handle it differently
                return;
            }
            PublishOnMainThread(exception);
        }

        private static void PublishOnMainThread(Exception exception)
        {
            HandleException(exception);            
        }

        private static void HandleException(Exception exception)
        {
            if (SystemInformation.UserInteractive)
            {
                using (ThreadExceptionDialog dialog = new ThreadExceptionDialog(exception))
                {
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                        return;
                }
                Application.Exit();
                Environment.Exit(0);
            }
        }

    }
}
