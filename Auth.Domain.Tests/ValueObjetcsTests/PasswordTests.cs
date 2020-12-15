using Auth.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auth.Domain.Tests.ValueObjetcsTests
{
    [TestClass]
    public class PasswordTests
    {

        private readonly Password _validPass;
        private readonly Password _invalidPass1;
        private readonly Password _invalidPass2;
        private readonly Password _invalidPass3;
        private readonly Password _invalidPass4;

        public PasswordTests()
        {
            _validPass = new Password("Let!230716");
            _invalidPass1 = new Password("let!230716");
            _invalidPass2 = new Password("Let230716");
            _invalidPass3 = new Password("Let!lete");
            _invalidPass4 = new Password("LET!230716");
        }


        [TestMethod]
        public void Deve_retornar_false_dado_senha_invalida_sem_maiuscula()
        {
            Assert.IsFalse(_invalidPass1.Valid);
        }
        [TestMethod]
        public void Deve_retornar_false_dado_senha_invalida_sem_especial()
        {
            Assert.IsFalse(_invalidPass2.Valid);
        }
        [TestMethod]
        public void Deve_retornar_false_dado_senha_invalida_sem_numero()
        {
            Assert.IsFalse(_invalidPass3.Valid);
        }
        [TestMethod]
        public void Deve_retornar_false_dado_senha_invalida_sem_minuscula()
        {
            Assert.IsFalse(_invalidPass4.Valid);
        }
        [TestMethod]
        public void Deve_retornar_true_dado_senha_invalida()
        {
            Assert.IsTrue(_validPass.Valid);
        }
    }
}
