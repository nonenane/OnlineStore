using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Settings.User;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Project;

namespace OnlineShopOrders
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainMenu());

            if (args.Length > 0)
            {
                Project.FillSettings(args);
                InitAndRun();
            }
        }

        private static void InitAndRun()
        {
            Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
            Logging.StartFirstLevel(1);
            Logging.Comment("Вход в программу");
            Logging.StopFirstLevel();

            Application.Run(new frmAddOrder());
            Logging.StartFirstLevel(2);
            Logging.Comment("Выход из программы");
            Logging.StopFirstLevel();
        }
    }
}
