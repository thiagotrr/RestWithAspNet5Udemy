using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAspNetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Input inválido!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Input inválido!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Input inválido!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(secondNumber) == 0)
                {
                    return BadRequest("Impossível dividir por zero!");
                }

                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());

            }
            return BadRequest("Input inválido!");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(avg.ToString());
            }
            return BadRequest("Input inválido!");
        }

        [HttpGet("raizq/{firstNumber}")]
        public IActionResult RaizQ(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                if (ConvertToDecimal(firstNumber) < 0)
                {
                    return BadRequest("Não é possível calcular raiz de número negativo!");
                }
                var sqtr = System.Math.Sqrt(Convert.ToDouble(firstNumber)); // ou (double) ConvertToDecimal(firstNumber)
                return Ok(sqtr.ToString());
            }

            return BadRequest("Input inválido!");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            
            return isNumber;
            
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
