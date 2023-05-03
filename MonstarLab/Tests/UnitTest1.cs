using System.Net;
using MonstarLab.Pages;
using NUnit.Framework;

namespace MonstarLab.Tests;

public class Tests
{ 
    private const int ModalItemCount = 15;
    

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
        
         
     }
    
     [OneTimeTearDown]
     public void TearDown()
     {
         // Pause for 5 seconds in-between tests (error 1015 too many requests, provided by Cloudflare on mall.cz
         Thread.Sleep(30000);
     }
}

