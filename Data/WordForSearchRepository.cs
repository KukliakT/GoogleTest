﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTest.Data
{
    public sealed class WordForSearchRepository
    {
        public string InputText;
        private WordForSearchRepository(string InputText)
        {
            this.InputText = InputText;
        }

        public static WordForSearchRepository GetWiki()
        {
            return new WordForSearchRepository("Wiki");
                
        }

    }
}