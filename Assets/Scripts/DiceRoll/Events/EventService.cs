using DiceRoll.Level;
using Utilities.Events;

namespace DiceRoll.Events
{
    public class EventService
    {
        #region GameEvent
        public EventController<LevelType> OnGameStart { get; private set; }
    
        public EventController<bool> OnGameOver { get; private set; }
        #endregion

        #region LevelEvent

        public EventController<LevelType> OnLevelStart { get; private set; }
        public EventController<bool> OnLevelOver { get; private set; }
        #endregion
        public EventService()
        {
            OnLevelStart = new EventController<LevelType>();
            OnLevelOver = new EventController<bool>();

            OnGameStart = new EventController<LevelType>();
            OnGameOver = new EventController<bool>();
        }

    }
}