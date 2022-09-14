using System;
using System.Threading;
using Microsoft.Win32;

namespace RobloxLaunchExpFixer
{
    class Program
    {
        static void Main(string[] args)
        {


            const string path = @"SOFTWARE\ROBLOX Corporation\Environments\roblox-player";


            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, true))
            {
                if (key == null) // If (for some reason) they don't have a roblox-player subkey, then...
                {
                    Console.WriteLine("roblox-player Regedit subkey does not exist; are you sure you have Roblox installed?");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Got roblox-player subkey...");

                while (true)
                {
                    Thread.Sleep(10);
                    try
                    {

                        object launchexp = key.GetValue("LaunchExp");
                        string value = launchexp.ToString().Replace(" ", ""); // Use replace as it gets rid of unnecessary whitespace

                        if (value != "InBrowser")
                        {
                            key.SetValue("LaunchExp", "InBrowser", RegistryValueKind.String);
                            Console.WriteLine("Changed LaunchExp from " + value + " to InBrowser");
                        }
                    }

                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Error occured, error: " + e.Message);
                        Console.ReadLine();
                    }

                }
            }
        }
    }
}
