using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuickSortWithPanels
{
    public partial class Form1 : Form
    {
        int[] Array = new int[6];
        List<Panel> panels = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
        }


        private int Partition(int[] array, int low, int high)
        {
           
            int pivot = array[high];
            int lowIndex = (low - 1);

            
            for (int j = low; j < high; j++)
            {
                printCharts(array, 250, j, -1);

                if (array[j] <= pivot)
                {
                    lowIndex++;

                    Swap(ref array, lowIndex, j);
                }
            }

            Swap(ref array, lowIndex + 1, high);

            return lowIndex + 1;
        }

        private void Swap(ref int[] array, int index1, int index2)
        {
            printCharts(array, 350, index1, index2);
            int temp1 = array[index1];
            array[index1] = array[index2];
            array[index2] = temp1;
            printCharts(array, 350, index1, index2);
        }

        private void Sort(int[] array, int low, int high)
        {
            Application.DoEvents();
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                

                printCharts(array, 100);
                Sort(array, low, partitionIndex - 1);

                printCharts(array, 100);
                Sort(array, partitionIndex + 1, high);
            }
        }
        private void printCharts(int[] array, int sleep, int lowred = -1, int highred = -1)
        {

            panel6.Height = array[0] * 20;
            panel5.Height = array[1] * 20;
            panel4.Height = array[2] * 20;
            panel3.Height = array[3] * 20;
            panel2.Height = array[4] * 20;
            panel1.Height = array[5] * 20;

            panels.Add(panel6);
            panels.Add(panel5);
            panels.Add(panel4);
            panels.Add(panel3);
            panels.Add(panel2);
            panels.Add(panel1);

            foreach (var panel in panels)
            {
                panel.BackColor = Color.FromArgb(128, 128, 255);
            }

            if (lowred >= 0) panels[lowred].BackColor = Color.Red;
            if (highred >= 0) panels[highred].BackColor = Color.Red;

            Application.DoEvents();

            Thread.Sleep(sleep);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random number = new Random();
            for (int i = 0; i < 6; i++)
            {
                Array[i] = number.Next(1, 9);
            }
            panel1.Height = Array[5] * 20;
            panel2.Height = Array[4] * 20;
            panel3.Height = Array[3] * 20;
            panel4.Height = Array[2] * 20;
            panel5.Height = Array[1] * 20;
            panel6.Height = Array[0] * 20;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Sort(Array, 0, Array.Length - 1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}