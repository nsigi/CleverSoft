using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task3
{
    public class Client
    {
        Task ClientThread;
        public int Name { get; set; }
        public RoleType Role { get; set; }

        public Client(int num, RoleType role)
        {
            Name = num;
            Role = role;
        }

        public static void Action(int Name, RoleType Role)
        {
            if (Role == RoleType.Reader)
            {
                Program.rwl.EnterReadLock();
                Program.Read(Name);
                Program.rwl.ExitReadLock();
            }
            else if (Role == RoleType.Writer)
            {
                var val = Program.r.Next(1, Name);
                Program.rwl.EnterWriteLock();
                Program.Write(Name, val);
                Server.AddToCount(val);
                Thread.Sleep(250);
                Program.EndWrite(Name);
                Program.rwl.ExitWriteLock();
            }
        }
    }
}
