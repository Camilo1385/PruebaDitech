using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesarrollo.Models;
using Microsoft.Extensions.Logging;

namespace PruebaDesarrollo.Controllers
{
    public class SellersController : Controller
    {
        private readonly PruebasContext conexion;

        public SellersController(PruebasContext dbContext)
        {
            conexion = dbContext;
        }

        [HttpGet]
        public IActionResult Sellers(int id)
        {
            var sellers = conexion.Sellers.ToList();
            var x = sellers.Where(item => item.CityId == id).ToList();
            return View("Sellers", x);
        }

        [HttpGet]
        public IActionResult CreateSellers(int id)
        {
            var seller = conexion.Cities.Find(id);
            var sellers = new Seller();
            ViewBag.Code = seller.Description;
            ViewBag.Id = seller.Code;
            return View("CreateSellers", sellers);
        }

        [HttpPost]
        public IActionResult CreateSellers([FromBody] Seller seller)
        {
            Seller newSeller = new Seller
            {
                Document = seller.Document,
                Name = seller.Name,
                LastName = seller.LastName,
                CityId = seller.CityId,
            };

            conexion.Sellers.Add(newSeller);
            conexion.SaveChanges();
            return Ok(newSeller);
        }

        [HttpGet]
        public IActionResult UpdateSeller(int id)
        {
            var seller = conexion.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }
            ViewBag.code = seller.Code;
            ViewBag.Nombre = seller.Name;
            ViewBag.SegundoNombre = seller.LastName;
            return View("UpdateSeller", seller);
        }

        [HttpPost]
        //public IActionResult Update([FromBody] int id, [FromBody] City city)
        public IActionResult Update([FromBody] Seller seller)
        {
            var existingSeller = conexion.Sellers.Find(seller.Code);
            if (existingSeller == null)
            {
                return NotFound();
            }

            existingSeller.Name = seller.Name;
            existingSeller.LastName = seller.LastName;
            conexion.Sellers.Update(existingSeller);
            conexion.SaveChanges();
            return Ok(existingSeller);
        }

        [HttpGet]
        public IActionResult DeleteSeller(int id)
        {
            var seller = conexion.Sellers.Find(id);
            if (seller == null)
            {
                return NotFound();
            }
            ViewBag.Nombre = seller.Name;
            ViewBag.Apellido = seller.LastName;
            ViewBag.code = seller.Code;
            return View("DeleteSeller", seller);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Seller seller)
        {
            var sellerDelete = conexion.Sellers.Find(seller.Code);
            if (sellerDelete == null)
            {
                return NotFound();
            }

            conexion.Sellers.Remove(sellerDelete);
            conexion.SaveChanges();
            return Ok(sellerDelete);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
