using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTokoBaju.Data
{
    public class Baju
    {
        public int IdBaju { get; set; }

        public int id_merk { get; set; }
        public int id_jenis_baju { get; set; }

        [DisplayName("Nama Baju")]
        public string NamaBaju { get; set; }

        public double Harga { get; set; }

        [DisplayName("Gambar Baju Lama")]
        public string PathGambarBaju { get; set; }

        [ForeignKey("id_merk")]
        public virtual Merk MyMerk { get; set; }

        [ForeignKey("id_jenis_baju")]
        public virtual JenisBaju MyJenisBaju { get; set; }

        [Required(ErrorMessage = "Please choose gambar baju")]
        [DisplayName("Gambar Baju")]
        [NotMapped]
        public IFormFile GambarBaju { get; set; }
    }
}
