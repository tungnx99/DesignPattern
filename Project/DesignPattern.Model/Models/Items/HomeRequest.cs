﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Model.Models.Items
{
    public class HomeRequest
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public int Story { get; set; }

        public int Room { get; set; }

        public bool IsCreateOrUpdate { get; set; }
    }
}