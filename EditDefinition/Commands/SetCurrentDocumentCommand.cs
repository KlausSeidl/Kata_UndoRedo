using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class SetCurrentDocumentCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly EditingDocument _newDocument;
        private readonly EditingDocument _oldDocument;
        
        public SetCurrentDocumentCommand(DefinitionsModel model, EditingDocument newDocument)  
        {
            _model = model;
            _newDocument = newDocument;

            if (_model.CurrentDocument == newDocument)
            {
                Discard = true;
                return;
            }

            _oldDocument = _model.CurrentDocument;

            Description = $"Select definition '{newDocument.Definition.Name}'";
        }
        
        protected override object Execute()
        {
            _model.CurrentDocument = _newDocument;
            return null;
        }

        protected override object Undo()
        {
            _model.CurrentDocument = _oldDocument;
            return null;
        }
    }
}