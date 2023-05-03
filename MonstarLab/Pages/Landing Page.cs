using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using static MonstarLab.Extensions.WebDriverExtensions;


namespace MonstarLab.Pages;

public class LandingPage
{
    private readonly HttpClient _httpClient;
    private const string CarouselAkce = "//*[@id=\"main-content\"]/div/div[1]/div/div/div[2]/ul";

    private const string CarouselFurniture =
        "//*[@id=\"main-content\"]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselKidsToys =
        "//*[@id=\"main-content\"]/div/div[2]/div[2]/div/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselTV =
        "//*[@id=\"main-content\"]/div/div[2]/div[4]/div/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselFreeDelivery =
        "//*[@id=\"main-content\"]/div/div[2]/div[6]/div/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselTools =
        "//*[@id=\"main-content\"]/div/div[2]/div[7]/div/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselCleaning =
        "//*[@id=\"main-content\"]/div/div[2]/div[9]/div/div/div/div/div/div[2]/div/section/div/ul";

    private const string CarouselFavCategories = "//*[@id=\"main-content\"]/div/div[2]/div[13]/div/div/ul";


    public static List<IWebElement> Carousels()
    {
        List<string> carouselXpaths = new List<string>{CarouselAkce, CarouselFurniture, CarouselKidsToys, CarouselTV, CarouselFreeDelivery, CarouselTools, CarouselCleaning, CarouselFavCategories};

        List<IWebElement> carousels = new List<IWebElement>();
        foreach (var elements in carouselXpaths.Select(xpath => Tests.Tests.Driver().FindElements(By.XPath(xpath))))
        {
            carousels.AddRange(elements);
        }

        return carousels;

    }
    
    public LandingPage()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
        
    }
    public HttpStatusCode GetStatusCode()
    {
    
        var response = _httpClient.GetAsync(Tests.Tests.LandingUrl).Result;
        return response.StatusCode;
    }

    public static int CarouselAkceItemCount()
    {
        //Using the same driver instance
       // var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
      //  var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[1]/div/div/div[2]/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
     //   Debug.Assert(carousel != null, nameof(carousel) + " != null");
        var carouselAkce = Carousels()[0];
        List<IWebElement> carouselItems = carouselAkce.FindElements(By.CssSelector("li")).ToList();
        
        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }
    
    public static bool CarouselAkceIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href"))
            .ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);

        return isUnique;
    }

    public static int CarouselFurnitureItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/section/div/ul"), 10, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }

    public static bool CarouselFurnitureIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);

        return isUnique;
    }
   
    public static int CarouselKidsToysItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[2]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }

    public static bool CarouselKidsToysIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
      // var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
      //  screenshot.SaveAsFile(@"C:\Users\folkus\Pictures\Rider\screenshot.png");
        
        //Saving the carousel as an IWebElement
        
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[2]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);
        
        return isUnique;
    }
    
    public static int CarouselTVItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[4]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }

    public static bool CarouselTVIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[4]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);
        
        return isUnique;
    }
    
    public static int CarouselFreeDeliveryItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[6]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }

    public static bool CarouselFreeDeliveryIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[6]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);

        return isUnique;
    }
    
    public static int CarouselToolsItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[7]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }

    public static bool CarouselToolsIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[7]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);

        return isUnique;
    }
    
    public static int CarouselCleaningItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[9]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }

    public static bool CarouselCleaningIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[9]/div/div/div/div/div/div[2]/div/section/div/ul"),5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);

        return isUnique;
    }
    
    public static int CarouselFavCategoriesItemCount()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[13]/div/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }
    
    public static bool CarouselFavCategoriesIsUnique()
    {
        //Using the same driver instance
        var driver = Tests.Tests.Driver();

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[13]/div/div/ul"),5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);
        
        return isUnique;
    }
}


