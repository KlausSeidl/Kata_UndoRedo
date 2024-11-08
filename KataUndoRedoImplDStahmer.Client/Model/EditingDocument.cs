namespace KataUndoRedoImplDStahmer.Client.Model
{
    public class EditingDocument(Definition definition)
    {
        public DocumentState State { get; set; }
        public bool HasChanges { get; set; }

        public Definition Definition { get; set; } = definition;
    }

    public enum DocumentState
    {
        New,
        Update
    }
}
