using System.Collections.Generic;

namespace EditDefinition.Model
{
    public class CommandManager
    {
        private IList<ICommand> _commands = new List<ICommand>();
        private int _commandIndex = 0;
        private bool _firstCommandUndone = false;
        private bool _lastCommandRedone = false;

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            _commandIndex = _commands.Count - 1;
        }

        public void StepThroughCommands(bool back)
        {
            if (back)
            {
                _commands[_commandIndex].Undo();
                _commandIndex--;
                if (_commandIndex < 0)
                {
                    _commandIndex = 0;
                }
            }
            else
            {
                _commands[_commandIndex].Redo();
                _commandIndex++;
                if (_commandIndex >= _commands.Count)
                {
                    _commandIndex = _commands.Count - 1;
                }
            }
        }
    }
}