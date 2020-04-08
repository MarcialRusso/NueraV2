namespace Main.Models.HouseholdItems
{
    /// <summary>
    /// Represents and household item added by the client 
    /// </summary>
    public class HouseholdItem
    {
        /// <summary>
        /// The item name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The item given insurable value
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// The item category
        /// </summary>
        public string Category { get; set; }
    }
}