using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.IO.File;

namespace NetCards.Api.Core.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImageController : ControllerBase
    {
        [HttpGet("{suit}/{code}")]
        public async Task<IActionResult> GetImage(string suit, string code)
        {
            Byte[] b = await ReadAllBytesAsync($@"{Directory.GetCurrentDirectory()}/Images/{suit}/{code}.png"); // You can use your own method over here.         
            return File(b, "image/png");
        }
    }
}