using System;

namespace DateTimePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            printer.PrintCurrentDateTime();
        }
    }
}