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
                if (_firstCommandUndone)
                {
                    return;
                }
                _commands[_commandIndex].Undo();
                _commandIndex--;
                _lastCommandRedone = false;
                if (_commandIndex < 0)
                {
                    _commandIndex = 0;
                    _firstCommandUndone = true;
                }
            }
            else
            {
                if (_lastCommandRedone)
                {
                    return;
                }
                _commandIndex++;
                if (_commandIndex >= _commands.Count)
                {
                    _commandIndex = _commands.Count - 1;
                    _lastCommandRedone = true;
                }
                else
                {
                    _commands[_commandIndex].Redo();
                    _firstCommandUndone = false;
                }
            }
        }
    }
}