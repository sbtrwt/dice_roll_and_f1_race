using Utilities.Events;

namespace DiceRoll.Events
{
    public class EventService
    {
        #region GameEvent
        public EventController<int> OnGameStart { get; private set; }
    
        public EventController<bool> OnGameOver { get; private set; }
        #endregion
        #region LevelEvent
        public EventController<int> OnLevelStart { get; private set; }
        public EventController<bool> OnLevelOver { get; private set; }
        #endregion
        public EventService()
        {
            OnGameStart = new EventController<int>();
            OnGameOver = new EventController<bool>();
        }

    }
}