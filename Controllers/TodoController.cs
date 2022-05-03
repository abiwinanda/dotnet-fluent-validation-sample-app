using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleFluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static readonly List<Todo> Todos = new List<Todo>
        {
            new Todo
            {
                Id = 1,
                Title = "One"
            },
            new Todo
            {
                Id = 2,
                Title = "Two",
                Description = "Description of Two"
            },
            new Todo
            {
                Id = 3,
                Title = "Three"
            },
        };
        
        // GET: api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return Ok(Todos);
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            var todo = Todos.Find(t => t.Id == id);
            
            return Ok(todo);
        }

        // POST: api/Todo
        [HttpPost]
        public ActionResult<Todo> Post(Todo newTodo)
        {
            Todos.Add(newTodo);

            return Ok(newTodo);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
