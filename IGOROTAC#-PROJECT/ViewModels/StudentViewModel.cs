using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IGOROTAC__PROJECT.Commands;
using IGOROTAC__PROJECT.Models;
using IGOROTAC__PROJECT.Views;
namespace IGOROTAC__PROJECT.ViewModels
{
    public class StudentViewModel:INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        StudentService ObjStudentService;

        public StudentViewModel()
        {
            ObjStudentService = new StudentService();
            LoadData();
            CurrentStudent = new Student();
            saveCommand = new RelayCommands(Save);
            searchCommand = new RelayCommands(Search);
            updateCommand = new RelayCommands(Update);
            deleteCommand = new RelayCommands(Delete);
        }

        private Student currentStudent;
        public Student CurrentStudent
        {
            get { return currentStudent; }
            set { currentStudent = value; OnPropertyChanged("CurrentStudent"); }
        }

        private ObservableCollection<Student> studentsList;

        public ObservableCollection<Student> StudentsList
        {
            get { return studentsList; }
            set { studentsList = value; OnPropertyChanged("StudentsList"); }
        }

        private void LoadData()
        {
            StudentsList = new ObservableCollection<Student> (ObjStudentService.GetAll());
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region SaveOperation
        private RelayCommands saveCommand;

        public RelayCommands SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var isSaved = ObjStudentService.Add(currentStudent);
                LoadData();
                CurrentStudent= new Student();
                if (isSaved)
                {
                    Message = "Student information saved";
                }
                else
                {
                    Message = "Save operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region SearchOperation
        private RelayCommands searchCommand;

        public RelayCommands SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjStudent = ObjStudentService.Search(CurrentStudent.Id);
                if (ObjStudent != null)
                {
                    CurrentStudent.Name = ObjStudent.Name;
                    CurrentStudent.Age = ObjStudent.Age;
                    CurrentStudent.Course = ObjStudent.Course;
                    CurrentStudent.Year = ObjStudent.Year;
                    Message = "Student found.";

                }
                else
                {
                    Message = "Student not found.";
                }
            }
            catch (Exception ex)
            {

                Message= ex.Message;
            }
        }
        #endregion

        #region updateOperation
        private RelayCommands updateCommand;

        public RelayCommands UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var isUpdated = ObjStudentService.Update(CurrentStudent);
                if (isUpdated)
                {
                    Message = "Employee Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                Message=ex.Message;
            }
        }
        #endregion

        #region deleteOperation
        private RelayCommands deleteCommand;
        public RelayCommands DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var isUpdated = ObjStudentService.Delete(CurrentStudent.Id);
                if (isUpdated)
                {
                    Message = "Employee Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region navigation
        private RelayCommands homeCommand;
        public ICommand HomeCommand
        {
            get
            {
                if (homeCommand == null)
                {
                    homeCommand = new RelayCommands(() => NavigateTo(new StudentView()));
                }
                return homeCommand;
            }
        }

        private RelayCommands aboutCommand;
        public ICommand AboutCommand
        {
            get
            {
                if (aboutCommand == null)
                {
                    aboutCommand = new RelayCommands(() => NavigateTo(new AboutView()));
                }
                return aboutCommand;
            }
        }


        private void NavigateTo(UserControl view)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.SetContent(view);
        }
        #endregion

    }
}
