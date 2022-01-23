using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{type}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string type, string firstNumber, string secondNumber)
        {
            switch (type)
            {
                case "sum":
                    return SumNumbers(firstNumber, secondNumber);
                case "sub":
                    return SubNumbers(firstNumber, secondNumber);
                case "mult":
                    return MultNumbers(firstNumber, secondNumber);
                case "div":
                    return DivNumbers(firstNumber, secondNumber);
                case "mean":
                    return MeanNumbers(firstNumber, secondNumber);
                default: return BadRequest("Invalid type2");
            }
        }

        private IActionResult SumNumbers(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private IActionResult SubNumbers(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private IActionResult MultNumbers(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private IActionResult DivNumbers(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private IActionResult MeanNumbers(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult SquareNumbers(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var square = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(square.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}