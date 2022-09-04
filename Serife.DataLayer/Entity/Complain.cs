﻿using System;
using System.Collections.Generic;

namespace Serife.DataLayer.Entity
{
    public partial class Complain
    {
        public int ComplainId { get; set; }
        public int ComplainantUserId { get; set; }
        public int ComplainedOfUserId { get; set; }
        public byte ComplainStatusId { get; set; }
        public DateTime ComplainDate { get; set; }
        public int MessageReferenceId { get; set; }

        public virtual User ComplainNavigation { get; set; } = null!;
        public virtual ComplainStatus ComplainStatus { get; set; } = null!;
        public virtual User ComplainantUser { get; set; } = null!;
        public virtual Message MessageReference { get; set; } = null!;
    }
}
