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
        public ClientModel(): base() {}
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
            Regex rgx = new Regex((@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"));
            return  (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname) && !string.IsNullOrEmpty(PhoneNumber)) &&
                (!Name.Any(char.IsDigit) && !Surname.Any(char.IsDigit) && rgx.IsMatch(PhoneNumber));
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
                        if (string.IsNullOrEmpty(Name))
                            result = "Cannot be empty";
                        else if (Name.Any(char.IsDigit))
                            result = "Name cannot contain digits";
                        break;
                    }
                    case "Surname":
                    {
                        if (string.IsNullOrEmpty(Surname))
                            result = "Cannot be empty";
                        else if (Surname.Any(char.IsDigit))
                            result = "Surname cannot contain digits";
                        break;
                    }
                    case "PhoneNumber":
                    {
                        if (string.IsNullOrEmpty(PhoneNumber))
                            result = "Cannot be empty";
                        else
                        {
                            Regex rgx = new Regex((@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"));
                            if (!rgx.IsMatch(PhoneNumber))
                                result = "Phone Number must be in correct format";
                        }
                        break;
                    }
                }
                return result;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public bool StartsWith(string searchText)
        {
            return Name.StartsWith(searchText) || Surname.StartsWith(searchText) || PhoneNumber.StartsWith(searchText);
        }
    }
}