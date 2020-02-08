/*
 * EmailSender 1.0
 * Written By: Matthew Knox
 * Copyright Matthew Knox 2012. All rights reserved.
*/

using System;
using System.Windows.Forms;

namespace EmailSender
{
    static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmailSender());
        }
    }
}
