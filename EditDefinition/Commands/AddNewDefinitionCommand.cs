using System;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class AddNewDefinitionCommand : Command
    {
        private static int Counter;
        
        private readonly DefinitionsModel _model;
        private readonly EditingDocument _document;
        private readonly EditingDocument _oldCurrent;
        
        public AddNewDefinitionCommand(DefinitionsModel model)  
        {
            _model = model;

            _document = new EditingDocument(new Definition()
            {
                Id = Guid.NewGuid(),
                Begin = DateTime.Now, 
                End = DateTime.Now.AddDays(7), 
                Name = $"New definition {Counter++}"
            })
            {
                State = DocumentState.New,
                HasChanges = true
            };

            _oldCurrent = _model.CurrentDocument;

            Description = $"Create new definition with Id {_document.Definition.Id}";
        }
        
        protected override object Execute()
        {
            _model.EditingDocuments.Add(_document);
            _model.CurrentDocument = _document;
            return _document;
        }

        protected override object Undo()
        {
            _model.EditingDocuments.Remove(_document);
            _model.CurrentDocument = _oldCurrent;
            return null;
        }
    }
}