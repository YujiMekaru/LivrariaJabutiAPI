using LivrariaJabutiAPI.Domain.Models.DTOs.File;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Impl
{
    public class FileStoreService : IFileStoreService
    {
        private readonly string _fileStorePath;
        private readonly string _fileDownloadPath;

        public FileStoreService()
        {
            var fileStorePath = Environment.GetEnvironmentVariable("FileStorePath");
            var fileDownloadPath = Environment.GetEnvironmentVariable("FileDownloadPath");

            if (fileStorePath == null)
                throw new Exception("FileStorePath not defined");

            if (fileDownloadPath == null)
                throw new Exception("FileDownloadPath not defined");

            _fileStorePath = fileStorePath;
            _fileDownloadPath = fileDownloadPath;
        }

        public async Task<DocumentStoreResponse> StoreDocumentAsync(IFormFile file, CancellationToken ct)
        {
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            var uniqueIdentifier = Guid.NewGuid();
            var fileName = $"{uniqueIdentifier}{fileExtension}";
            var uploadPath = Path.Combine(_fileStorePath, fileName);

            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
                await file.CopyToAsync(fileStream, ct);

            return new DocumentStoreResponse
            {
                DocumentUrl = $"{_fileDownloadPath}/{fileName}"
            };
        }
    }
}
