using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace ReportExplorer
{

    public class AkClient
    {
        SerialPort serialPort;
        public string Name;
        public string Socket;
        public string Status { get; set; }

        CancellationTokenThread idleThread;

        public AkClient(string name, string socket)
        {
            Name = name;
            if (!socket.Contains(":"))
                socket += ":7700";
            Socket = socket;
            Status = "init";

            if (Socket.ToUpper().Contains("COM") && (Socket.Split(' ').Length == 3))
            {
                if (Socket.Split(' ')[2].ToUpper().Trim() == "8N1")

                    serialPort = new SerialPort(Socket.Split(' ')[0], int.Parse(Socket.Split(' ')[1]), Parity.None, 8, StopBits.One);
            }
            else if (Socket.ToUpper().Contains("COM") && (Socket.Split(' ').Length == 1))
            {
                serialPort = new SerialPort(Socket.Split(' ')[0], 9600, Parity.None, 8, StopBits.One);
            }
            else
            {
                //  IpEndPoint = new IPEndPoint(IPAddress.Parse(Socket.Split(':')[0]), int.Parse(Socket.Split(':')[1]));
                TcpClient = new TcpClient();
            }

            idleThread = new CancellationTokenThread("akClientIdle");
            idleThread.Idle = new Thread(Idle) { IsBackground = true };
            idleThread.Start();
            //System.Threading.Thread thread = new System.Threading.Thread(Idle);
            //thread.IsBackground = true;
            //thread.Start();
        }




        static TimeSpan timeout = TimeSpan.FromMilliseconds(500);
        public string AkTransfer(string command, ref int duration)
        {
            bool lockTaken = false;
            string response = "#";
            try
            {
                System.Threading.Monitor.TryEnter(this, timeout, ref lockTaken);
                if (lockTaken)
                {
                    DateTime start = DateTime.Now;
                    response = Transceive(command, 500);
                    duration = (int)(DateTime.Now - start).TotalMilliseconds;
                }
                else
                {
                    // The lock was not acquired.
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken)
                {
                    System.Threading.Monitor.Exit(this);
                }
            }
            return response;
        }

        public string Command(string command)
        {
            try
            {
                return Transceive(command, 500).Replace(command, "");
            }
            catch (Exception e)
            {
                return "";
            }
        }


        public delegate void LogEventHandler(object sender, string message);
        public event LogEventHandler LogEvent;

        private TcpClient TcpClient = null;
        private Thread IdleThread;
        IPEndPoint IpEndPoint;
        void Log(object sender, string message)
        {
            //log.Info(message);
            if (LogEvent != null)
                LogEvent(sender, message);
        }

        public void Abort()
        {

            idleThread.ThreadToken.Cancel();
            
            //try
            //{
            //    IdleThread.Abort();
            //}
            //catch { }

            //try
            //{
            //    if (TcpClient != null)
            //        TcpClient.Close();
            //}
            //catch { }
        }

        bool _isDisconnecting = false;
        public void Disconnect(string message)
        {
            if (_isDisconnecting) return;
            //  log.Info($"disconnecting Client '{Name}': info:{message}");
            _isDisconnecting = true;
            try
            {
                int checkTries = 0;
                try
                {
                    if (TcpClient != null)
                        TcpClient.Close();
                }
                catch
                {
                    exceptionCounter++;
                }

                /*
                try
                {
                    string msg = " SREM K0";
                    sendBuffer[0] = 0x02;
                    int byteLength = message.Length;
                    for (int i = 1; i < byteLength + 1; i++)
                        sendBuffer[i] = Convert.ToByte(message[i - 1]);
                    byteLength += 2;

                    sendBuffer[byteLength - 1] = 0x03;
                    checkTries = 1; 
                    TcpClient.Client.Send(sendBuffer, byteLength, SocketFlags.None);
                    Thread.Sleep(500);
                    checkTries++;
                    TcpClient.Client.Send(sendBuffer, byteLength, SocketFlags.None);
                    Thread.Sleep(500);
                    checkTries++;
                    TcpClient.Client.Send(sendBuffer, byteLength, SocketFlags.None);
                    Thread.Sleep(500);
                }
                catch
                {
              //      exceptionCounter++;
                    _connected = false;
                    Log(this, Name + " disconnected ok " + checkTries);
                }
                */

                _connected = false;
                connectionEstablished = false;
                errorcounter = 0;
                disconnectCounter++;
                //      log.Info(Name + " disconnected <" + message + "," + exceptionCounter + ">");
                Log(this, Name + " disconnected <" + message + "," + exceptionCounter + ">");
                Status = "nc " + message + " " + disconnectCounter + " !(" + errorcounter + "/" + exceptionCounter + ")";
            }
            finally
            {
                _isDisconnecting = false;
            }
        }

        private bool _connected = false;
        public bool Connected
        {
            get
            {
                if (!_connected) return false;
                try
                {
                    if (serialPort != null)
                    {
                    }
                    if (TcpClient != null)
                    {
                        if (TcpClient.Client == null) return false; // !!!!
                        if (!TcpClient.Client.Connected) return false;
                    }

                }
                catch
                {
                    exceptionCounter += 1000;
                }
                return true;
            }
        }

        bool connectionEstablished = false;
        private int disconnectCounter = 0;
        private int errorcounter = 0;
        private int exceptionCounter = 0;

        public void Idle()
        {
            while (!idleThread.Thread.IsCancellationRequested)
            {
                if (idleThread.Thread.IsCancellationRequested)
                    break;
                try
                {
                    if (!Connected)
                    {
                        if (idleThread.Thread.IsCancellationRequested)
                            break;
                        if (connectionEstablished)
                            Disconnect("reset");

                        if (TcpClient != null)
                        {
                            TcpClient = new TcpClient();
                            IpEndPoint = new IPEndPoint(IPAddress.Parse(Socket.Split(':')[0]), int.Parse(Socket.Split(':')[1]));
                            try
                            {
                                if (idleThread.Thread.IsCancellationRequested)
                                    break;
                                TcpClient.Connect(IpEndPoint);
                                //      log.Info($"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} connected");
                                Log(this, $"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} connected");
                                connectionEstablished = true;
                            }
                            catch (Exception ex)
                            {
                                //    log.Error($"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} retry ({ex.Message})");
                                Log(this, Name + "/" + IpEndPoint.Address + ":" + IpEndPoint.Port + " retry " + ex.Message);
                                connectionEstablished = false;
                            }
                        }
                        if (serialPort != null)
                        {
                            if (!serialPort.IsOpen)
                                serialPort.Open();
                            _connected = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    exceptionCounter++;
                    Disconnect("!!!! c1");
                }

                Thread.Sleep(1000);

                if (TcpClient != null)
                {
                    try
                    {
                        if (connectionEstablished && (TcpClient.Client != null) && TcpClient.Client.Connected && !_connected)
                        {
                            _connected = true;
                            Status = "ok " + disconnectCounter + " !(" + errorcounter + "/" + exceptionCounter + ")";
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptionCounter++;
                        Disconnect("!!!! c2 " + ex.ToString());
                        Thread.Sleep(2000);
                    }
                    try
                    {
                        if (connectionEstablished && (TcpClient.Client != null) && !TcpClient.Client.Connected)
                        {
                            //   log.Info($"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} disconnecting");
                            Log(this, $"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} disconnecting");
                            Status = "nc** " + disconnectCounter + " !(" + errorcounter + "/" + exceptionCounter + ")";
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptionCounter++;
                        Disconnect("!!!! c3 " + ex.ToString());
                        Thread.Sleep(2000);
                    }
                }
            }
            if (idleThread.Thread.IsCancellationRequested)
                TcpClient.Close();
        }
        public string TransceiveForced(object sender, string message, int timeout)
        {
            return Transceive(message, timeout);
        }


        byte[] receiveBytes = new byte[4096];
        byte[] receiveBuffer = new byte[4096];
        byte[] sendBuffer = new byte[4096];
        int receivBufferIndex = 0;
        public int TxMsgCount = 0;
        public string Transceive(string message, int timeout)
        {
            if (TcpClient != null)
            {
                if (!Connected)
                {
                    //  log.Warn($"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} not connected/not sent " + message);
                    //**       Log(this, $"{Name}/{IpEndPoint.Address}: {IpEndPoint.Port} not connected/not sent " + message);
                    return null;
                }

                try
                {
                    while (TcpClient.Client.Available > 0)
                        TcpClient.Client.Receive(receiveBytes, 4096, SocketFlags.None);
                    receivBufferIndex = 0;
                }
                catch (Exception ex)
                {
                    exceptionCounter++;
                    Disconnect("dummy");
                    return null;
                }
            }

            if (serialPort != null)
                if (serialPort.IsOpen)
                    serialPort.ReadExisting();

            try
            {
                sendBuffer[0] = 0x02;
                int byteLength = message.Length;
                for (int i = 1; i < byteLength + 1; i++)
                    sendBuffer[i] = Convert.ToByte(message[i - 1]);
                byteLength += 2;
                sendBuffer[byteLength - 1] = 0x03;

                if (TcpClient != null)
                    TcpClient.Client.Send(sendBuffer, byteLength, SocketFlags.None);

                if (serialPort != null)
                    if (serialPort.IsOpen)
                        serialPort.Write(sendBuffer, 0, byteLength);

                TxMsgCount++;
            }
            catch (Exception ex)
            {
                exceptionCounter++;
                Disconnect("send");
                return null;
            }



            int counter = timeout / 10;
            try
            {
                while (counter > 0)
                {
                    if (TcpClient != null)
                    {
                        if (TcpClient.Client != null)
                        {
                            while (TcpClient.Client.Available > 0)
                            {
                                int readBytes = TcpClient.Client.Receive(receiveBytes, 4096, SocketFlags.None);
                                if (readBytes > 0)
                                {
                                    for (int i = 0; i < readBytes; i++)
                                    {
                                        if (receiveBytes[i] == 0x02)
                                            receivBufferIndex = 0;
                                        else if (receiveBytes[i] == 0x03)
                                        {
                                            errorcounter = 0;
                                            return Encoding.UTF8.GetString(receiveBuffer, 0, receivBufferIndex);

                                        }
                                        else
                                        {
                                            receiveBuffer[receivBufferIndex] = receiveBytes[i];
                                            receivBufferIndex++;
                                            receivBufferIndex %= 4096;
                                            receiveBuffer[receivBufferIndex] = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (serialPort != null)
                    {
                        while (serialPort.BytesToRead > 0)
                        {
                            int readBytes = serialPort.Read(receiveBytes, 0, serialPort.BytesToRead);
                            if (readBytes > 0)
                            {
                                for (int i = 0; i < readBytes; i++)
                                {
                                    if (receiveBytes[i] == 0x02)
                                        receivBufferIndex = 0;
                                    else if (receiveBytes[i] == 0x03)
                                    {
                                        errorcounter = 0;
                                        return Encoding.UTF8.GetString(receiveBuffer, 0, receivBufferIndex);

                                    }
                                    else
                                    {
                                        receiveBuffer[receivBufferIndex] = receiveBytes[i];
                                        receivBufferIndex++;
                                        receivBufferIndex %= 4096;
                                        receiveBuffer[receivBufferIndex] = 0;
                                    }
                                }
                            }
                        }
                    }



                    Thread.Sleep(7); // -> ca. 10ms
                    counter--;
                }
                if (timeout > 0)
                {
                    errorcounter++;
                    if (errorcounter > 2)
                    {
                        Disconnect("retries");
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionCounter++;
                Disconnect("receive");
            }
            return null;
        }
    }
}
