namespace DurakSrcLibrary
{
    /// <summary>
    /// Current Player status during the game
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// default status
        /// </summary>
        None,

        /// <summary>
        /// Player is Attacking
        /// </summary>
        Attacking,

        /// <summary>
        /// Player is Defending
        /// </summary>
        Defending,

        /// <summary>
        /// Player has Won the Game
        /// </summary>
        Won,

        /// <summary>
        /// Player has lost the Game
        /// </summary>
        Lost
    }
}
