namespace BullsAndCows
{
    using System;

    public class PlayerScore : IComparable<PlayerScore>
    {
        private string nickName;

        public PlayerScore(string nickName, int guesses)
        {
            this.NickName = nickName;
            this.Guesses = guesses;
        }

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

        public int Guesses { get; set; }

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

        public override string ToString()
        {
            string result = string.Format("{0,3}    | {1}", this.Guesses, this.NickName);
            return result;
        }
    }
}