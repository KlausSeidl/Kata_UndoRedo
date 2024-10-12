using System;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class SetDefinitionEndCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly DateTime _newValue;
        private readonly DateTime _oldValue;
        private readonly EditingDocument _successor;
        
        public SetDefinitionEndCommand(DefinitionsModel model, DateTime newValue)  
        {
            _model = model;
            _newValue = newValue;

            if (model.CurrentDocument == null || _model.CurrentDocument.Definition.End == newValue)
            {
                Discard = true;
                return;
            }

            _successor = model.GetSuccessor(model.CurrentDocument);

            if (_successor != null && _successor.Definition.End < newValue)
            {
                Discard = true;
                return;
            }
            
            _oldValue = _model.CurrentDocument.Definition.End;

            Description = $"Change definition end from {_model.CurrentDocument.Definition.End} to {_newValue}";
        }
        
        protected override object Execute()
        {
            _model.CurrentDocument.Definition.End = _newValue;
            if (_successor != null)
            {
                _successor.Definition.Begin = _newValue;
            }
            return null;
        }

        protected override object Undo()
        {
            _model.CurrentDocument.Definition.End = _oldValue;
            if (_successor != null)
            {
                _successor.Definition.Begin = _oldValue;
            }
            return null;
        }
    }
}