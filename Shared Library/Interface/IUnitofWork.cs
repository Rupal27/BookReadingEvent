﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library.Interface
{
    public interface IUnitofWork : IDisposable
    {
        void Save();
    }
}