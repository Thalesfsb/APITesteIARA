using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjetoTesteIara.Controllers;
using ProjetoTesteIara.Domain.Entities;
using ProjetoTesteIara.Domain.Interfaces.Repositories;
using ProjetoTesteIara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteIara.UnitTest.WebApi.Controllers
{
    [TestClass]
    public class CotacaoControllerTest
    {
        Mock<ICotacaoRepository> mockCotacaoRepository;
        IMapper _mapper;

        [TestInitialize]
        public void Inicializar()
        {
            mockCotacaoRepository = new Mock<ICotacaoRepository>();

            MapperConfiguration mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CotacaoModel, CotacaoEntity>();
                config.CreateMap<CotacaoItemModel, CotacaoItemEntity>();
                config.CreateMap<CotacaoEntity, CotacaoModel>();
                config.CreateMap<CotacaoItemEntity, CotacaoItemModel>();
                config.CreateMap<CotacaoModel2, CotacaoEntity>();
                config.CreateMap<CotacaoItemModel2, CotacaoItemEntity>();
            });

            _mapper = mapper.CreateMapper();
        }

        [TestMethod]
        public void SelectAllComSucessoTest()
        {

            IList<CotacaoEntity> cotacaoEntities = new List<CotacaoEntity>();

            cotacaoEntities.Add(new CotacaoEntity
            {
                Bairro = "Vila Clementino"
            });

            mockCotacaoRepository.Setup(x => x.SelectAll()).Returns(Task.FromResult(cotacaoEntities));

            CotacaoController cotacaoController = new CotacaoController(_mapper, mockCotacaoRepository.Object);
            var cotController = cotacaoController.SelectAll().Result;

            var test = cotController as OkObjectResult;
            var test1 = test.Value as List<CotacaoModel>;

            Assert.IsNotNull(test1);

            Assert.AreEqual("Vila Clementino", test1[0].Bairro);
        }

        [TestMethod]
        public void SelectAllComErroTest()
        {
            IList<CotacaoEntity> cotacaoEntities = new List<CotacaoEntity>();
            
            mockCotacaoRepository.Setup(x => x.SelectAll()).Returns(Task.FromResult(cotacaoEntities));

            CotacaoController cotacaoController = new CotacaoController(_mapper, mockCotacaoRepository.Object);
            var cotController = cotacaoController.SelectAll().Result;

            var test = cotController as StatusCodeResult;

            Assert.IsNotNull(test);
            Assert.AreEqual(404, test.StatusCode);
        }
    }
}
