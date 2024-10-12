using System;
using System.Windows.Forms;
using EditDefinition.Commands;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition
{
    public partial class TimePeriodPanel : UserControl
    {
        public TimePeriodPanel()
        {
            InitializeComponent();
            
            
        }
        
        private CommandManager _commandManager;
        private DefinitionsModel _model;
            
        public void DetachEvents()
        {
            _begin.ValueChanged -= BeginOnValueChanged;
            _end.ValueChanged -= EndOnValueChanged;
            
            _beginPlus1.Click -= BeginPlus1OnClick;
            _endPlus1.Click -= EndPlus1OnClick;
        }

        public void RefreshView(CommandManager commandManager, DefinitionsModel model)
        {
            _commandManager = commandManager;
            _model = model;

            var document = model.CurrentDocument;
            if (document == null)
            {
                _begin.Enabled = false;
                _end.Enabled = false;
                
                _beginPlus1.Enabled = false;
                _endPlus1.Enabled = false;
                return;
            }

            _begin.Enabled = true;
            _end.Enabled = true;
            
            _beginPlus1.Enabled = true;
            _endPlus1.Enabled = true;
            
            _begin.Value = document.Definition.Begin;
            _end.Value = document.Definition.End;
        }

        public void AttachEvents()
        {
            _begin.ValueChanged += BeginOnValueChanged;
            _end.ValueChanged += EndOnValueChanged;
            
            _beginPlus1.Click += BeginPlus1OnClick;
            _endPlus1.Click += EndPlus1OnClick;
        }

        private void EndOnValueChanged(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetDefinitionEndCommand(_model, _end.Value));
        }

        private void BeginOnValueChanged(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetDefinitionBeginCommand(_model, _begin.Value));
        }
        
        private void EndPlus1OnClick(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetDefinitionEndCommand(_model, _model.CurrentDocument.Definition.End.AddDays(1)));
        }

        private void BeginPlus1OnClick(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetDefinitionBeginCommand(_model, _model.CurrentDocument.Definition.Begin.AddDays(1)));
        }

    }
}
