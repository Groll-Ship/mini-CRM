using System;
using System.Collections.Generic;
using System.Text;

namespace Statuses.ModelStatus
{
    public class ModelStatusUpdate
    {
        public int IdModel { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string JsonModel { get; set; }
    }
}
