using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleFluentValidation.Models;

namespace SampleFluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private static readonly List<Course> Courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name = "Dotnet",
                Description = "Learn dotnet from zero to hero",
                Videos = new List<Video>
                {
                    new Video
                    {
                        Id = 1,
                        Title = "Introduction"
                    },
                    new Video
                    {
                        Id = 2,
                        Title = "Installation"
                    }
                }
            }
        };
        
        // GET: api/Course
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(Courses);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Course
        [HttpPost]
        public ActionResult<Course> Post(Course course)
        {
            Courses.Add(course);

            return Ok(course);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
