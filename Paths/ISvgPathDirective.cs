﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGFactory.Paths
{
    public interface ISvgPathDirective
    {
        bool Absolute { get; set; }
        string AttributeString();
    }
}
