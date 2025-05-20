using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityToolkitApp01.Models
{
    public class Person : ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value); // SetProperty를 사용하면 OnPropertyChanged가 자동 발생
            }
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set
            {
                SetProperty(ref _gender, value);
            }
        }
    }
}
