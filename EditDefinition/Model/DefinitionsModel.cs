using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var successor = EditingDocuments.Single(x => x.Definition.Id == element.Definition.DiscontinuedToId);
                yield return successor;

                element = successor;
            }

            element = document;

            while (element.Definition.ChangeFromDokId.HasValue)
            {
                var predecessor = EditingDocuments.SingleOrDefault(x => x.Definition.Id == element.Definition.ChangeFromDokId);

                if (predecessor == null)
                {
                    yield break;
                }

                yield return predecessor;

                element = predecessor;
            }
        }

        public bool IsMemberOfChangeSeries(EditingDocument document)
        {
            return GetChangeSeriesElements(document).Count() > 1;
        }
    }
}
