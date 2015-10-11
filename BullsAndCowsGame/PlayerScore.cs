namespace BullsAndCows
{
    using System;

    /// <summary>
    /// Player score.
    /// </summary>
    public class PlayerScore : IComparable<PlayerScore>
    {
        /// <summary>
        /// Nick name.
        /// </summary>
        private string nickName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerScore" /> class.
        /// </summary>
        /// <param name="nickName">Nick name.</param>
        /// <param name="guesses">Guesses Integer.</param>
        public PlayerScore(string nickName, int guesses)
        {
            this.NickName = nickName;
            this.Guesses = guesses;
        }

        /// <summary>
        /// Gets or sets nick name.
        /// </summary>
        /// <value>String value.</value>
        public string NickName
        {
            get
            {
                return this.nickName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("NickName should have at least 1 symbol!");
                }
                else
                {
                    this.nickName = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets guesses.
        /// </summary>
        /// <value>Integer number.</value>
        public int Guesses { get; set; }

        /// <summary>
        /// Compares score.
        /// </summary>
        /// <param name="other">Other player score.</param>
        /// <returns>Returns integer.</returns>
        public int CompareTo(PlayerScore other)
        {
            if (this.Guesses.CompareTo(other.Guesses) == 0)
            {
                return this.NickName.CompareTo(other.NickName);
            }
            else
            {
                return this.Guesses.CompareTo(other.Guesses);
            }
        }

        /// <summary>
        /// Makes result to string.
        /// </summary>
        /// <returns>String value.</returns>
        public override string ToString()
        {
            string result = string.Format("{0,3}    | {1}", this.Guesses, this.NickName);
            return result;
        }
    }
}