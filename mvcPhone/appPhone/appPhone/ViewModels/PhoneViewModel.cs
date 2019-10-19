
namespace appPhone.View_Models
{
    using appPhone.Models;
    using appPhone.Services;
    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class PhoneViewModel:BaseViewModel
    {
        #region Attributes
        ApiService apiservice;
        private ObservableCollection<Phone> phone;
        #endregion

        #region Properties
       public ObservableCollection<Phone> Phones
        {
            get { return this.phone; }
            set { SetValue(ref this.phone, value); } 
        }
        #endregion

        #region Constructor
        public PhoneViewModel()
        {
            this.apiservice = new ApiService();
            this.LoadPhones();
        }
        #endregion


        #region Method
        private async void LoadPhones()
        {
            var connection = await apiservice.CheckConnection(); 
            if(!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error en Internet", connection.Message, "Accept");
                return;
            }
            var response = await apiservice.GetList<Phone>("http://localhost:50311/", //ruta base
              "api/" , //intermedio
              "Phones"); //controlador

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Service Phone Error", 
                    response.Message, 
                    "Accept");
                return;
            }

            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ListPhone = (List<Phone>)response.Result;

            this.Phones = new ObservableCollection<Phone>(this.ToPhoneCollect());
        } 

        private IEnumerables<Phone> ToPhoneCollect()
        {
            ObservableCollection<Phone> collect = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach(var lista in main.ListPhone)
            {
                Phone phone = new Phone();
                phone.PhoneID = lista.PhoneID;
                phone.Name = lista.Name;
                phone.Type = lista.Type;
                phone.Contact = lista.Contact;
                collect.Add(phone);
            }
            return (collect);
        }

        #endregion
    }
}