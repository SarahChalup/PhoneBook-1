using appPhone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace appPhone.View_Models
{
    public class MainViewModel
    {
        #region Properties
        public List<Phone> ListPhone { get; set; }
        #endregion

        #region ViewModel
        public PhoneViewModel phoneViewModel { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {

        } 
        #endregion


        #region singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance==null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
