using System;
using System.Windows;

namespace Lab2CSharp_Frankiv.Models
{
    public class Person
    {
        private DateTime _dateOfBirth;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                SunSign = CalculateSunSign();
                ChineseSign = CalculateChineseSign();
            }
        }

        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }

        public bool IsAdult => CalculateAge() >= 18;

        public bool IsBirthday => DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
        private string CalculateSunSign()
        {
            int month = _dateOfBirth.Month;
            int day = _dateOfBirth.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                return "Capricorn";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
            {
                return "Pisces";
            }

            return "Sun Sign";
        }
        

        private string CalculateChineseSign()
        {
            const int startYear = 1884;
            int year = _dateOfBirth.Year;
            int offset = year - startYear;
            int index = offset % 12;

            string[] chineseSigns = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };
            return chineseSigns[index];
        }
        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
       
    }
}
