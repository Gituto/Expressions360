using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expressions360.Models
{
    public class ArticlesModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public byte[] Image { get; set; }
        public byte[] Attachment { get; set; }
    }
}