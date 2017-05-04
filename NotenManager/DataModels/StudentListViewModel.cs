using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace NotenManager.DataModels
{
    public class StudentListViewModel
    {
        ObservableCollection<Student> _students;
        RCommand addCommand;
        RCommand deleteCommand;
        private string _name;
        

        public StudentListViewModel()
        {
            this._students = new ObservableCollection<Student>();
            deleteCommand = new RCommand(delete, canDelete);
            addCommand = new RCommand(add, () => { return true; });
        }
        public StudentListViewModel(string name)
        {
            this._students = new ObservableCollection<Student>();
            this.Name = name;
            deleteCommand = new RCommand(delete, canDelete);
            addCommand = new RCommand(add, () => { return true; });
        }

        public ObservableCollection<Student> Students
        {
            get
            {

                return this._students;
            }
        }

        [XmlIgnore]
        public ICommand AddCommand
        {
            get
            {
                return addCommand;
            }
        }

        [XmlIgnore]
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        private bool canDelete()
        {
            return this.SelectedStudent != null;
        }

        private void delete()
        {
            Students.Remove(SelectedStudent);
        }

        private void add()
        {
            Students.Add(new Student("someStudent", "someSurname"));
        }

        [XmlIgnore]
        public Student SelectedStudent { get; set; }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



    }
}
