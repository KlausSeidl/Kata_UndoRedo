using System;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class SetDefinitionBeginCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly DateTime _newValue;
        private readonly DateTime _oldValue;
        private readonly EditingDocument _predecessor;
        
        public SetDefinitionBeginCommand(DefinitionsModel model, DateTime newValue)  
        {
            _model = model;
            _newValue = newValue;

            if (model.CurrentDocument == null || _model.CurrentDocument.Definition.Begin == newValue)
            {
                Discard = true;
                return;
            }

            _predecessor = model.GetPredecessor(model.CurrentDocument);

            if (_predecessor != null && _predecessor.Definition.Begin > newValue)
            {
                Discard = true;
                return;
            }
            
            _oldValue = _model.CurrentDocument.Definition.Begin;
            
            Description = $"Change definition begin from {_model.CurrentDocument.Definition.Begin} to {_newValue}";
        }
        
        protected override object Execute()
        {
            _model.CurrentDocument.Definition.Begin = _newValue;
            if (_predecessor != null)
            {
                _predecessor.Definition.End = _newValue;
            }
            return null;
        }

        protected override object Undo()
        {
            _model.CurrentDocument.Definition.Begin = _oldValue;
            if (_predecessor != null)
            {
                _predecessor.Definition.End = _oldValue;
            }
            return null;
        }
    }
}