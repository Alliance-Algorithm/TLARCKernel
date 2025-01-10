
#define humble
using System.Collections.Concurrent;
using Rcl;
using Rcl.Logging;
using Rosidl.Messages.Builtin;

// [assembly: System.Runtime.CompilerServices.DisableRuntimeMarshalling]
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
                internal static string ConfigurationPath =  Environment.ProcessPath.Substring(0,Environment.ProcessPath.LastIndexOf('/')) + "/../../share/tlarc/configuration/";
                internal static string RootPath = Environment.ProcessPath.Substring(0,Environment.ProcessPath.LastIndexOf('/')) + "/../../share/tlarc/";
#endif
                static ConcurrentQueue<Action> Prints = new();
                public static bool TryGetPrint(out Action action) => Prints.TryDequeue(out action);
                static public void LogError(string Message)
                {
                        #if DEBUG
                        Task.Run(() =>
                        Prints.Enqueue(() =>
                        {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"[Error:{DateTime.UtcNow.Ticks}]:" + Message);
                                Console.ResetColor();
                        }));
                        #else
                                Ros2Def.node.Logger.LogFatal($"[Info:{DateTime.UtcNow.Ticks}]:" + Message);
                        #endif
                }
                static public void LogWarning(string Message)
                {
                        #if DEBUG
                        Task.Run(() =>
                        Prints.Enqueue(() =>
                        {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"[Warning:{DateTime.UtcNow.Ticks}]:" + Message);
                                Console.ResetColor();
                        }));
                        #else
                         Ros2Def.node.Logger.LogWarning($"[Info:{DateTime.UtcNow.Ticks}]:" + Message);
                        #endif
                }
                static public void LogInfo(string Message)
                {
                        #if DEBUG
                        
                        Task.Run(() =>
                        Prints.Enqueue(() =>
                        {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"[Info:{DateTime.UtcNow.Ticks}]:" + Message);
                                Console.ResetColor();
                        }));

                        #else
                         Ros2Def.node.Logger.LogInformation($"[Info:{DateTime.UtcNow.Ticks}]:" + Message);
                        #endif
                }
                static public void Log(string Message, ConsoleColor color)
                {
                        Task.Run(() =>
                        Prints.Enqueue(() =>
                        {
                                Console.ForegroundColor = color;
                                Console.WriteLine(Message);
                                Console.ResetColor();
                        }));
                }
        }
}