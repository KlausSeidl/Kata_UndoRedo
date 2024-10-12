using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition.Commands
{
    public class SetDefinitionNameCommand : Command
    {
        private readonly DefinitionsModel _model;
        private readonly string _newName;
        private readonly string _oldName;
        
        public SetDefinitionNameCommand(DefinitionsModel model, string newName)  
        {
            _model = model;
            _newName = newName;

            if (model.CurrentDocument == null || _model.CurrentDocument.Definition.Name == newName)
            {
                Discard = true;
                return;
            }

            _oldName = _model.CurrentDocument.Definition.Name;
            
            Description = $"Change definition name from '{_oldName}' to '{newName}'";
        }
        
        protected override object Execute()
        {
            foreach (var document in _model.GetChangeSeriesElements(_model.CurrentDocument))
            {
                document.Definition.Name = _newName;
            }
            
            return null;
        }

        protected override object Undo()
        {
            foreach (var document in _model.GetChangeSeriesElements(_model.CurrentDocument))
            {
                document.Definition.Name = _oldName;
            }

            return null;
        }
    }
}