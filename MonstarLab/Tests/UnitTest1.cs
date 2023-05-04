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
    public static class Driver
    {
        //Setting an instance of the ChromeDriver
        public static ChromeDriver driver { get; internal set; }
    }
    [SetUp]
    public static void SetUp()
    {
        //Check that driver is not set up alreay
        if (Driver.driver == null)
        {
            //Adding some options
            var options = new ChromeOptions();
            options.AddArguments("--headless", "-window-size=1920,1080");
            Driver.driver = new ChromeDriver(options);
            
            //Going to the landing page
            Driver.driver.Navigate().GoToUrl(LandingUrl);
            
            //Ensuring that al carousels are loaded
            IJavaScriptExecutor js = Driver.driver;
            js.ExecuteScript("window.scrollBy(0, 10000);");
            Thread.Sleep(1000);
        }
        //Initialising a method to save all carousels into carousels list
        LandingPage.carousels = LandingPage.Carousels();

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
      public void CarouselCleaningIsUniqueCheck()
      { 
          //Calling the method
          var uniqueCheck = LandingPage.CarouselCleaningIsUnique();
           
          //Assertion
          Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
      }

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
      public void CarouselFavCategoryIsUniqueCheck()
      {
          //Calling the method
          var uniqueCheck = LandingPage.CarouselFavCategoriesIsUnique();
           
          //Assertion
          Assert.That(uniqueCheck, Is.True, "There were repetitions in the list"); //check console for the list
      }

    [OneTimeTearDown]
     public void TearDown()
     {
        Driver.driver.Quit();
        Driver.driver.Dispose();
     }
}

