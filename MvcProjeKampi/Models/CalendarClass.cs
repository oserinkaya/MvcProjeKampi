﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class CalendarClass
    {
        public string title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public bool allday { get; set; }
    }
}