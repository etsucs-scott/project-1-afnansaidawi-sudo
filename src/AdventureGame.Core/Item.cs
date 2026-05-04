namespace AdventureGame.Core
{
    public abstract class Item
    {
        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <value>
        /// A string representing the name of the item, such as a weapon or potion.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the message displayed when the item is picked up or used.
        /// </summary>
        /// <value>
        /// A string containing the text shown to the player when interacting with the item.
        /// </value>
        public string PickupMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class with a specified name and pickup message.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="pickupMessage">The message displayed when the item is picked up or used.</param>
        protected Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }
    }
}
