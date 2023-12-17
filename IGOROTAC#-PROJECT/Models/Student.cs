using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGOROTAC__PROJECT.Models
{
    public class Student:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        private string name;
        private string course;
        private int age;
        private string year;


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }

        public string Course
        {
            get { return course; }
            set { course = value; OnPropertyChanged("Course"); }
        }

        public string Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged("Year"); }
        }

    }
}
