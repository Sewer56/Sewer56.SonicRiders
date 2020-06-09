using System.ComponentModel;
using System.Runtime.CompilerServices;
using Reloaded.Hooks.Definitions;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Tasks;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;

namespace Sewer56.SonicRiders.Utility
{
    /// <summary>
    /// Used to track pointers to various common tasks.
    /// You should check if the pointers are not null before using.
    /// </summary>
    public unsafe class TaskTracker
    {
        /// <summary>
        /// The last executed task.
        /// </summary>
        public Tasks LastTask { get; private set; }

        public Task<CharacterSelect, CharacterSelectTaskState>* CharacterSelect { get; private set; }
        public Task<CourseSelect, CourseSelectTaskState>* CourseSelect { get; private set; }
        public Task<TitleSequence, TitleSequenceTaskState>* TitleSequence { get; private set; }
        public Task<RaceRules, RaceRulesTaskState>* RaceRules { get; private set; }
        public Task<byte, RaceTaskState>* Race { get; private set; }
        public Task<MessageBox, MessageBoxTaskState>* MessageBox { get; private set; }

        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onRaceHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onCourseSelectHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onCharaSelectHook;
        private IHook<Functions.Functions.TitleSequenceTaskFn> _onTitleSequenceHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _messageBoxHook;
        private IHook<Functions.Functions.DefaultTaskFnWithReturn> _onRaceSettingsHook;

        public TaskTracker()
        {
            _onRaceHook = Functions.Functions.UnknownRaceTask.Hook(OnRaceTask).Activate();
            _onTitleSequenceHook = Functions.Functions.TitleSequenceTask.Hook(OnTitleSequenceTask).Activate();
            _onCharaSelectHook = Functions.Functions.CharaSelectTask.Hook(OnCharacterSelectTask).Activate();
            _onCourseSelectHook = Functions.Functions.CourseSelectTask.Hook(OnCourseSelectTask).Activate();
            _onRaceSettingsHook = Functions.Functions.RaceSettingTask.Hook(OnRaceSettingsTask).Activate();
            _messageBoxHook = Functions.Functions.MessageBoxTask.Hook(OnMessageBoxTask).Activate();
        }

        private int OnMessageBoxTask()
        {
            LastTask = Tasks.MessageBox;
            MessageBox = (Task<MessageBox, MessageBoxTaskState>*) (*State.CurrentTask);
            return _messageBoxHook.OriginalFunction();
        }

        private int OnRaceSettingsTask()
        {
            LastTask = Tasks.RaceRules;
            RaceRules = (Task<RaceRules, RaceRulesTaskState>*) *State.CurrentTask;
            return _onRaceSettingsHook.OriginalFunction();
        }

        private int OnCourseSelectTask()
        {
            LastTask = Tasks.CourseSelect;
            CourseSelect = (Task<CourseSelect, CourseSelectTaskState>*) *State.CurrentTask;
            return _onCourseSelectHook.OriginalFunction();
        }

        private int OnCharacterSelectTask()
        {
            LastTask = Tasks.CharacterSelect;
            CharacterSelect = (Task<CharacterSelect, CharacterSelectTaskState>*) *State.CurrentTask;
            return _onCharaSelectHook.OriginalFunction();
        }

        private int OnTitleSequenceTask(int a1, int a2)
        {
            LastTask = Tasks.TitleSequence;
            TitleSequence = (Task<TitleSequence, TitleSequenceTaskState>*) *State.CurrentTask;
            return _onTitleSequenceHook.OriginalFunction(a1, a2);
        }

        private int OnRaceTask()
        {
            LastTask = Tasks.Race;
            Race = (Task<byte, RaceTaskState>*) *State.CurrentTask;
            return _onRaceHook.OriginalFunction();
        }

        /// <summary>
        /// Disables the state tracker.
        /// </summary>
        public void Disable()
        {
            _onTitleSequenceHook.Disable();
            _onRaceHook.Disable();
        }

        /// <summary>
        /// Re-enables the state tracker.
        /// </summary>
        public void Enable()
        {
            _onTitleSequenceHook.Enable();
            _onRaceHook.Enable();
        }
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
