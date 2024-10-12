using System.Collections.Generic;
using System.Linq;

namespace EditDefinition.Model
{
    public class DefinitionsModel
    {
        private readonly IList<EditingDocument> _editingDocuments = new List<EditingDocument>();
        public EditingDocument CurrentDocument { get; set; } = null;

        public IList<EditingDocument> EditingDocuments => _editingDocuments;

        public void Clear()
        {
            _editingDocuments.Clear();
            CurrentDocument = null;
        }

        public bool HasChanges => EditingDocuments.Any(x => x.HasChanges);

        public IEnumerable<EditingDocument> GetChangeSeriesElements(EditingDocument document)
        {
            yield return document;
            var element = document;

            while (element.Definition.DiscontinuedToId.HasValue)
            {
                var successor = GetSuccessor(element);
                yield return successor;

                element = successor;
            }

            element = document;

            while (element.Definition.ChangeFromDokId.HasValue)
            {
                var predecessor = GetPredecessor(element);

                if (predecessor == null)
                {
                    yield break;
                }

                yield return predecessor;

                element = predecessor;
            }
        }

        public EditingDocument GetPredecessor(EditingDocument element)
        {
            return EditingDocuments.SingleOrDefault(x => x.Definition.Id == element.Definition.ChangeFromDokId);
        }

        public EditingDocument GetSuccessor(EditingDocument element)
        {
            if (element == null)
            {
                return null;
            }
            
            return EditingDocuments.SingleOrDefault(x => x.Definition.Id == element.Definition.DiscontinuedToId);
        }

        public bool IsMemberOfChangeSeries(EditingDocument document)
        {
            return GetChangeSeriesElements(document).Count() > 1;
        }

        public bool CanBeRemoved(EditingDocument document)
        {
            if (document == null)
            {
                return false;
            }
            
            var successor = GetSuccessor(document);

            return successor == null;
        }
    }
}
