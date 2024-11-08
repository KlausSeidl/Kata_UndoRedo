using System.Text.Json;

namespace KataUndoRedoImplDStahmer.Client.Model
{
    public class Definition : ICloneable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public Guid? DiscontinuedToId { get; set; }
        public Guid? ChangeFromDokId { get; set; }
        public Guid? CompositionId { get; set; }

        public object Clone()
        {
            return JsonSerializer.Deserialize<Definition>(JsonSerializer.Serialize(this))!;
        }
    }
}
