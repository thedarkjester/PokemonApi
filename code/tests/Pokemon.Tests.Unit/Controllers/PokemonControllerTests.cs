using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Pokemon.ApiModels;
using Pokemon.Controllers;
using Pokemon.Domain.Services;

namespace Pokemon.Tests.Unit.Controllers
{
    public class PokemonControllerTests
    {
        private PokemonController _controller;
        private readonly Mock<IPokemonLookupProcessor> _mockLookupProcessor;

        public PokemonControllerTests()
        {
            _mockLookupProcessor = new Mock<IPokemonLookupProcessor>();
        }

        [SetUp]
        public void Setup()
        {
            _controller = new PokemonController(_mockLookupProcessor.Object);
        }

        //this would run through all the functions mocked, catching edge cases etc.
    }
}