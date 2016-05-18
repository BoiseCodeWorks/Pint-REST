using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pintrest.Web.Models;

namespace Pintrest.Web
{
    [Route("/api/resources")]
    public class ResourceController
    {
        private static List<Board> _boards = new List<Board>(new[] {
            new Board() { Id = 1, Title = "Javascript", Description = "My Javascript Interest", Json = "{\"TestMissing\":\"property\",\"myObj\":{\"subProp\":\"sub property\"}}"},
            new Board() { Id = 2, Title = "Music", Description = "Anything related to music that I enjoy", Json = "{\"property\":\"property\",\"myObj\":{\"subProp\":\"sub property\"}}"},
            new Board() { Id = 3, Title = "Pizza", Description = "I love pizza... enough said", Json = "{\"property\":\"property\",\"myObj\":{\"subProp\":\"sub property\"}}" }
        });

        public IEnumerable<Board> Get()
        {
            return _boards;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var board = _boards.FirstOrDefault(p => p.Id == id);

            if (board == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(board);
        }

        [HttpPost]
        public void Post([FromBody]Board board)
        {
            _boards.Add(board);
        }


    }
}