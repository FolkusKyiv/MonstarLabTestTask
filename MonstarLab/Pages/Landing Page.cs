using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static MonstarLab.Tests.Tests;

namespace MonstarLab.Pages;

public class LandingPage
{
    //Initiate httpClient
    private readonly HttpClient _httpClient;
    
    //Saving locators  for caroules
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
        
    //Setting Up usages of carousels
    public static List<IWebElement> carousels { get; set; }
    
    //Method of saving all elements in carousels list
    public static List<IWebElement> Carousels()
    {
        //Saving all xpaths to carousels in to the list
        List<string> carouselXpaths = new List<string>{CarouselAkce, CarouselFurniture, CarouselKidsToys, CarouselTV, CarouselFreeDelivery, CarouselTools, CarouselCleaning, CarouselFavCategories};

        //Saving all carousels (webelements) into one  master list @carousels@
        var carousels = new List<IWebElement>();
        
        //add it one by one
        foreach (string xpath in carouselXpaths)
        {
            //A small thing to ensure the the elements are present
            var webDriverWait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(5));
            webDriverWait.Until(driver => Driver.driver.FindElement(By.XPath(xpath)).Displayed);
            
            //Use var element to hold single carousel
            IWebElement element = Driver.driver.FindElement(By.XPath(xpath));
            
            //Forming up the list
            carousels.Add(element);
        }
        
        return carousels;
    }
    public LandingPage()
    {
        //setting up httpClient
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
        
    }
    public HttpStatusCode GetStatusCode()
    {
        //Sending GET request
        var response = _httpClient.GetAsync(LandingUrl).Result;
        
        return response.StatusCode;
    }

    //Checking carousels
    public static int CarouselAkceItemCount()
    {
        //Retrieving needed carousel from a list
        var carouselAkce = carousels[0];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselAkce.FindElements(By.CssSelector("li")).ToList();
        
        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;
    }
    public static bool CarouselAkceIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselAkce = carousels[0];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselAkce.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselFurniture = carousels[1];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFurniture.FindElements(By.XPath("li")).ToList();
        
        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }
    public static bool CarouselFurnitureIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselFurniture = carousels[1];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFurniture.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselKidsToys = carousels[2];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselKidsToys.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }
    public static bool CarouselKidsToysIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselKidsToys = carousels[2];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselKidsToys.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselTV = carousels[3];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselTV.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }
    public static bool CarouselTVIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselTV = carousels[3];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselTV.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselFreeDelivery = carousels[4];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFreeDelivery.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }
    public static bool CarouselFreeDeliveryIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselFreeDelivery = carousels[4];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFreeDelivery.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselTools = carousels[5];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselTools.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }
    public static bool CarouselToolsIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselTools = carousels[5];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselTools.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselCleaning = carousels[6];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselCleaning.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        return carouselItemCount;

    }
    public static bool CarouselCleaningIsUnique()
    {
        //Retrieving needed carousel from a list

        var carouselCleaning = carousels[6];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselCleaning.FindElements(By.XPath("li")).ToList();
        
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
        //Retrieving needed carousel from a list
        var carouselFavCategories = carousels[7];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFavCategories.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;

        return carouselItemCount;

    }
    public static bool CarouselFavCategoriesIsUnique()
    {
        //Retrieving needed carousel from a list
        var carouselFavCategories = carousels[7];
        
        //Saving all <li> elements into the carouselItems list 
        List<IWebElement> carouselItems = carouselFavCategories.FindElements(By.XPath("li")).ToList();
        
        //We will differentiate between different <li> elements by comparing their links, adding them productLinks list
        var productLinks = carouselItems.Select(item => item.FindElement(By.CssSelector("a")).GetAttribute("href")).ToList();
        
        // Check that each link is unique
        var isUnique = productLinks.Count == productLinks.Distinct().Count();
        
        //Logging into the console for clarity
        productLinks.ForEach(Console.WriteLine);
        
        return isUnique;
    }

}


