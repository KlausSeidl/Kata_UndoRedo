using System.Diagnostics;
using Skc.BestPractices.CommandManager;

namespace KataUndoRedoImplDStahmer.Client.Model
{
    public class DefinitionChangedCommand(
        Definition definition
    ) : Command
    {
        public string? NewName { get; init; }
        public DateTime? NewBeginDate { get; init; }
        public DateTime? NewEndDate { get; init; }
        
        private readonly string _prevName = definition.Name;
        private readonly DateTime _prevBeginDate = definition.Begin;
        private readonly DateTime _prevEndDate = definition.End;
        
        protected override object Execute()
        {
            if (NewName != null) definition.Name = NewName;
            if (NewBeginDate != null) definition.Begin = (DateTime)NewBeginDate!;
            if (NewEndDate != null) definition.End = (DateTime)NewEndDate!;
            return definition;
        }

        protected override object Undo()
        {
            definition.Name = _prevName;
            definition.Begin = _prevBeginDate;
            definition.End = _prevEndDate;
            return definition;
        }
    }
    
    public class DefinitionNewCommand(
        List<Definition> definitions,
        Definition newDefinition
    ) : Command
    {
        protected override object Execute()
        {
            definitions.Add(newDefinition);
            return definitions;
        }

        protected override object Undo()
        {
            definitions.RemoveAt(definitions.Count - 1);
            return definitions;
        }
    }
    
    public class DefinitionDeleteCommand(
        List<Definition> definitions,
        Definition toDelete
    ) : Command
    {
        private readonly int _prevIndex = definitions.IndexOf(toDelete);
        
        protected override object Execute()
        {
            definitions.Remove(toDelete);
            return definitions;
        }

        protected override object Undo()
        {
            definitions.Insert(_prevIndex, toDelete);
            return definitions;
        }
    }
};