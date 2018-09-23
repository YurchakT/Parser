using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParser.Models
{
    public class Statement
    {
        public int Id { get; set; }
        public string ReverseWords { get; set; }
        public int NumberWord { get; set; }

        public Statement() { }
        public Statement(string words, int number)
        {
            ReverseWords = words;
            NumberWord = number;
        }
    }
}