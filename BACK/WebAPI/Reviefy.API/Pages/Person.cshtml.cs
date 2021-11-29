using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reviefy.API.Entities;

namespace Reviefy.API.Pages
{
    public class PersonModel : PageModel
    {
        // public string Message { get; set; }
        //
        // [BindProperty(SupportsGet=true)]
        // public Person Person { get; set; }
        //
        // [BindProperty(SupportsGet = true)]
        // public int Id { get; set; }
        // [BindProperty(SupportsGet = true)]
        // public string Name { get; set; }
        //
        // [BindProperty(SupportsGet = true)]
        // public int Age { get; set; }

        // public void OnGet(int id)
        // {
        //     Message = "Введите данные";
        // }
        //
        // public void OnPost()
        // {
        //    Message = $"Имя: {Person.Name}  Возраст: {Person.Age}";
        //    // Message = $"Имя: {Name}  Возраст: {Age}";
        // }



        // List<Person> people;
        // public List<Person> DisplayedPeople { get; set; }
        //
        // public PersonModel()
        // {
        //     people = new List<Person>()
        //     {
        //         new Person {Id = 1, Name = "Tom", Age = 23},
        //         new Person {Id = 2, Name = "Sam", Age = 25},
        //         new Person {Id = 3, Name = "Bob", Age = 23},
        //         new Person {Id = 4, Name = "Tom", Age = 25},
        //         new Person {Id = 5, Name = "Alex", Age = 43},
        //         new Person {Id = 6, Name = "Ford", Age = 12},
        //         new Person {Id = 7, Name = "John", Age = 18},
        //         new Person {Id = 8, Name = "Jon", Age = 29},
        //         new Person {Id = 9, Name = "Jimmy", Age = 15},
        //         new Person {Id = 10, Name = "Kurt", Age = 27}
        //     };
        // }
        //
        // public void OnGet()
        // {
        //     DisplayedPeople = people;
        // }
        //
        // public void OnGetByName(string name)
        // {
        //     DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        // }
        //
        // public void OnGetByAge(int age)
        // {
        //     DisplayedPeople = people.Where(p => p.Age == age).ToList();
        // }
        //
        // public void OnGetSortByAge()
        // {
        //     DisplayedPeople = people.OrderBy(p => p.Age).ToList();
        // }
        //
        // public void OnPostGreaterThan(int age)
        // {
        //     DisplayedPeople = people.Where(p => p.Age > age).ToList();
        // }
        // public void OnPostLessThan(int age)
        // {
        //     DisplayedPeople = people.Where(p => p.Age < age).ToList();
        // }


        public List<Person> people;
        public Person Person { get; set; }

        public PersonModel()
        {
            // people = new List<Person>
            // {
            //     new() {Name = "Tom", Age = 23},
            //     new() {Name = "Sam", Age = 25},
            //     new() {Name = "Bob", Age = 23},
            //     new() {Name = "Tim", Age = 25}
            // };
        }

        public IActionResult OnGet(string name)
        {
            // Person = people.FirstOrDefault(p => p.Name == name);
            // if (Person == null)
            //     return NotFound("Такого пользователя не существует");

            return Page();
        }
        
        public IActionResult OnPost(int id, string name, int age)
        {
            // people.Add(new Person {Id = id, Name = name, Age = age});
            //
            // Person = people.FirstOrDefault(p => p.Name == name);
            // if (name is null)
            //     return NotFound("Ошибка ввода");
            //
             return Page();
        }
    }
}