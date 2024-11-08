using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditDefinition.Model;

namespace EditDefinition
{
    public partial class Form1 : Form
    {
        private DefinitionsModel _definitionsModel;
        private string _newDefinitionName = string.Empty;
        private CommandManager _commandManager;
        
        public Form1()
        {
            InitializeComponent();
            _definitionsModel = new DefinitionsModel();
            _commandManager = new CommandManager();
        }

        private void _addDefinition_Click(object sender, EventArgs e)
        {
            ICommand addDefinitionCommand = new AddDefinitionsCommand(_definitionsModel, _newDefinitionName);
            addDefinitionCommand.Execute();
            _commandManager.AddCommand(addDefinitionCommand);
            
            RefreshListOfDefinitions();
        }

        private void RefreshListOfDefinitions()
        {
            documentsDurationPanel1.ShowDefinitions(_definitionsModel.EditingDocuments.Select(x => x.Definition.Name).ToArray());
        }

        private void _definitionName_TextChanged(object sender, EventArgs e)
        {
            _newDefinitionName = (sender as TextBox)?.Text;
        }

        private void _undo_Click(object sender, EventArgs e)
        {
            _commandManager.StepThroughCommands(true);
            
            RefreshListOfDefinitions();
        }

        private void _redo_Click(object sender, EventArgs e)
        {
            _commandManager.StepThroughCommands(false);
            
            RefreshListOfDefinitions();
        }
    }
}
