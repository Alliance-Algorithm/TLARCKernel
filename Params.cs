
#define humble
using Rcl;

[assembly: System.Runtime.CompilerServices.DisableRuntimeMarshalling]
namespace TlarcKernel
{

        internal static class Ros2Def
        {
#if humble
                internal static RclContext context;
                internal static IRclNode node;
#endif
        }
        internal static class TlarcSystem
        {
#if DEBUG
                internal static string ConfigurationPath = "./configuration/";
                internal static string RootPath = "./";
#else
                internal static string ConfigurationPath = Environment.ProcessPath + "/../../../share/tlarc/configuration/";
                internal static string RootPath = Environment.ProcessPath + "/../../../share/tlarc/";
#endif

                static public void LogError(string Message)
                {
#if DEBUG
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("[Error]:" + Message);
                        Console.ResetColor();
#else
                        Ros2Def.node.Logger.LogError(Message);
#endif
                }
                static public void LogWarning(string Message)
                {
#if DEBUG
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("[Warning]:" + Message);
                        Console.ResetColor();
#else
                        Ros2Def.node.Logger.LogError(Message);
#endif
                }
        }
}