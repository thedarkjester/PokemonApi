using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Pokemon.ApiModels;
using Pokemon.Controllers;
using Pokemon.Domain.Models;
using Pokemon.Domain.Services;
using System.Net;
using System.Threading.Tasks;

namespace Pokemon.Tests.Unit.Controllers
{
    public class PokemonControllerTests
    {
        private PokemonController _controller;
        private Mock<IPokemonLookupProcessor> _mockLookupProcessor;

        public PokemonControllerTests()
        {
            _mockLookupProcessor = new Mock<IPokemonLookupProcessor>();
        }

        [SetUp]
        public void Setup()
        {
            _controller = new PokemonController(_mockLookupProcessor.Object);
        }

    }
}