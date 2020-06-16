﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Upload
{
    [Route("UploadFile")]
    public class FileUploadController : Controller
    {
        private IHostingEnvironment hostingEnv;

        public FileUploadController(IHostingEnvironment env)
        {
            this.hostingEnv = env;

        }
        [Route("Upload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> files)
        {
            var httpPostedFile = files[0];
            string filename = ContentDispositionHeaderValue.Parse(httpPostedFile.ContentDisposition).FileName.Trim('"');
            if (httpPostedFile != null)
            {
                filename = this.EnsureCorrectFilename(filename);
                // Save the uploaded file to "UploadedFiles" folder
                GetPathAndFilename(filename);
                var path = Path.Combine(
                 Directory.GetCurrentDirectory(), "wwwroot/VideoUpload/Movie",
                 filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await httpPostedFile.CopyToAsync(stream);
                }
            }

            return Content("Succes");
        }
        [Route("UploadImageDirector")]
        [HttpPost]
        public async Task<IActionResult> UploadImageDirector(IList<IFormFile> files)
        {
            var httpPostedFile = files[0];
            string filename = ContentDispositionHeaderValue.Parse(httpPostedFile.ContentDisposition).FileName.Trim('"');
            if (httpPostedFile != null)
            {
                filename = this.EnsureCorrectFilename(filename);
                // Save the uploaded file to "UploadedFiles" folder
                GetPathAndFilename(filename);
                var path = Path.Combine(
                 Directory.GetCurrentDirectory(), "wwwroot/img/Director",
                 filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await httpPostedFile.CopyToAsync(stream);
                }
            }

            return Content("Succes");
        }
        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return this.hostingEnv.WebRootPath + "\\uploads\\" + filename;
        }
    }
}