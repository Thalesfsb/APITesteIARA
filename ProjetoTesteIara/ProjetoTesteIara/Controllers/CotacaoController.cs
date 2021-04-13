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
        #region Global Variaveis

        private readonly ICotacaoRepository _cotacaoRepository;
        private readonly IMapper _mapper;
        private IList<CotacaoEntity> cotacaoEntity = null;
        private IList<CotacaoEntity> cotacaoEntities = null;

        #endregion

        public CotacaoController(IMapper mapper, ICotacaoRepository cotacaoRepository)
        {
            _mapper = mapper;
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

                if (cotacaoEntities == null || cotacaoEntities.Count == 0)
                    return StatusCode(404);
                else
                    return Ok(_mapper.Map<List<CotacaoModel>>(cotacaoEntities));
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
                IList<CotacaoModel> cotacaoModel = new List<CotacaoModel>();
                cotacaoEntity = new List<CotacaoEntity>();
                cotacaoEntity = await _cotacaoRepository.Select(id);

                if (cotacaoEntity == null)
                    return StatusCode(404);
                else
                    return Ok(_mapper.Map(cotacaoEntity, cotacaoModel));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] List<CotacaoModel> cotacaoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                cotacaoEntity = new List<CotacaoEntity>();

                foreach (var item in cotacaoModel)
                {
                    if (item.Logradouro == "" && item.Bairro == "" && item.UF == "")
                    {
                        ViaCepResponseModel viaCepResponse = new ViaCepResponseModel();
                        ViaCepResponseModel endereco = await viaCepResponse.ViaCepResponse(item.CEP);

                        if (endereco == null)
                            return StatusCode(404);

                        item.Logradouro = endereco.Logradouro;
                        item.Bairro = endereco.Bairro;
                        item.UF = endereco.Uf;
                    }
                }

                return Ok(await _cotacaoRepository.Insert(_mapper.Map(cotacaoModel, cotacaoEntity)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CotacaoModel2 cotacaoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (cotacaoModel.NumeroCotacao == 0)
                    return BadRequest();

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

                var cotacaoEntity = await _cotacaoRepository.SelectCotacao(cotacaoModel.NumeroCotacao);

                if (cotacaoEntity == null)
                    return StatusCode(404);

                _mapper.Map(cotacaoModel, cotacaoEntity);

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
