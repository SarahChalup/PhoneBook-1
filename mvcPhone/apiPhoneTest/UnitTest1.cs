using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace apiPhoneTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1Exist()
        { 
            //organizar
            var Controler = new apiPhone.Controllers.PhonesController();

            //actuar
            var response = Controler.PhoneExists(1);

            //afirmar
            Assert.AreEqual(Controler,response);
        }
    }
}
