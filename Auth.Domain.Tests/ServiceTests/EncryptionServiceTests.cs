using Auth.Domain.Infra.Services;
using Auth.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auth.Domain.Tests.ServiceTests
{
    [TestClass]
    public class EncryptionServiceTests
    {
        private IEncryptionService _service;
        public EncryptionServiceTests()
        {
            _service = new EncryptionService();
        }

        [TestMethod]
        public void Deve_retornanr_ola()
        {
            var esconder = _service.Encrypt("Olá");
            var mostrar = _service.Decrypt(esconder);

            Assert.AreEqual("Olá", mostrar);
        }

        [TestMethod]
        public void Deve_retornanr_4b968DEA()
        {
            var esconder = _service.Encrypt("4b968DEA");
            var mostrar = _service.Decrypt(esconder);

            Assert.AreEqual("4b968DEA", mostrar);
        }

    }
}
