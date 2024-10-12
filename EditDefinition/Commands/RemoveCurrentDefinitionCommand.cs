using System;
using System.Linq;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class RemoveCurrentDefinitionCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly EditingDocument _oldCurrent;
        private readonly EditingDocument _oldPredecessor;

        public RemoveCurrentDefinitionCommand(DefinitionsModel model)  
        {
            _model = model;

            if (model.CurrentDocument == null)
            {
                Discard = true;
                return;
            }

            _oldCurrent = _model.CurrentDocument;
            _oldPredecessor = _model.GetPredecessor(_oldCurrent);

            if (_model.CanBeRemoved(_oldCurrent) == false)
            {
                Discard = true;
                return; 
            }

            Description = $"Remove definition with Id '{_oldCurrent.Definition.Id}'.";
        }
        
        protected override object Execute()
        {
            if (_oldPredecessor != null)
            {
                _oldPredecessor.Definition.DiscontinuedToId = null;
            }
            _model.EditingDocuments.Remove(_oldCurrent);
            _model.CurrentDocument = _model.EditingDocuments.FirstOrDefault();
            return null;
        }

        protected override object Undo()
        {
            if (_oldPredecessor != null)
            {
                _oldPredecessor.Definition.DiscontinuedToId = _oldCurrent.Definition.Id;
            }
            _model.EditingDocuments.Add(_oldCurrent);
            _model.CurrentDocument = _oldCurrent;
            return null;
        }
    }
}