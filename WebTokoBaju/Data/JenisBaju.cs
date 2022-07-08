using System.ComponentModel;

namespace WebTokoBaju.Data
{
    public class JenisBaju
    {
        public int IdJenisBaju { get; set; }

        [DisplayName("Jenis Baju")]
        public string NamaJenisBaju { get; set; }

        //public virtual ICollection<Baju> Bajus { get; set; }
    }
}
