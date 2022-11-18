namespace ShelterBuddy.CodePuzzle.Core.Entities
{
    public class AuditStamper : IAuditStamper
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public string Name => "Test";
    }
}
