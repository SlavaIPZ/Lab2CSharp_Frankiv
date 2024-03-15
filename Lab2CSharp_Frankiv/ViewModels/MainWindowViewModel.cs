using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Lab2CSharp_Frankiv.Models;
using Lab2CSharp_Frankiv.Tools;

namespace Lab2CSharp_Frankiv.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                _proceedCommand.RaiseCanExecuteChanged();
            }
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
                _proceedCommand.RaiseCanExecuteChanged();
            }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
                _proceedCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
                _proceedCommand.RaiseCanExecuteChanged();
            }
        }

        private readonly RelayCommand _proceedCommand;
        public ICommand ProceedCommand => _proceedCommand;

        public MainWindowViewModel()
        {
            _proceedCommand = new RelayCommand(Proceed, CanProceed);
        }

        private void Proceed(object? parameter)
        {
            if (!ValidateDateOfBirth())
            {
                MessageBox.Show("Enter the valid birthdate");
                return;
            }
            

            Person person = new Person
            {
                Name = Name,
                Surname = Surname,
                EmailAddress = EmailAddress,
                DateOfBirth = DateOfBirth
            };

            if (person.IsBirthday)
            {
                MessageBox.Show("HAPPY BIRTHDAY!!!");
            }

            string outputMessage = $"Name: {person.Name}\n" +
                                   $"Surname: {person.Surname}\n" +
                                   $"Email: {person.EmailAddress}\n" +
                                   $"Date of Birth: {person.DateOfBirth.ToShortDateString()}\n" +
                                   $"Sun Sign: {person.SunSign}\n" +
                                   $"Chinese Sign: {person.ChineseSign}\n" +
                                   $"Is Adult: {(person.IsAdult ? "Yes" : "No")}\n" +
                                   $"Is Birthday: {(person.IsBirthday ? "Yes" : "No")}";

            MessageBox.Show(outputMessage, "Person Information");
        }

        private bool CanProceed(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(EmailAddress) &&
                   DateOfBirth != default;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool ValidateDateOfBirth()
        {
            DateTime today = DateTime.Today;
            if (DateOfBirth > today)
            {
                DateOfBirth = default; 
                return false;
            }

            int age = today.Year - DateOfBirth.Year; ;
            if (age > 135)
            {
                DateOfBirth = default; 
                return false;
            }

            return true;
        }
    }
}
