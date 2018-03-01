using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace Ng2FileUploadAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IHostingEnvironment _env;
        public ValuesController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> PostFile()
        {
            var files = Request.Form.Files;

            foreach (var file in files)
            {
                var filename = ContentDispositionHeaderValue
                              .Parse(file.ContentDisposition)
                              .FileName
                              .Trim('"');
              
                var savePath = Path.Combine(_env.ContentRootPath, "uploads", filename);

                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    await file.OpenReadStream().CopyToAsync(fileStream);
                }
                return Created(savePath, file);
            }
            return Ok();
        }



    }

}
