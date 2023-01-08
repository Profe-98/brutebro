using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bruteBro
{
    public class LoginObject
    {

        private string _user = null;
        private string _password = null;
        private DateTime _requestDateTime = DateTime.MinValue;
        private string _request = null;
        private string _response = null;
        private DateTime _responseDateTime = DateTime.MinValue;
        private ThreadObject _workingThread = null;
        private bool _executed = false;
        private bool _loggedIn = false;

        public DateTime RequestDateTime
        {
            get { return _requestDateTime; }
            set { _requestDateTime = value; }
        }
        public DateTime ResponseDateTime
        {
            get { return _responseDateTime; }
            set { _responseDateTime = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Request
        {
            get { return _request; }
            set { _request = value; }
        }
        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }
        public bool Executed
        {
            get { return _executed; }
            set { _executed = value; }
        }
        public bool LoggedIn
        {
            get { return _loggedIn; }
            set { _loggedIn = value; }
        }
        public ThreadObject ExecutionThread
        {
            get { return _workingThread; }
            set { _workingThread = value; }
        }
    }
}
