using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Category : CommonEntity
    {
        public string? Name { get; set; }

    }
}
