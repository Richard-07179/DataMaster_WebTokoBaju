using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTokoBaju.Data
{
    public class Merk
    {
        [Column("id_merk")]
        public int IdMerk { get; set; }

        [Column("nama_merk")]
        [DisplayName("Merk")]
        public string NamaMerk { get; set; }

        //public virtual ICollection<Baju> Bajus { get; set; }
    }
}
