using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        static DateTime now = DateTime.Now;
        public Form1()
        {
            InitializeComponent();

            DateTime firstDay = new DateTime(now.Year, now.Month, 1); //1일

            int date = DateTime.DaysInMonth(now.Year, now.Month); //며칠
            int dayWeek = Convert.ToInt32(firstDay.DayOfWeek); //요일 

            yearMonth.Text = now.Year.ToString() + "년" + now.Month.ToString() + "월";      //n년 n월  

            DrawCalendar(dayWeek, date);
        }
        public void DrawCalendar(int dayWeek, int date)
        {
            for (int i = 0; i < dayWeek; i++) // 빈 칸
            {
                UserControl2 userControl2 = new UserControl2();
                panel1.Controls.Add(userControl2);
            }
            for (int i = 1; i <= date; i++) //시작 날짜
            {
                UserControl1 userControl1 = new UserControl1();
                UserControl3 userControl3 = new UserControl3();
                UserControl4 userControl4 = new UserControl4();
                UserControl5 userControl5 = new UserControl5();
                DateTime dw1 = new DateTime(now.Year, now.Month, i);
                int dw = Convert.ToInt32(dw1.DayOfWeek);
                if (dw1 == DateTime.Today) // 오늘 강조
                {
                    panel1.Controls.Add(userControl5);
                    userControl5.num(i);
                }
                else
                {
                    if (dw == 0) // 일요일
                    {
                        panel1.Controls.Add(userControl3);
                        userControl3.num(i);
                    }
                    else if (dw == 6) //토요일
                    {
                        panel1.Controls.Add(userControl4);
                        userControl4.num(i);
                    }
                    else //평일
                    {
                        panel1.Controls.Add(userControl1);
                        userControl1.num(i); // 증가
                    }
                }
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) // 다음 달
        {
            panel1.Controls.Clear();

            now = now.AddMonths(1);

            DateTime firstDay = new DateTime(now.Year, now.Month, 1); //1일

            int date = DateTime.DaysInMonth(now.Year, now.Month); //며칠
            int dayWeek = Convert.ToInt32(firstDay.DayOfWeek); //요일 

            yearMonth.Text = now.Year.ToString() + "년" + now.Month.ToString() + "월";
            DrawCalendar(dayWeek, date);
        }
        private void button2_Click(object sender, EventArgs e) // 이전 달
        {
            panel1.Controls.Clear();

            now = now.AddMonths(-1);

            DateTime firstDay = new DateTime(now.Year, now.Month, 1); //1일

            int date = DateTime.DaysInMonth(now.Year, now.Month); //며칠
            int dayWeek = Convert.ToInt32(firstDay.DayOfWeek); //요일 

            yearMonth.Text = now.Year.ToString() + "년" + now.Month.ToString() + "월";
            DrawCalendar(dayWeek, date);
        }
    }
}

