using NueraVersion2.Domain.Interfaces;

namespace NueraVersion2.Domain.Commands
{
    /// <summary>
    /// Command to add an client's household item
    /// </summary>
    public class AddHouseholdItemForClientCommand : ICommand
    {
        public AddHouseholdItemForClientCommand(string name, uint value, string type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        // TODO - Document properties
        public string Name { get; }
        public uint Value { get; }
        public string Type { get; }
    }
}