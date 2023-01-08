using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace bruteBro
{
    public class ThreadObject
    {
        private Thread _threadObject = null;
        private bool _threadUsed = false;
        private bool _threadCreated = false;
        private int _logonTries = 0;

        public Thread ThreadO
        {
            get { return _threadObject; }
            set { _threadObject = value; }
        }
        public int LogOnTries
        {
            get { return _logonTries; }
            set { _logonTries = value; }
        }
        public bool ThreadInUse
        {
            get { return _threadUsed; }
            set { _threadUsed = value; }
        }
        public bool ThreadCreated
        {
            get { return _threadCreated; }
            set { _threadCreated = value; }
        }
    }
}
