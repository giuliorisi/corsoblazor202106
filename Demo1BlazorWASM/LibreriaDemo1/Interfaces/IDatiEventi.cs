﻿using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibreriaDemo1.Interfaces
{
    public interface IDatiEventi
    {
        List<ElementoListaEventi> EstraiEventi();
    }
}