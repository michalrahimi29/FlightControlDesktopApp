using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FlightMobileApp.Models
{
    public class Model
    {
        TelnetClient telnetClient;
        volatile Boolean connected;
        private static Mutex mut = new Mutex();
        //public Image CurrImage { get; set; }

        public Model()
        {
            this.telnetClient = new TelnetClient();
            Connect("127.0.0.1", 5000);
            connected = false;
        }

        public void Connect(string ip, int port)
        {
            Console.WriteLine(ip);
            connected = telnetClient.connect(ip, port);
           // telnetClient.write("data\n");
            if (connected)
            {
                //error
            }
            else
            {
                //error
            }
        }

        public void Disconnect()
        {
            connected = false;
            telnetClient.disconnect();
            //error
        }

        public void SetAileron(string number)
        {
            if (connected)
            {
                telnetClient.write("set /controls/flight/aileron " + number + "\n");
                telnetClient.write("get /controls/flight/aileron \n");
                try
                {
                    string aileron = telnetClient.read();
                    if (string.Compare(number, aileron) != 0)
                    {
                        throw new Exception();
                    }
                }
                catch (TimeoutException)
                {
                    throw new TimeoutException();
                }
            }
        }

        public void SetThrottle(string number)
        {
            if (connected)
            {
                telnetClient.write("set /controls/engines/current-engine/throttle " + number + "\n");
                telnetClient.write("get /controls/engines/current-engine/throttle \n");
                string throttle = telnetClient.read();
                if (string.Compare(number, throttle) != 0)
                {
                    throw new Exception();
                }
            }
        }

        public void SetElevator(string number)
        {
            if (connected)
            {
                telnetClient.write("set /controls/flight/elevator " + number + "\n");
                telnetClient.write("get /controls/flight/elevator \n");
                string elevator = telnetClient.read();
                if (string.Compare(number, elevator) != 0)
                {
                    throw new Exception();
                }
            }
        }

        public void SetRudder(string number)
        {
            if (connected)
            {
                telnetClient.write("set /controls/flight/rudder " + number + "\n");
                telnetClient.write("get /controls/flight/rudder \n");
                string rudder = telnetClient.read();
                if (string.Compare(number, rudder) != 0)
                {
                    throw new Exception();
                }
            }
        }
    }
}