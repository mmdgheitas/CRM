using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class ItemViewModel
    {
        public bool Name { get; set; }
        public bool ItemCategory { get; set; }
        public bool Taxable { get; set; }
        public bool Details { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }

        public ItemViewModel()
        {
            Name =  true;
            ItemCategory = true;
            Taxable = true;
            Details = true;
            modifiedInfo = true;
            test = false;
        }

    }



    public class ItemModifireViewModel
    {
        public bool Name { get; set; }
        [Display(Name = "Category")]
        public bool ItemCategory { get; set; }
        [Display(Name = "Form Title")]
        public bool FormTitle { get; set; }
        public bool Enable { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }



        public ItemModifireViewModel()
        {
            Name = true;
            ItemCategory = true;
            FormTitle = true;
            Enable = true;
            test = false;
            modifiedInfo = true;

        }

    }



}