using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using CoreAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly IEntertainmentRepo _entRepo;
        public ExamController(IEntertainmentRepo entRepo)
        {
            _entRepo = entRepo;
        }

        [HttpGet(Name ="GetQuestions")]
        public IActionResult GetResult()
        {
            var model =  _entRepo.GetEntertainment();

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

    }
}