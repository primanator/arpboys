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
            if (textBox1.Text == "")
                textBox1.Text = ("0");
        }

        public void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = ("0");
        }
        
        public void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = ("0");
            
            if (textBox2.Text == "")
                textBox2.Text = ("0");

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

            Resl.Text =
"\n Уменьшение физ. урона до рейтинга пробивания = " + Convert.ToString(ArmRedPre) + " %"
+ "\n Остаток эффективной брони после рейтинга пробивания = " + Convert.ToString(ArmLeft)
+ "\n Уменьшение физ. урона после рейтинга пробивания = " + Convert.ToString(ArmRedPost) + " %"
+ "\n Разница физ урона после рейтинга пробивания = " + Convert.ToString(ArmRedDef) + " %";
        }
    }
}
    


