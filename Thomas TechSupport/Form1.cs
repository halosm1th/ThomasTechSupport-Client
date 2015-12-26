using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Thomas_TechSupport
{
    public partial class Form1 : Form
    {
        Form2 NewTicket = new Form2(); //Create an object for the new ticket form
        Form3 status = new Form3(); //Create an object for the read a ticket in form 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;//Hide the main form
            NewTicket.Visible = true; //Show the new ticket form
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If there is a error, shoot me an email @thomastrkie@gmail.com"); //The email me button message.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewTicket.Close(); //Close all of the forms
            status.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false; //Hide this form
            status.Visible = true; //Show the read ticket form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Variable creation
            string ipAdress = "xxx.xxx.xxx.xxx"; //The ipadress of the server
            //string ipadress = "127.0.0.1"; //The debugging adress
            TcpClient socketforserver = new TcpClient(ipAdress, 4000);
            NetworkStream networkStream = socketforserver.GetStream(); //Create a new network stream
            var streamWrite = new System.IO.StreamWriter(networkStream); //Create a way to write to the stream
            var streamReader = new System.IO.StreamReader(networkStream);//Create a way to read from the stream.
            string update;
            //End of variable creation

            //start of reading and writing data.
            streamWrite.WriteLine("3"); //Tell the server that we want to read data.
            streamWrite.Flush();
            update = streamReader.ReadLine(); //Read in the update
            MessageBox.Show(update); //Show the update
        }
    }
}
