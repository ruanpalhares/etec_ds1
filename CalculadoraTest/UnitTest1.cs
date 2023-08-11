using Calculadora;
using System;
using Xunit;

namespace CalculadoraTest
{
    public class UnitTest1
    {
        [Fact]
        public void Somar_DoisDouble_RetornarDouble()
        {
            //Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var valorEsperado = 6;

            //Act
            var soma = Calculo.Somar(num1, num2);

            //Assert
            Assert.Equal(valorEsperado, soma);
        }

        [Fact(Skip ="Teste ainda não disponivel")]
        public void Teste2()
        {

        }
    }
}
