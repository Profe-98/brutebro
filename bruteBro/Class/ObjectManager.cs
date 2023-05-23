using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace bruteBro
{
    public static class ObjectManager
    {
        public enum SERVICE_RESPONSE : int
        {
            LOGIN_SUCCES = 0,
            LOGIN_FAILED = 1,
            NO_RESPONSE = 2,
            NO_USERNAME = 3,
            NO_PASSWORD = 4

        }

        private static IPAddress _ipAddr = null;
        private static int _port = 0;
        
        private static Dictionary<string, string> _filedatapairs = new Dictionary<string, string>();

        private static string[] loginMessages = new string[3] { "(none) login:", "Password:", "Login incorrect" };

        private static string[] _letters_lower = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private static string[] _letters_upper = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private static int[] _numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static string[] _specialsign = new string[] { "^", "!", "\"", "§", "$", "%", "&", "/", "(", ")", "=", "?", "´", "`", "{", " }", @"\", "~", "#", "'", "*", "+", "-", "_", ".", ",", ":", ";", ">", "<", "|" };
        private static string[] _selectedSigns = new string[] { };

        private static int _passwordLength = 6;

        private static string[] _knownUserName = new string[] { "root", "admin", "Admin", "Root", "Sysadmin", "sysadmin" };

        public static Dictionary<string, string> Filedatapairs
        {
            get { return _filedatapairs; }
            set { _filedatapairs = value; }
        }

        public static string[] Letters
        {
            get { return _letters_lower; }
        }
        public static string[] Specialsign
        {
            get { return _specialsign; }
        }
        public static int[] Numbers
        {
            get { return _numbers; }
        }
        public static string[] SelectedSigns
        {
            get { return _selectedSigns; }
        }
        public static IPAddress IpAddr
        {
            get { return _ipAddr; }
        }
        public static int Port
        {
            get { return _port; }
        }
        public static int PasswordLength
        {
            get { return _passwordLength; }
            set { _passwordLength = value; }
        }

        private static List<LoginObject> _loginAttempt = new List<LoginObject>();
        public static List<LoginObject> LoginAttempt
        {
            get { return _loginAttempt; }
            set { _loginAttempt = value; }
        }
    }
}
