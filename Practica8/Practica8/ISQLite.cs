﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace Practica8
{
    public interface ISQLite
    {
        string GetLocalFilePath(string Filename);
    }
}
