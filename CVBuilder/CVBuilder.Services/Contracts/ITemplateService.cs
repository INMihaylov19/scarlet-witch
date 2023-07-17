using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface ITemplateService
    {
        public Task<List<Template>> GetTemplatesAsync();

        public Task<Template> GetTemplateByIdAsync(Guid id);

        public Task<bool> UpdateTemplateAsync(Guid id, Template template);

        public Task<Template> CreateTemplateAsync(Template template);

        public Task<bool> DeleteTemplateAsync(Guid id);

        public bool TemplateExists(Guid id);

    }
}
