using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace task3
{
    class Program
    {
        public static Random r = new Random();
        public static ReaderWriterLockSlim rwl;

        public static void Write(int name, int val) => Console.WriteLine($"Писатель {name} добавляет {val}");
        public static void EndWrite(int name) => Console.WriteLine($"Писатель {name} закончил запись => count = {Server.GetCount()}");
        public static void Read(int name) => Console.WriteLine($"Читатель {name} прочитал {Server.GetCount()}");

        static void Main(string[] args)
        {
            Console.Write("Количество клиентов: ");
            int n = int.Parse(Console.ReadLine());

            rwl = new ReaderWriterLockSlim();

            Task[] tasks = new Task[n];
            for (int i = 0; i < n; ++i)
            {
                Client client = new Client(i + 1, (RoleType)(r.Next(0, 2) % 2));
                tasks[i] = new Task(() => Client.Action(client.Name, client.Role));
            }
            foreach (var item in tasks.AsParallel())
            {
               item.Start();
            }

            Task.WaitAll(tasks);
        }
    }
}