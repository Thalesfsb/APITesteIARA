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
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        private readonly IMapper _mapper;
        private CotacaoItemEntity cotacaoItemEntity = null;
        private List<CotacaoItemEntity> cotacaoItemEntities = null;

        public CotacaoItemController(IMapper mapper, ICotacaoItemRepository cotacaoItemRepository)
        {
            _mapper = mapper;
            _cotacaoItemRepository = cotacaoItemRepository;
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
        public async Task<IActionResult> Create(CotacaoItemModel cotacaoItemModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (cotacaoItemModel.NumeroCotacao == 0)
                    return BadRequest();

                cotacaoItemEntity = new CotacaoItemEntity();

                return Ok(await _cotacaoItemRepository.Insert(_mapper.Map(cotacaoItemModel, cotacaoItemEntity)));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CotacaoItemUpdModel cotacaoItemUpdModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (cotacaoItemUpdModel.NumeroCotacaoItem == 0)
                    return BadRequest();

                var cotacaoEntity = await _cotacaoItemRepository.Select(cotacaoItemUpdModel.NumeroCotacaoItem);

                if (cotacaoEntity == null)
                    return StatusCode(404);

                _mapper.Map(cotacaoItemUpdModel, cotacaoEntity);

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
