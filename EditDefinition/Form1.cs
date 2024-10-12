using System;
using System.Linq;
using System.Windows.Forms;
using EditDefinition.Commands;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition
{
    public partial class Form1 : Form
    {
        private readonly CommandManager _commandManager = new CommandManager();
        private DefinitionsModel _model = new DefinitionsModel();
        readonly ToolTip _toolTipControl = new ToolTip();
        
        public Form1()
        {
            InitializeComponent();
            
            _commandManager.Clear();
            _commandManager.CommandFutureChanged += CommandManagerOnCommandFutureChanged;
            _commandManager.CommandHistoryChanged += CommandManagerOnCommandHistoryChanged;
            _commandManager.Executing += CommandManagerOnExecuting;
            _commandManager.Executed += CommandManagerOnExecuted;

            DetachEvents();
            RefreshView();
            AttachEvent();

            _undo.Enabled = false;
            _redo.Enabled = false;
            _definitionName.Enabled = false;
        }

        private void DetachEvents()
        {
            _definitionName.TextChanged -= DefinitionNameOnTextChanged;
            documentsDurationPanel1.DetachEvents();
            timePeriodPanel1.DetachEvents();
        }

        private void RefreshView()
        {
            _clear.Enabled = _model.EditingDocuments.Count > 0;
            _addToChangeSeries.Enabled = _model.EditingDocuments.Count > 0;
            _deleteDefinition.Enabled = _model.CanBeRemoved(_model.CurrentDocument);
            
            _definitionName.Enabled = _model.CurrentDocument != null;
            _definitionName.Text = _model.CurrentDocument?.Definition?.Name ?? string.Empty;
            
            documentsDurationPanel1.RefreshView(_commandManager, _model);
            timePeriodPanel1.RefreshView(_commandManager, _model);
        }

        private void AttachEvent()
        {
            _definitionName.TextChanged += DefinitionNameOnTextChanged;
            
            documentsDurationPanel1.AttachEvents();
            timePeriodPanel1.AttachEvents();
        }

        private void DefinitionNameOnTextChanged(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetDefinitionNameCommand(_model, _definitionName.Text));
        }
        
        private void CommandManagerOnExecuted(object sender, NotifyEventArgs e)
        {
            DetachEvents();
            RefreshView();
            AttachEvent();
        }

        private void CommandManagerOnExecuting(object sender, ExecutingEventArgs e)
        {
            
        }

        private void CommandManagerOnCommandHistoryChanged(object sender, EventArgs e)
        {
            UpdateUndoRedoButtons();  
        }

        private void CommandManagerOnCommandFutureChanged(object sender, EventArgs e)
        {
            UpdateUndoRedoButtons();
        }

        private void UpdateUndoRedoButtons()
        {
            var undoCommand = _commandManager.GetUndoCommands().FirstOrDefault();
            var redoCommand = _commandManager.GetRedoCommands().FirstOrDefault();

            if (undoCommand != null)
            {
                _undo.Enabled = true;
                _toolTipControl.SetToolTip(_undo, $"Undo '{undoCommand.Description}'");
            }
            else
            {
                _undo.Enabled = false;
                _toolTipControl.SetToolTip(_undo, null);
            }
            
            if (redoCommand != null)
            {
                _redo.Enabled = true;
                _toolTipControl.SetToolTip(_redo, $"Redo '{redoCommand.Description}'");
            }
            else
            {
                _redo.Enabled = false;
                _toolTipControl.SetToolTip(_redo, null);
            }
        }

        private void _addDefinition_Click(object sender, EventArgs e)
        {
            _commandManager.Execute(new AddNewDefinitionCommand(_model));
        }

        private void _undo_Click(object sender, EventArgs e)
        {
            _commandManager.Undo();
        }

        private void _redo_Click(object sender, EventArgs e)
        {
            _commandManager.Redo();
        }

        private void _clear_Click(object sender, EventArgs e)
        {
            _commandManager.Clear();
        }

        private void _addToChangeSeries_Click(object sender, EventArgs e)
        {
            _commandManager.Execute(new AddNewDefinitionToChangeSeriesCommand(_model));
        }

        private void _deleteDefinition_Click(object sender, EventArgs e)
        {
            _commandManager.Execute(new RemoveCurrentDefinitionCommand(_model));
        }
    }
}
