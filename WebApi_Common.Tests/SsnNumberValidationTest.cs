using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using WebApi_Common.Validation;

namespace WebApi_Common.Tests
{
    [TestClass]
    public class SsnNumberValidationTest: SsnNumberValidation
    {
        [DataRow("967 529 159")]
        [DataRow("604 506 936")]
        [DataRow("369 798 114")]
        [DataRow("096 234 716")]
        [DataRow("798 035 402")]
        [DataRow("481 422 992")]
        [DataTestMethod]
        public void IsValid_WithValidArgument_NoErrorShown(string ssnNumber)
        {
            var validationContext = new ValidationContext(ssnNumber);
            var attribute = new SsnNumberValidation();

            var validationResult = attribute.GetValidationResult(ssnNumber, validationContext);

            Assert.AreEqual(ValidationResult.Success, validationResult);
        }


        [DataRow("724524867")]
        [DataRow("47 2615 853")]
        [DataRow("fdggghfdhdg")]
        [DataRow("5f6e 4h9e 45e")]
        [DataRow("           ")]
        [DataRow("4f2 á9z gg4")]
        [DataRow("491 111 125 456")]
        [DataRow("491 fff 456")]
        [DataRow("hjdu piwqs zdfki")]
        [DataRow("\t\t\t\t\t\t")]
        [DataTestMethod]
        public void IsValid_WithInValidArgument_ErrorMessageShown(string ssnNumber)
        {
            var validationContext = new ValidationContext(ssnNumber);
            var attribute = new SsnNumberValidation();
            var expected = "A TAJ szám formátuma nem megfelelő!";

            var validationResult = attribute.GetValidationResult(ssnNumber, validationContext);

            Assert.AreEqual(expected, validationResult.ErrorMessage);
        }
    }
}
