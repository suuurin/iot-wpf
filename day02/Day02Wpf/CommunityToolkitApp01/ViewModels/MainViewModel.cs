using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitApp01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkitApp01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private IList<Person>? _people;
        public IList<Person>? People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        private Person? _selectedPerson;
        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public MainViewModel()
        {
            People = new List<Person>
            {
                new Person{Id = 119302, Name = "성명건", Gender = true},
                new Person{Id = 119801, Name = "애슐리", Gender = false},
                new Person{Id = 111202, Name = "손흥민", Gender = true},
                new Person{Id = 111319, Name = "박주영", Gender = true},
                new Person{Id = 112206, Name = "최명길", Gender = false},
            };
        }
    }
}
