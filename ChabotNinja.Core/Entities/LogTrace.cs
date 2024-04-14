using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.Entities
{
    public class LogTrace
    {
        [Key]
        public int LogId { get; set; }

        public int Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; } = null!;
        public DateTime TraceData { get; set; }
        public Guid? User { get; set; }

    }
}
