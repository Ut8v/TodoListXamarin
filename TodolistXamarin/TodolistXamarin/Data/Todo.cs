using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodolistXamarin.Data
{
     public class Todo
    {
        
        public string task { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public bool done { get; set; }
    }
}
