using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nwuram.Framework.Project;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Logging;


namespace OnlineStoreViewOrders
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

            if (args.Length>0)
            {
                Project.FillSettings(args);
                Config.RunArguments = args;

                Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(),
                ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

                //Настройки коннектов (основной и дополнительный)

                Config.connect = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(),
                    ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
               
                Logging.StartFirstLevel(1);
                Logging.Comment("Вход в программу");
                Logging.StopFirstLevel();
                Application.Run(new frmViewOrders());
                
                Logging.StartFirstLevel(2);
                Logging.Comment("Пользователь закрыл программу");
                Logging.StopFirstLevel();

            }

        }
    }
}
