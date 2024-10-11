using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDefinition.Model
{
    public class EditingDocument
    {
        public DocumentState State { get; set; }
        public bool HasChanges { get; set; }

        public Definition Definition { get; set; }

        public EditingDocument(Definition definition)
        {
            Definition = definition;
        }
    }

    public enum DocumentState
    {
        New,
        Update
    }
}
