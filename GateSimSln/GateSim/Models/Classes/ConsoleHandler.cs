using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GateSim.Models.Classes
{
    /// <summary>
    /// Prawie działą.
    /// Słowo kluczowe. Prawie
    /// Nie ruszać na razię aczkolwiek zostanie prawdopodobnie usunięta
    /// </summary>
    public static class ConsoleHandler
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int swHide = 0;
        const int swShow = 5;

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public static void ShowConsoleWindow()
        {

            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
                InvalidateOutAndError();
            }
            else
            {
                ShowWindow(handle, swShow);
            }

            //Console.SetOut(System.IO.TextWriter.Null);
        }//---------------------------------------------------

        static void InvalidateOutAndError()
        {
            Type type = typeof(System.Console);

            System.Reflection.FieldInfo _out = type.GetField("_out",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.FieldInfo _error = type.GetField("_error",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Debug.Assert(_out != null);
            Debug.Assert(_error != null);

            Debug.Assert(_InitializeStdOutError != null);

            _out.SetValue(null, null);
            _error.SetValue(null, null);

            _InitializeStdOutError.Invoke(null, new object[] { true });
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, swHide);
        }//----------------------------------------------------

        public static void Print(string msg)
        {
            Console.Write(msg);
        }//---------------------------------------------------

        public static void Print(string msg, ConsoleColor color, bool shouldReset = false)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            if (shouldReset) Console.ResetColor();
        }//---------------------------------------------------

        public static void Print(string msg, ConsoleColor color, ConsoleColor newColor)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = newColor;
        }//---------------------------------------------------



    }//######################################################################
}
