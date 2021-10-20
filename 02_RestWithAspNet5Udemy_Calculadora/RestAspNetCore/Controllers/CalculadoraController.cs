﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Input inválido!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Input inválido!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Input inválido!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
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

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult GetAvg(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(avg.ToString());
            }
            return BadRequest("Input inválido!");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                if (ConvertToDecimal(firstNumber) < 0)
                {
                    return BadRequest("Não é possível calcular raiz de número negativo!");
                }
                var sqtr = System.Math.Sqrt(Convert.ToDouble(firstNumber));
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
