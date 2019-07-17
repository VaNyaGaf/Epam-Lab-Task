﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.PL.ViewModels
{
    public class ReplyCommentViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int ParentCommentId { get; set; }

        [Required]
        public int GameId { get; set; }
    }
}