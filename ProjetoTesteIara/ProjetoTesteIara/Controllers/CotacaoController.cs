using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IMapper _mapper;

        public CotacaoController(IMapper mapper, ICotacaoItemRepository cotacaoItemRepository, ICotacaoRepository cotacaoRepository)
        {
            _mapper = mapper;
            _cotacaoItemRepository = cotacaoItemRepository;
            _cotacaoRepository = cotacaoRepository;
        }
        // GET: Cotacao/Details/5
        //public ActionResult Details(int id)
        //{
        //}

        //// GET: Cotacao/Create
        //public ActionResult Create()
        //{
        //}

        // POST: Cotacao/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CotacaoModel cotacaoModel)
        {
            try
            {
                CotacaoEntity cotacaoEntity = new CotacaoEntity();

                _mapper.Map(cotacaoModel, cotacaoEntity);

               return Ok(await _cotacaoRepository.Insert(cotacaoEntity));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: Cotacao/Edit/5
        //public ActionResult Edit(int id)
        //{
        //}

        //// POST: Cotacao/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Cotacao/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Cotacao/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
