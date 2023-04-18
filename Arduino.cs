using System.IO.Ports;

namespace TicTacChess {

    class Arduino {
        readonly (int, int)[] map = { 
            (320,20), (400,135), (570,245),
            (850,0), (900,110), (1050,200),
            (1330,0), (1400,95), (1520,175),
        };

        const int pickUpHeight = 1150;
        const int dropOffHeight = 1150;

        SerialPort serialPort = new SerialPort();
        Stack<(int, int)> moves = new();

        ComboBox ports;

        Arduino(ComboBox ports) {
            this.ports = ports;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }


        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            string data = serialPort.ReadExisting();
            Utils.Println(data);
        }


        //returns comports
        void Scan() {
            ports.Items.Clear();

            foreach (var port in SerialPort.GetPortNames()) {
                ports.Items.Add(port);
            }
        }

        void Connect(string port) {

        }

        void AddMove(int from, int to) {
            moves.Push((from, to));
        }

        //function read the port
        public void Read() {

            Utils.Println("hi!");
        }


    }
}
