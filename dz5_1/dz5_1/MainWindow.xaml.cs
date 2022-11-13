using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dz5_1
{
    public class Fraction
    {
        int chislitel;
        int znamenatel;
        public Fraction(int a, int b)
        {
            chislitel = a;
            znamenatel = b;
        }
        public int getChislitel()
        {
            return chislitel;
        }
        public int getZnamenatel()
        {
            return znamenatel;
        }
        public int setChislitel
        {
            set { chislitel = value; }
        }
        public int setZnamenatel
        {
            set { znamenatel = value; }
        }
    }
    public partial class MainWindow
    {
        public static void calculate()
        {
            int buf = fractions[0].getZnamenatel();
            fractions[0].setZnamenatel = fractions[0].getZnamenatel() * fractions[1].getZnamenatel();
            fractions[0].setChislitel = fractions[0].getChislitel() * fractions[1].getZnamenatel();
            fractions[1].setZnamenatel = fractions[1].getZnamenatel() * buf;
            fractions[1].setChislitel = fractions[1].getChislitel() * buf;
            fractions[2] = new Fraction((fractions[0].getChislitel() + fractions[1].getChislitel()), fractions[0].getZnamenatel());

        }


        public MainWindow()
        {
            InitializeComponent();
        }


        public static Fraction[] fractions = new Fraction[3];


        private void calc_Click(object sender, RoutedEventArgs e)
        {
            string[] buf;
            bool correct = false;
            for (int i = 0; i < drob1.Text.Length; i++)
            {
                if (drob1.Text[i] == '/')
                {
                    correct = true;
                    break;
                }
            }

            if (correct == false)
            {
                MessageBox.Show("Введите дробь 1 корректно");
                drob1.Clear();
            }

            correct = false;
            for (int i = 0; i < drob2.Text.Length; i++)
            {
                if (drob2.Text[i] == '/')
                {
                    correct = true;
                    break;
                }
            }
            if (correct == false)
            {
                MessageBox.Show("Введите дробь 2 корректно");
                drob2.Clear();
            }


            buf = drob1.Text.Split('/');
            int vihod;


            if (int.TryParse(buf[0], out vihod) && int.TryParse(buf[1], out vihod))
            {
                fractions[0] = new Fraction(int.Parse(buf[0]), int.Parse(buf[1]));
            }
            else
            {
                MessageBox.Show("Введите дробь 1 корректно");
            }

            buf = drob2.Text.Split('/');
            if (int.TryParse(buf[0], out vihod) && int.TryParse(buf[1], out vihod))
            {
                fractions[1] = new Fraction(int.Parse(buf[0]), int.Parse(buf[1]));
            }
            else
            {
                MessageBox.Show("Введите дробь 2 корректно");
            }
            calculate();
            otvet.Text = string.Format("{0}/{1}", fractions[2].getChislitel(), fractions[2].getZnamenatel());

        }
    }

}

