using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Reflection;
using System.Diagnostics;

namespace TempoCrashHandler
{
    static class Program
    {
        static void SetProgramIcon()
        {
            var icon = Icon.ExtractAssociatedIcon(EntryAssemblyInfo.ExecutablePath);
            typeof(Form)
                .GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, icon);
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                args = new string[] { "NULL OBJECT REFERENCE", "Template text", "tempo-crash-2024-11-17-21-06-04" };

                Console.WriteLine("Running in Debug Mode!");
            }

            if (args.Length < 1)
            {
                Application.Exit();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProgramIcon();
            Application.Run(new Form1(args));
        }
    }

    static class EntryAssemblyInfo
    {
        private static string _executablePath;
        public static string ExecutablePath
        {
            get
            {
                if (_executablePath == null)
                {
                    PermissionSet permissionSets = new PermissionSet(PermissionState.None);
                    permissionSets.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
                    permissionSets.AddPermission(new SecurityPermission(SecurityPermissionFlag.UnmanagedCode));
                    permissionSets.Assert();

                    string uriString = null;
                    var entryAssembly = Assembly.GetEntryAssembly();

                    if (entryAssembly == null)
                        uriString = Process.GetCurrentProcess().MainModule.FileName;
                    else
                        uriString = entryAssembly.CodeBase;

                    PermissionSet.RevertAssert();

                    if (string.IsNullOrWhiteSpace(uriString))
                        throw new Exception("Can not Get EntryAssembly or Process MainModule FileName");
                    else
                    {
                        var uri = new Uri(uriString);
                        if (uri.IsFile)
                            _executablePath = string.Concat(uri.LocalPath, Uri.UnescapeDataString(uri.Fragment));
                        else
                            _executablePath = uri.ToString();
                    }
                }

                return _executablePath;
            }
        }
    }
}
