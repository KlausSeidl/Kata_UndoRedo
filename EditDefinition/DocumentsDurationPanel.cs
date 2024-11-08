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
    public partial class DocumentsDurationPanel : UserControl
    {
        public DocumentsDurationPanel()
        {
            InitializeComponent();
        }

        public void ShowDefinitions(object[] definitions)
        {
            _definitions.Items.Clear();
            _definitions.Items.AddRange(definitions);
        }
    }
}
