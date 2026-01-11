using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonCategoryResponse
    {
        public Guid? CategoryId { get; set; }

        public string? Name { get; set; }
    }
}
