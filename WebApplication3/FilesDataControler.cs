using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3
{
    public class FilesDataControler : ApiController
    {
        [HttpGet]
        public Object DownloadFile(String uniqueName)
        {
            //Physical Path of Root Folder
            var rootPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");

            //Find File from DB against unique name
            var fileDTO = FilesDataModel.GetFileByUniqueID(uniqueName);

            if (fileDTO != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileFullPath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);

                byte[] file = System.IO.File.ReadAllBytes(fileFullPath);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(file);

                response.Content = new ByteArrayContent(file);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                //String mimeType = MimeType.GetMimeType(file); //You may do your hard coding here based on file extension

                response.Content.Headers.ContentType = new MediaTypeHeaderValue(fileDTO.ContentType);// obj.DocumentName.Substring(obj.DocumentName.LastIndexOf(".") + 1, 3);
                response.Content.Headers.ContentDisposition.FileName = fileDTO.FileActualName;
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }

        }
    }

}