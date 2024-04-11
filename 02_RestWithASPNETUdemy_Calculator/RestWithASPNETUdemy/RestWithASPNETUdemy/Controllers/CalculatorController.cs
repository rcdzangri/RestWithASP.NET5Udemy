using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("sum/{firstNumber}/{SecondNumber}")]
        public IActionResult Get(string firstNumber, string SecondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());   
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{SecondNumber}")]
        public IActionResult GetSub(string firstNumber, string SecondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var op = ConvertToDecimal(firstNumber) - ConvertToDecimal(SecondNumber);
                return Ok(op.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mlt/{firstNumber}/{SecondNumber}")]
        public IActionResult GetMlt(string firstNumber, string SecondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var op = ConvertToDecimal(firstNumber) * ConvertToDecimal(SecondNumber);
                return Ok(op.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("dvs/{firstNumber}/{SecondNumber}")]
        public IActionResult GetDvs(string firstNumber, string SecondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var op = ConvertToDecimal(firstNumber) / ConvertToDecimal(SecondNumber);
                return Ok(op.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{SecondNumber}")]
        public IActionResult GetMean(string firstNumber, string SecondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var op = (ConvertToDecimal(firstNumber) + ConvertToDecimal(SecondNumber)) / 2;
                return Ok(op.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {

            if (IsNumeric(firstNumber))
            {
                var op = Math.Sqrt((double) ConvertToDecimal(firstNumber));
                return Ok(op.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
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
