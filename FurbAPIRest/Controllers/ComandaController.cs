using FurbAPIRest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurbAPIRest.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    public class ComandaController : Controller
    {
        private ComandaService _comandaService { get; set; }

        public ComandaController(ComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet("Comandas")]
        public ActionResult Comandas()
        {
            var teste = _comandaService.GetComandas();
            return Ok(teste);
        }

        [HttpGet("Comanda/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComandaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComandaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComandaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComandaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComandaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComandaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
