using Bogus;
using Bogus.DataSets;
using Degree.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }
        public ICommand AddOrUpdateCommand { get; set; }    
        public ICommand DeleteCommand { get; set; }    

        public MainPageViewModel() 
        {
            Refresh();
            GenereteNewCustomer();
            AddOrUpdateCommand = new Command(async =>
            {
                App.CustomerRepository.SaveItem(CurrentCustomer);
                Console.WriteLine(App.CustomerRepository.StatusMessage);
                GenereteNewCustomer();
                Refresh();
            });
            DeleteCommand= new Command(() =>
            {
                App.CustomerRepository.DeleteItem(CurrentCustomer);
                Refresh();
            });

        }

        private void GenereteNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();

        }
       
        private void Refresh ()
        {
            Customers = App.CustomerRepository.GetItems();
        }
    }
}
