using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Thomas_TechSupport
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            //Hide all the componetes when the page is opened.
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            button2.Visible = false;
            textBox8.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            /* The variables to read in from the server*/
            string name; 
            string tickDescription;
            string TicketImportance;
            string email;
            string ipAdress = "xxx.xxx.xxx.xxx"; //the ipadress needed
            //string ipAdress = "127.0.0.1"; //The debugging adress.
            TcpClient socketforserver = new TcpClient(ipAdress, 4000);
            string problemName = textBox1.Text;
            try
            {
                { 
                    /* Hide all of the texts boxes that need to be hid, show the boxes that need to be showed.*/
                    label1.Visible = false; 
                    textBox1.Visible = false;
                    button1.Visible = false;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    button2.Visible = true;

                    NetworkStream networkStream = socketforserver.GetStream(); //Create a new network stream
                    var streamWrite = new System.IO.StreamWriter(networkStream); //Create a way to write to the stream
                    var streamReader = new System.IO.StreamReader(networkStream);//Create a way to read from the stream.
                    streamWrite.WriteLine("2"); //Tell the server that we want to read data.
                    streamWrite.Flush();//Clear the network stream
                    streamWrite.WriteLine(problemName);//Write out the name of the ticket we are searching for.
                    streamWrite.Flush();
                    /* 
                    *This will read in all the data sent from the server, and display it.
                    */
                    name = streamReader.ReadLine();
                    problemName= streamReader.ReadLine();
                    tickDescription = streamReader.ReadLine();
                    TicketImportance = streamReader.ReadLine();
                    email = streamReader.ReadLine();
                    string date = streamReader.ReadLine();
                    string ticketid = streamReader.ReadLine();
                    textBox2.Text = name;
                    textBox3.Text = problemName;
                    textBox4.Text = tickDescription;
                    textBox5.Text = TicketImportance;
                    textBox6.Text = email;
                    textBox7.Text = date;
                    textBox8.Text = ticketid;
                    
                }
            }
            catch//Error checking
            {
                MessageBox.Show("error sending data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false; //Hide this form.
            Form1 form = new Form1();//Create a object for the main form.
            form.Visible = true;//Display the main form.
        }
    }
}
