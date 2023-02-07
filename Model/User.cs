using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_User_Management.ViewModel;

namespace WPF_User_Management.Model
{
    public class User: ValidatableBindableBase
    {
        int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        string? _FirstName;
        [Required]
        public string? FirstName { get { return string.IsNullOrEmpty(_FirstName) ? string.Empty : _FirstName; ; } set { SetProperty(ref _FirstName, value); } }


        string? _LastName;
        [Required]
        public string? LastName { get { return string.IsNullOrEmpty(_LastName) ? string.Empty : _LastName; ; } set { SetProperty(ref _LastName, value); } }

        string? _Email;

        [EmailAddress]
        [Required]
        public string? Email { get { return string.IsNullOrEmpty(_Email) ? string.Empty : _Email; } set { SetProperty(ref _Email, value); } }

        string? _PhoneNumber;
        [Phone]
        [Required]
        public string? PhoneNumber { get { return string.IsNullOrEmpty(_PhoneNumber) ? string.Empty : _PhoneNumber;} set { SetProperty(ref _PhoneNumber, value); } }

        string? _Address;
        [Required]
        public string? Address { get { return string.IsNullOrEmpty(_Address) ? string.Empty : _Address; ; } set { SetProperty(ref _Address, value); } }

        string? _City;
        [Required]
        public string? City { get { return string.IsNullOrEmpty(_City) ? string.Empty : _City; ; } set { SetProperty(ref _City, value); } }

        string? _State;
        [Required]
        public string? State { get { return string.IsNullOrEmpty(_State) ? string.Empty : _State; ; } set { SetProperty(ref _State, value); } }

        string? _ZipCode;
        [Required]
        public string? ZipCode { get { return string.IsNullOrEmpty(_ZipCode) ? string.Empty : _ZipCode; ; } set { SetProperty(ref _ZipCode, value); } }

        DateTime _DateofBirth;
        [Required]
        public DateTime DateofBirth { get { return _DateofBirth; } set { SetProperty(ref _DateofBirth, value); } }

        string? _ProfilePicture;
        public string? ProfilePicture { get { return _ProfilePicture; } set { SetProperty(ref _ProfilePicture, value); } }

        public override string ToString()
        {
            return string.Concat(FirstName, LastName, Email, PhoneNumber, Address, City, State, ZipCode, DateofBirth.ToString("mmddyyyy"));
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
