using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UploadController : ControllerBase
	{
        private readonly AspProjekatContext _context;

		public UploadController(AspProjekatContext context)
		{
			_context = context;
		}

		// POST api/<UploadController>
		[HttpPost("{blogId}")]
        public void Post([FromForm] ImageDto dto, int blogId)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }

            var picture = new Picture
            {
                BlogId = blogId,
                Src = newFileName
            };

            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }
    }
}
