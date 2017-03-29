using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaceCalculatorAPI.Models;

namespace PaceCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaceController : Controller
    {
        // GET api/pace
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest("Pace is empty");
        }

        // GET api/pace/3-45
        [HttpGet("{pace}")]
        public IActionResult Get(string pace)
        {
            if (string.IsNullOrEmpty(pace)) return BadRequest("Pace is incorrect. Format mm-ss");

            var input = pace.Split('-');
            var p = new Pace(Convert.ToInt32(input[0]), Convert.ToInt32(input[1]));

            var paces = new Dictionary<string, string>
            {
                {"half", p.GetFinishTime(21.097)},
                {"marathon", p.GetFinishTime(42.195)}
            };

            for (var i = 1; i < 43; i++)
            {
                paces.Add($"{i}", p.GetFinishTime(i));
            }

            return new ObjectResult(paces);
        }
    }
}
