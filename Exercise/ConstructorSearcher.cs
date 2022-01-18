using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise
{
    public class ConstructorSearcher
    {

        private ISearcher _searcher;
        
        public ConstructorSearcher(ISearcher _searcher)
        {
            this._searcher = _searcher;
        }

        public IActionResult Search()
        {
            return _searcher.Search();
        }
        
        
    }
}
