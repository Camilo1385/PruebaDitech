using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesarrollo.Models;
using Microsoft.Extensions.Logging;


namespace PruebaDesarrollo.Controllers
{
    public class CitiesController : Controller
    {

        private readonly PruebasContext conexion;
        public CitiesController(PruebasContext dbContext)
        {
            conexion = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cities = conexion.Cities.ToList();
            return View("Cities", cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var city = new City();
            return View("Create", city); 
        }

        [HttpGet]
        public IActionResult UpdateCity(int id)
        {
            var city = conexion.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewBag.Nombre = city.Description;
            ViewBag.code = city.Code;
            return View("UpdateCity",city);
        }

        [HttpGet]
        public IActionResult DeleteCity(int id)
        {
            var city = conexion.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewBag.Nombre = city.Description;
            ViewBag.code = city.Code;
            return View("DeleteCity", city);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var city = conexion.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // POST api/city
        [HttpPost]
        public IActionResult Create([FromBody] City city)
        {
            conexion.Cities.Add(city);
            conexion.SaveChanges();
            return Ok(city);
        }

        // PUT api/city/1
        [HttpPost]
        //public IActionResult Update([FromBody] int id, [FromBody] City city)
        public IActionResult Update([FromBody] City city)
        {
            var existingCity = conexion.Cities.Find(city.Code);
            if (existingCity == null)
            {
                return NotFound();
            }

            existingCity.Description = city.Description;
            conexion.Cities.Update(existingCity);
            conexion.SaveChanges();
            return Ok(existingCity);
        }

        // DELETE api/city/1
        [HttpPost]
        public IActionResult Delete([FromBody] City city)
        {
            var cityDelete = conexion.Cities.Find(city.Code);
            if (cityDelete == null)
            {
                return NotFound();
            }

            conexion.Cities.Remove(cityDelete);
            conexion.SaveChanges();
            return Ok(cityDelete);
        }

    }
}
