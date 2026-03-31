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
            GuessedLetterEvent guessdLetterEvent = new GuessedLetterEvent(gameData , letter);



            for(int i = 0; i < gameData.Word.Length; i++)
            {
                bool dansLeMot = gameData.HasSameLetterAtIndex(letter, i);
                if(dansLeMot == true)
                {
                    RevealLetterEvent revealLetterEvent = new RevealLetterEvent(gameData, letter, i);
                    continue;
                }

                else if(i == gameData.Word.Length-1 && dansLeMot == false)
                {
                    WrongGuessEvent wrongGuessEvent = new WrongGuessEvent(gameData);
                }
            }

                gameData.GuessedLetters.Add(letter);

        }
    }
}
