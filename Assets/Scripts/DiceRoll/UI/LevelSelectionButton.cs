using DiceRoll.Events;
using DiceRoll.Level;
using UnityEngine;
using UnityEngine.UI;

namespace DiceRoll.UI
{
    public class LevelSelectionButton : MonoBehaviour
    {
        [SerializeField] private LevelType levelType;
        [SerializeField] private Button levelButton;
        private EventService eventService;

        private void Start() => levelButton.onClick.AddListener(OnMapButtonClicked);
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void OnMapButtonClicked() => eventService.OnLevelStart.InvokeEvent(levelType);
    }
}
