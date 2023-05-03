using System.Diagnostics;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static MonstarLab.Extensions.WebDriverExtensions;


namespace MonstarLab.Pages;

public class LandingPage
{
    private const string LandingUrl = "https://www.mall.cz/";
    private readonly HttpClient _httpClient;

    public LandingPage()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");
    }

    public HttpStatusCode GetStatusCode()
    {
    
        var response = _httpClient.GetAsync(LandingUrl).Result;
        return response.StatusCode;
    }

    public static int CarouselAkceItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[1]/div/div/div[2]/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.CssSelector("li")).ToList();
        
        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }
    
    public static bool CarouselAkceIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }

    public static int CarouselFurnitureItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");

        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
     
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/section/div/ul"), 10, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }

    public static bool CarouselFurnitureIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
   
    public static int CarouselKidsToysItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[2]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        
        return carouselItemCount;

    }

    public static bool CarouselKidsToysIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
    
    public static int CarouselTVItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[4]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }

    public static bool CarouselTVIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
    
    public static int CarouselFreeDeliveryItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[6]/div/div/div/div/div/div[2]/div/section/div/ul"),5,true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }

    public static bool CarouselFreeDeliveryIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
    
    public static int CarouselToolsItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");  
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[7]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }

    public static bool CarouselToolsIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
    
    public static int CarouselCleaningItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[9]/div/div/div/div/div/div[2]/div/section/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }

    public static bool CarouselCleaningIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
    
    public static int CarouselFavCategoriesItemCount()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
        //Saving the carousel as an IWebElement
        var carousel = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[2]/div[13]/div/div/ul"), 5, true);
        
        //Saving all <li> elements into the carouselItems list 
        Debug.Assert(carousel != null, nameof(carousel) + " != null");
        List<IWebElement> carouselItems = carousel.FindElements(By.XPath("li")).ToList();

        //Counting them
        var carouselItemCount = carouselItems.Count;
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return carouselItemCount;

    }
    
    public static bool CarouselFavCategoriesIsUnique()
    {
        //Setting up Chrome Driver
        var chromeOptions = new ChromeOptions();
        
        // --headless allows to run faster and more convenient. Window size specs needed so the website work correctly 
        // in headless mode
        chromeOptions.AddArguments("--headless", "-window-size=1920,1080");
        
        var driver = new ChromeDriver(chromeOptions);
        
        //Going to URL
        driver.Navigate().GoToUrl(LandingUrl);
        
        //Scrolling down the page to load bottom carousels
        IJavaScriptExecutor js = driver;
        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        
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
        
        //Closing driver instance for resource management
        driver.Quit();
        driver.Dispose();
        return isUnique;
    }
}


