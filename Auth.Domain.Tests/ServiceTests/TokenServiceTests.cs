using Auth.Domain.Entities;
using Auth.Domain.Infra.Services;
using Auth.Domain.Services;
using Auth.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Tests.ServiceTests
{
    [TestClass]
    public class TokenServiceTests
    {

        private readonly ITokenService _service;
        private readonly User _validUser;

        public TokenServiceTests()
        {
            _service = new TokenService();
            _validUser = new User(
                new Name("Yan", "Santos"),
                new Email("yanbrunosilvasantos@gmail.com"),
                new Password("12345678")
                );

        }


        [TestMethod]
        public void Deve_retornar_token()
        {
            var result = _service.GenerateToken(_validUser);
            Assert.IsNotNull(result);
        }


    }
}
