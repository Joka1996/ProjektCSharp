using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject
{
    public class SeenMoviesClass: Object
    {
        //properties
        public string Title { get; set; }

        public int Grade { get; set; }

        public string Rewatch { get; set; }

        public string Review { get; set; }


        public List<SeenMoviesClass> SeenList = new List<SeenMoviesClass>();
    }
}
