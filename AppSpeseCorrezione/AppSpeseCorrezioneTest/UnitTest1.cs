using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Runtime;

namespace AppSpeseCorrezioneTest
{
    public class Tests
    {

        private WindowsDriver _driver;

        [SetUp]
        public void Setup()
        {
            //Oggetto che contiene e opzioni di APPIUM per accedere all'applicazione
            //Oggetto di tipo AppiumOptions
            var options = new AppiumOptions();

            options.PlatformName = "Windows";
            options.AutomationName = "Windows";
            options.DeviceName = "WindowsPC";
            //Attenzione Aggiungere il punto esclamativo App alla fine
            options.App = "com.companyname.appspesecorrezione_9zz4h110yvjzm!App";

            //Indica i driver da chiamara al Sistema operativo
            options.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            //Avvia l'APP e attende 10s
            options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            //Uniform Resource Identifier
            var serverUri = new Uri("http://127.0.0.1:4723/");
            _driver = new WindowsDriver(serverUri, options);
        }

        [Test]
        public void Test_verificaTitoloApp()
        {
            Assert.That(_driver.Title, Is.EqualTo("AppSpeseCorrezione").Or.Contain("LE MIE SPESE"));
        }

        [Test]
        public void Test_InserientoNome()
        {
            //Aspettiamo 3 secondi che l'app sia caricata
            //Thread permette la programmazione parallela
            System.Threading.Thread.Sleep(3000);

            //Nella variabile inserisco l'elemento che ha l'automationID = EntNomeLista
            var inputNome = _driver.FindElement(MobileBy.AccessibilityId("EntNomeLista"));
            //Mettiamo il focus sull'entry
            inputNome.Click();
            //Puliamo l'entry
            inputNome.Clear();
            //Scriviamo nel controllo
            inputNome.SendKeys("Spesa Aprile");
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Test_InserientoDescrizione()
        {
            System.Threading.Thread.Sleep(3000);
            var inputDescrizione = _driver.FindElement(MobileBy.AccessibilityId("EntDescrizione"));
            inputDescrizione.Click();
            inputDescrizione.Clear();
            inputDescrizione.SendKeys("Automobile");
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Test_InserientoImporto()
        {
            System.Threading.Thread.Sleep(3000);
            var inputImporto = _driver.FindElement(MobileBy.AccessibilityId("EntImporto"));
            inputImporto.Click();
            inputImporto.Clear();
            inputImporto.SendKeys("200");
            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void Test_BottoneSalvaSpesa()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()

        {
            _driver?.Quit();
            _driver?.Dispose();
        }

    }
}