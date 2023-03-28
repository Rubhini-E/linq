using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace generic
{
    /// <summary>
    /// Interaction logic for reg.xaml
    /// </summary>
    public partial class reg : Window
    {

        // List<rreg> register;
        List<rreg> detail = new List<rreg>();
        public reg()
        {
            InitializeComponent();
            // rootpath = @"C:\\Users\\rubhi\\OneDrive\\Documents\\reg\";
          

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string gen = " ";

            if (rbm.IsChecked == true)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }

            string name = txtname.Text;
            //string dob = txtdob.Text;
            //string qual = txtqul.Text;
            //string email = txtmail.Text;
            //string contact = txtnum.Text;
           // string name = txtname.Text.ToString();

            string rpath = Rpath();
            string path = System.IO.Path.Combine(rpath, name + ".txt");

            //if (register == null)
            //{
            //    register = new List<rreg>();
            //}
            //rreg info = new rreg();
            //numbers.Select(n => n.ToString()).ToArray();
            //info.name = txtname.Text;
            //info.dob = txtdob.Text;
            //info.qual = txtqul.Text;
            //info.email = txtmail.Text;
            //info.gen = gen.ToString();
            //info.contact = txtnum.Text;
            //register.Add(info);

            // File.WriteAllText(path, info.name +  info.dob +  info.gen +  info. qual +  info.email +  info.contact );
            //File.WriteAllText(path, info.name + "|" + info.dob + "|" + info.gen + "|" + info.qual + "|" + info.email + "|" + info.contact);

            // File.WriteAllText(path, register.ToString());
            // File.WriteAllText(path, contant);

            // File.WriteAllText(path, "NAME   :" + txtname.Text + "\n" + "DOB  :" + txtdob.Text + "\n" + "GENDER  :" + gen + "\n" + "QUALIFICATION  :" + txtqul.Text + "\n" + "EMAIL ID   :" + txtmail.Text + "\n" + "cONTACT NUM  :" + txtnum.Text);
            File.WriteAllText(path, txtname.Text + "|" + txtdob.Text + "|" + gen + "|" + txtqul.Text + "|" + txtmail.Text + "|" + txtnum.Text);
            MessageBoxResult res = MessageBox.Show("Saved Successfully", "success", MessageBoxButton.OK, MessageBoxImage.Information);
            if (res == MessageBoxResult.OK)
            {
                txtname.Clear();
                txtdob.Clear();
                txtqul.Clear();
                txtmail.Clear();
                txtnum.Clear();
                rbm.IsChecked = false;
                rbf.IsChecked = false;
                //rbt.IsChecked = false;



            }
        }


        private string Rpath()
        {
            string filepath = System.Environment.CurrentDirectory;
            int index = filepath.IndexOf("bin");
            string removebin = filepath.Remove(index);
            return removebin;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lstview.Visibility = Visibility.Visible;

            string sname = txtname1.Text;

            string rpath = Rpath();
            string path = System.IO.Path.Combine(rpath, sname + ".txt");

           
            foreach (string line in File.ReadAllLines(path))
            {
                string[] fields = line.Split('|');
               // rreg det = new rreg(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                rreg det = new rreg(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                det.name = fields[0];
                det.dob = fields[1];
                det.gen = fields[2];
                det.qual = fields[3];
                det.email = fields[4];
                det.contact = fields[5];
                detail.Add(det);
                // MessageBox.Show(fields[2]);

            }
           // MessageBox.Show(detail.ToString());


            var con = from deta in detail
                              //where det != null
                                where deta.name == sname
                                 select deta;

            // lstview.DataContext = con;
            //  MessageBox.Show(con.ToString());
            if (sname != null)
            {

                lstview.ItemsSource = con;
                lstview.Items.Refresh();
            }



        }


    }
}
