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
    public class CotacaoItemController : ControllerBase
    {
        #region Global Variaveis

        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IMapper _mapper;
        private CotacaoItemEntity cotacaoItemEntity = null;
        private IList<CotacaoItemEntity> cotacaoItemEntities = null;

        #endregion

        public CotacaoItemController(IMapper mapper, ICotacaoItemRepository cotacaoItemRepository, ICotacaoRepository cotacaoRepository)
        {
            _mapper = mapper;
            _cotacaoItemRepository = cotacaoItemRepository;
            _cotacaoRepository = cotacaoRepository;
        }

        [HttpGet("SelectAll")]
        public async Task<IActionResult> SelectAll()
        {
            try
            {
                List<CotacaoItemModel> cotacaoModel = new List<CotacaoItemModel>();
                cotacaoItemEntities = new List<CotacaoItemEntity>();
                cotacaoItemEntities = (List<CotacaoItemEntity>)await _cotacaoItemRepository.SelectAll();

                if (cotacaoItemEntities == null)
                    return StatusCode(404);
                else
                    return Ok(_mapper.Map<List<CotacaoItemModel>>(cotacaoItemEntities));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("Select/{id}")]
        public async Task<IActionResult> Select(int id)
        {
            try
            {
                cotacaoItemEntity = new CotacaoItemEntity();
                cotacaoItemEntity = await _cotacaoItemRepository.Select(id);

                if (cotacaoItemEntity == null)
                    return StatusCode(404);
                else
                    return Ok(_mapper.Map<CotacaoItemModel>(cotacaoItemEntity));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CotacaoItemModel2 cotacaoItem)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (cotacaoItem.NumeroCotacao == 0)
                    return BadRequest();

                cotacaoItemEntity = new CotacaoItemEntity();

                var cotacao = await _cotacaoRepository.SelectCotacao(cotacaoItem.NumeroCotacao);

                if (cotacao == null)
                    return BadRequest();

                return Ok(await _cotacaoItemRepository.Insert(_mapper.Map(cotacaoItem, cotacaoItemEntity)));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CotacaoItemModel2 cotacaoItem)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (cotacaoItem.NumeroCotacaoItem == 0)
                    return BadRequest();

                var cotacaoEntity = await _cotacaoItemRepository.Select(cotacaoItem.NumeroCotacaoItem);

                if (cotacaoEntity == null)
                    return StatusCode(404);

                _mapper.Map(cotacaoItem, cotacaoEntity);

                return Ok(await _cotacaoItemRepository.Update(cotacaoEntity));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest();

                if (await _cotacaoItemRepository.Delete(id))
                    return Ok();
                else
                    return StatusCode(404);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
