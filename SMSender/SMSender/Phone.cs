using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace SMSender
{
    public class PhoneControl
    {
        private readonly BluetoothPhone _phone;

        public PhoneControl(BluetoothPhone phone)
        {
            _phone = phone;
            _phone.IncomingPort.DataReceived += IncomingPort_DataReceived;
            _phone.IncomingPort.Open();
        }

        ~PhoneControl()
        {
            _phone.IncomingPort.Close();
        }

        private void IncomingPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("----");
            Console.WriteLine("Data Received:");
            var prt = (SerialPort)sender;
            Console.WriteLine(prt.ReadExisting());
            Console.WriteLine("----");
        }

        public bool SendSMS(string phoneNumber, string message)
        {
            try
            {
                _phone.OutgoingPort.Open();
                _phone.OutgoingPort.Write("AT+CMGF=1\r");
                _phone.OutgoingPort.Write("AT+CMGS=\"" + phoneNumber + "\"\r\n");
                _phone.OutgoingPort.Write(message + "\x1A");
                _phone.OutgoingPort.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public struct MessageStruct
        {
            public ContactStruct From;
            public ContactStruct To;
            public string Message;
            public override string ToString()
            {
                return From.ToString();
            }
        }

        public List<MessageStruct> GetMessageList()
        {
            throw new NotImplementedException();
            _phone.OutgoingPort.Open();
            _phone.OutgoingPort.Write("AT+CMGF=1\r");
            _phone.OutgoingPort.Write("AT+CMGS=\"" + "\"\r\n");
            //_phone.OutgoingPort.Write(message + "\x1A");
            _phone.OutgoingPort.Close();
            
        }

        public struct ContactStruct
        {
            public string Name;
            public string Number;

            public override string ToString()
            {
                return string.IsNullOrWhiteSpace(Name) ? Number : Name;
            }
        }

        public List<ContactStruct> GetContactList()
        {
            throw new NotImplementedException();
        }
    }

    public class BluetoothPhone
    {
        public SerialPort OutgoingPort;
        public SerialPort IncomingPort;
        public string DeviceName;
    }
}
