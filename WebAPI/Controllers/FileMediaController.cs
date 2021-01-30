using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Helpers;
using WebAPI.Services;
using WebAPI.Entities;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.IO;
using WebAPI.Models.Parts;
using System.Net;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FileMediaController : ControllerBase
    {
        private IFileMediaService _filemediaService;
        private readonly AppSettings _appSettings;

        public FileMediaController(
            IFileMediaService filemediaService, IOptions<AppSettings> appSettings)
        {
            _filemediaService = filemediaService;
            _appSettings = appSettings.Value;
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        [Route("/FileMedia/UploadFiles")]
        public async Task<HttpResponseMessage> UploadFilesAsync([FromForm]FileData model)
        {
            try
            {

                var filePath = _appSettings.MediaPath;

                using (var stream = new FileStream(Path.Combine(filePath, model.file.FileName), FileMode.Create))
                {
                    await model.file.CopyToAsync(stream);

                    string fileName = Path.GetFileNameWithoutExtension(model.file.FileName);
                    string path = Path.Combine(filePath, fileName);
                    var extension = Path.GetExtension(model.file.FileName);
                    var contentType = model.file.ContentType;
                   
                    File_Media fileData = new File_Media
                    {
                        File_Name = fileName,
                        Content_Type = contentType,
                        File_Type = extension,
                        File_Url = path + extension,
                        Part_Id = model.id
                    };
                    _filemediaService.AddFile(fileData);
                }
            }
            catch (Exception arg)
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("/FileMedia/DownloadFileFromFileSystem/{id}")]
        public string DownloadFileFromFileSystem(int id)
        {
            File_Media fileMedia = _filemediaService.GetMediaName(id);
            if (fileMedia == null) return null;
            string virtualFile = "assets/upload/" + fileMedia.File_Name + fileMedia.File_Type;
            return JsonConvert.SerializeObject(virtualFile);
            //var filePath = _appSettings.MediaPath;
            //var memory = new MemoryStream();
            //using (var stream = new FileStream(Path.Combine(filePath, fileMedia.File_Name + fileMedia.File_Type), FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;
            //return File(memory, fileMedia.Content_Type, fileMedia.File_Name + fileMedia.File_Type);
        }
    }
}