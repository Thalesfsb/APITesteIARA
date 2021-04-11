using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
        private CotacaoEntity cotacaoEntity = null;
        private List<CotacaoEntity> cotacaoEntities = null;
        public CotacaoController(IMapper mapper, ICotacaoItemRepository cotacaoItemRepository, ICotacaoRepository cotacaoRepository)
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
                List<CotacaoModel> cotacaoModel = new List<CotacaoModel>();
                cotacaoEntities = new List<CotacaoEntity>();
                cotacaoEntities = (List<CotacaoEntity>)await _cotacaoRepository.SelectAll();

                if (cotacaoEntities != null)
                    return Ok(_mapper.Map<List<CotacaoModel>>(cotacaoEntities));
                else
                    return StatusCode(400);
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
                cotacaoEntity = new CotacaoEntity();
                cotacaoEntity = await _cotacaoRepository.Select(id);

                if (cotacaoEntity != null)
                    return Ok(_mapper.Map<CotacaoModel>(cotacaoEntity));
                else
                    return StatusCode(400);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CotacaoModel cotacaoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                cotacaoEntity = new CotacaoEntity();

                if (cotacaoModel.Logradouro == "" && cotacaoModel.Bairro == "" && cotacaoModel.UF == "")
                {
                    ViaCepResponseModel viaCepResponse = new ViaCepResponseModel();
                    ViaCepResponseModel endereco = await viaCepResponse.ViaCepResponse(cotacaoModel.CEP);

                    if (endereco == null)
                        return StatusCode(404);

                    cotacaoModel.Logradouro = endereco.Logradouro;
                    cotacaoModel.Bairro = endereco.Bairro;
                    cotacaoModel.UF = endereco.Uf;
                }

                _mapper.Map(cotacaoModel, cotacaoEntity);

                return Ok(await _cotacaoRepository.Insert(cotacaoEntity));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CotacaoUpdateModel cotacaoUpdateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var cotacaoEntity = await _cotacaoRepository.Select(cotacaoUpdateModel.NumeroCotacao);

                if (cotacaoEntity == null)
                    return StatusCode(404);

                _mapper.Map(cotacaoUpdateModel, cotacaoEntity);
                return Ok(await _cotacaoRepository.Update(cotacaoEntity));
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

                if (await _cotacaoRepository.Delete(id))
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
