using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject
{
    public  class NewMovieClass : object
    {
        //properties
        public string Title { get; set; }

        public decimal Imdb { get; set; }

        public string Stream { get; set; }

        public List<NewMovieClass> NewList = new List<NewMovieClass>();
    }
}
