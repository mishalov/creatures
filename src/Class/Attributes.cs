using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    public class Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        public int Dex
        {
            get;
            set;
        }

        public int Str
        {
            get;
            set;
        }

        public int Int
        {
            get;
            set;
        }

        public int End
        {
            get;
            set;
        }

        public Attributes(int Dex = 0, int Str = 0, int Int = 0, int End = 0) {
            this.Str = Str;
            this.Dex = Dex;
            this.Int = Int;
            this.End = End;
        }

        public Attributes Clone()
        {
            return new Attributes(Dex, Str, Int, End);
        }
    }
}
