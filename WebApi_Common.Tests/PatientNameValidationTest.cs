using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using WebApi_Common.Validation;

namespace WebApi_Common.Models.Tests
{
    [TestClass]
    public class PatientNameValidationTest : PatientNameValidation
    {
        [DataRow("The Doctor")]
        [DataRow("Teszt Elek")]
        [DataRow("Sherlock Holmes")]
        [DataRow("Satoshi Nakamoto")]
        [DataRow("Okabe Rintaro")]
        [DataRow("Jugemu Jugemu Furaimatsu Chosuke")]
        [DataTestMethod]
        public void IsValid_WithValidArgument_NoErrorShown(string name)
        {
            var validationContext = new ValidationContext(name);
            var attribute = new PatientNameValidation();

            var validationResult = attribute.GetValidationResult(name, validationContext);

            Assert.AreEqual(ValidationResult.Success,validationResult);
        }



        [DataRow("")]
        [DataRow("      ")]
        [DataRow("\t\t\t")]
        [DataRow("\n\n\n")]
        [DataRow("\n\t")]
        [DataRow("\r\r\r")]
        [DataRow("\v\v\v")]
        [DataTestMethod]
        public void IsValid_WithWhiteSpaceOrNullInput_ErrorMessageShown(string name)
        {
            var validationContext = new ValidationContext(name);
            var attribute = new PatientNameValidation();
            var expected = "A név mező kitöltése kötelező!";

            var validationResult = attribute.GetValidationResult(name, validationContext);

            Assert.AreEqual(expected,validationResult.ErrorMessage);
        }

        [DataRow("();.-/*ß¤Ł`")]
        [DataRow(":@Đ[ł|˛^~˘%*_")]
        [DataRow("\\,&#>˝{}u$+")]
        [DataRow("?¬°µ†š")]
        [DataRow("¥ƒœ£¢™")]
        [DataRow("×!¶¤¼ÇÏ")]
        [DataRow("ØÝþ=¸\"")]
        [DataTestMethod]
        public void IsValid_WithNonAlphabeticCharacters_ErrorMessageShown(string name)
        {
            var validationContext = new ValidationContext(name);
            var attribute = new PatientNameValidation();
            var expected = "A név mező csak alfabetikus karaktereket tartalmazhat!";

            var validationResult = attribute.GetValidationResult(name, validationContext);

            Assert.AreEqual(expected, validationResult.ErrorMessage);
        }
    }
}