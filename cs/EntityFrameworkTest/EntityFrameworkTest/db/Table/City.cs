﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkTest
{
    class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
