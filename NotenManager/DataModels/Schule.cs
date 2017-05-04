using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace NotenManager.DataModels
{
    public class Schule
    {

       
        public ObservableCollection<StudentListViewModel> StudentGroups
        {
            get
            {

                return _studentGroups;
            }
        }
        private ObservableCollection<StudentListViewModel> _studentGroups = new ObservableCollection<StudentListViewModel>();


        private StudentListViewModel _selectedGroup;

        private RCommand addBtnClick;
        private RCommand delBtnClick;
        private RCommand saveBtnClick;

        [XmlIgnore]
        public StudentListViewModel SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; }
        }



        public Schule()
        {
    
            addBtnClick = new RCommand(addStudentGroup, () => { return true; });
            delBtnClick = new RCommand(deleteStudentGroup, canDeleteStudentGroup);

        }

        private void addStudentGroup()
        {
            this.StudentGroups.Add(new StudentListViewModel("dfsdfsd"));
        }

        private void deleteStudentGroup()
        {
            this.StudentGroups.Remove(this.SelectedGroup);
        }

        private bool canDeleteStudentGroup()
        {
            return this.SelectedGroup != null;
        }

        [XmlIgnore]
        public ICommand AddStudentGroup
        {
            get
            {
                return this.addBtnClick;
            }
        }

        [XmlIgnore]
        public ICommand DeleteStudentGroup
        {
            get
            {
                return this.delBtnClick;
            }
        }
     

        public string ToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Schule));
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, this);
            ms.Position = 0;
            StreamReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }
    }
}
