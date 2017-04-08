using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotenManager.DataModels
{
    public class Student
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surName;

        public string SurName
        {
            get { return _surName; }
            set { _surName = value; }
        }



        public Student(string name, string surname)
        {
            this.Name   = name  ;
            this.SurName = surname;
        }

        public string DisplayName
        {
            get { return this.SurName + ", " + this.Name; }
            private set {  }
        }


    }
}
