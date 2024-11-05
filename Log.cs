using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log
{
        public static class Log
        {
        public static void Banner() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"   ____ ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"  / ___J ___ _     ____    FJ_     FJ___      _    _  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" |  _| | |--| |  | '----_ | |-'   | |--| |  | |/  \| |");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@" F |_J F L__J J  )-____  LF |__-. F L  J J  F   /\   J");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"J__F  J\____,__LJ\______/F\_____/J__L  J__LJ\__//\\__/L");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(@"|__|   J____,__F J______F J_____F|__L  J__| \__/  \__/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              by georgeckito");
            Console.ResetColor();
        }

        public static char Option()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. Integrate fasthw with a new Visual Studio project");
            Console.WriteLine("2. Add a new homework task");
            Console.WriteLine("3. List all homework tasks");
            Console.WriteLine("4. Remove a homework task");
            Console.WriteLine("5. Help");
            Console.WriteLine("6. Exit");
            Console.Write("\nChoose an option: ");
            Console.ResetColor();
            return Console.ReadKey().KeyChar;

        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR - {message}");
            Console.ResetColor();
        }
        public static void Warning(string message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"WARNING - {message}");
            Console.ResetColor();
        }
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"INFO - {message}");
            Console.ResetColor();
        }
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"SUCCESS - {message}");
            Console.ResetColor();
        }
    }
}
