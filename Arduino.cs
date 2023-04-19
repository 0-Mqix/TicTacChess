using System.IO.Ports;

namespace TicTacChess {
    struct Action {
        public int id;
        public string message;
        public string ready;
    }

    class Arduino {
        
        //(horizontal, rotation)
        readonly (int, int)[] map = { 
            (320,20), (400,135), (570,245),
            (850,0), (900,110), (1050,200),
            (1330,0), (1400,95), (1520,175),
        };

        const int pickUpHeight = 1150;
        const int dropOffHeight = 950;

        /*
       VS:0000 == Vertical
       HS:0000 == Horizontal
       RS:0000 == Rotation
       CS:0 == Compressor OFF / CS:1 Compressor ON
       SS:0 == Suction OFF / SS:1 Suction ON
       ZS:0 == Zero all
       ZS:1 == Zero Vertical
       ZS:2 == Zero Horizontal
       ZS:3 == Zero Rotation
       */

        Action zeroAll = new Action { message = "ZS:0", ready = "Initializing system for action value: 0 Ready" };
        Action zeroRotation = new Action { message = "ZS:3", ready = "Initializing system for action value: 3 Ready" };
        Action zeroHorizontal = new Action { message = "ZS:2", ready = "Initializing system for action value: 2 Ready" };
        Action zeroVertical = new Action { message = "ZS:1", ready = "Initializing system for action value: 1 Ready" };

        Action suctionOn = new Action { message = "SS:1", ready = "SS:Ready" };
        Action suctionOff = new Action { message = "SS:0", ready = "SS:Ready" };

        Action compressorOn = new Action { message = "CS:1", ready = "CS:Ready" };
        Action compressorOff = new Action { message = "CS:0", ready = "CS:Ready" };

        Action setHeighForPickUp = new Action { message = $"VS:{Digits(pickUpHeight)}", ready = "VS:Ready" };
        Action setHeightForDropOff = new Action { message = $"VS:{Digits(dropOffHeight)}", ready = "VS:Ready" };


        SerialPort serialPort = new();
        Queue<Action> actions = new();

        int totalActionCount = 0;
        int lastFinishedActionId = 0;

        public bool enabled;

        Game game;
        ComboBox ports;
        Label statusLabel;
        Label queueLabel;
        ProgressBar bar;


        public Arduino(Game game, ComboBox ports, Label statusLabel, Label queueLabel, ProgressBar bar) {
            this.game = game;
            this.ports = ports;
            this.statusLabel = statusLabel;
            this.queueLabel = queueLabel;
            this.bar = bar;

            bar.Minimum = 0;
            bar.Value = 0;
            bar.Step = 0;

            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            serialPort.BaudRate = 115200;

            game.SetArduino(this);
        }

        void UpdateQueueDisplay() {
            int value = lastFinishedActionId;
            
            bar.Maximum = totalActionCount;
            bar.Value = value;

            queueLabel.Text = $"queue ({value}/{totalActionCount})";
            bar.PerformStep();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            string data = serialPort.ReadLine();
            
            if (actions.Count < 1) {
                return;
            }

            var action = actions.Peek();

            if (data.Contains(action.ready)) {
                
                actions.Dequeue();
                Utils.Println($"[ARDUINO] action done: id:{action.id} {action.message}");
                
                lastFinishedActionId = action.id;
                UpdateQueueDisplay();

                if (actions.Count > 0) {
                    serialPort.Write(actions.Peek().message);
                }

            }  
        }

        //returns comports
        public void Scan() {
            ports.Items.Clear();

            foreach (var port in SerialPort.GetPortNames()) {
                ports.Items.Add(port);
            }
        }
        void PushAction(Action action) {
            if (!enabled) {
                return;
            }
            
            action.id = totalActionCount++;
            int size = actions.Count;
            actions.Enqueue(action);

            UpdateQueueDisplay();

            if (size == 0 && serialPort.IsOpen) {
                Utils.Println($"[ARDUINO] executing: id:{action.id} " + action.message);
                serialPort.Write(action.message);
            }

        }

        public void Connect(string port) {
            serialPort.Close();
            
            serialPort.PortName = port;
            statusLabel.Text = "Connecting to" + port +"...";
            
            try {
                serialPort.Open();
                if (serialPort.IsOpen) {
                    statusLabel.Text = "Connected on " + port;

                    PushAction(zeroAll);
                }

            } catch (Exception e) {
                Utils.Println(e.Message);
            }
        }
       
        static string Digits(int number) {
           return number.ToString("D4");
        }
        void PickUp() {
            PushAction(setHeighForPickUp);
            PushAction(compressorOn);
            PushAction(suctionOn);
            PushAction(setHeightForDropOff);
        }
        void DropOff() {
            PushAction(suctionOff);
            PushAction(compressorOff);
        }

        public void Zero() {
            if (!enabled) {
                return;
            }
            PushAction(zeroRotation);
        }
      
        void PositionToAction(int position) {
            var (h, r) = map[position];
            PushAction(new Action { message = $"RS:{Digits(r)}", ready="RS:Ready" });
            PushAction(new Action { message = $"HS:{Digits(h)}", ready="HS:Ready" });
        }

        public void Move(int a, int b) {
            if (!enabled) {
                return;
            }

            Utils.Println($"[ARDUINO] move {a} -> {b} id:{totalActionCount + 1}");
            
            PositionToAction(a);
            PickUp();
            PositionToAction(b);
            DropOff();
        }

        public void Swap(int a, int b) {
            if (!enabled) {
                return;
            }
            
            var (succes, empty) = game.GetEmptyPosition(); 

            if (!succes) {
                Utils.Println("[ARDUINO] cant find empty position");
                return;
            }
            
            Utils.Println($"\n[ARDUINO] start swap {a} <-> {b} empty:{empty} id:{totalActionCount + 1}");

            Move(a, empty);
            Move(b, a);
            Move(empty, b);
            
            Utils.Println($"[ARDUINO] end swap\n");
         }

        //call this before reset of the live game
        public void Reset() {
            if (!enabled) {
                return;
            }
            
            Utils.Println($"\n[ARDUINO] reset id:{totalActionCount + 1}");
            var (white, black) = game.GetStartPositions();
            var starting = white.Union(black).ToDictionary(pair => pair.Key, pair => pair.Value);

            var pieces = game.GetPieces();
            
            foreach (var pair in starting) {
                int start = pair.Key;
                IPiece piece = pair.Value;

                int position = game.GetPieceLocation(piece.Color(), piece.GetType());

                if (start == position) {
                    continue;
                }

                if (!pieces.ContainsKey(start)) {
                    pieces.Remove(position);
                    pieces.Add(start, piece);

                    Move(position, start);
                } else {
                    var temp = pieces[start];

                    pieces.Remove(start);
                    pieces.Add(start, piece);

                    pieces.Remove(position);
                    pieces.Add(position, temp);
                   
                    Swap(position, start);
                }

                Zero();
            }
            
            PushAction(zeroVertical);
            PushAction(zeroHorizontal);
            PushAction(zeroRotation);
            
            Utils.Println($"[ARDUINO] end reset\n");
        }
    }
}
