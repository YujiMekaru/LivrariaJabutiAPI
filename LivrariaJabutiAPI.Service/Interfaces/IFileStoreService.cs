using LivrariaJabutiAPI.Domain.Models.DTOs.File;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface IFileStoreService
    {
        Task<DocumentStoreResponse> StoreDocumentAsync(IFormFile file, CancellationToken ct);
    }
}
