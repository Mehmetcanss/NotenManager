using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using System;

namespace NotenManager.DataModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Schule _Schule;
        private SaveFileDialog sfd = new SaveFileDialog();
        private OpenFileDialog ofd = new OpenFileDialog();
        private RCommand saveCommand;
        private RCommand openCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public Schule Schule
        {
            get { return _Schule; }
            set {

                _Schule = value;
                OnPropertyChanged("Schule");
            }
        }

        private void OnPropertyChanged(string v)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public AppViewModel()
        {
            this.Schule = new Schule();
            sfd.AddExtension = true;
            sfd.Filter = "Schule Files | *.schule";
            ofd.AddExtension = true;
            ofd.Filter = "Schule Files | *.schule";
            this.saveCommand = new RCommand(saveBtnClick, () => { return true; });
            this.openCommand = new RCommand(openBtnClick, () => { return true; });
            
        }

        private void saveBtnClick()
        {

            if (sfd.ShowDialog() == true)
            {
                if (sfd.FileName != "")
                {
                    string text = this.Schule.ToXml();
                    File.WriteAllText(sfd.FileName, text);
                }
            }

        }

        private void openBtnClick()
        {
            if (ofd.ShowDialog() == true)
            {
                if (ofd.FileName != "")
                {
                    StreamReader ff = System.IO.File.OpenText(ofd.FileName);
                    XmlSerializer ser = new XmlSerializer(typeof(Schule));
                    this.Schule = (Schule)ser.Deserialize(ff);
                    
                }
            }
        }

        public ICommand SaveClickCommand
        {
            get
            {
                return this.saveCommand;
            }
        }
        public ICommand OpenClickCommand
        {
            get
            {
                return this.openCommand;
            }
        }
    }


    


}
