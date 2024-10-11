using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDefinition.Model
{
    public class Definition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public Guid? DiscontinuedToId { get; set; }
        public Guid? ChangeFromDokId { get; set; }
        public Guid? CompositionId { get; set; }

    }
}
