using Microsoft.AspNetCore.Mvc;
using PersonReader.Factory;
using PersonReader.Interface;
//using PersonReader.CSV;
//using PersonReader.Service;
//using PersonReader.SQL;

namespace PeopleViewer.Controllers
{
    public class PersonsController : Controller
    {
        private ReaderFactory factory = new ReaderFactory();

        IConfiguration Configuration;

        //IConfiguration item is filled in for us automatically by DependencyInjection container
        public PersonsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult UseConfiguredReader()
        {
            string readerType = Configuration["PersonReaderType"];
            ViewData["Title"] = "Using Configured Reader";
            return PopulatePeopleView(readerType);
        }

        public IActionResult UseService()
        {
            ViewData["Title"] = "Using a Web Service";
            //IPersonReader reader = new ServiceReader();
            //return PopulatePeopleView(reader);
            //or 
            return PopulatePeopleView("Service");
        }

        public IActionResult UseCSV()
        {
            ViewData["Title"] = "Using a CSV File";
            //IPersonReader reader = new CSVReader();
            //return PopulatePeopleView(reader);
            //or
            return PopulatePeopleView("CSV");
        }

        public IActionResult UseSQL()
        {
            //TO DO data in Database
            ViewData["Title"] = "Using a SQL Database";
            //IPersonReader reader = new SQLReader();
            //return PopulatePeopleView(reader);
            //or
            return PopulatePeopleView("SQL");

        }

        private IActionResult PopulatePeopleView(string readerType)
        {
            IPersonReader reader = factory.GetReader(readerType);
            IEnumerable<Person> people = reader.GetPeople();

            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", people);
        }

        //Before adding Factory
        //public IActionResult UseService()
        //{
        //    ViewData["Title"] = "Using a Web Service";
        //    //IPersonReader reader = new ServiceReader();
        //    //return PopulatePeopleView(reader);
        //    //or 
        //    return PopulatePeopleView(new ServiceReader());
        //}

        //Before Factory
        //private IActionResult PopulatePeopleView(IPersonReader reader)
        //{
        //    IEnumerable<Person> people = reader.GetPeople();

        //    ViewData["ReaderType"] = reader.GetType().ToString();
        //    return View("Index", people);
        //}


    }
}
