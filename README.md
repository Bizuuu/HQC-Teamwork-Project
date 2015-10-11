# Refactoring Documentation for "Bull-And-Cows-1" HQC Teamwork Project

### Structural Improvements:
1. Created folder Contracts holding the interfaces:
    - ICommandProcessor
    - IMessage
    - IPrinter
    - IRandomNumberProvider
2. Created folder Messages holding related classes like:
    - abstract Message
    - Message factory
    - OneParameterMessage
    - TwoParameterMessage
    - SimpleMessage
    - Printer
3. Created folder CommandProcessors holding the different classes processing different commands:
    - Abstract CommandProcessor
    - Exit, Help, Number, Restart, Top, Invalid CommandProcessors
4. Created folder SortingAlgorithms holding the different algorithms used for sorting the scoreboard.
5. Created new project for the unit tests
    - the tests for each class are separated into different files

### Naming Improvements
1. Renamed "numberForGuessString" to "NumberForGuess".
2. Renamed "count1" to "CheatAttemptCounter".
3. Renamed "count2" to "GuessAttemptCounter".
4. Renamed "PlayerInfo" to "PlayerScore".
5. Renamed "cows_buls" class to "BullsAndCowsGame".
6. Changed the name of the solution from "cows_buls" to "Bulls-And-Cows-Game".

### Code extractions
1. Extracted class BullsAndCowsCounter, which counts the resulting bulls and cows.
    - Moved all related methods to it (CountBullsAndCows, CountCows, CountBulls, CountCowsForCurrentDigit, etc.)
2. Extracted class BullsAndCowsResult holding information about the Bulls and Cows on the current turn of the game.
3. Extracted class RandomNumberProvider, whose job is to return random numbers in a given range.
4. Extracted classes for processing commands and removed unnecessary methods from BullsAndCowsGame class.
5. Extracted class ScoreBoard and moved all related methods to it.
6. Extracted factory and message classes, as well as printer to handle all messages and objects needed to be printer

### Formatting Improvements
1. Removed unnecessary empty lines
    - Before
        ~~~c#
        public string NickName
        {
            get
            {
    
    
                return nickName;
            }
            set
            {
                if (nickName == String.Empty)
                {
                    throw new ArgumentException("NickName should have at least 1 symbol!");
                }
                else
                {
                    nickName = value;
                }
            }
        }
        ~~~
    - After
        ~~~c#
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

                this.nickName = value;
            }
        }
        ~~~
2. Fixed inconsistent line endings
3. Removed unnecessary variable "c" and method

### StyleCop warnings fixed
1. Included "this" everywhere
2. Documented everything
3. Added access modifiers
4. Ordered usings alphabetically for easier following
5. Added empty lines where necessary

### Other Improvements
1. Introduced constants
    - Examples
        ```
        private const byte GuessNumberLength = 4;
        private const byte AllDigitsCount = 10;
        ```
        ```
        public const string FilePath = "../../Common/scores.txt";
        ```

### Design Pattern Implementations
1. Singleton:
    - RandomNumberProvider - guarantees a single instance when creating a RandomNumberProvider
    - ScoreBoard - allows for only one ScoreBoard
2. Lazy Initialization:
    - ScoreBoard - creation is delayed until needed
    - RandomNumberProvided - delayed until needed
3. Simple Factory:
    - MessageFactory - Creating different Messages based on an enum
4. Composite:
    - Message - allows SimpleMessage, OneParameterMessage and TwoParameterMessage to be treated in the same way
5. Facade:
    - BullsAndCowsArcade - creates, initializes, prepares all needed instances and starts the game
6. Chain of Responsibility:
    - CommandProcessor - commands are passed from one processor to another allowing for easy extension of command handling
7. Strategy:
    - In BullsAndCowsGame constructor, Interfaces are passed as dependencies, allowing the user to implement different logic for them
    - Sorter - the sorting algorithm of the scoreboard can easily be exchanged for another

### Examples of followed principles
1. Single Responsibility Principle
    - CommandProcessor - each processor handles on it's own command or passes to the next
    - PlayerScore - only holds information about the score of the player
    - BullsAndCowsResult - only holds the current result
    - BullsAndCowsCounter - only calculates the result based on the number and the guess
2. Open/Close Principle
    - CommandProcessor - easily extended by creating new CommandProcessors. No need to edit the other processors
    - Sorter - easy way to add new algorithms for sorting which can be used in the scoreboard
3. Liskov Substitution Principle
    - CommandProcessors
    - Sorters
4. Interface Segregation Principle
    - ICommandProcessor - implementing only the vital parts of the Chain of Responsibility pattern
    - IMessage - no unneeded methods
    - IRandomNumberProvider - small interface with only the most important
5. Dependency Inversion Principle
    - BullsAndCowsGame - outside dependencies are passed through the constructor