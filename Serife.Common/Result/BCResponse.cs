﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serife.Common.Result
{
    public class BCResponse
    {
        public string? Errors { get; set; } = null;
        public object? Value { get; set; }

    }
}
