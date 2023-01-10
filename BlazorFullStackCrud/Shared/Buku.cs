using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFullStackCrud.Shared
{
    public class Buku
    {
        public int Id { get; set; }
        public string Judul_Buku { get; set; } = string.Empty;
        public string Penerbit { get; set; } = string.Empty;
        public string Penulis { get; set; }
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
    }
}
