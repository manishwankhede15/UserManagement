using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_User_Management.Commands;
using WPF_User_Management.Model;
using WPF_User_Management.Repository;

namespace WPF_User_Management.ViewModel
{
    internal class UserViewModel:ViewModelBase
    {
        public User? _user;
        ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get { return _users; } }
        public User? User { get { return _user; } set { SetProperty(ref _user, value); } }
        public ICommand AddUserCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteRowCommand { get; private set; }
        public ICommand SearchUserCommand { get; private set; }
        public ICommand ResetUserCommand { get; private set; }
        
        IUserRepository userRepository;
        string _SearchText;
        public string SearchText { get { return _SearchText; } set { SetProperty(ref _SearchText, value); } }

        public UserViewModel()
        {
            AddUserCommand = new ActionCommand(AddNewUser, CanAddNewUser);
            SaveCommand = new ActionCommand(SaveUser, CanSaveUser);
            DeleteRowCommand = new ActionCommand(DeleteUser, CanDeleteUser);
            SearchUserCommand = new ActionCommand(SearchUser, CanSearchUser);
            ResetUserCommand = new ActionCommand(ResetSearch,  ()=>{ return true; } );
            userRepository = new UserRepository();
            GetUsersFromrepository();

        }

        private void GetUsersFromrepository()
        {
            Users.Clear();
            foreach (User user in userRepository.GetUsers())
            {
                Users.Add(user);
            }
        }

        public void AddNewUser(object parameter)
        {
            User = new User();
        }
        public bool CanAddNewUser()
        {
            return true;
            if (_user!=null)
                return !_user.HasErrors;

            return false;
        }
        public void SaveUser(object parameter)
        {
            if (_user != null)
            {
                if (User?.Id > 0) { userRepository.UpdateUser(User); }
                else { userRepository.AddUser(User); }

                GetUsersFromrepository();
            }
        }
        public bool CanSaveUser()
        {
            return true;
            if (_user != null)
                return !_user.HasErrors;

            return false;
        }
        public void DeleteUser(object parameter)
        {
            if (parameter is User)
            {
                User user = (User)parameter;
                userRepository.DeleteUser((parameter as User).Id);
                Users.Remove(user);
            }

            
        }
        public bool CanDeleteUser()
        {
            return true;
            //if (_user != null)
            //    return !_user.HasErrors;

            //return false;
        }
        public void SearchUser(object parameter)
        {
            IEnumerable<User> searchedUsers =  userRepository.SearchUser(SearchText);
            Users.Clear();
            foreach (User user in searchedUsers)
            {
                Users.Add(user);
            }           
        }
        public bool CanSearchUser()
        {
            return true;
            //if (_user != null)
            //    return !_user.HasErrors;

            //return false;
        }
        public void ResetSearch(object parameter)
        {
            SearchText = "";
            GetUsersFromrepository();
        }
    }
}
