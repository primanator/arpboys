using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox1.Text = CheckTextBoxEmpty(textBox1.Text);
        }

        public void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox2.Text = CheckTextBoxEmpty(textBox2.Text);
        }

        public string CheckTextBoxEmpty(string text)
        {
            if (text == "")
                return "0";
            return text;
        }

        public void CheckTextBoxValue(string text)
        {
            char[] arr = text.ToCharArray();
            foreach (char c in arr)
                if (c < '0' & c > '9')
                    throw new FormatException();
        }

        public void ClearAllFileds()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            Resl.Text = "";
        }

        public void Calculations()
        {
            double Arm = Convert.ToDouble(textBox1.Text);
            double Pen = Convert.ToDouble(textBox2.Text) / 100;
            if (Pen > 1)
            {
                Pen = 1;
            }
            double ArmRedPre = (Arm / (Arm + 15235.5)) * 100;
            if (ArmRedPre > 75)
                ArmRedPre = 75;
            double ArmLeft = (Arm - ((Arm + 15235.5) / 3) * Pen);
            if (ArmLeft < 0)
                ArmLeft = 0;
            if (ArmLeft > 45706.5)
                ArmLeft = 45706.5;
            double ArmRedPost = (ArmLeft / (ArmLeft + 15235.5)) * 100;
            double ArmRedDef = (ArmRedPre - ArmRedPost);

            Resl.Text = String.Format("\n Decreasing of physical damage BEFORE armor penetration = {0} %\n Residue of effective armor AFTER penetration = {1}\n Decreasing of physical damage AFTER armor penetration = {2} %\n The difference of physical damage AFTER armor penetration = {3} %",
                Math.Round(ArmRedPre, 2), Math.Round(ArmLeft,2), Math.Round(ArmRedPost,2), Math.Round(ArmRedDef, 2));
        }

        public void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckTextBoxValue(textBox1.Text);
                CheckTextBoxValue(textBox2.Text);
                Calculations();
            }
            catch
            {
                MessageBox.Show("Please enter only numbers!");
                ClearAllFileds();
            }
        }
    }
}
    


