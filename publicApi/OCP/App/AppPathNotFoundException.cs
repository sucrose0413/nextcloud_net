﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCP.App
{
    class AppPathNotFoundException : Exception
    {
        public AppPathNotFoundException(string msg) : base(msg)
        {
            
        }
    }
}
