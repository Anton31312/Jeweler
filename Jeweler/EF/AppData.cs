﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeweler.EF
{
    public static class AppData
    {
        public static Entities Context { get; } = new Entities();

        public static User userData;
    }
}
