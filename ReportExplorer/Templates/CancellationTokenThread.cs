using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReportExplorer
{
    public class CancellationTokenThread
    {
        public Thread Idle;
        public CancellationTokenSource ThreadToken;
        public CancellationToken Thread;
        public string Name;

        public CancellationTokenThread(string name)
        {
            Name = name;
            ThreadToken = new CancellationTokenSource();
            Thread = ThreadToken.Token;
        }
        public void Start()
        {
            ThreadToken = new CancellationTokenSource();
            Thread = ThreadToken.Token;
            Idle.Start();
        }

    }
}
