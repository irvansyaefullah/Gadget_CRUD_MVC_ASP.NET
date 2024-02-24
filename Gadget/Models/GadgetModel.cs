using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadget.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Appears in this movie")]
        public string Appearsln { get; set; }
        [Required]
        public string WithThisActor { get; set; }

        public GadgetModel() 
        {
            Id = -1;
            Name = "Nothing";
            Description = "Nothing Yet";
            Appearsln = "Nowhere";
            WithThisActor = "With No One";
        }

        public GadgetModel(int id, string name, string description, string appearsln, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            Appearsln = appearsln;
            WithThisActor = withThisActor;
        }
    }
}