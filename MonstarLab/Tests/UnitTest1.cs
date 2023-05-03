using System.Net;
using MonstarLab.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MonstarLab.Tests;

public class Tests
{ 
    private const int ModalItemCount = 15;
    public const string LandingUrl = "https://www.mall.cz/";
    private const int TimeBetweenTests = 30000; // in milisec

    public static ChromeDriver Driver()
    {
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load all carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        return driver; 
    }

    [SetUp]
    public void SetUp()
    {
        var elementMaster = LandingPage.Carousels();
    }
    [Test]
     public void PageConnectionCheck()
     {

         // Arrange
         var landingPage = new LandingPage();
         // Act
         var statusCode = landingPage.GetStatusCode();
         // Assert
         Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
     
         
         
     }

     [TestFixture]
     public class CarouselAkce
     {

      [Test]
      public void CarouselAkceItemCountCheck()
      {
          //Calling the method
          var itemCount = LandingPage.CarouselAkceItemCount();
          
          //Assertion
          Assert.That(itemCount, Is.EqualTo(ModalItemCount),
           $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
      }

      [Test]
      public void CarouselAkceIsUniqueCheck()
      {
           //Calling the method
           var uniqueCheck = LandingPage.CarouselAkceIsUnique();
           
           //Assertion
           Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
      }
      [OneTimeTearDown]
      public void TearDownOneTime()
      {
          // Pause for 5 seconds in-between tests 
          Thread.Sleep(TimeBetweenTests);
      }
     }

     [TestFixture]
     public class CarouselHouseFurniture
     {
         [Test]
         public void CarouselFurnitureItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselFurnitureItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselFurnitureIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselFurnitureIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }
     
     [TestFixture]
     public class CarouselKidsToys
     {
         [Test]
         public void CarouselKidsToysItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselKidsToysItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselKidsToysIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselKidsToysIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }
     
     [TestFixture]
     public class CarouselTV
     {
         [Test]
         public void CarouselTVItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselTVItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselTVIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselTVIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }

     [TestFixture]
     public class CarouselFreeDelivery
     {
         [Test]
         public void CarouselFreeDeliveryItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselFreeDeliveryItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselFreeDeliveryIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselFreeDeliveryIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }
     
     [TestFixture]
     public class CarouselTools
     {
         [Test]
         public void CarouselToolsItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselToolsItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselToolsIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselToolsIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }
     
     [TestFixture]
     public class CarouselCleaning
     {
         [Test]
         public void CarouselCleaningItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselCleaningItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselToolsIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselCleaningIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
     }
     
     [TestFixture]
     public class CarouselFavCategories
     {
         [Test]
         public void CarouselFavCategoriesItemCountCheck()
         {
             //Calling the method
             var itemCount = LandingPage.CarouselFavCategoriesItemCount();
          
             //Assertion
             Assert.That(itemCount, Is.EqualTo(ModalItemCount),
                 $"There are {itemCount} items in the carousel. Whereas expected: {ModalItemCount}");
       
         }

         [Test]
         public void CarouselToolsIsUniqueCheck()
         {
             //Calling the method
             var uniqueCheck = LandingPage.CarouselFavCategoriesIsUnique();
           
             //Assertion
             Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
         }
        
         [OneTimeTearDown]
         public void TearDownOneTime()
         {
             // Pause for 5 seconds in-between tests 
             Thread.Sleep(TimeBetweenTests);
         }
         
     }

     [TearDown]
     public void TearDown()
     {
     //Closing driver instance
         Driver().Quit();
         Driver().Dispose();
     }
}

