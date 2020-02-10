using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly static List<movie> movieList = new List<movie>(); 
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("Show")]
        public ActionResult<string> Get(string prueba)
        {
            if (movieList.Count < 10)
            {
                for (int i = movieList.Count - 1; i >= 0; i--)
                {
                    string show = "\n" +"nombre: " + movieList[i].name + "\n" + "director: " + movieList[i].director + "\n" + "año: " + movieList[i].year ;
                    prueba += show;
                }
            }
            else
            {
                for (int i = movieList.Count; i > movieList.Count - 10; i--)
                {
                    string show = "\n" + "nombre: " + movieList[i].name + "\n" + "director: " + movieList[i].director + "\n" + "año: " + movieList[i].year;
                    prueba += show;
                  
                }
            }

             

             return prueba;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] movie movie)
        {
            movieList.Add(movie);
           
        }      
    }
}
