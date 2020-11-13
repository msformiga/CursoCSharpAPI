using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace Calculadora.Controllers
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

/*
    forma de execução
    https://localhost:5001/Calculator/sum/2/3
    a url acima deverá retornar 5
    ou
    localhost:5001/Calculator/sum/2,5/3,7
    retorna 6,2

    No arquivo Properties/lauchSettings.json foi substituída a linha "lauchUrl":"WeatherForeCast" por "launchUrl":"Calculator",  para que seja o ponto principal

*/
//a linha abaixo é um endpoint
[HttpGet("Soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
//a linha abaixo é um endpoint
[HttpGet("Divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

//a linha abaixo é um endpoint
[HttpGet("Multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }
//a linha abaixo é um endpoint
[HttpGet("Subtracao/{firstNumber}/{secondNumber}")]
                public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

//a linha abaixo é um endpoint da raíz-quadrada
[HttpGet("square-root/{firstNumber}/{secondNumber}")]
                public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber)){
                var result = Math.Sqrt((double) ConvertToDecimal(firstNumber)) ;
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }        


        private bool IsNumeric(string strNumber){
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
            throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string strNumber){
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue)){
                return decimalValue;
            }
            return 0;
            throw new NotImplementedException();
        }
    }
}
