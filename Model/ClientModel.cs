using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Model
{
    public class ClientModel: Model, IDataErrorInfo
    {
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private Regex rgx = new Regex((@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"));

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                NotifyPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyPropertyChanged();
            } 
        }
        
        public string Error { get; }

        public bool Validate()
        {
            return !Name.Any(char.IsDigit) && !Surname.Any(char.IsDigit) && rgx.IsMatch(PhoneNumber);
        }

        public string this[string name]
        {
            get
            {
                string result = null;
                switch (name)
                {
                    case "Name":
                    {
                        if (Name.Any(char.IsDigit))
                            result = "Name cannot contain digits";
                        break;
                    }
                    case "Surname":
                    {
                        if (Surname.Any(char.IsDigit))
                            result = "Surname cannot contain digits";
                        break;
                    }
                    case "PhoneNumber":
                    {
                        if (!rgx.IsMatch(PhoneNumber))
                            result = "Phone Number must be in correct format";
                        break;
                    }
                }
                return result;
            }
        }
    }
}