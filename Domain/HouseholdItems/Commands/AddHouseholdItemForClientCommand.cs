using Main.Domain.Interfaces;

namespace Main.Domain.HouseholdItems.Commands
{
    /// <summary>
    /// Command to add an client's household item
    /// </summary>
    public class AddHouseholdItemForClientCommand : ICommand
    {
        public AddHouseholdItemForClientCommand(string name, uint value, string category)
        {
            Name = name;
            Value = value;
            Category = category;
        }

        // TODO - Document properties
        public string Name { get; }
        public uint Value { get; }
        public string Category { get; }
    }
}