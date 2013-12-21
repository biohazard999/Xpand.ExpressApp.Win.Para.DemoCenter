using System;
using System.Windows.Forms;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Xpo;
using Xpand.Demo.Para.DemoCenter.Module.Win;
using Xpand.ExpressApp.Win.Para.WindowsIntegration;

namespace Xpand.Demo.Para.DemoCenter.Win
{
    static class Program
    {
        private static WinApplication _Application;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var assemblyName = typeof(Program).Assembly.GetName();
            var mutexName = assemblyName.Name + "_" + assemblyName.Version.ToString(3);

#if DEBUG
            mutexName += "_Debug";
#endif
            using (var instance = new SingleInstance(mutexName))
            {
                if (instance.IsFirstInstance)
                {
                    instance.ArgumentsReceived += WindowsIntegrationWindowsFormsModule.InstanceOnArgumentsReceived;

                    instance.ListenForArgumentsFromSuccessiveInstances();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    _Application = new WinApplication
                    {
                        ApplicationName = assemblyName.Name,
                        SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen()
                    };

                    _Application.CreateCustomObjectSpaceProvider += (sender, args) =>
                    {
                        args.ObjectSpaceProvider = new XPObjectSpaceProvider(new ConnectionStringDataStoreProvider(args.ConnectionString));
                    };

                    _Application.DatabaseVersionMismatch += (sender, args) =>
                    {
                        args.Updater.Update();
                        args.Handled = true;
                    };

                    _Application.Modules.Add(new SystemModule());
                    _Application.Modules.Add(new SystemWindowsFormsModule());
                    _Application.Modules.Add(new WindowsIntegrationWindowsFormsModule());
                    _Application.Modules.Add(new DemoCenterModule());
                    _Application.Modules.Add(new DemoCenterWindowsFormsModule());

                    WindowsIntegrationWindowsFormsModule.TaskbarApplication = _Application;

                    InMemoryDataStoreProvider.Register();
                    _Application.ConnectionString = InMemoryDataStoreProvider.ConnectionString;

                    try
                    {
                        _Application.Setup();

                        _Application.Start();
                    }
                    catch (Exception e)
                    {
                        _Application.HandleException(e);
                    }
                }
                else
                {
                    instance.PassArgumentsToFirstInstance();
                }
            }
        }
    }
}