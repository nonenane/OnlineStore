using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineModuleCreateFileGoods
{
    public partial class Form1 : Form
    {
        string[] args;
        public Form1(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnlineStoreServiceLogic.Logic l = new OnlineStoreServiceLogic.Logic(); ;            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int port = 8888; // порт сервера
            string address = "192.168.5.55"; // адрес сервера

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                Console.Write("Введите сообщение:");
                string message = "GetData";
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                Console.WriteLine("ответ сервера: " + builder.ToString());
                MessageBox.Show(builder.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                NetworkStream serverStream;
                clientSocket.Connect("192.168.5.65", 8888);
                serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Message from Client$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                byte[] inStream = new byte[10025];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                Console.WriteLine(returndata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        ServiceTest service = new ServiceTest();

        private void button4_Click(object sender, EventArgs e)
        {
            service.TestStart(args);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //service.TestStop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"\\192.168.8.103");
        }
    }

    class ServiceTest : winServiceOnline.winServiceOnline
    {       
        public void TestStart(string[] args)
        {
            OnStart(args);
        }

        public void TestStop()
        {
            OnStop();
        }
    }
}
