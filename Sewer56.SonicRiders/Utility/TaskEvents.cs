using Reloaded.Hooks.Definitions;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Tasks;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;

namespace Sewer56.SonicRiders.Utility
{
    /// <summary>
    /// Provides events for when certain common tasks are executed.
    /// </summary>
    public unsafe class TaskEvents
    {
        /// <summary>
        /// The last executed task.
        /// This is provided only for convenience, for manipulating task specific data, consider subscribing to the events.
        /// </summary>
        public Tasks LastTask { get; private set; }

        public event RaceFn OnRace;
        public event TitleSequenceFn OnTitleSequence;
        public event CharacterSelectFn OnCharacterSelect;
        public event CourseSelectFn OnCourseSelect;
        public event RaceSettingsFn OnRaceSettings;
        public event MessageBoxFn OnMessageBox;

        public event RaceFn AfterRace;
        public event TitleSequenceFn AfterTitleSequence;
        public event CharacterSelectFn AfterCharacterSelect;
        public event CourseSelectFn AfterCourseSelect;
        public event RaceSettingsFn AfterRaceSettings;
        public event MessageBoxFn AfterMessageBox;

        // Last known pointers for each task. Provided for brevity.
        // These are not guaranteed to be valid, so exercise caution.
        // I would advise against using these unless you feel it is absolutely safe.
        // My advice is to only use them if a task is a child of another task. i.e. access TitleSequence if in any other menu event.
        public Task<CharacterSelect, CharacterSelectTaskState>* CharacterSelect { get; private set; }
        public Task<CourseSelect, CourseSelectTaskState>* CourseSelect { get; private set; }
        public Task<TitleSequence, TitleSequenceTaskState>* TitleSequence { get; private set; }
        public Task<RaceRules, RaceRulesTaskState>* RaceRules { get; private set; }
        public Task<byte, RaceTaskState>* Race { get; private set; }
        public Task<MessageBox, MessageBoxTaskState>* MessageBox { get; private set; }

        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onRaceHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onCourseSelectHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onCharaSelectHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onTitleSequenceHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _messageBoxHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onRaceSettingsHook;

        public TaskEvents()
        {
            _onRaceHook = Functions.Functions.UnknownRaceTask.Hook(OnRaceTask).Activate();
            _onTitleSequenceHook = Functions.Functions.TitleSequenceTask.Hook(OnTitleSequenceTask).Activate();
            _onCharaSelectHook = Functions.Functions.CharaSelectTask.Hook(OnCharacterSelectTask).Activate();
            _onCourseSelectHook = Functions.Functions.CourseSelectTask.Hook(OnCourseSelectTask).Activate();
            _onRaceSettingsHook = Functions.Functions.RaceSettingTask.Hook(OnRaceSettingsTask).Activate();
            _messageBoxHook = Functions.Functions.MessageBoxTask.Hook(OnMessageBoxTask).Activate();
        }

        private byte OnMessageBoxTask()
        {
            LastTask = Tasks.MessageBox;
            MessageBox = (Task<MessageBox, MessageBoxTaskState>*) (*State.CurrentTask);

            OnMessageBox?.Invoke(MessageBox);
            var result = _messageBoxHook.OriginalFunction();
            AfterMessageBox?.Invoke(MessageBox);
            return result;
        }

        private byte OnRaceSettingsTask()
        {
            LastTask = Tasks.RaceRules;
            RaceRules = (Task<RaceRules, RaceRulesTaskState>*) *State.CurrentTask;
            OnRaceSettings?.Invoke(RaceRules);
            var result = _onRaceSettingsHook.OriginalFunction();
            AfterRaceSettings?.Invoke(RaceRules);
            return result;
        }

        private byte OnCourseSelectTask()
        {
            LastTask = Tasks.CourseSelect;
            CourseSelect = (Task<CourseSelect, CourseSelectTaskState>*) *State.CurrentTask;
            OnCourseSelect?.Invoke(CourseSelect);
            var result = _onCourseSelectHook.OriginalFunction();
            AfterCourseSelect?.Invoke(CourseSelect);
            return result;
        }

        private byte OnCharacterSelectTask()
        {
            LastTask = Tasks.CharacterSelect; 
            CharacterSelect = (Task<CharacterSelect, CharacterSelectTaskState>*) *State.CurrentTask;
            OnCharacterSelect?.Invoke(CharacterSelect);
            var result = _onCharaSelectHook.OriginalFunction();
            AfterCharacterSelect?.Invoke(CharacterSelect);
            return result;
        }

        private byte OnTitleSequenceTask()
        {
            LastTask = Tasks.TitleSequence;
            TitleSequence = (Task<TitleSequence, TitleSequenceTaskState>*) *State.CurrentTask;
            OnTitleSequence?.Invoke(TitleSequence);
            var result = _onTitleSequenceHook.OriginalFunction();
            AfterTitleSequence?.Invoke(TitleSequence);
            return result;
        }

        private byte OnRaceTask()
        {
            ResetMenu();
            LastTask = Tasks.Race;
            Race = (Task<byte, RaceTaskState>*) *State.CurrentTask;
            OnRace?.Invoke(Race);
            var result = _onRaceHook.OriginalFunction();
            AfterRace?.Invoke(Race);
            return result;
        }

        /// <summary>
        /// Resets the pointers.
        /// </summary>
        public void Reset()
        {
            ResetMenu();
            Race = null;
        }

        /// <summary>
        /// Resets the menu pointers.
        /// </summary>
        public void ResetMenu()
        {
            CharacterSelect = null;
            CourseSelect = null;
            TitleSequence = null;
            RaceRules = null;
            MessageBox = null;
        }

        /// <summary>
        /// Disables the state tracker.
        /// </summary>
        public void Disable()
        {
            _onTitleSequenceHook.Disable();
            _onRaceHook.Disable();
            _onCharaSelectHook.Disable();
            _onCourseSelectHook.Disable();
            _onRaceSettingsHook.Disable();
            _messageBoxHook.Disable();
        }

        /// <summary>
        /// Re-enables the state tracker.
        /// </summary>
        public void Enable()
        {
            _onTitleSequenceHook.Enable();
            _onRaceHook.Enable(); 
            _onCharaSelectHook.Enable();
            _onCourseSelectHook.Enable();
            _onRaceSettingsHook.Enable();
            _messageBoxHook.Enable();
        }

        public delegate void RaceFn(Task<byte, RaceTaskState>* task);
        public delegate void TitleSequenceFn(Task<TitleSequence, TitleSequenceTaskState>* task);
        public delegate void CharacterSelectFn(Task<CharacterSelect, CharacterSelectTaskState>* task);
        public delegate void CourseSelectFn(Task<CourseSelect, CourseSelectTaskState>* task);
        public delegate void RaceSettingsFn(Task<RaceRules, RaceRulesTaskState>* task);
        public delegate void MessageBoxFn(Task<MessageBox, MessageBoxTaskState>* task);
    }

    public enum Tasks
    {
        Null,
        CharacterSelect,
        TitleSequence,
        CourseSelect,
        RaceRules,
        Race,
        MessageBox
    }
}
