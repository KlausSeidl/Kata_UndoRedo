using System;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class AddNewDefinitionToChangeSeriesCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly EditingDocument _document;
        private readonly EditingDocument _oldCurrent;
        private readonly Guid _newId;
        private readonly Guid? _oldDiscontinueToId;
        
        public AddNewDefinitionToChangeSeriesCommand(DefinitionsModel model)  
        {
            _model = model;

            if (model.CurrentDocument == null)
            {
                Discard = true;
                return;
            }

            _oldCurrent = _model.CurrentDocument;
            _oldDiscontinueToId = _oldCurrent.Definition.DiscontinuedToId;
            
            _newId = Guid.NewGuid();
            
            _document = new EditingDocument(new Definition()
            {
                Id = _newId,
                Begin = _oldCurrent.Definition.End, 
                End = _oldCurrent.Definition.End.AddDays(7), 
                Name = _oldCurrent.Definition.Name,
                ChangeFromDokId = _oldCurrent.Definition.Id
            })
            {
                State = DocumentState.New,
                HasChanges = true
            };

            Description = $"Add new definition with Id '{_newId}' a successor to definition with id '{_oldCurrent.Definition.Id}'";
        }
        
        protected override object Execute()
        {
            _oldCurrent.Definition.DiscontinuedToId = _newId;
            _model.EditingDocuments.Add(_document);
            _model.CurrentDocument = _document;
            return _document;
        }

        protected override object Undo()
        {
            _oldCurrent.Definition.DiscontinuedToId = _oldDiscontinueToId;
            _model.EditingDocuments.Remove(_document);
            _model.CurrentDocument = _oldCurrent;
            return null;
        }
    }
}