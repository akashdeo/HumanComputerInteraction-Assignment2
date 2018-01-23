using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Header Comments*/
/* Author:Akash Deo
 * netid-apd160330
 * 
 * So ,in this application,we have 12 fields
 * 1)First_Name
 * 2)Last_Name
 * 3)Middle_Initial(Optional)
 * 4)Address Line 1
 * 5)Address Line 2(Optional)
 * 6)City
 * 7)State(list provided)
 * 8)ZipCode
 * 9)Phone_Number
 * 10)Email_address
 * 11)Proof_of_residence
 * 12)Date_Recieved
 * 
 * Function Add_Record(button1_click)
 * {
 * In this function,we take all the values from the form and then build a record and then check whether the record already exists.
 * If exists,then error message is produced,otherwise it is added.
 * 
 * }
 * 
 * Function Delete_Record(button3_click)
 * {
 * Here we Delete a specific record by selecting a record from the listbox,if the record is available in the listbox,then we delete the record .
 * And print the message
 * }
 * Function Modify_Record(button2_click)
 * {
 * Here we select a record from the listbox,the values of the record are populated into the fields,then we change the values as we want 
 * and then we press the modify button.Message is displayed if the record has been modified or not.
 * }
 * 
 * ListBox
 * {
 * Here we read the contents of the text file and then we populate the listbox with the name and phone number.It is basically used for
 * Selecting a particular record for deletion and modification. 
 *
 * }
 * Form_load(This constructor loads the text data into the listbox when we execute the program)
 * 
 * I have set maximum characters allowed for each field and also what kind of data is allowed in each field
 * 
 * for example,first and last name cannot have spaces
 * 
 * also email can have all kinds of characters
 *  
 * phone number,pincode can only consist of numbers
 * 
 * State has drop down list of all the 50 states of the US. etc
 * */
namespace Asg2apd160330
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)//ADD RECORD
        {
            FileStream fs;
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\CS6326Asg2.txt");
            if (!File.Exists(path))
            {
                fs = File.Create(path);
                fs.Close();
            }
            int f = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                // Read and display lines from the file until 
                // the end of the file is reached. 
                while ((line = sr.ReadLine()) != null)
                {
                    String[] tokens = line.Split('\t');
                    if (textBox1.Text.Equals(tokens[0]) && textBox2.Text.Equals(tokens[1]))
                    {
                        MessageBox.Show("duplicate records");
                        f = 1;
                        break;
                    }

                }

            }




            if (f == 0)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    if (textBox1.Text != null && textBox2.Text != null && textBox4.Text != null && textBox6.Text != null && textBox8.Text != null && textBox9.Text != null && textBox10.Text != null && comboBox1.Text != null && comboBox2.Text != null && dateTimePicker1.Text.ToString() != null)
                    {
                        
                        sw.WriteLine(textBox1.Text.ToString() + "\t" + textBox2.Text.ToString() + "\t" + textBox4.Text.ToString() + "\t" + textBox6.Text.ToString() + "\t" + comboBox1.SelectedItem.ToString() + "\t" + textBox8.Text.ToString() + "\t" + textBox9.Text.ToString() + "\t" + textBox10.Text.ToString() + "\t" + comboBox2.SelectedItem.ToString() + "\t" + dateTimePicker1.Text.ToString()+ "\t" + DateTime.Now.ToString("h:mm:ss tt"));
                    }
                    if(textBox1.Text != null && textBox2.Text != null && textBox3.Text!=null&&textBox4.Text != null && textBox5.Text!=null&& textBox6.Text != null && textBox8.Text != null && textBox9.Text != null && textBox10.Text != null && comboBox1.Text != null && comboBox2.Text != null && dateTimePicker1.Text.ToString() != null)
                    {
                        sw.WriteLine(textBox1.Text.ToString() + "\t" + textBox2.Text.ToString() + "\t" + textBox3.Text.ToString() + "\t" + textBox4.Text.ToString() + "\t" + textBox5.Text.ToString() + "\t" + textBox6.Text.ToString() + "\t" + comboBox1.SelectedItem.ToString() + "\t" + textBox8.Text.ToString() + "\t" + textBox9.Text.ToString() + "\t" + textBox10.Text.ToString() + "\t" + comboBox2.SelectedItem.ToString() + "\t" + dateTimePicker1.Text.ToString() + "\t" + DateTime.Now.ToString("h:mm:ss tt"));
                    }
                }
                MessageBox.Show("Record added Successfully");

            }

        }
        private void button2_Click(object sender, EventArgs e)//MODIFY BUTTON
        {
            int k = 0;
            string selectItem = Text_File_Contents.SelectedItem.ToString();
            string[] splitSelectItem = selectItem.Split('\t');
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\CS6326Asg2.txt");
            //string filename = @"C:/books/UI Design/CS6326Asg2.txt";
            string[] records = null;
            try
            {
                records = File.ReadAllLines(path);
            }
            catch (Exception er)
            {
                MessageBox.Show("empty file");
                throw er;
            }
           
            int index = -1;
            int  k1 = 0;
            string[] values = new string[records.Length];

            String answer = "";
            for (int i = 0; i < records.Length; i++)
            {
                string[] fields = records[i].Split(new char[] { '\t' });
                if (fields[0] == splitSelectItem[0] && fields[1] == splitSelectItem[1])
                {
                    if (textBox3.Text != null && textBox5.Text != null)
                        answer = answer + textBox1.Text.ToString() + "\t" + textBox2.Text.ToString() + "\t" + textBox3.Text.ToString() + "\t" + textBox4.Text.ToString() + "\t" + textBox5.Text.ToString() + "\t" + textBox6.Text.ToString() + "\t" + comboBox1.Text.ToString() + "\t" + textBox8.Text.ToString() + "\t" + textBox9.Text.ToString() + "\t" + textBox10.Text.ToString() + "\t" + comboBox2.Text.ToString() + "\t" + dateTimePicker1.Text.ToString();
                    else
                        answer = answer + textBox1.Text.ToString() + "\t" + textBox2.Text.ToString() + "\t" + textBox4.Text.ToString() + "\t" + textBox6.Text.ToString() + "\t" + comboBox1.Text.ToString() + "\t" + textBox8.Text.ToString() + "\t" + textBox9.Text.ToString() + "\t" + textBox10.Text.ToString() + "\t" + comboBox2.Text.ToString() + "\t" + dateTimePicker1.Text.ToString();
                    index = i;
                    k = i;

                    break;
                }
                else
                    values[k1++] = records[i];
            }
            for (int i = k1; i < records.Length - 1; i++)
            {
                values[k1++] = records[i + 1];
            }
            values[records.Length-1] = answer;
            string filename1 = Path.GetTempFileName();
            bool isWhiteSpace = false;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename1))
            {
                foreach (string line in values)
                {
                    isWhiteSpace = string.IsNullOrEmpty(line);

                    if (!isWhiteSpace)
                    {
                        file.WriteLine(line);
                    }
                }
            }
            File.Delete(path);
            File.Move(filename1, path);
            MessageBox.Show("Record Modified Successfully");

        }

        private void button3_Click(object sender, EventArgs e)//DELETE BUTTON
        {
            string selectItem = Text_File_Contents.SelectedItem.ToString();
            string[] splitSelectItem = selectItem.Split('\t');
            //string filename = @"C:/books/UI Design/CS6326Asg2.txt";
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\CS6326Asg2.txt");
            string[] records = null;
            try
            {
                 records = File.ReadAllLines(path);
            }
            catch(Exception er)
            {
                MessageBox.Show("empty file");
                throw er;
            }
           
            int index = -1;
            int k = 0,k1=0;
            string[] values = new string[records.Length];
            for (int i = 0; i < records.Length; i++)
            {
                string[] fields = records[i].Split(new char[] { '\t' });
                if (fields[0] == splitSelectItem[0] && fields[1] == splitSelectItem[1])
                {
                    index = i;
                    k = i;
                    
                    break;
                }
                else
                    values[k1++] = records[i];
            }
           for(int i=k1;i<records.Length-1;i++)
            {
                values[k1++] = records[i + 1];
            }
            
            string filename1 = Path.GetTempFileName();
            bool isWhiteSpace=false;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename1))
            {
                foreach (string line in values)
                {
                    isWhiteSpace = string.IsNullOrEmpty(line);
                   
                    if (!isWhiteSpace)
                    {
                        file.WriteLine(line);
                    }
                }
            }
            File.Delete(path);
            File.Move(filename1,path);
            MessageBox.Show("Record Deleted Successfully");
           
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
                // MessageBox.Show("Enter only alphabets");
            }
            textBox1.MaxLength = 20;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            textBox2.MaxLength = 20;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            textBox3.MaxLength = 1;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9,\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9,\s]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            textBox6.MaxLength = 25;
        }



        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox8.MaxLength = 9;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox9.MaxLength = 21;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^\w!#$%&'*+-/=?^_`{|}~@]");
            if (regex.IsMatch(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            textBox10.MaxLength = 60;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //String filename = "C:/books/UI Design/CS6326Asg2.txt";
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\CS6326Asg2.txt");
            string path1 = Path.GetFullPath(path);
            if (!File.Exists(path1))
            {
                File.Create(path1).Dispose();
            }
            else
            {
                string[] curItem =File.ReadAllLines(path); 
                foreach (var item in curItem)
                {
                    if (string.IsNullOrWhiteSpace(item)) 
                    {
                        continue;
                    }
                    string[] split = item.Split('\t');
                    Text_File_Contents.Items.Add(split[0] + "\t" + split[1] + "\t" + split[2] + "\t" + split[8]); 
                
            }
        }
    }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectItem = Text_File_Contents.SelectedItem.ToString();
            string[] splitSelectItem = selectItem.Split('\t');
           
            string path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\CS6326Asg2.txt");
            string[] curItem =File.ReadAllLines(path);
            foreach (var item in curItem)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    continue;
                }
                string[] splitCurItem = item.Split('\t');
                if (splitCurItem[0] == splitSelectItem[0] && splitCurItem[1] == splitSelectItem[1] && splitCurItem[2] == splitSelectItem[2]) 
                {
                    textBox1.Text = splitCurItem[0];
                    textBox2.Text = splitCurItem[1];
                    textBox3.Text = splitCurItem[2];
                    textBox4.Text = splitCurItem[3];
                    textBox5.Text = splitCurItem[4];
                    textBox6.Text = splitCurItem[5];
                    comboBox1.Text = splitCurItem[6];
                    textBox8.Text = splitCurItem[7];
                    textBox9.Text = splitCurItem[8];
                    textBox10.Text = splitCurItem[9];
                    comboBox2.Text = splitCurItem[10];
                    dateTimePicker1.Text = splitCurItem[11];
                }
            }
        }
    }
}
