using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            Events = new List<GameEvent>() { };
            
            GuessedLetterEvent guessdLetterEvent = new GuessedLetterEvent(gameData , letter);
            Events.Add(guessdLetterEvent);


            bool wrongGuess = true;
            for (int i = 0; i < gameData.Word.Length; i++)
            {
                bool dansLeMot = gameData.HasSameLetterAtIndex(letter, i);
                if (dansLeMot == true)
                {
                    
                    RevealLetterEvent revealLetterEvent = new RevealLetterEvent(gameData, letter, i);
                    Events.Add(revealLetterEvent);
                    wrongGuess = false;
                }
            }

            if (wrongGuess)
            {

                if(gameData.NbWrongGuesses == 6)
                {
                    LoseEvent loseEvent = new LoseEvent(gameData);
                    Events.Add(loseEvent);
                }
                WrongGuessEvent wrongGuessEvent = new WrongGuessEvent(gameData);
                Events.Add(wrongGuessEvent);

            }

            if (gameData.HasGuessedTheWord)
            {
                WinEvent winEvent = new WinEvent(gameData);
                Events.Add(winEvent);

              


            }

           

            



        }
    }
}
