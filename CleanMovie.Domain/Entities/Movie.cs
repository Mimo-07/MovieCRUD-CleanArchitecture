using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public decimal MovieCost { get; set; }
    }
}
