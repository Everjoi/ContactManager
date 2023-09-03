using ContactManager.Models;
using ContactManager.Repository.Implementation;
using ContactManager.Repository.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace ContactManager.Controllers
{
    public class PersonController:Controller
    {
        private IPersonRepository _repository; // TODO: create Services, and use this one insted of Repository

        public PersonController()
        {
            _repository = new PersonRepository();     
        }


        [HttpGet]
        public IActionResult Upload()
        {
            return View("/Views/Home/Index.cshtml");          
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile csvFile)
        {
            if(csvFile == null || csvFile.Length == 0)
            {
                ModelState.AddModelError("FileError","Файл відсутній або має нульовий розмір.");
                return View();
            }

            var extension = Path.GetExtension(csvFile.FileName);
            if(extension != ".csv")
            {
                ModelState.AddModelError("FileError","Необхідно завантажити файл формату CSV.");
                return View();
            }

            var persons = new List<Person>();
            using(var reader = new StreamReader(csvFile.OpenReadStream()))
            using(var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                persons =  csv.GetRecords<Person>().ToList();
            }


            if(await _repository.CreatePerson(persons,default))
                return RedirectToAction("Upload");

            return View("/Views/Home/Index.cshtml"); // TODO: add error view 

        }
        

        public IActionResult WorkWithData()
        {
            return View("/Views/Data/DataWork.cshtml",_repository.GetPersons());
        }


        public IActionResult Edit(int personId)
        {
            _repository.UpdatePerson(personId);

            return View("WorkWithData");
        }


        public IActionResult Delete(int personId)
        {
            _repository.DeletePerson(personId);
            return RedirectToAction("WorkWithData");
        }

    }
}
