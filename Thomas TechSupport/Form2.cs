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
using System.Threading;

namespace Thomas_TechSupport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            *this is all the data for the ticket
            */
            string name = textBox1.Text; //The variable for name
            string TicketTitle = textBox2.Text; //The ticket title
            string tickDescription = textBox3.Text; //What the problem is.
            string TicketImportance = textBox4.Text; //The level of importance
            string email = textBox5.Text; //The client email adress.


            string ipAdress = "xxx.xxx.xxx.xxx"; //the ip adress for the server
            //string ipAdress = "127.0.0.1"; //My debugging ip adress
            TcpClient socketforserver = new TcpClient(ipAdress, 4000); //Create a new socket for the client to connect to the server on.

            try
            {
                {
                    NetworkStream networkStream = socketforserver.GetStream();
                    var streamWrite = new System.IO.StreamWriter(networkStream);
                    streamWrite.WriteLine("1");//Tell the server that it is imputting data.
                    streamWrite.Flush();//Clear the stream
                    /* This bit of code is sending all the data to the server in realtion to the ticket*/
                    streamWrite.WriteLine(name); 
                    streamWrite.Flush();
                    streamWrite.WriteLine(TicketTitle);
                    streamWrite.Flush();
                    streamWrite.WriteLine(tickDescription);
                    streamWrite.Flush();
                    streamWrite.WriteLine(TicketImportance);
                    streamWrite.Flush();
                    streamWrite.WriteLine(email);
                    streamWrite.Close();
                    /* End of data transmission*/
                }
            }
            catch//If there is a error
            {
                MessageBox.Show("error sending data");//Display this error message.
            }
            this.Visible = false; //Hide this form
            Form1 form = new Form1(); //Make the main form object
            form.Visible = true; //Make the main form visible again.
        }
    }
}
