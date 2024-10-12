using System;
using System.Windows.Forms;
using EditDefinition.Commands;
using EditDefinition.Model;
using Skc.BestPractices.CommandManager;

namespace EditDefinition
{
    public partial class DocumentsDurationPanel : UserControl
    {
        public DocumentsDurationPanel()
        {
            InitializeComponent();
        }
        
        private CommandManager _commandManager;
        private DefinitionsModel _model;
            
        public void DetachEvents()
        {
            _definitions.SelectedIndexChanged -= DefinitionsOnSelectedIndexChanged;
        }

        public void RefreshView(CommandManager commandManager, DefinitionsModel model)
        {
            _commandManager = commandManager;
            _model = model;
            
            _definitions.Items.Clear();

            DocumentItem current = null;
            foreach (var document in model.EditingDocuments)
            {
                var item = new DocumentItem(document);
                if (document == model.CurrentDocument)
                {
                    current = item;
                }
                _definitions.Items.Add(item);
                _definitions.SelectedItem = current;
            }
        }

        public void AttachEvents()
        {
            _definitions.SelectedIndexChanged += DefinitionsOnSelectedIndexChanged;
        }

        private void DefinitionsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            _commandManager.Execute(new SetCurrentDocumentCommand(_model, ((DocumentItem)_definitions.SelectedItem).Document));
        }

        private class DocumentItem
        {
            public EditingDocument Document { get; }

            public DocumentItem(EditingDocument document)
            {
                Document = document;
            }

            public override string ToString()
            {
                return $"{Document.Definition.Name} {Document.Definition.Begin:G} - {Document.Definition.End:G}";
            }
        }
    }
}
