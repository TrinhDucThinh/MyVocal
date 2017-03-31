﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("Semantics")]
    public class Semantic
    {
        public int Semantic_Id { get; set; }

        public int WordId { get; set; }

        public virtual Word Word { get; set; }
              
        public string WordFollow { get; set; }

        public string Example { get; set; }
               
        public string ExampleSound { get; set; }

        public string Image { get; set; }

        public int? SemamticTime { get; set; }

        public bool? Status { get; set; }
    }
}