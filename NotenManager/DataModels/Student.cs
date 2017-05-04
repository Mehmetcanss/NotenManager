using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotenManager.DataModels
{
    public class Student : DependencyObject
    {
        private string _name;
        private string _surName;



        public static readonly DependencyProperty ersteKleinProperty =
            DependencyProperty.Register("ersteKlein", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty zweiteKleinProperty =
            DependencyProperty.Register("zweiteKlein", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty dritteKleinProperty =
            DependencyProperty.Register("dritteKlein", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty vierteKleinProperty =
            DependencyProperty.Register("vierteKlein", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty fünfteKleinProperty =
            DependencyProperty.Register("fünfteKlein", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty ersteGrossProperty =
            DependencyProperty.Register("ersteGross", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));
        public static readonly DependencyProperty zweiteGrossProperty =
            DependencyProperty.Register("zweiteGross", typeof(double), typeof(Student), new PropertyMetadata(0d, NoteChanged));



        // Using a DependencyProperty as the backing store for Average.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AverageProperty =
            DependencyProperty.Register("Average", typeof(double), typeof(Student), new PropertyMetadata(0d));


        public Student()
        {

        }

        public double ersteKlein
        {
            get { return (double)GetValue(ersteKleinProperty); }
            set { SetValue(ersteKleinProperty, value); }
        }
        public double zweiteKlein
        {
            get { return (double)GetValue(zweiteKleinProperty); }
            set { SetValue(zweiteKleinProperty, value); }
        }
        public double dritteKlein
        {
            get { return (double)GetValue(dritteKleinProperty); }
            set { SetValue(dritteKleinProperty, value); }
        }
        public double vierteKlein
        {
            get { return (double)GetValue(vierteKleinProperty); }
            set { SetValue(vierteKleinProperty, value); }
        }
        public double fünfteKlein
        {
            get { return (double)GetValue(fünfteKleinProperty); }
            set { SetValue(fünfteKleinProperty, value); }
        }
        public double ersteGross
        {
            get { return (double)GetValue(ersteGrossProperty); }
            set { SetValue(ersteGrossProperty, value); }
        }
        public double zweiteGross
        {
            get { return (double)GetValue(zweiteGrossProperty); }
            set { SetValue(zweiteGrossProperty, value); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string SurName
        {
            get { return _surName; }
            set { _surName = value; }
        }


        public Student(string name, string surname)
        {
            this.Name = name;
            this.SurName = surname;
        }

        private static void NoteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double average = CalculateAverage((Student)d);
            d.SetValue(Student.AverageProperty, average);
        }

        private static double CalculateAverage(Student d)
        {
            double averageSmall = 0;
            double[] smallNotes = new double[5];
            double[] bigNotes = new double[2];
            double averageBig = 0;
            smallNotes[0] = (double)d.GetValue(Student.ersteKleinProperty);
            smallNotes[1] = (double)d.GetValue(Student.zweiteKleinProperty);
            smallNotes[2] = (double)d.GetValue(Student.dritteKleinProperty);
            smallNotes[3] = (double)d.GetValue(Student.vierteKleinProperty);
            smallNotes[4] = (double)d.GetValue(Student.fünfteKleinProperty);
            double k = 0;
            for (int i = 0; i < 5; i++)
            {
                if (smallNotes[i] > 0)
                {
                    k++;
                    averageSmall += smallNotes[i];
                }
            }

            if(k>0)
                averageSmall /= k;
            bigNotes[0] = (double)d.GetValue(Student.ersteGrossProperty);
            bigNotes[1] = (double)d.GetValue(Student.zweiteGrossProperty);
            k = 0;
            for (int i = 0; i < 2; i++)
            {
                if (bigNotes[i] > 0)
                {
                    k++;
                    averageBig += bigNotes[i];
                }
            }
            if(k>0)
            averageBig /= k;

            double average = 0;
            if (averageBig > 0 && averageSmall > 0)
            {
                average = (averageSmall + averageBig * (double)2) / (double)3;

            } else if(averageBig > 0 && averageSmall == 0)
            {
                average = averageBig;
            } else if(averageSmall > 0 && averageBig == 0)
            {
                average = averageSmall;
            }
            return average;

        }

        public double Average
        {
            get { return (double)GetValue(AverageProperty); }
            set { SetValue(AverageProperty, value); }
        }



    }
}
