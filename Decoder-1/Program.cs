﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Decoder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(("App.config")));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Basic_DecoderOperation.SendCameraInfo(new Decoder(), new PackageOfPB());
            //Console.Read();
             Application.Run(new MainWindow());
          //  Application.Run(new Form3());
        }
    }
}
