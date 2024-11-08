using System;
using System.Linq;

namespace EditDefinition.Model
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    public class AddDefinitionsCommand : ICommand
    {
        private readonly DefinitionsModel _definitionsModel;
        private readonly string _definitionName;
        private EditingDocument _editingDocumentToWorkOn;

        public AddDefinitionsCommand(DefinitionsModel definitionsModel, string definitionName)
        {
            _definitionsModel = definitionsModel;
            _definitionName = definitionName;
        }
        
        public void Execute()
        {
            var editingDocument = new EditingDocument(new Definition
            {
                Id = Guid.NewGuid(),
                Name = _definitionName,
                Begin = DateTime.Now, // TODO
                End = DateTime.Now.AddDays(2) // TODO
            });
            _editingDocumentToWorkOn = editingDocument;
            _definitionsModel.AddEditingDocument(_editingDocumentToWorkOn);
        }

        public void Undo()
        {
            _definitionsModel.RemoveEditingDocument(_editingDocumentToWorkOn.Definition.Id);
        }

        public void Redo()
        {
            _definitionsModel.EditingDocuments.Add(_editingDocumentToWorkOn);
        }
    }
}