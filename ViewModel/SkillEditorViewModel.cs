using DynamicData;
using Microsoft.Win32;
using NSC_Toolbox.Model;
using NSC_Toolbox.Properties;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Linq;
using XFBIN_LIB;
using XFBIN_LIB.XFBIN;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace NSC_Toolbox.ViewModel {
    public class SkillEditorViewModel : INotifyPropertyChanged {
        public string filePath;
        public XFBIN_READER XfbinReader = new XFBIN_READER();

        public ObservableCollection<string> SkillType_List { get; set; }
        public ObservableCollection<string> Attribute_List { get; set; }
        public ObservableCollection<string> Event_List { get; set; }
        public ObservableCollection<string> Decal_List { get; set; }
        public ObservableCollection<string> ActionType_List { get; set; }
        public ObservableCollection<string> Command_List { get; set; }
        public ObservableCollection<string> PriorityCategory_List { get; set; }
        public ObservableCollection<string> ShotType_List { get; set; }
        public ObservableCollection<SkillEntryModel> SkillList { get; set; }
        private SkillEntryModel _selectedSkill;
        public SkillEntryModel SelectedSkill {
            get { return _selectedSkill; }
            set {
                _selectedSkill = value;
                if (value is not null) {
                    ChunkName_field = value.ChunkName;
                    SkillTypeIndex_field = Program.ProjectileType.IndexOf(value.SkillType);
                    ProjectileHitEntry = value.HitEntry;
                    FilePathList = value.FilePathList;
                    ClassName_field = value.ClassName;
                    ActionList = value.ActionList;
                }

                OnPropertyChanged("SelectedSkill");
            }
        }
        private int _selectedSkillIndex;
        public int SelectedSkillIndex {
            get { return _selectedSkillIndex; }
            set {
                _selectedSkillIndex = value;
                OnPropertyChanged("SelectedSkillIndex");
            }
        }

        private ObservableCollection<SkillActionModel> _actionList;
        public ObservableCollection<SkillActionModel> ActionList {
            get { return _actionList; }
            set {
                _actionList = value;
                OnPropertyChanged("ActionList");
            }
        }

        private SkillActionModel _selectedAction;
        public SkillActionModel SelectedAction {
            get { return _selectedAction; }
            set {
                _selectedAction = value;
                if (value is not null) {
                    ActionID_field = value.ActionID;
                    ActionType_field = value.ActionType;
                    AnimationEntry = value.AnimationEntry;
                    ActionHitEntry = value.HitEntry;
                    Gravity_field = value.Gravity;
                    Restitution_field = value.Restitution;
                    RandomDirection_field = value.RandomDirection;
                    RandomRoll_field = value.RandomRoll;
                    ViewingAngle_field = value.ViewingAngle;
                    Friction_field = value.Friction;
                    Frequency_x_field = value.Frequency_x;
                    Frequency_y_field = value.Frequency_y;
                    Frequency_z_field = value.Frequency_z;
                    BankStrong_field = value.BankStrong;
                    BankRollMax_field = value.BankRollMax;
                    BankSpring_field = value.BankSpring;
                    Amplitude_x_field = value.Amplitude_x;
                    Amplitude_y_field = value.Amplitude_y;
                    Amplitude_z_field = value.Amplitude_z;
                    Velocity_field = value.Velocity;
                    VelocityRandomize_field = value.VelocityRandomize;
                    Inductivity_field = value.Inductivity;
                    CharacterHitDisable_field = value.CharacterHitDisable;
                    WorldHitDisable_field = value.WorldHitDisable;
                    NumLimitNum_field = value.NumLimitNum;
                    NumLimitEnable_field = value.NumLimitEnable;
                    HitAttach_field = value.HitAttach;
                    HitAttach2_field = value.HitAttach2;
                    HitAttach3_field = value.HitAttach3;
                    HitAttach4_field = value.HitAttach4;
                    HitAttach5_field = value.HitAttach5;
                    FixedUp_field = value.FixedUp;
                    SkillHitMine_field = value.SkillHitMine;
                    AtkHitMine_field = value.AtkHitMine;
                    State_field = value.State;
                    EventList = value.EventList;
                    SoundList = value.SoundList;
                    SkillHomingEntry = value.SkillHomingEntry;
                    SkillDecalEntry = value.SkillDecalEntry;
                    SkillCameraQuakeEntry = value.SkillCameraQuakeEntry;
                }

                OnPropertyChanged("SelectedAction");
            }
        }
        private int _selectedActionIndex;
        public int SelectedActionIndex {
            get { return _selectedActionIndex; }
            set {
                _selectedActionIndex = value;
                OnPropertyChanged("SelectedActionIndex");
            }
        }

        private int _actionID;
        public int ActionID_field {
            get { return _actionID; }
            set {
                _actionID = value;
                OnPropertyChanged("ActionID_field");
            }
        }
        private int _actionTypeIndex;
        public int ActionTypeIndex_field {
            get { return _actionTypeIndex; }
            set {
                _actionTypeIndex = value;
                OnPropertyChanged("ActionTypeIndex_field");
            }
        }
        private string _actionType;
        public string ActionType_field {
            get { return _actionType; }
            set {
                _actionType = value;
                if (value is not null) {
                    ActionTypeIndex_field = Program.ProjectileActionType.IndexOf(value);
                    if (ActionTypeIndex_field == -1)
                        ActionTypeIndex_field = 0;
                } else {
                    ActionTypeIndex_field = 0;
                }

                OnPropertyChanged("ActionType_field");
            }
        }
        //values
        private float _gravity;
        public float Gravity_field {
            get { return _gravity; }
            set {
                _gravity = value;
                OnPropertyChanged("Gravity_field");
            }
        }
        private float _restitution;
        public float Restitution_field {
            get { return _restitution; }
            set {
                _restitution = value;
                OnPropertyChanged("Restitution_field");
            }
        }
        private float _randomDirection;
        public float RandomDirection_field {
            get { return _randomDirection; }
            set {
                _randomDirection = value;
                OnPropertyChanged("RandomDirection_field");
            }
        }
        private float _randomRoll;
        public float RandomRoll_field {
            get { return _randomRoll; }
            set {
                _randomRoll = value;
                OnPropertyChanged("RandomRoll_field");
            }
        }
        private float _viewingAngle;
        public float ViewingAngle_field {
            get { return _viewingAngle; }
            set {
                _viewingAngle = value;
                OnPropertyChanged("ViewingAngle_field");
            }
        }
        private float _friction; //max 1, min 0
        public float Friction_field {
            get { return _friction; }
            set {
                _friction = value;
                OnPropertyChanged("Friction_field");
            }
        }
        private float _frequency_x;
        public float Frequency_x_field {
            get { return _frequency_x; }
            set {
                _frequency_x = value;
                OnPropertyChanged("Frequency_x_field");
            }
        }
        private float _frequency_y;
        public float Frequency_y_field {
            get { return _frequency_y; }
            set {
                _frequency_y = value;
                OnPropertyChanged("Frequency_y_field");
            }
        }
        private float _frequency_z;
        public float Frequency_z_field {
            get { return _frequency_z; }
            set {
                _frequency_z = value;
                OnPropertyChanged("Frequency_z_field");
            }
        }
        private float _bankStrong;
        public float BankStrong_field {
            get { return _bankStrong; }
            set {
                _bankStrong = value;
                OnPropertyChanged("BankStrong_field");
            }
        }
        private float _bankSpring; //max 1, min 0
        public float BankSpring_field {
            get { return _bankSpring; }
            set {
                _bankSpring = value;
                OnPropertyChanged("BankSpring_field");
            }
        }
        private float _bankRollMax;
        public float BankRollMax_field {
            get { return _bankRollMax; }
            set {
                _bankRollMax = value;
                OnPropertyChanged("BankRollMax_field");
            }
        }
        private float _amplitude_x;
        public float Amplitude_x_field {
            get { return _amplitude_x; }
            set {
                _amplitude_x = value;
                OnPropertyChanged("Amplitude_x_field");
            }
        }
        private float _amplitude_y;
        public float Amplitude_y_field {
            get { return _amplitude_y; }
            set {
                _amplitude_y = value;
                OnPropertyChanged("Amplitude_y_field");
            }
        }
        private float _amplitude_z;
        public float Amplitude_z_field {
            get { return _amplitude_z; }
            set {
                _amplitude_z = value;
                OnPropertyChanged("Amplitude_z_field");
            }
        }
        private float _velocity;
        public float Velocity_field {
            get { return _velocity; }
            set {
                _velocity = value;
                OnPropertyChanged("Velocity_field");
            }
        }
        private float _velocityRandomize;
        public float VelocityRandomize_field {
            get { return _velocityRandomize; }
            set {
                _velocityRandomize = value;
                OnPropertyChanged("VelocityRandomize_field");
            }
        }
        private float _inductivity;
        public float Inductivity_field {
            get { return _inductivity; }
            set {
                _inductivity = value;
                OnPropertyChanged("Inductivity_field");
            }
        }
        private bool _characterHitDisable;
        public bool CharacterHitDisable_field {
            get { return _characterHitDisable; }
            set {
                _characterHitDisable = value;
                OnPropertyChanged("CharacterHitDisable_field");
            }
        }
        private bool _worldHitDisable;
        public bool WorldHitDisable_field {
            get { return _worldHitDisable; }
            set {
                _worldHitDisable = value;
                OnPropertyChanged("WorldHitDisable_field");
            }
        }
        private int _numLimitNum;
        public int NumLimitNum_field {
            get { return _numLimitNum; }
            set {
                _numLimitNum = value;
                OnPropertyChanged("NumLimitNum_field");
            }
        }
        private bool _numLimitEnable;
        public bool NumLimitEnable_field {
            get { return _numLimitEnable; }
            set {
                _numLimitEnable = value;
                OnPropertyChanged("NumLimitEnable_field");
            }
        }
        private string _hitAttach;
        public string HitAttach_field {
            get { return _hitAttach; }
            set {
                _hitAttach = value;
                OnPropertyChanged("HitAttach_field");
            }
        }
        private string _hitAttach2;
        public string HitAttach2_field {
            get { return _hitAttach2; }
            set {
                _hitAttach2 = value;
                OnPropertyChanged("HitAttach2_field");
            }
        }
        private string _hitAttach3;
        public string HitAttach3_field {
            get { return _hitAttach3; }
            set {
                _hitAttach3 = value;
                OnPropertyChanged("HitAttach3_field");
            }
        }
        private string _hitAttach4;
        public string HitAttach4_field {
            get { return _hitAttach4; }
            set {
                _hitAttach4 = value;
                OnPropertyChanged("HitAttach4_field");
            }
        }
        private string _hitAttach5;
        public string HitAttach5_field {
            get { return _hitAttach5; }
            set {
                _hitAttach5 = value;
                OnPropertyChanged("HitAttach5_field");
            }
        }
        private bool _fixedUp;
        public bool FixedUp_field {
            get { return _fixedUp; }
            set {
                _fixedUp = value;
                OnPropertyChanged("FixedUp_field");
            }
        }
        private bool _skillHitMine;
        public bool SkillHitMine_field {
            get { return _skillHitMine; }
            set {
                _skillHitMine = value;
                OnPropertyChanged("SkillHitMine_field");
            }
        }
        private bool _atkHitMine;
        public bool AtkHitMine_field {
            get { return _atkHitMine; }
            set {
                _atkHitMine = value;
                OnPropertyChanged("AtkHitMine_field");
            }
        }
        private string _state;
        public string State_field {
            get { return _state; }
            set {
                _state = value;
                OnPropertyChanged("State_field");
            }
        }
        private SkillAnimationModel _animationEntry;
        public SkillAnimationModel AnimationEntry {
            get { return _animationEntry; }
            set {
                _animationEntry = value;
                if (value is not null) {

                    KeepPreviousAnimation_field = value.KeepPreviousAnimation;
                    AnimationChunkName_field = value.AnimationChunkName;
                }
                OnPropertyChanged("AnimationEntry");
            }
        }
        private ObservableCollection<SkillEventModel> _eventList;
        public ObservableCollection<SkillEventModel> EventList {
            get { return _eventList; }
            set {
                _eventList = value;
                OnPropertyChanged("EventList");
            }
        }
        private ObservableCollection<SkillSoundModel> _soundList;
        public ObservableCollection<SkillSoundModel> SoundList {
            get { return _soundList; }
            set {
                _soundList = value;
                OnPropertyChanged("SoundList");
            }
        }

        private SkillSoundModel _selectedSound;
        public SkillSoundModel SelectedSound {
            get { return _selectedSound; }
            set {
                _selectedSound = value;
                if (value is not null) {
                    Code_field = value.Code;
                    Delay_field = value.Delay;
                    Repeat_field = value.Repeat;
                    Interval_field = value.Interval;
                }

                OnPropertyChanged("SelectedSound");
            }
        }
        private int _selectedSoundIndex;
        public int SelectedSoundIndex {
            get { return _selectedSoundIndex; }
            set {
                _selectedSoundIndex = value;
                OnPropertyChanged("SelectedSoundIndex");
            }
        }

        private SkillEventModel _selectedEvent;
        public SkillEventModel SelectedEvent {
            get { return _selectedEvent; }
            set {
                _selectedEvent = value;
                if (value is not null) {
                    EventType_field = value.EventType;
                    EventCommand_field = value.EventCommand;
                    EventCommandParameter_field = value.EventCommandParameter;
                    EventArgument_field = value.EventArgument;
                    EnableLoopCount_field = value.EnableLoopCount;
                    LoopCount_field = value.LoopCount;
                    EffectList = value.EffectList;
                }

                OnPropertyChanged("SelectedEvent");
            }
        }
        private int _selectedEventIndex;
        public int SelectedEventIndex {
            get { return _selectedEventIndex; }
            set {
                _selectedEventIndex = value;
                OnPropertyChanged("SelectedEventIndex");
            }
        }

        private string _eventType;
        public string EventType_field {
            get { return _eventType; }
            set {
                _eventType = value;
                if (value is not null) {
                    EventTypeIndex_field = Program.ProjectileEventType.IndexOf(value);
                    if (EventTypeIndex_field == -1)
                        EventTypeIndex_field = 0;
                } else {
                    EventTypeIndex_field = 0;
                }
                OnPropertyChanged("EventType_field");
            }
        }
        private int _eventTypeIndex;
        public int EventTypeIndex_field {
            get { return _eventTypeIndex; }
            set {
                _eventTypeIndex = value;
                OnPropertyChanged("EventTypeIndex_field");
            }
        }
        private string _eventCommand;
        public string EventCommand_field {
            get { return _eventCommand; }
            set {
                _eventCommand = value;
                if (value is not null) {
                    EventCommandIndex_field = Program.ProjectileCommand.IndexOf(value);
                    if (EventCommandIndex_field == -1)
                        EventCommandIndex_field = 0;
                } else {
                    EventCommandIndex_field = 0;
                }
                OnPropertyChanged("EventCommand_field");
            }
        }
        private int _eventCommandIndex;
        public int EventCommandIndex_field {
            get { return _eventCommandIndex; }
            set {
                _eventCommandIndex = value;
                OnPropertyChanged("EventCommandIndex_field");
            }
        }
        private int _eventCommandParameter;
        public int EventCommandParameter_field {
            get { return _eventCommandParameter; }
            set {
                _eventCommandParameter = value;
                OnPropertyChanged("EventCommandParameter_field");
            }
        }
        private int _eventArgument;
        public int EventArgument_field {
            get { return _eventArgument; }
            set {
                _eventArgument = value;
                OnPropertyChanged("EventArgument_field");
            }
        }
        private bool _enableLoopCount;
        public bool EnableLoopCount_field {
            get { return _enableLoopCount; }
            set {
                _enableLoopCount = value;
                OnPropertyChanged("EnableLoopCount_field");
            }
        }
        private int _loopCount;
        public int LoopCount_field {
            get { return _loopCount; }
            set {
                _loopCount = value;
                OnPropertyChanged("LoopCount_field");
            }
        }
        private ObservableCollection<SkillEffectModel> _effectList;
        public ObservableCollection<SkillEffectModel> EffectList {
            get { return _effectList; }
            set {
                _effectList = value;
                OnPropertyChanged("EffectList");
            }
        }
        private SkillEffectModel _selectedEffect;
        public SkillEffectModel SelectedEffect {
            get { return _selectedEffect; }
            set {
                _selectedEffect = value;
                if (value is not null) {
                    EffectName_field = value.EffectName;
                    ShotType_field = value.ShotType;
                    ShotParam1_field = value.ShotParam1;
                    ShotParam2_field = value.ShotParam2;
                    Coord_field = value.Coord;
                    TargetDir_field = value.TargetDir;
                    PlaneDir_field = value.PlaneDir;
                }

                OnPropertyChanged("SelectedEffect");
            }
        }
        private int _selectedEffectIndex;
        public int SelectedEffectIndex {
            get { return _selectedEffectIndex; }
            set {
                _selectedEffectIndex = value;
                OnPropertyChanged("SelectedEffectIndex");
            }
        }

        private string _effectName;
        public string EffectName_field {
            get { return _effectName; }
            set {
                _effectName = value;
                OnPropertyChanged("EffectName_field");
            }
        }
        private string _shotType;
        public string ShotType_field {
            get { return _shotType; }
            set {
                _shotType = value;
                if (value is not null) {
                    ShotTypeIndex_field = Program.ProjectileShotType.IndexOf(value);
                    if (ShotTypeIndex_field == -1)
                        ShotTypeIndex_field = 0;
                } else {
                    ShotTypeIndex_field = 0;
                }
                OnPropertyChanged("ShotType_field");
            }
        }
        private int _shotTypeIndex;
        public int ShotTypeIndex_field {
            get { return _shotTypeIndex; }
            set {
                _shotTypeIndex = value;

                OnPropertyChanged("ShotTypeIndex_field");
            }
        }
        private float _shotParam1;
        public float ShotParam1_field {
            get { return _shotParam1; }
            set {
                _shotParam1 = value;
                OnPropertyChanged("ShotParam1_field");
            }
        }
        private float _shotParam2;
        public float ShotParam2_field {
            get { return _shotParam2; }
            set {
                _shotParam2 = value;
                OnPropertyChanged("ShotParam2_field");
            }
        }
        private string _coord;
        public string Coord_field {
            get { return _coord; }
            set {
                _coord = value;
                OnPropertyChanged("Coord_field");
            }
        }
        private bool _targetDir;
        public bool TargetDir_field {
            get { return _targetDir; }
            set {
                _targetDir = value;
                OnPropertyChanged("TargetDir_field");
            }
        }
        private bool _planeDir;
        public bool PlaneDir_field {
            get { return _planeDir; }
            set {
                _planeDir = value;
                OnPropertyChanged("PlaneDir_field");
            }
        }


        private string _code;
        public string Code_field {
            get { return _code; }
            set {
                _code = value;
                OnPropertyChanged("Code_field");
            }
        }
        private int _delay;
        public int Delay_field {
            get { return _delay; }
            set {
                _delay = value;
                OnPropertyChanged("Delay_field");
            }
        }
        private int _repeat;
        public int Repeat_field {
            get { return _repeat; }
            set {
                _repeat = value;
                OnPropertyChanged("Repeat_field");
            }
        }
        private int _interval;
        public int Interval_field {
            get { return _interval; }
            set {
                _interval = value;
                OnPropertyChanged("Interval_field");
            }
        }

        private SkillHomingModel _skillHomingEntry;
        public SkillHomingModel SkillHomingEntry {
            get { return _skillHomingEntry; }
            set {
                _skillHomingEntry = value;
                if (value is not null) {

                    UseSkillHoming_field = value.UseSkillHoming;
                    SkillHomingSkillName_field = value.SkillHomingSkillName;
                    SkillHomingDummy_field = value.SkillHomingDummy;
                    SkillHomingActionNum_field = value.SkillHomingActionNum;
                    PlayerHomingDummy_field = value.PlayerHomingDummy;
                    UseEnemyHoming_field = value.UseEnemyHoming;
                }

                OnPropertyChanged("SkillHomingEntry");
            }
        }
        private SkillDecalModel _skillDecalEntry;
        public SkillDecalModel SkillDecalEntry {
            get { return _skillDecalEntry; }
            set {
                _skillDecalEntry = value;
                if (value is not null) {
                    UseDecalCheckBox_field = value.UseDecalCheckBox;
                    SkillDecalType_field = value.SkillDecalType;
                    DecalTextureName_field = value.DecalTextureName;
                    DecalHeightScale_field = value.DecalHeightScale;
                    DecalWidthScale_field = value.DecalWidthScale;
                }

                OnPropertyChanged("SkillDecalEntry");
            }
        }

        private bool _keepPreviousAnimation_field;
        public bool KeepPreviousAnimation_field {
            get { return _keepPreviousAnimation_field; }
            set {
                _keepPreviousAnimation_field = value;
                OnPropertyChanged("KeepPreviousAnimation_field");
            }
        }
        private string _animationChunkName_field;
        public string AnimationChunkName_field {
            get { return _animationChunkName_field; }
            set {
                _animationChunkName_field = value;
                OnPropertyChanged("AnimationChunkName_field");
            }
        }

        private bool _useDecalCheckBox;
        public bool UseDecalCheckBox_field {
            get { return _useDecalCheckBox; }
            set {
                _useDecalCheckBox = value;
                OnPropertyChanged("UseDecalCheckBox_field");
            }
        }
        private string _skillDecalType;
        public string SkillDecalType_field {
            get { return _skillDecalType; }
            set {
                _skillDecalType = value;
                if (value is not null) {
                    SkillDecalTypeIndex_field = Program.ProjectileDecalType.IndexOf(value);
                    if (SkillDecalTypeIndex_field == -1)
                        SkillDecalTypeIndex_field = 0;
                } else {
                    SkillDecalTypeIndex_field = 0;
                }
                OnPropertyChanged("SkillDecalType_field");
            }
        }
        private int _skillDecalTypeIndex;
        public int SkillDecalTypeIndex_field {
            get { return _skillDecalTypeIndex; }
            set {
                _skillDecalTypeIndex = value;
                OnPropertyChanged("SkillDecalTypeIndex_field");
            }
        }
        private string _decalTextureName;
        public string DecalTextureName_field {
            get { return _decalTextureName; }
            set {
                _decalTextureName = value;
                OnPropertyChanged("DecalTextureName_field");
            }
        }
        private float _decalHeightScale;
        public float DecalHeightScale_field {
            get { return _decalHeightScale; }
            set {
                _decalHeightScale = value;
                OnPropertyChanged("DecalHeightScale_field");
            }
        }
        private float _decalWidthScale;
        public float DecalWidthScale_field {
            get { return _decalWidthScale; }
            set {
                _decalWidthScale = value;
                OnPropertyChanged("DecalWidthScale_field");
            }
        }

        private SkillCameraQuakeModel _skillCameraQuakeEntry;
        public SkillCameraQuakeModel SkillCameraQuakeEntry {
            get { return _skillCameraQuakeEntry; }
            set {
                _skillCameraQuakeEntry = value;

                if (value is not null) {
                    UseCameraQuake_field = value.UseCameraQuake;
                    HeightStrength_field = value.HeightStrength;
                    WidthStrength_field = value.WidthStrength;
                    QuakeTime_field = value.QuakeTime;
                    PerReduction_field = value.PerReduction;
                }

                OnPropertyChanged("SkillCameraQuakeEntry");
            }
        }

        private bool _useCameraQuake;
        public bool UseCameraQuake_field {
            get { return _useCameraQuake; }
            set {
                _useCameraQuake = value;
                OnPropertyChanged("UseCameraQuake_field");
            }
        }
        private int _heightStrength;
        public int HeightStrength_field {
            get { return _heightStrength; }
            set {
                _heightStrength = value;
                OnPropertyChanged("HeightStrength_field");
            }
        }
        private int _widthStrength;
        public int WidthStrength_field {
            get { return _widthStrength; }
            set {
                _widthStrength = value;
                OnPropertyChanged("WidthStrength_field");
            }
        }
        private int _quakeTime;
        public int QuakeTime_field {
            get { return _quakeTime; }
            set {
                _quakeTime = value;
                OnPropertyChanged("QuakeTime_field");
            }
        }
        private float _perReduction;
        public float PerReduction_field {
            get { return _perReduction; }
            set {
                _perReduction = value;
                OnPropertyChanged("PerReduction_field");
            }
        }

        private string _chunkName_field;
        public string ChunkName_field {
            get { return _chunkName_field; }
            set {
                _chunkName_field = value;
                OnPropertyChanged("ChunkName_field");
            }
        }
        private int _skillTypeIndex_field;
        public int SkillTypeIndex_field {
            get { return _skillTypeIndex_field; }
            set {
                _skillTypeIndex_field = value;
                OnPropertyChanged("SkillTypeIndex_field");
            }
        }
        private SkillHitModel _projectileHitEntry;
        public SkillHitModel ProjectileHitEntry {
            get { return _projectileHitEntry; }
            set {
                _projectileHitEntry = value;
                if (value is not null) {
                    SkillEnableHit_field = value.EnableHit;
                    SkillHitRadius_field = value.HitRadius;
                    SkillHitHorizontalLimit_field = value.HitHorizontalLimit;
                    SkillHitVerticalLimit_field = value.HitVerticalLimit;
                    SkillHitWorldRadius_field = value.HitWorldRadius;
                    SkillHitPriorityCategory_field = value.HitPriorityCategory;
                    SkillHitPriorityOffset_field = value.HitPriorityOffset;
                    SkillHitDamageID_field = value.HitDamageID;
                    SkillHitPoint_field = value.HitPoint;
                    SkillHitIntervalFrame_field = value.HitIntervalFrame;
                    SkillHitAttributeType_field = value.SkillAttributeType;
                    SkillRigidBody_field = value.RigidBody;

                }

                OnPropertyChanged("ProjectileHitEntry");
            }
        }
        private Visibility _projectileHitVisibility;
        public Visibility ProjectileHitVisibility {
            get { return _projectileHitVisibility; }
            set {
                _projectileHitVisibility = value;
                OnPropertyChanged("ProjectileHitVisibility");
            }
        }
        private bool _skillEnableHit_field;
        public bool SkillEnableHit_field {
            get { return _skillEnableHit_field; }
            set {
                _skillEnableHit_field = value;
                if (value) {
                    ProjectileHitVisibility = Visibility.Visible;
                } else {

                    ProjectileHitVisibility = Visibility.Hidden;
                }
                OnPropertyChanged("SkillEnableHit_field");
            }
        }
        private float _skillHitRadius_field;
        public float SkillHitRadius_field {
            get { return _skillHitRadius_field; }
            set {
                _skillHitRadius_field = value;
                OnPropertyChanged("SkillHitRadius_field");
            }
        }
        private float _skillHitHorizontalLimit_field;
        public float SkillHitHorizontalLimit_field {
            get { return _skillHitHorizontalLimit_field; }
            set {
                _skillHitHorizontalLimit_field = value;
                OnPropertyChanged("SkillHitHorizontalLimit_field");
            }
        }
        private float _skillHitVerticalLimit_field;
        public float SkillHitVerticalLimit_field {
            get { return _skillHitVerticalLimit_field; }
            set {
                _skillHitVerticalLimit_field = value;
                OnPropertyChanged("SkillHitVerticalLimit_field");
            }
        }
        private float _skillHitWorldRadius_field;
        public float SkillHitWorldRadius_field {
            get { return _skillHitWorldRadius_field; }
            set {
                _skillHitWorldRadius_field = value;
                OnPropertyChanged("SkillHitWorldRadius_field");
            }
        }
        private int _skillHitAttributeTypeIndex_field;
        public int SkillHitAttributeTypeIndex_field {
            get { return _skillHitAttributeTypeIndex_field; }
            set {
                _skillHitAttributeTypeIndex_field = value;
                OnPropertyChanged("SkillHitAttributeTypeIndex_field");
            }
        }
        private string _skillHitAttributeType_field;
        public string SkillHitAttributeType_field {
            get { return _skillHitAttributeType_field; }
            set {
                _skillHitAttributeType_field = value;


                if (value is not null) {
                    SkillHitAttributeTypeIndex_field = Program.ProjectileAttributeType.IndexOf(value);
                    if (SkillHitAttributeTypeIndex_field == -1)
                        SkillHitAttributeTypeIndex_field = 0;
                } else {
                    SkillHitAttributeTypeIndex_field = 0;
                }

                OnPropertyChanged("SkillHitAttributeType_field");
            }
        }
        private int _skillHitPriorityCategoryIndex_field;
        public int SkillHitPriorityCategoryIndex_field {
            get { return _skillHitPriorityCategoryIndex_field; }
            set {
                _skillHitPriorityCategoryIndex_field = value;
                OnPropertyChanged("SkillHitPriorityCategoryIndex_field");
            }
        }
        private string _skillHitPriorityCategory_field;
        public string SkillHitPriorityCategory_field {
            get { return _skillHitPriorityCategory_field; }
            set {
                _skillHitPriorityCategory_field = value;

                if (value is not null) {
                    SkillHitPriorityCategoryIndex_field = Program.ProjectilePriorityCategory.IndexOf(value);
                    if (SkillHitPriorityCategoryIndex_field == -1)
                        SkillHitPriorityCategoryIndex_field = 0;
                } else {
                    SkillHitPriorityCategoryIndex_field = 0;
                }

                OnPropertyChanged("SkillHitPriorityCategory_field");
            }
        }
        private int _skillHitPriorityOffset_field;
        public int SkillHitPriorityOffset_field {
            get { return _skillHitPriorityOffset_field; }
            set {
                _skillHitPriorityOffset_field = value;
                OnPropertyChanged("SkillHitPriorityOffset_field");
            }
        }
        private string _skillHitDamageID_field;
        public string SkillHitDamageID_field {
            get { return _skillHitDamageID_field; }
            set {
                _skillHitDamageID_field = value;
                OnPropertyChanged("SkillHitDamageID_field");
            }
        }
        private int _skillhitPoint_field;
        public int SkillHitPoint_field {
            get { return _skillhitPoint_field; }
            set {
                _skillhitPoint_field = value;
                OnPropertyChanged("SkillHitPoint_field");
            }
        }
        private int _skillhitIntervalFrame_field;
        public int SkillHitIntervalFrame_field {
            get { return _skillhitIntervalFrame_field; }
            set {
                _skillhitIntervalFrame_field = value;
                OnPropertyChanged("SkillHitIntervalFrame_field");
            }
        }
        private bool _skillRigidBody_field;
        public bool SkillRigidBody_field {
            get { return _skillRigidBody_field; }
            set {
                _skillRigidBody_field = value;
                OnPropertyChanged("SkillRigidBody_field");
            }
        }
        private SkillHitModel _actionHitEntry;
        public SkillHitModel ActionHitEntry {
            get { return _actionHitEntry; }
            set {
                _actionHitEntry = value;
                if (value is not null) {
                    ActionEnableHit_field = value.EnableHit;
                    ActionHitRadius_field = value.HitRadius;
                    ActionHitHorizontalLimit_field = value.HitHorizontalLimit;
                    ActionHitVerticalLimit_field = value.HitVerticalLimit;
                    ActionHitWorldRadius_field = value.HitWorldRadius;
                    ActionHitDamageID_field = value.HitDamageID;
                    ActionHitPoint_field = value.HitPoint;
                    ActionHitIntervalFrame_field = value.HitIntervalFrame;

                }

                OnPropertyChanged("ActionHitEntry");
            }
        }

        private bool _actionEnableHit_field;
        public bool ActionEnableHit_field {
            get { return _actionEnableHit_field; }
            set {
                _actionEnableHit_field = value;
                OnPropertyChanged("ActionEnableHit_field");
            }
        }
        private float _actionHitRadius_field;
        public float ActionHitRadius_field {
            get { return _actionHitRadius_field; }
            set {
                _actionHitRadius_field = value;
                OnPropertyChanged("ActionHitRadius_field");
            }
        }
        private float _actionHitHorizontalLimit_field;
        public float ActionHitHorizontalLimit_field {
            get { return _actionHitHorizontalLimit_field; }
            set {
                _actionHitHorizontalLimit_field = value;
                OnPropertyChanged("ActionHitHorizontalLimit_field");
            }
        }
        private string _actionHitDamageID_field;
        public string ActionHitDamageID_field {
            get { return _actionHitDamageID_field; }
            set {
                _actionHitDamageID_field = value;
                OnPropertyChanged("ActionHitDamageID_field");
            }
        }
        private float _actionHitVerticalLimit_field;
        public float ActionHitVerticalLimit_field {
            get { return _actionHitVerticalLimit_field; }
            set {
                _actionHitVerticalLimit_field = value;
                OnPropertyChanged("ActionHitVerticalLimit_field");
            }
        }
        private float _actionHitWorldRadius_field;
        public float ActionHitWorldRadius_field {
            get { return _actionHitWorldRadius_field; }
            set {
                _actionHitWorldRadius_field = value;
                OnPropertyChanged("ActionHitWorldRadius_field");
            }
        }

        private int _actionhitPoint_field;
        public int ActionHitPoint_field {
            get { return _actionhitPoint_field; }
            set {
                _actionhitPoint_field = value;
                OnPropertyChanged("ActionHitPoint_field");
            }
        }
        private int _actionhitIntervalFrame_field;
        public int ActionHitIntervalFrame_field {
            get { return _actionhitIntervalFrame_field; }
            set {
                _actionhitIntervalFrame_field = value;
                OnPropertyChanged("ActionHitIntervalFrame_field");
            }
        }


        private bool _useSkillHoming;
        public bool UseSkillHoming_field {
            get { return _useSkillHoming; }
            set {
                _useSkillHoming = value;
                OnPropertyChanged("UseSkillHoming_field");
            }
        }
        private string _skillHomingSkillName;
        public string SkillHomingSkillName_field {
            get { return _skillHomingSkillName; }
            set {
                _skillHomingSkillName = value;
                OnPropertyChanged("SkillHomingSkillName_field");
            }
        }
        private string _skillHomingDummy;
        public string SkillHomingDummy_field {
            get { return _skillHomingDummy; }
            set {
                _skillHomingDummy = value;
                OnPropertyChanged("SkillHomingDummy_field");
            }
        }
        private int _skillHomingActionNum;
        public int SkillHomingActionNum_field {
            get { return _skillHomingActionNum; }
            set {
                _skillHomingActionNum = value;
                OnPropertyChanged("SkillHomingActionNum_field");
            }
        }
        private string _playerHomingDummy;
        public string PlayerHomingDummy_field {
            get { return _playerHomingDummy; }
            set {
                _playerHomingDummy = value;
                OnPropertyChanged("PlayerHomingDummy_field");
            }
        }
        private bool _useEnemyHoming;
        public bool UseEnemyHoming_field {
            get { return _useEnemyHoming; }
            set {
                _useEnemyHoming = value;
                OnPropertyChanged("UseEnemyHoming_field");
            }
        }



        private ObservableCollection<string> _filePathList;
        public ObservableCollection<string> FilePathList {
            get { return _filePathList; }
            set {
                _filePathList = value;
                OnPropertyChanged("FilePathList");
            }
        }

        private string _selectedFilePath;
        public string SelectedFilePath{
            get { return _selectedFilePath; }
            set {
                _selectedFilePath = value;
                FilePathTextBox_field = SelectedFilePath;
                OnPropertyChanged("SelectedFilePath");
            }
        }
        private int _selectedFilePathIndex;
        public int SelectedFilePathIndex {
            get { return _selectedFilePathIndex; }
            set {
                _selectedFilePathIndex = value;
                OnPropertyChanged("SelectedFilePathIndex");
            }
        }
        private string _filePathTextBox_field;
        public string FilePathTextBox_field {
            get { return _filePathTextBox_field; }
            set {
                _filePathTextBox_field = value;
                OnPropertyChanged("FilePathTextBox_field");
            }
        }

        private string _className_field;
        public string ClassName_field {
            get { return _className_field; }
            set {
                _className_field = value;
                OnPropertyChanged("ClassName_field");
            }
        }
        private string _skillTextBox_field;
        public string SkillTextBox_field {
            get { return _skillTextBox_field; }
            set {
                _skillTextBox_field = value;
                OnPropertyChanged("SkillTextBox_field");
            }
        }
        public SkillEditorViewModel() {
            filePath = "";
            SkillList = new ObservableCollection<SkillEntryModel>();
            ActionList = new ObservableCollection<SkillActionModel>();
            EventList = new ObservableCollection<SkillEventModel>();
            SoundList = new ObservableCollection<SkillSoundModel>();
            SkillType_List = new ObservableCollection<string>();
            Attribute_List = new ObservableCollection<string>();
            Event_List = new ObservableCollection<string>();
            Decal_List = new ObservableCollection<string>();
            ActionType_List = new ObservableCollection<string>();
            Command_List = new ObservableCollection<string>();
            PriorityCategory_List = new ObservableCollection<string>();
            ShotType_List = new ObservableCollection<string>();
            for (int x = 0; x < Program.ProjectileType.Length; x++) SkillType_List.Add(Program.ProjectileType[x]);
            for (int x = 0; x < Program.ProjectileAttributeType.Length; x++) Attribute_List.Add(Program.ProjectileAttributeType[x]);
            for (int x = 0; x < Program.ProjectileEventType.Length; x++) Event_List.Add(Program.ProjectileEventType[x]);
            for (int x = 0; x < Program.ProjectileDecalType.Length; x++) Decal_List.Add(Program.ProjectileDecalType[x]);
            for (int x = 0; x < Program.ProjectileActionType.Length; x++) ActionType_List.Add(Program.ProjectileActionType[x]);
            for (int x = 0; x < Program.ProjectileCommand.Length; x++) Command_List.Add(Program.ProjectileCommand[x]);
            for (int x = 0; x < Program.ProjectilePriorityCategory.Length; x++) PriorityCategory_List.Add(Program.ProjectilePriorityCategory[x]);
            for (int x = 0; x < Program.ProjectileShotType.Length; x++) ShotType_List.Add(Program.ProjectileShotType[x]);
        }


        public void Clear() {
            SkillList.Clear();
        }
        public void OpenFile(string basepath = "") {
            Clear();
            if (basepath == "") {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "XFBIN Container (*.xfbin)|*.xfbin";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true) {
                    filePath = myDialog.FileName;
                } else {
                    return;
                }
            } else {
                filePath = basepath;
            }
            if (File.Exists(filePath)) {
                XfbinReader.ReadXFBIN(filePath);
                foreach (PAGE page in XfbinReader.XfbinFile.Pages) {
                    foreach (CHUNK chunk in page.Chunks) {
                        if (XfbinReader.GetXfbinChunkType((int)chunk.ChunkMapIndex) == "nuccChunkBinary") {

                            SkillEntryModel skillEntry = new SkillEntryModel();
                            XmlDocument xDoc = new XmlDocument();
                            using (var ms = new MemoryStream(chunk.ChunkData))
                            using (var reader = new StreamReader(ms)) {
                                int i = 0;
                                while (!reader.EndOfStream && reader.Peek() > -1 && i != 4) {
                                    reader.Read();
                                    i++;
                                }
                                if (!reader.EndOfStream)
                                    xDoc.Load(reader);
                                XmlElement? xRoot = xDoc.DocumentElement;
                                if (xRoot != null) {

                                    SkillHitModel skillHitEntry = new SkillHitModel();
                                    ObservableCollection<string> FilePaths = new ObservableCollection<string>();
                                    ObservableCollection<SkillActionModel> SkillActionsList = new ObservableCollection<SkillActionModel>();
                                    //Skill Tag
                                    skillEntry.ChunkName = xRoot.Attributes.GetNamedItem("id").Value;
                                    skillEntry.SkillType = xRoot.Attributes.GetNamedItem("type").Value;


                                    //All Tags inside of Skill Tag
                                    foreach (XmlElement xnode in xRoot) {
                                        //Hit Entry
                                        if (xnode.Name == "Hit") {
                                            skillHitEntry.EnableHit = true;
                                            foreach (XmlAttribute attribute in xnode.Attributes) {
                                                if (attribute.Name == "radius") {
                                                    skillHitEntry.HitRadius = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                } else if (attribute.Name == "hitLimitV") {
                                                    skillHitEntry.HitVerticalLimit = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                } else if (attribute.Name == "hitLimitH") {
                                                    skillHitEntry.HitHorizontalLimit = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                } else if (attribute.Name == "worldHitRadius") {
                                                    skillHitEntry.HitWorldRadius = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                } else if (attribute.Name == "priorityCategory") {
                                                    skillHitEntry.HitPriorityCategory = attribute.Value;
                                                } else if (attribute.Name == "priorityOffset") {
                                                    skillHitEntry.HitPriorityOffset = (int)Convert.ToInt32(attribute.Value);
                                                } else if (attribute.Name == "damageId") {
                                                    skillHitEntry.HitDamageID = attribute.Value;
                                                } else if (attribute.Name == "hitPoint") {
                                                    skillHitEntry.HitPoint = (int)Convert.ToInt32(attribute.Value);
                                                } else if (attribute.Name == "hitIntervalFrame") {
                                                    skillHitEntry.HitIntervalFrame = (int)Convert.ToInt32(attribute.Value);
                                                } else if (attribute.Name == "rigidBody") {
                                                    skillHitEntry.RigidBody = (bool)Convert.ToBoolean(attribute.Value);
                                                }
                                            }
                                        } else if (xnode.Name == "Files") {
                                            foreach (XmlNode xmlNode in xnode.ChildNodes) {
                                                if (xmlNode.Name == "File") {
                                                    FilePaths.Add(xmlNode.Attributes.GetNamedItem("path").Value);
                                                }
                                            }
                                        } else if (xnode.Name == "Actions") {
                                            foreach (XmlNode xmlNode in xnode.ChildNodes) {
                                                if (xmlNode.Name == "Action") {
                                                    //Action Attributes
                                                    SkillActionModel ActionEntry = new SkillActionModel();
                                                    foreach (XmlAttribute attribute in xmlNode.Attributes) {
                                                        if (attribute.Name == "id") {
                                                            ActionEntry.ActionID = (int)Convert.ToInt32(attribute.Value);
                                                        } else if (attribute.Name == "type") {
                                                            ActionEntry.ActionType = attribute.Value;
                                                        }
                                                    }

                                                    SkillHitModel ActionHitEntry = new SkillHitModel();
                                                    SkillHomingModel ActionHomingEntry = new SkillHomingModel();
                                                    SkillDecalModel ActionDecalEntry = new SkillDecalModel();
                                                    SkillCameraQuakeModel ActionCameraQuakeEntry = new SkillCameraQuakeModel();
                                                    SkillAnimationModel ActionAnimationEntry = new SkillAnimationModel();
                                                    ObservableCollection<SkillSoundModel> ActionSoundList = new ObservableCollection<SkillSoundModel>();
                                                    ObservableCollection<SkillEventModel> ActionEventList = new ObservableCollection<SkillEventModel>();
                                                    //Action Child nodes
                                                    foreach (XmlNode actionNode in xmlNode.ChildNodes) {

                                                        //Hit Node
                                                        SkillSoundModel ActionSoundEntry = new SkillSoundModel();
                                                        SkillEventModel ActionEventEntry = new SkillEventModel();

                                                        //Animation Tag in Action
                                                        if (actionNode.Name == "Animation") {
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "chunk") {
                                                                    ActionAnimationEntry.AnimationChunkName = attribute.Value;
                                                                } else if (attribute.Name == "inherite") {
                                                                    ActionAnimationEntry.KeepPreviousAnimation = (bool)Convert.ToBoolean(attribute.Value);
                                                                }
                                                            }
                                                        }
                                                        //Hit Tag in Action
                                                        else if (actionNode.Name == "Hit") {
                                                            ActionHitEntry.EnableHit = true;
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "hitRadius") {
                                                                    ActionHitEntry.HitRadius = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                } else if (attribute.Name == "hitLimitV") {
                                                                    ActionHitEntry.HitVerticalLimit = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                } else if (attribute.Name == "hitLimitH") {
                                                                    ActionHitEntry.HitHorizontalLimit = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                } else if (attribute.Name == "hitRadiusWorld") {
                                                                    ActionHitEntry.HitWorldRadius = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                } else if (attribute.Name == "damageId") {
                                                                    ActionHitEntry.HitDamageID = attribute.Value;
                                                                } else if (attribute.Name == "hitPoint") {
                                                                    ActionHitEntry.HitPoint = (int)Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "hitInterval") {
                                                                    ActionHitEntry.HitIntervalFrame = Convert.ToInt32(attribute.Value);
                                                                }
                                                            }
                                                        }
                                                        //SkillHoming Tag in Action
                                                        else if (actionNode.Name == "SkillHoming") {
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "useSkillHoming") {
                                                                    ActionHomingEntry.UseSkillHoming = Convert.ToBoolean(attribute.Value);
                                                                } else if (attribute.Name == "skillHomingSkillName") {
                                                                    ActionHomingEntry.SkillHomingSkillName = attribute.Value;
                                                                } else if (attribute.Name == "skillHomingDummy") {
                                                                    ActionHomingEntry.SkillHomingDummy = attribute.Value;
                                                                } else if (attribute.Name == "skillHomingActionNum") {
                                                                    ActionHomingEntry.SkillHomingActionNum = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "playerHomingDummy") {
                                                                    ActionHomingEntry.PlayerHomingDummy = attribute.Value;
                                                                } else if (attribute.Name == "useEnemyHoming") {
                                                                    ActionHomingEntry.UseEnemyHoming = Convert.ToBoolean(attribute.Value);
                                                                }
                                                            }
                                                        }
                                                        //SkillDecal Tag in Action
                                                        else if (actionNode.Name == "SkillDecal") {
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "UseDecalCheckBox") {
                                                                    ActionDecalEntry.UseDecalCheckBox = Convert.ToBoolean(attribute.Value);
                                                                } else if (attribute.Name == "skillDecalType") {
                                                                    ActionDecalEntry.SkillDecalType = attribute.Value;
                                                                } else if (attribute.Name == "decalTextureName") {
                                                                    ActionDecalEntry.DecalTextureName = attribute.Value;
                                                                } else if (attribute.Name == "decalHeightScale") {
                                                                    ActionDecalEntry.DecalHeightScale = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                } else if (attribute.Name == "decalWidthScale") {
                                                                    ActionDecalEntry.DecalWidthScale = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                }
                                                            }
                                                        }
                                                        //CameraQuake Tag in Action
                                                        else if (actionNode.Name == "CameraQuake") {
                                                            ActionCameraQuakeEntry.UseCameraQuake = true;
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "HeightStrength") {
                                                                    ActionCameraQuakeEntry.HeightStrength = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "WidthStrength") {
                                                                    ActionCameraQuakeEntry.WidthStrength = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "QuakeTime") {
                                                                    ActionCameraQuakeEntry.QuakeTime = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "PerReduction") {
                                                                    ActionCameraQuakeEntry.PerReduction = float.Parse(attribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                }
                                                            }
                                                        }
                                                        //SoundEffect Tag in Action
                                                        else if (actionNode.Name == "SoundEffect") {
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "code") {
                                                                    ActionSoundEntry.Code = attribute.Value;
                                                                } else if (attribute.Name == "delay") {
                                                                    ActionSoundEntry.Delay = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "repeat") {
                                                                    ActionSoundEntry.Repeat = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "interval") {
                                                                    ActionSoundEntry.Interval = Convert.ToInt32(attribute.Value);
                                                                }
                                                            }
                                                            ActionSoundList.Add(ActionSoundEntry);
                                                        }
                                                        //Event Tag in Action
                                                        else if (actionNode.Name == "Event") {
                                                            ActionEventEntry.EnableLoopCount = false;
                                                            ObservableCollection<SkillEffectModel> ActionEffectList = new ObservableCollection<SkillEffectModel>();

                                                            //Event Attributes
                                                            foreach (XmlAttribute attribute in actionNode.Attributes) {
                                                                if (attribute.Name == "type") {
                                                                    ActionEventEntry.EventType = attribute.Value;
                                                                } else if (attribute.Name == "command") {
                                                                    ActionEventEntry.EventCommand = attribute.Value;
                                                                } else if (attribute.Name == "commandParameter") {
                                                                    ActionEventEntry.EventCommandParameter = Convert.ToInt32(attribute.Value);
                                                                } else if (attribute.Name == "loopCount") {
                                                                    ActionEventEntry.LoopCount = Convert.ToInt32(attribute.Value);
                                                                    ActionEventEntry.EnableLoopCount = true;
                                                                } else if (attribute.Name == "arg") {
                                                                    ActionEventEntry.EventArgument = Convert.ToInt32(attribute.Value);
                                                                }
                                                            }

                                                            //Event Child Nodes - Effects
                                                            foreach (XmlNode EffectNode in actionNode.ChildNodes) {
                                                                SkillEffectModel ActionEffectEntry = new SkillEffectModel();
                                                                foreach (XmlAttribute EffectAttribute in EffectNode.Attributes) {
                                                                    if (EffectAttribute.Name == "name") {
                                                                        ActionEffectEntry.EffectName = EffectAttribute.Value;
                                                                    } else if (EffectAttribute.Name == "shotType") {
                                                                        ActionEffectEntry.ShotType = EffectAttribute.Value;
                                                                    } else if (EffectAttribute.Name == "shotParam1") {
                                                                        ActionEffectEntry.ShotParam1 = float.Parse(EffectAttribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                    } else if (EffectAttribute.Name == "shotParam2") {
                                                                        ActionEffectEntry.ShotParam2 = float.Parse(EffectAttribute.Value, CultureInfo.InvariantCulture.NumberFormat);
                                                                    } else if (EffectAttribute.Name == "coord") {
                                                                        ActionEffectEntry.Coord = EffectAttribute.Value;
                                                                    } else if (EffectAttribute.Name == "targetDir") {
                                                                        ActionEffectEntry.TargetDir = Convert.ToBoolean(EffectAttribute.Value);
                                                                    } else if (EffectAttribute.Name == "planeDir") {
                                                                        ActionEffectEntry.PlaneDir = Convert.ToBoolean(EffectAttribute.Value);
                                                                    }

                                                                }
                                                                ActionEffectList.Add(ActionEffectEntry);
                                                            }
                                                            ActionEventEntry.EffectList = ActionEffectList;
                                                            ActionEventList.Add(ActionEventEntry);
                                                        }
                                                        //Values
                                                        else if (actionNode.Name == "Gravity") { 
                                                            ActionEntry.Gravity = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Restitution") {
                                                            ActionEntry.Restitution = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "RandomDirection") {
                                                            ActionEntry.RandomDirection = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "RandomRoll") {
                                                            ActionEntry.RandomRoll = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "ViewingAngle") {
                                                            ActionEntry.ViewingAngle = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Friction") {
                                                            ActionEntry.Friction = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Frequency_x") {
                                                            ActionEntry.Frequency_x = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Frequency_y") {
                                                            ActionEntry.Frequency_y = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Frequency_z") {
                                                            ActionEntry.Frequency_z = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "BankStrong") {
                                                            ActionEntry.BankStrong = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "BankSpring") {
                                                            ActionEntry.BankSpring = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Amplitude_x") {
                                                            ActionEntry.Amplitude_x = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Amplitude_y") {
                                                            ActionEntry.Amplitude_y = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Amplitude_z") {
                                                            ActionEntry.Amplitude_z = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Velocity") {
                                                            ActionEntry.Velocity = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "VelocityRandomize") {
                                                            ActionEntry.VelocityRandomize = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "Inductivity") {
                                                            ActionEntry.Inductivity = float.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "NumLimitNum") {
                                                            ActionEntry.NumLimitNum = int.Parse(actionNode.Attributes.GetNamedItem("value").Value, CultureInfo.InvariantCulture.NumberFormat);
                                                        } else if (actionNode.Name == "HitAttach") {
                                                            ActionEntry.HitAttach = actionNode.Attributes.GetNamedItem("value").Value;
                                                        } else if (actionNode.Name == "HitAttach2") {
                                                            ActionEntry.HitAttach2 = actionNode.Attributes.GetNamedItem("value").Value;
                                                        } else if (actionNode.Name == "HitAttach3") {
                                                            ActionEntry.HitAttach3 = actionNode.Attributes.GetNamedItem("value").Value;
                                                        } else if (actionNode.Name == "HitAttach4") {
                                                            ActionEntry.HitAttach4 = actionNode.Attributes.GetNamedItem("value").Value;
                                                        } else if (actionNode.Name == "HitAttach5") {
                                                            ActionEntry.HitAttach5 = actionNode.Attributes.GetNamedItem("value").Value;
                                                        } else if (actionNode.Name == "CharacterHitDisable") {
                                                            ActionEntry.CharacterHitDisable = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "WorldHitDisable") {
                                                            ActionEntry.WorldHitDisable = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "NumLimitEnable") {
                                                            ActionEntry.NumLimitEnable = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "FixedUp") {
                                                            ActionEntry.FixedUp = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "SkillHitMine") {
                                                            ActionEntry.SkillHitMine = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "AtkHitMine") {
                                                            ActionEntry.AtkHitMine = Convert.ToBoolean(actionNode.Attributes.GetNamedItem("value").Value);
                                                        } else if (actionNode.Name == "State") {
                                                            ActionEntry.State = actionNode.Attributes.GetNamedItem("state").Value;
                                                        }
                                                        ActionEntry.AnimationEntry = ActionAnimationEntry;
                                                        ActionEntry.HitEntry = ActionHitEntry;
                                                    }

                                                    ActionEntry.HitEntry = ActionHitEntry;
                                                    ActionEntry.SkillHomingEntry = ActionHomingEntry;
                                                    ActionEntry.SkillDecalEntry = ActionDecalEntry;
                                                    ActionEntry.SkillCameraQuakeEntry = ActionCameraQuakeEntry;
                                                    ActionEntry.AnimationEntry = ActionAnimationEntry;
                                                    ActionEntry.SoundList = ActionSoundList;
                                                    ActionEntry.EventList = ActionEventList;
                                                    SkillActionsList.Add(ActionEntry);

                                                }
                                            }
                                        } else if (xnode.Name == "Class") {
                                            foreach (XmlAttribute attribute in xnode.Attributes) {
                                                if (attribute.Name == "name") {
                                                    skillEntry.ClassName = attribute.Value;
                                                }
                                            }
                                        }
                                        skillEntry.HitEntry = skillHitEntry;
                                        skillEntry.FilePathList = FilePaths;
                                        skillEntry.ActionList = SkillActionsList;
                                    }

                                }


                            }
                            SkillList.Add(skillEntry);
                        }
                    }
                }

            }
        }

        public void AddFilePath() {
            if (SelectedSkill is not null) {
                if (FilePathTextBox_field != "" && FilePathTextBox_field is not null){
                    if (SelectedSkill.FilePathList.Count != 3) {

                        SelectedSkill.FilePathList.Add(FilePathTextBox_field);
                        SelectedFilePathIndex = SelectedSkill.FilePathList.Count - 1;
                    } else {

                        ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_73"]);
                    }
                }
                else {

                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_74"]);
                }
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_75"]);
            }
        }

        public void DeleteFilePath() {
            if (SelectedSkill is not null && SelectedFilePath is not null) {
                SelectedSkill.FilePathList.Remove(SelectedFilePath);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_76"]);
            }
        }

        public void AddSkill() {
            SkillEntryModel new_skill_entry = new SkillEntryModel();
            new_skill_entry.ChunkName = "new_skill_entry";
            new_skill_entry.SkillType = "SKILL_TYPE_EFFECT";
            new_skill_entry.HitEntry = new SkillHitModel();
            new_skill_entry.FilePathList = new ObservableCollection<string>();
            new_skill_entry.ActionList = new ObservableCollection<SkillActionModel>();
            new_skill_entry.ClassName = "";

            SkillList.Add(new_skill_entry);
        }

        public void DuplicateSkill() {
            if (SelectedSkill is not null) {
                SkillEntryModel new_skill_entry = (SkillEntryModel)SelectedSkill.Clone();
                new_skill_entry.ChunkName = new_skill_entry.ChunkName + "_copy";
                SkillList.Add(new_skill_entry);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_75"]);
            }
        }

        public void DeleteSkill() {
            if (SelectedSkill is not null) {
                SkillList.Remove(SelectedSkill);
            }
        }

        public void SaveSkill() {
            if (SelectedSkill is not null) {
                SelectedSkill.ChunkName = ChunkName_field;
                SelectedSkill.SkillType = Program.ProjectileType[SkillTypeIndex_field];

                SelectedSkill.HitEntry.EnableHit = SkillEnableHit_field;
                SelectedSkill.HitEntry.HitRadius = SkillHitRadius_field;
                SelectedSkill.HitEntry.HitHorizontalLimit = SkillHitHorizontalLimit_field;
                SelectedSkill.HitEntry.HitVerticalLimit = SkillHitVerticalLimit_field;
                SelectedSkill.HitEntry.HitWorldRadius = SkillHitWorldRadius_field;
                SelectedSkill.HitEntry.HitPriorityCategory = Program.ProjectilePriorityCategory[SkillHitPriorityCategoryIndex_field];
                SelectedSkill.HitEntry.HitPriorityOffset = SkillHitPriorityOffset_field;
                SelectedSkill.HitEntry.HitDamageID = SkillHitDamageID_field;
                SelectedSkill.HitEntry.HitPoint = SkillHitPoint_field;
                SelectedSkill.HitEntry.HitIntervalFrame = SkillHitIntervalFrame_field;
                SelectedSkill.HitEntry.SkillAttributeType = Program.ProjectileAttributeType[SkillHitAttributeTypeIndex_field];
                SelectedSkill.HitEntry.RigidBody = SkillRigidBody_field;


                SelectedSkill.FilePathList = FilePathList;
                SelectedSkill.ActionList = ActionList;
                SelectedSkill.ClassName = ClassName_field;
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_77"]);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_78"]);
            }
        }
        public int SearchStringIndex(ObservableCollection<SkillEntryModel> FunctionList, string member_name, int Selected) {
            for (int x = 0; x < FunctionList.Count; x++) {

                string mainString = FunctionList[x].ChunkName;
                string subString = member_name;
                int index = mainString.ToLower().IndexOf(subString.ToLower());
                if (index != -1 && Selected < x) {
                    return x;
                }

            }
            return -1;
        }
        public void SearchSkill() {
            if (SkillTextBox_field is not null) {
                if (SearchStringIndex(SkillList, SkillTextBox_field, SelectedSkillIndex) != -1) {
                    SelectedSkillIndex = SearchStringIndex(SkillList, SkillTextBox_field, SelectedSkillIndex);
                    CollectionViewSource.GetDefaultView(SkillList).MoveCurrentTo(SelectedSkill);
                } else {
                    if (SearchStringIndex(SkillList, SkillTextBox_field, 0) != -1) {
                        SelectedSkillIndex = SearchStringIndex(SkillList, SkillTextBox_field, -1);
                        CollectionViewSource.GetDefaultView(SkillList).MoveCurrentTo(SelectedSkill);
                    } else {
                        ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_18"], "No result", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_17"]);
            }
        }

        public void AddAction() {
            if (SelectedSkill is not null) {
                SkillActionModel new_action_entry = new SkillActionModel();
                new_action_entry.ActionID = SelectedSkill.ActionList.Count;
                new_action_entry.ActionType = "SKILL_ACTION_TYPE_NONE";
                new_action_entry.AnimationEntry = new SkillAnimationModel();
                new_action_entry.HitEntry = new SkillHitModel();
                new_action_entry.Gravity = 0;
                new_action_entry.Restitution = 0;
                new_action_entry.RandomDirection = 0;
                new_action_entry.RandomRoll = 0;
                new_action_entry.ViewingAngle = 0;
                new_action_entry.Friction = 0;
                new_action_entry.Frequency_x = 0;
                new_action_entry.Frequency_y = 0;
                new_action_entry.Frequency_z = 0;
                new_action_entry.BankStrong = 0;
                new_action_entry.BankRollMax = 0;
                new_action_entry.BankSpring = 0;
                new_action_entry.Amplitude_x = 0;
                new_action_entry.Amplitude_y = 0;
                new_action_entry.Amplitude_z = 0;
                new_action_entry.Velocity = 0;
                new_action_entry.VelocityRandomize = 0;
                new_action_entry.Inductivity = 0;
                new_action_entry.CharacterHitDisable = false;
                new_action_entry.WorldHitDisable = false;
                new_action_entry.NumLimitNum = 0;
                new_action_entry.NumLimitEnable = false;
                new_action_entry.HitAttach = "";
                new_action_entry.HitAttach2 = "";
                new_action_entry.HitAttach3 = "";
                new_action_entry.HitAttach4 = "";
                new_action_entry.HitAttach5 = "";
                new_action_entry.FixedUp = false;
                new_action_entry.SkillHitMine = false;
                new_action_entry.AtkHitMine = false;
                new_action_entry.State = "";
                new_action_entry.EventList = new ObservableCollection<SkillEventModel>();
                new_action_entry.SoundList = new ObservableCollection<SkillSoundModel>();
                new_action_entry.SkillHomingEntry = new SkillHomingModel();
                new_action_entry.SkillDecalEntry = new SkillDecalModel();
                new_action_entry.SkillCameraQuakeEntry = new SkillCameraQuakeModel();
                if (SelectedSkill.ActionList.Count != 16) {
                    SelectedSkill.ActionList.Add(new_action_entry);
                } else {

                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_79"]);
                }

            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_80"]);
            }
        }
        public void DeleteAction() {
            if (SelectedAction is not null) {
                ActionList.Remove(SelectedAction);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_81"]);
            }
        }
        public void SaveAction() {
            if (SelectedAction is not null) {
                SelectedAction.ActionID = ActionID_field;
                SelectedAction.ActionType = Program.ProjectileActionType[ActionTypeIndex_field];
                SelectedAction.AnimationEntry.KeepPreviousAnimation = KeepPreviousAnimation_field;
                SelectedAction.AnimationEntry.AnimationChunkName = AnimationChunkName_field;

                SelectedAction.HitEntry.EnableHit = ActionEnableHit_field;
                SelectedAction.HitEntry.HitRadius = ActionHitRadius_field;
                SelectedAction.HitEntry.HitHorizontalLimit = ActionHitHorizontalLimit_field;
                SelectedAction.HitEntry.HitVerticalLimit = ActionHitVerticalLimit_field;
                SelectedAction.HitEntry.HitWorldRadius = ActionHitWorldRadius_field;

                SelectedAction.HitEntry.HitDamageID = ActionHitDamageID_field;
                SelectedAction.HitEntry.HitPoint = ActionHitPoint_field;
                SelectedAction.HitEntry.HitIntervalFrame = ActionHitIntervalFrame_field;

                SelectedAction.Gravity = Gravity_field;
                SelectedAction.Restitution = Restitution_field;
                SelectedAction.RandomDirection = RandomDirection_field;
                SelectedAction.RandomRoll = RandomRoll_field;
                SelectedAction.ViewingAngle = ViewingAngle_field;
                SelectedAction.Friction = Friction_field;
                SelectedAction.Frequency_x = Frequency_x_field;
                SelectedAction.Frequency_y = Frequency_y_field;
                SelectedAction.Frequency_z = Frequency_z_field;
                SelectedAction.BankStrong = BankStrong_field;
                SelectedAction.BankRollMax = BankRollMax_field;
                SelectedAction.BankSpring = BankSpring_field;
                SelectedAction.Amplitude_x = Amplitude_x_field;
                SelectedAction.Amplitude_y = Amplitude_y_field;
                SelectedAction.Amplitude_z = Amplitude_z_field;
                SelectedAction.Velocity = Velocity_field;
                SelectedAction.VelocityRandomize = VelocityRandomize_field;
                SelectedAction.Inductivity = Inductivity_field;
                SelectedAction.CharacterHitDisable = CharacterHitDisable_field;
                SelectedAction.WorldHitDisable = WorldHitDisable_field;
                SelectedAction.NumLimitNum = NumLimitNum_field;
                SelectedAction.NumLimitEnable = NumLimitEnable_field;
                SelectedAction.HitAttach = HitAttach_field;
                SelectedAction.HitAttach2 = HitAttach2_field;
                SelectedAction.HitAttach3 = HitAttach3_field;
                SelectedAction.HitAttach4 = HitAttach4_field;
                SelectedAction.HitAttach5 = HitAttach5_field;
                SelectedAction.FixedUp = FixedUp_field;
                SelectedAction.SkillHitMine = SkillHitMine_field;
                SelectedAction.AtkHitMine = AtkHitMine_field;
                SelectedAction.State = State_field;

                SelectedAction.SkillHomingEntry.UseSkillHoming = UseSkillHoming_field;
                SelectedAction.SkillHomingEntry.SkillHomingSkillName = SkillHomingSkillName_field;
                SelectedAction.SkillHomingEntry.SkillHomingDummy = SkillHomingDummy_field;
                SelectedAction.SkillHomingEntry.SkillHomingActionNum = SkillHomingActionNum_field;
                SelectedAction.SkillHomingEntry.PlayerHomingDummy = PlayerHomingDummy_field;
                SelectedAction.SkillHomingEntry.UseEnemyHoming = UseEnemyHoming_field;

                SelectedAction.SkillDecalEntry.UseDecalCheckBox = UseDecalCheckBox_field;
                SelectedAction.SkillDecalEntry.SkillDecalType = Program.ProjectileDecalType[SkillDecalTypeIndex_field];
                SelectedAction.SkillDecalEntry.DecalTextureName = DecalTextureName_field;
                SelectedAction.SkillDecalEntry.DecalHeightScale = DecalHeightScale_field;
                SelectedAction.SkillDecalEntry.DecalWidthScale = DecalWidthScale_field;


                SelectedAction.SkillCameraQuakeEntry.UseCameraQuake = UseCameraQuake_field;
                SelectedAction.SkillCameraQuakeEntry.HeightStrength = HeightStrength_field;
                SelectedAction.SkillCameraQuakeEntry.WidthStrength = WidthStrength_field;
                SelectedAction.SkillCameraQuakeEntry.QuakeTime = QuakeTime_field;
                SelectedAction.SkillCameraQuakeEntry.PerReduction = PerReduction_field;
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_82"]);
            }
        }

        public void AddSound() {
            if (SelectedAction is not null) {
                SkillSoundModel new_sound_entry = new SkillSoundModel();
                new_sound_entry.Code = "S_sound";
                new_sound_entry.Interval = 0;
                new_sound_entry.Delay = 0;
                new_sound_entry.Repeat = 1;
                SelectedAction.SoundList.Add(new_sound_entry);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_83"]);
            }
        }

        public void DeleteSound() {
            if (SelectedSound is not null) {
                SoundList.Remove(SelectedSound);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_84"]);
            }
        }

        public void SaveSound() {
            if (SelectedSound is not null) {
                SelectedSound.Code = Code_field;
                SelectedSound.Delay = Delay_field;
                SelectedSound.Interval = Interval_field;
                SelectedSound.Repeat = Repeat_field;
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_85"]);
            }
        }

        public void AddEffect() {
            if (SelectedEvent is not null) {
                SkillEffectModel new_effect_entry = new SkillEffectModel();
                new_effect_entry.EffectName = "skill_entry_name";
                new_effect_entry.ShotType = "";
                new_effect_entry.ShotParam1 = 0;
                new_effect_entry.ShotParam2 = 0;
                new_effect_entry.Coord = "";
                new_effect_entry.TargetDir = false;
                new_effect_entry.PlaneDir = false;
                if (SelectedEvent.EffectList.Count != 2) {
                    SelectedEvent.EffectList.Add(new_effect_entry);
                } else {

                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_86"]);
                }
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_87"]);
            }
        }

        public void DeleteEffect() {
            if (SelectedEffect is not null) {
                EffectList.Remove(SelectedEffect);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_88"]);
            }
        }

        public void SaveEffect() {
            if (SelectedEffect is not null) {
                SelectedEffect.EffectName = EffectName_field;
                SelectedEffect.ShotType = Program.ProjectileShotType[ShotTypeIndex_field];
                SelectedEffect.ShotParam1 = ShotParam1_field;
                SelectedEffect.ShotParam2 = ShotParam2_field;
                SelectedEffect.Coord = Coord_field;
                SelectedEffect.TargetDir = TargetDir_field;
                SelectedEffect.PlaneDir = PlaneDir_field;
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_89"]);
            }
        }

        public void AddEvent() {
            if (SelectedAction is not null) {
                SkillEventModel new_event_entry = new SkillEventModel();
                new_event_entry.EventType = "SKILL_EVENT_TYPE_ANIMATION_END";
                new_event_entry.EventCommand = "SKILL_EVENT_COMMAND_KILL";
                new_event_entry.EventCommandParameter = 0;
                new_event_entry.EventArgument = 0;
                new_event_entry.EnableLoopCount = false;
                new_event_entry.LoopCount = 0;
                new_event_entry.EffectList = new ObservableCollection<SkillEffectModel>();
                SelectedAction.EventList.Add(new_event_entry);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_90"]);
            }
        }
        public void DeleteEvent() {
            if (SelectedEvent is not null) {
                EventList.Remove(SelectedEvent);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_91"]);
            }
        }
        public void SaveEvent() {
            if (SelectedEvent is not null) {
                SelectedEvent.EventType = Program.ProjectileEventType[EventTypeIndex_field];
                SelectedEvent.EventCommand = Program.ProjectileCommand[EventCommandIndex_field];
                SelectedEvent.EventCommandParameter = EventCommandParameter_field;
                SelectedEvent.EventArgument = EventArgument_field;
                SelectedEvent.EnableLoopCount = EnableLoopCount_field;
                SelectedEvent.LoopCount = LoopCount_field;
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_92"]);
            }
        }

        public void SaveFile() {
            try {
                if (SkillList.Count > 0) {
                    if (filePath != "") {

                        if (File.Exists(filePath + ".backup")) {
                            File.Delete(filePath + ".backup");
                        }
                        File.Copy(filePath, filePath + ".backup");
                        File.WriteAllBytes(filePath, ConvertToFile());
                        ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_3"] + filePath + ".");
                    } else {
                        SaveFileAs();
                    }
                } else {
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_93"]);
                }
            }
            catch (Exception ex) {
                ModernWpf.MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
        }

        public void SaveFileAs(string basepath = "") {
            if (SkillList.Count > 0) {
                SaveFileDialog s = new SaveFileDialog();
                {
                    s.DefaultExt = ".xfbin";
                    s.Filter = "*.xfbin|*.xfbin";
                }
                if (basepath != "")
                    s.FileName = basepath;
                else
                    s.ShowDialog();
                if (s.FileName == "") {
                    return;
                }
                if (s.FileName == filePath) {
                    if (File.Exists(filePath + ".backup")) {
                        File.Delete(filePath + ".backup");
                    }
                    File.Copy(filePath, filePath + ".backup");
                } else {
                    filePath = s.FileName;
                }
                File.WriteAllBytes(filePath, ConvertToFile());
                if (basepath == "")
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_3"] + filePath + ".");
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_93"]);
            }
        }

        public byte[] ConvertToFile() {
            // Build the header
            int totalLength4 = 0;

            byte[] fileBytes36 = new byte[127] { 0x4E, 0x55, 0x43, 0x43, 0x00, 0x00, 0x00, 0x79, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xBC, 0x00, 0x00, 0x00, 0x03, 0x00, 0x79, 0x3E, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x3B, 0x00, 0x00, 0x01, 0x49, 0x00, 0x00, 0x4C, 0xE3, 0x00, 0x00, 0x01, 0x4B, 0x00, 0x00, 0x0F, 0x6F, 0x00, 0x00, 0x01, 0x4B, 0x00, 0x00, 0x0F, 0x84, 0x00, 0x00, 0x05, 0x20, 0x00, 0x00, 0x00, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x4E, 0x75, 0x6C, 0x6C, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x42, 0x69, 0x6E, 0x61, 0x72, 0x79, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x50, 0x61, 0x67, 0x65, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x49, 0x6E, 0x64, 0x65, 0x78, 0x00 };
            int PtrNucc = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            for (int x6 = 0; x6 < SkillList.Count; x6++) {
                fileBytes36 = BinaryReader.b_AddString(fileBytes36, "e:/next5/char_hi/param/skill/e/" + SkillList[x6].ChunkName + ".xml");
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            }

            int PtrPath = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            for (int x5 = 0; x5 < 1; x5++) {
                fileBytes36 = BinaryReader.b_AddString(fileBytes36, SkillList[x5].ChunkName);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            }
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "Page0");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "index");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            for (int x4 = 1; x4 < SkillList.Count; x4++) {
                fileBytes36 = BinaryReader.b_AddString(fileBytes36, SkillList[x4].ChunkName);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            }

            int PtrName = fileBytes36.Length;
            totalLength4 = PtrName;
            int AddedBytes = 0;

            while (fileBytes36.Length % 4 != 0) {
                AddedBytes++;
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            }

            // Build bin1
            totalLength4 = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[48]
            {
                0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03
            });

            for (int x3 = 1; x3 < SkillList.Count; x3++) {
                int actualEntry = x3 - 1;
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[4]
                {
                    0,
                    0,
                    0,
                    1
                });
                byte[] xbyte = BitConverter.GetBytes(2 + actualEntry);
                byte[] ybyte = BitConverter.GetBytes(4 + actualEntry);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, xbyte, 1);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, ybyte, 1);
            }

            int PtrSection = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[16]
            {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                2,
                0,
                0,
                0,
                3
            });
            for (int x2 = 1; x2 < SkillList.Count; x2++) {
                int actualEntry2 = x2 - 1;
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[4]);
                byte[] xbyte2 = BitConverter.GetBytes(4 + actualEntry2);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, xbyte2, 1);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[4]
                {
                    0,
                    0,
                    0,
                    2
                });
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[4]
                {
                    0,
                    0,
                    0,
                    3
                });
            }

            totalLength4 = fileBytes36.Length;

            int PathLength = PtrPath - 127;
            int NameLength = PtrName - PtrPath;
            int Section1Length = PtrSection - PtrName - AddedBytes;
            int FullLength = totalLength4 - 68 + 40;
            int ReplaceIndex8 = 16;
            byte[] buffer8 = BitConverter.GetBytes(FullLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 36;
            buffer8 = BitConverter.GetBytes(SkillList.Count + 1);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 40;
            buffer8 = BitConverter.GetBytes(PathLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 44;
            buffer8 = BitConverter.GetBytes(SkillList.Count + 3);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 48;
            buffer8 = BitConverter.GetBytes(NameLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 52;
            buffer8 = BitConverter.GetBytes(SkillList.Count + 3);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 56;
            buffer8 = BitConverter.GetBytes(Section1Length);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 60;
            buffer8 = BitConverter.GetBytes(SkillList.Count * 4);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            for (int x = 0; x < SkillList.Count; x++) {
                fileBytes36 = ((x != 0) ? BinaryReader.b_AddBytes(fileBytes36, new byte[32]
                {
                    0,
                    0,
                    0,
                    8,
                    0,
                    0,
                    0,
                    2,
                    0,
                    121,
                    0,
                    0,
                    0,
                    0,
                    0,
                    4,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    121,
                    0,
                    0,

                }) : BinaryReader.b_AddBytes(fileBytes36, new byte[24]
                {
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    121,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    121,
                    0,
                    0,

                }));

                XDocument XmlDoc = new XDocument(new XDeclaration("1.0", "Shift_JIS", "yes"));

                XElement SkillEntryChunk = new XElement("Skill",
                    new XAttribute("id", SkillList[x].ChunkName),
                    new XAttribute("type", SkillList[x].SkillType)
                    );

                //Hit Chunk
                XElement HitChunk = new XElement("Hit",
                   new XAttribute("radius", SkillList[x].HitEntry.HitRadius),
                   new XAttribute("worldHitRadius", SkillList[x].HitEntry.HitWorldRadius),
                   new XAttribute("priorityCategory", SkillList[x].HitEntry.HitPriorityCategory ?? ""),
                   new XAttribute("priorityOffset", SkillList[x].HitEntry.HitPriorityOffset),
                   new XAttribute("damageId", SkillList[x].HitEntry.HitDamageID ?? ""));
                if (SkillList[x].HitEntry.HitVerticalLimit != 0)
                    HitChunk.Add(new XAttribute("hitLimitV", SkillList[x].HitEntry.HitVerticalLimit));
                if (SkillList[x].HitEntry.HitHorizontalLimit != 0)
                    HitChunk.Add(new XAttribute("hitLimitH", SkillList[x].HitEntry.HitHorizontalLimit));
                if (SkillList[x].HitEntry.HitPoint != 0)
                    HitChunk.Add(new XAttribute("hitPoint", SkillList[x].HitEntry.HitPoint));
                if (SkillList[x].HitEntry.HitIntervalFrame != 0)
                    HitChunk.Add(new XAttribute("hitIntervalFrame", SkillList[x].HitEntry.HitIntervalFrame));
                if (SkillList[x].HitEntry.SkillAttributeType is not null && SkillList[x].HitEntry.SkillAttributeType != "")
                    HitChunk.Add(new XAttribute("skillAttributeType", SkillList[x].HitEntry.SkillAttributeType ?? ""));
                if (SkillList[x].HitEntry.RigidBody)
                    HitChunk.Add(new XAttribute("rigidBody", SkillList[x].HitEntry.RigidBody));
                //FilePaths
                XElement FilePaths = new XElement("Files",
                    new XAttribute("num", SkillList[x].FilePathList.Count));

                for (int f =0; f< SkillList[x].FilePathList.Count; f++) {
                    XElement filePath = new XElement("File",
                    new XAttribute("path", SkillList[x].FilePathList[f]));
                    FilePaths.Add(filePath);
                }


                //Action List
                XElement Actions = new XElement("Actions",
                    new XAttribute("num", SkillList[x].ActionList.Count));

                //Action Code
                for (int i = 0; i < SkillList[x].ActionList.Count; i++) {
                    XElement AnimationChunk = new XElement("Animation");

                    if (SkillList[x].ActionList[i].AnimationEntry.AnimationChunkName != "" && SkillList[x].ActionList[i].AnimationEntry.AnimationChunkName is not null && !SkillList[x].ActionList[i].AnimationEntry.KeepPreviousAnimation)
                        AnimationChunk.Add(new XAttribute("chunk", SkillList[x].ActionList[i].AnimationEntry.AnimationChunkName ?? ""));
                    if (SkillList[x].ActionList[i].AnimationEntry.KeepPreviousAnimation)
                        AnimationChunk.Add(new XAttribute("inherite", SkillList[x].ActionList[i].AnimationEntry.KeepPreviousAnimation));

                    XElement SkillHit = new XElement("Hit");

                    if (SkillList[x].ActionList[i].HitEntry.HitDamageID !="" && SkillList[x].ActionList[i].HitEntry.HitDamageID is not null)
                        SkillHit.Add(new XAttribute("damageId", SkillList[x].ActionList[i].HitEntry.HitDamageID ?? ""));
                    if (SkillList[x].ActionList[i].HitEntry.HitRadius != 0)
                    SkillHit.Add(new XAttribute("hitRadius", SkillList[x].ActionList[i].HitEntry.HitRadius));
                    if (SkillList[x].ActionList[i].HitEntry.HitWorldRadius != 0)
                        SkillHit.Add(new XAttribute("hitRadiusWorld", SkillList[x].ActionList[i].HitEntry.HitWorldRadius));
                    if (SkillList[x].ActionList[i].HitEntry.HitPoint != 0)
                        SkillHit.Add(new XAttribute("hitPoint", SkillList[x].ActionList[i].HitEntry.HitPoint));
                    if (SkillList[x].ActionList[i].HitEntry.HitIntervalFrame != 0)
                        SkillHit.Add(new XAttribute("hitInterval", SkillList[x].ActionList[i].HitEntry.HitIntervalFrame));
                    if (SkillList[x].ActionList[i].HitEntry.HitVerticalLimit != 0)
                        SkillHit.Add(new XAttribute("hitLimitV", SkillList[x].ActionList[i].HitEntry.HitVerticalLimit));
                    if (SkillList[x].ActionList[i].HitEntry.HitHorizontalLimit != 0)
                        SkillHit.Add(new XAttribute("hitLimitH", SkillList[x].ActionList[i].HitEntry.HitHorizontalLimit));


                    string SkillDecal_bool = Convert.ToString(SkillList[x].ActionList[i].SkillDecalEntry.UseDecalCheckBox);
                    string SkillHomingChunk_bool1 = Convert.ToString(SkillList[x].ActionList[i].SkillHomingEntry.UseSkillHoming);
                    string SkillHomingChunk_bool2 = Convert.ToString(SkillList[x].ActionList[i].SkillHomingEntry.UseEnemyHoming);
                    string SkillCameraQuakeChunk_bool = Convert.ToString(SkillList[x].ActionList[i].SkillCameraQuakeEntry.UseCameraQuake);

                    

                    XElement SkillDecalChunk = new XElement("SkillDecal",
                        new XAttribute("UseDecalCheckBox", char.ToUpper(SkillDecal_bool[0]) + SkillDecal_bool.Substring(1)),
                        new XAttribute("skillDecalType", SkillList[x].ActionList[i].SkillDecalEntry.SkillDecalType ?? ""),
                        new XAttribute("decalTextureName", SkillList[x].ActionList[i].SkillDecalEntry.DecalTextureName ?? ""),
                        new XAttribute("decalHeightScale", SkillList[x].ActionList[i].SkillDecalEntry.DecalHeightScale),
                        new XAttribute("decalWidthScale", SkillList[x].ActionList[i].SkillDecalEntry.DecalWidthScale)
                        );
                    XElement SkillHomingChunk = new XElement("SkillHoming",
                        new XAttribute("useSkillHoming", char.ToUpper(SkillHomingChunk_bool1[0]) + SkillHomingChunk_bool1.Substring(1)),
                        new XAttribute("skillHomingSkillName", SkillList[x].ActionList[i].SkillHomingEntry.SkillHomingSkillName ?? ""),
                        new XAttribute("skillHomingDummy", SkillList[x].ActionList[i].SkillHomingEntry.SkillHomingDummy ?? ""),
                        new XAttribute("skillHomingActionNum", SkillList[x].ActionList[i].SkillHomingEntry.SkillHomingActionNum),
                        new XAttribute("playerHomingDummy", SkillList[x].ActionList[i].SkillHomingEntry.PlayerHomingDummy ?? ""),
                        new XAttribute("useEnemyHoming", char.ToUpper(SkillHomingChunk_bool2[0]) + SkillHomingChunk_bool2.Substring(1))
                        );
                    XElement SkillCameraQuakeChunk = new XElement("CameraQuake",
                        new XAttribute("useCameraQuake", char.ToUpper(SkillCameraQuakeChunk_bool[0]) + SkillCameraQuakeChunk_bool.Substring(1)),
                        new XAttribute("HeightStrength", SkillList[x].ActionList[i].SkillCameraQuakeEntry.HeightStrength),
                        new XAttribute("WidthStrength", SkillList[x].ActionList[i].SkillCameraQuakeEntry.WidthStrength),
                        new XAttribute("QuakeTime", SkillList[x].ActionList[i].SkillCameraQuakeEntry.QuakeTime),
                        new XAttribute("PerReduction", SkillList[x].ActionList[i].SkillCameraQuakeEntry.PerReduction)
                        );



                    XElement Action = new XElement("Action",
                        new XAttribute("id", SkillList[x].ActionList[i].ActionID),
                        new XAttribute("type", SkillList[x].ActionList[i].ActionType)
                    );

                    if (SkillList[x].ActionList[i].State != "" && SkillList[x].ActionList[i].State is not null)
                        Action.Add(new XElement("State", new XAttribute("state", SkillList[x].ActionList[i].State ?? "")));
                    if ((SkillList[x].ActionList[i].AnimationEntry.AnimationChunkName != "" && SkillList[x].ActionList[i].AnimationEntry.AnimationChunkName is not null) || SkillList[x].ActionList[i].AnimationEntry.KeepPreviousAnimation != false) {
                        Action.Add(AnimationChunk);
                    }
                    if (SkillList[x].ActionList[i].HitEntry.EnableHit == true) {
                        Action.Add(SkillHit);
                    }
                    if (SkillList[x].ActionList[i].Gravity != 0)
                        Action.Add(new XElement("Gravity", new XAttribute("value", SkillList[x].ActionList[i].Gravity)));
                    if (SkillList[x].ActionList[i].ViewingAngle != 0)
                        Action.Add(new XElement("ViewingAngle", new XAttribute("value", SkillList[x].ActionList[i].ViewingAngle)));
                    if (SkillList[x].ActionList[i].Velocity != 0)
                        Action.Add(new XElement("Velocity", new XAttribute("value", SkillList[x].ActionList[i].Velocity)));
                    if (SkillList[x].ActionList[i].VelocityRandomize != 0)
                        Action.Add(new XElement("VelocityRandomize", new XAttribute("value", SkillList[x].ActionList[i].VelocityRandomize)));
                    if (SkillList[x].ActionList[i].Inductivity != 0)
                        Action.Add(new XElement("Inductivity", new XAttribute("value", SkillList[x].ActionList[i].Inductivity)));
                    if (SkillList[x].ActionList[i].RandomDirection != 0)
                        Action.Add(new XElement("RandomDirection", new XAttribute("value", SkillList[x].ActionList[i].RandomDirection)));
                    if (SkillList[x].ActionList[i].RandomRoll != 0)
                        Action.Add(new XElement("RandomRoll", new XAttribute("value", SkillList[x].ActionList[i].RandomRoll)));
                    if (SkillList[x].ActionList[i].BankStrong != 0)
                        Action.Add(new XElement("BankStrong", new XAttribute("value", SkillList[x].ActionList[i].BankStrong)));
                    if (SkillList[x].ActionList[i].BankRollMax != 0)
                        Action.Add(new XElement("BankRollMax", new XAttribute("value", SkillList[x].ActionList[i].BankRollMax)));
                    if (SkillList[x].ActionList[i].BankSpring != 0)
                        Action.Add(new XElement("BankSpring", new XAttribute("value", SkillList[x].ActionList[i].BankSpring)));
                    if (SkillList[x].ActionList[i].CharacterHitDisable)
                        Action.Add(new XElement("CharacterHitDisable", new XAttribute("value", SkillList[x].ActionList[i].CharacterHitDisable)));
                    if (SkillList[x].ActionList[i].WorldHitDisable)
                        Action.Add(new XElement("WorldHitDisable", new XAttribute("value", SkillList[x].ActionList[i].WorldHitDisable)));

                    if (SkillList[x].ActionList[i].ActionType == "SKILL_ACTION_TYPE_BOUNDBALL") {
                        if (SkillList[x].ActionList[i].Restitution != 0)
                            Action.Add(new XElement("Restitution", new XAttribute("value", SkillList[x].ActionList[i].Restitution)));
                        if (SkillList[x].ActionList[i].Friction != 0)
                            Action.Add(new XElement("Friction", new XAttribute("value", SkillList[x].ActionList[i].Friction)));

                    }
                    if (SkillList[x].ActionList[i].ActionType == "SKILL_ACTION_TYPE_SINCURVE") {
                        if (SkillList[x].ActionList[i].Frequency_x != 0)
                            Action.Add(new XElement("Frequency_x", new XAttribute("value", SkillList[x].ActionList[i].Frequency_x)));
                        if (SkillList[x].ActionList[i].Frequency_y != 0)
                            Action.Add(new XElement("Frequency_y", new XAttribute("value", SkillList[x].ActionList[i].Frequency_y)));
                        if (SkillList[x].ActionList[i].Frequency_z != 0)
                            Action.Add(new XElement("Frequency_z", new XAttribute("value", SkillList[x].ActionList[i].Frequency_z)));
                        if (SkillList[x].ActionList[i].Amplitude_x != 0)
                            Action.Add(new XElement("Amplitude_x", new XAttribute("value", SkillList[x].ActionList[i].Amplitude_x)));
                        if (SkillList[x].ActionList[i].Amplitude_y != 0)
                            Action.Add(new XElement("Amplitude_y", new XAttribute("value", SkillList[x].ActionList[i].Amplitude_y)));
                        if (SkillList[x].ActionList[i].Amplitude_z != 0)
                            Action.Add(new XElement("Amplitude_z", new XAttribute("value", SkillList[x].ActionList[i].Amplitude_z)));
                    }
                    if (SkillList[x].ActionList[i].NumLimitEnable) {
                        Action.Add(new XElement("NumLimitEnable", new XAttribute("value", SkillList[x].ActionList[i].NumLimitEnable)));
                        if (SkillList[x].ActionList[i].NumLimitNum != 0)
                            Action.Add(new XElement("NumLimitNum", new XAttribute("value", SkillList[x].ActionList[i].NumLimitNum)));
                    }
                    if (SkillList[x].ActionList[i].HitAttach != "" && SkillList[x].ActionList[i].HitAttach is not null)
                        Action.Add(new XElement("HitAttach", new XAttribute("value", SkillList[x].ActionList[i].HitAttach ?? "")));
                    if (SkillList[x].ActionList[i].HitAttach2 != "" && SkillList[x].ActionList[i].HitAttach2 is not null)
                        Action.Add(new XElement("HitAttach2", new XAttribute("value", SkillList[x].ActionList[i].HitAttach2 ?? "")));
                    if (SkillList[x].ActionList[i].HitAttach3 != "" && SkillList[x].ActionList[i].HitAttach3 is not null)
                        Action.Add(new XElement("HitAttach3", new XAttribute("value", SkillList[x].ActionList[i].HitAttach3 ?? "")));
                    if (SkillList[x].ActionList[i].HitAttach4 != "" && SkillList[x].ActionList[i].HitAttach4 is not null)
                        Action.Add(new XElement("HitAttach4", new XAttribute("value", SkillList[x].ActionList[i].HitAttach4 ?? "")));
                    if (SkillList[x].ActionList[i].HitAttach5 != "" && SkillList[x].ActionList[i].HitAttach5 is not null)
                        Action.Add(new XElement("HitAttach5", new XAttribute("value", SkillList[x].ActionList[i].HitAttach5 ?? "")));

                    if (SkillList[x].ActionList[i].ActionType == "SKILL_ACTION_TYPE_CRAWLER") {
                        if (SkillList[x].ActionList[i].FixedUp)
                            Action.Add(new XElement("FixedUp", new XAttribute("value", SkillList[x].ActionList[i].FixedUp)));
                    }
                    if (SkillList[x].ActionList[i].SkillHitMine)
                        Action.Add(new XElement("SkillHitMine", new XAttribute("value", SkillList[x].ActionList[i].SkillHitMine)));
                    if (SkillList[x].ActionList[i].AtkHitMine)
                        Action.Add(new XElement("AtkHitMine", new XAttribute("value", SkillList[x].ActionList[i].AtkHitMine)));

                    
                    
                    
                    
                    //Event List
                    for (int s = 0; s < SkillList[x].ActionList[i].EventList.Count; s++) {

                        XElement EventElement = new XElement("Event",
                            new XAttribute("type", SkillList[x].ActionList[i].EventList[s].EventType ?? "")
                        );

                        if (SkillList[x].ActionList[i].EventList[s].EventCommand is not null && SkillList[x].ActionList[i].EventList[s].EventCommand != "") {
                            EventElement.Add(new XAttribute("command", SkillList[x].ActionList[i].EventList[s].EventCommand ?? ""));
                            EventElement.Add(new XAttribute("commandParameter", SkillList[x].ActionList[i].EventList[s].EventCommandParameter));
                        }

                        if (SkillList[x].ActionList[i].EventList[s].EventArgument != 0 || SkillList[x].ActionList[i].EventList[s].EventType == "SKILL_EVENT_TYPE_FRAME_ELAPSED") {
                            EventElement.Add(new XAttribute("arg", SkillList[x].ActionList[i].EventList[s].EventArgument));
                        }
                        if (SkillList[x].ActionList[i].EventList[s].EnableLoopCount) {
                            EventElement.Add(new XAttribute("loopCount", SkillList[x].ActionList[i].EventList[s].LoopCount));
                        }

                        //Effect List
                        for (int e = 0; e < SkillList[x].ActionList[i].EventList[s].EffectList.Count; e++) {
                            XElement EffectElement = new XElement("Effect",
                                new XAttribute("name", SkillList[x].ActionList[i].EventList[s].EffectList[e].EffectName ?? "")
                            );


                            if (SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotType != "" && SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotType is not null) {
                                EffectElement.Add(new XAttribute("shotType", SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotType ?? ""));
                                if (SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotParam1 != 0)
                                    EffectElement.Add(new XAttribute("shotParam1", SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotParam1));
                                if (SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotParam2 != 0)
                                    EffectElement.Add(new XAttribute("shotParam2", SkillList[x].ActionList[i].EventList[s].EffectList[e].ShotParam2));
                                if (SkillList[x].ActionList[i].EventList[s].EffectList[e].Coord != "" && (SkillList[x].ActionList[i].EventList[s].EffectList[e].Coord) is not null)
                                    EffectElement.Add(new XAttribute("coord", SkillList[x].ActionList[i].EventList[s].EffectList[e].Coord ?? ""));
                            }
                            if (SkillList[x].ActionList[i].EventList[s].EffectList[e].TargetDir)
                                EffectElement.Add(new XAttribute("targetDir", SkillList[x].ActionList[i].EventList[s].EffectList[e].TargetDir));
                            if (SkillList[x].ActionList[i].EventList[s].EffectList[e].PlaneDir)
                                EffectElement.Add(new XAttribute("planeDir", SkillList[x].ActionList[i].EventList[s].EffectList[e].PlaneDir));
                            EventElement.Add(EffectElement);
                        }
                        if (Program.ProjectileEventType.IndexOf(SkillList[x].ActionList[i].EventList[s].EventType) > 0)
                            Action.Add(EventElement);
                    }
                    //Sound List
                    for (int s = 0; s < SkillList[x].ActionList[i].SoundList.Count; s++) {
                        XElement SoundElement = new XElement("SoundEffect",
                        new XAttribute("code", SkillList[x].ActionList[i].SoundList[s].Code ?? ""),
                        new XAttribute("delay", SkillList[x].ActionList[i].SoundList[s].Delay),
                        new XAttribute("repeat", SkillList[x].ActionList[i].SoundList[s].Repeat),
                        new XAttribute("interval", SkillList[x].ActionList[i].SoundList[s].Interval)
                        );
                        if (SkillList[x].ActionList[i].SoundList[s].Code is not null && SkillList[x].ActionList[i].SoundList[s].Code != "")
                            Action.Add(SoundElement);
                    }
                    if (SkillList[x].ActionList[i].SkillDecalEntry.UseDecalCheckBox == true) {
                        Action.Add(SkillDecalChunk);
                    }
                    if (SkillList[x].ActionList[i].SkillHomingEntry.UseSkillHoming == true) {
                        Action.Add(SkillHomingChunk);
                    }
                    if (SkillList[x].ActionList[i].SkillCameraQuakeEntry.UseCameraQuake == true) {
                        Action.Add(SkillCameraQuakeChunk);
                    }
                    Actions.Add(Action);
                }

                //Class
                XElement ClassChunk = new XElement("Class",
                    new XAttribute("name", SkillList[x].ClassName ?? ""));

                if (SkillList[x].HitEntry.EnableHit)
                    SkillEntryChunk.Add(HitChunk);
                SkillEntryChunk.Add(FilePaths);
                SkillEntryChunk.Add(Actions);
                if (SkillList[x].ClassName != "" && SkillList[x].ClassName is not null)
                    SkillEntryChunk.Add(ClassChunk);

                XmlDoc.Add(SkillEntryChunk);
                XmlDocument ConvertedXmlDoc = XmlDoc.ToXmlDocument();

                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                XmlTextWriter writer = new XmlTextWriter(stringWriter);
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                ConvertedXmlDoc.WriteTo(writer);
                writer.Flush();


                byte[] skillXmlBytes = Encoding.UTF8.GetBytes(stringWriter.ToString());


                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, BitConverter.GetBytes(skillXmlBytes.Length + 4 + 0x3D), 1);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[8] { 0x00, 0x00, 0x00, 0x01, 0x00, 0x79, 0x07, 0x77 });
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, BitConverter.GetBytes(skillXmlBytes.Length + 0x3D), 1);
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[0x3D] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31, 0x2E, 0x30, 0x22, 0x20, 0x65, 0x6E, 0x63, 0x6F, 0x64, 0x69, 0x6E, 0x67, 0x3D, 0x22, 0x53, 0x68, 0x69, 0x66, 0x74, 0x5F, 0x4A, 0x49, 0x53, 0x22, 0x20, 0x73, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x6C, 0x6F, 0x6E, 0x65, 0x3D, 0x22, 0x79, 0x65, 0x73, 0x22, 0x3F, 0x3E, 0x0D, 0x0A });
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, skillXmlBytes);


            }
            return BinaryReader.b_AddBytes(fileBytes36, new byte[20]
            {
                0,
                0,
                0,
                8,
                0,
                0,
                0,
                2,
                0,
                121,
                0,
                0,
                0,
                0,
                0,
                4,
                0,
                0,
                0,
                0
            });
        }


        private RelayCommand _openFileCommand;
        public RelayCommand OpenFileCommand {
            get {
                return _openFileCommand ??
                  (_openFileCommand = new RelayCommand(obj => {
                      OpenFile();
                  }));
            }
        }

        private RelayCommand _addFilePathCommand;
        public RelayCommand AddFilePathCommand {
            get {
                return _addFilePathCommand ??
                  (_addFilePathCommand = new RelayCommand(obj => {
                      AddFilePath();
                  }));
            }
        }
        private RelayCommand _deleteFilePathCommand;
        public RelayCommand DeleteFilePathCommand {
            get {
                return _deleteFilePathCommand ??
                  (_deleteFilePathCommand = new RelayCommand(obj => {
                      DeleteFilePath();
                  }));
            }
        }

        private RelayCommand _addSkillCommand;
        public RelayCommand AddSkillCommand {
            get {
                return _addSkillCommand ??
                  (_addSkillCommand = new RelayCommand(obj => {
                      AddSkill();
                  }));
            }
        }
        private RelayCommand _deleteSkillCommand;
        public RelayCommand DeleteSkillCommand {
            get {
                return _deleteSkillCommand ??
                  (_deleteSkillCommand = new RelayCommand(obj => {
                      DeleteSkill();
                  }));
            }
        }
        private RelayCommand _duplicateSkillCommand;
        public RelayCommand DuplicateSkillCommand {
            get {
                return _duplicateSkillCommand ??
                  (_duplicateSkillCommand = new RelayCommand(obj => {
                      DuplicateSkill();
                  }));
            }
        }
        private RelayCommand _saveSkillCommand;
        public RelayCommand SaveSkillCommand {
            get {
                return _saveSkillCommand ??
                  (_saveSkillCommand = new RelayCommand(obj => {
                      SaveSkill();
                  }));
            }
        }
        private RelayCommand _searchSkillCommand;
        public RelayCommand SearchSkillCommand {
            get {
                return _searchSkillCommand ??
                  (_searchSkillCommand = new RelayCommand(obj => {
                      SearchSkill();
                  }));
            }
        }
        private RelayCommand _addActionCommand;
        public RelayCommand AddActionCommand {
            get {
                return _addActionCommand ??
                  (_addActionCommand = new RelayCommand(obj => {
                      AddAction();
                  }));
            }
        }
        private RelayCommand _deleteActionCommand;
        public RelayCommand DeleteActionCommand {
            get {
                return _deleteActionCommand ??
                  (_deleteActionCommand = new RelayCommand(obj => {
                      DeleteAction();
                  }));
            }
        }
        private RelayCommand _saveActionCommand;
        public RelayCommand SaveActionCommand {
            get {
                return _saveActionCommand ??
                  (_saveActionCommand = new RelayCommand(obj => {
                      SaveAction();
                  }));
            }
        }

        private RelayCommand _addSoundCommand;
        public RelayCommand AddSoundCommand {
            get {
                return _addSoundCommand ??
                  (_addSoundCommand = new RelayCommand(obj => {
                      AddSound();
                  }));
            }
        }
        private RelayCommand _deleteSoundCommand;
        public RelayCommand DeleteSoundCommand {
            get {
                return _deleteSoundCommand ??
                  (_deleteSoundCommand = new RelayCommand(obj => {
                      DeleteSound();
                  }));
            }
        }
        private RelayCommand _saveSoundCommand;
        public RelayCommand SaveSoundCommand {
            get {
                return _saveSoundCommand ??
                  (_saveSoundCommand = new RelayCommand(obj => {
                      SaveSound();
                  }));
            }
        }

        private RelayCommand _addEffectCommand;
        public RelayCommand AddEffectCommand {
            get {
                return _addEffectCommand ??
                  (_addEffectCommand = new RelayCommand(obj => {
                      AddEffect();
                  }));
            }
        }
        private RelayCommand _deleteEffectCommand;
        public RelayCommand DeleteEffectCommand {
            get {
                return _deleteEffectCommand ??
                  (_deleteEffectCommand = new RelayCommand(obj => {
                      DeleteEffect();
                  }));
            }
        }
        private RelayCommand _saveEffectCommand;
        public RelayCommand SaveEffectCommand {
            get {
                return _saveEffectCommand ??
                  (_saveEffectCommand = new RelayCommand(obj => {
                      SaveEffect();
                  }));
            }
        }
        private RelayCommand _addEventCommand;
        public RelayCommand AddEventCommand {
            get {
                return _addEventCommand ??
                  (_addEventCommand = new RelayCommand(obj => {
                      AddEvent();
                  }));
            }
        }
        private RelayCommand _deleteEventCommand;
        public RelayCommand DeleteEventCommand {
            get {
                return _deleteEventCommand ??
                  (_deleteEventCommand = new RelayCommand(obj => {
                      DeleteEvent();
                  }));
            }
        }
        private RelayCommand _saveEventCommand;
        public RelayCommand SaveEventCommand {
            get {
                return _saveEventCommand ??
                  (_saveEventCommand = new RelayCommand(obj => {
                      SaveEvent();
                  }));
            }
        }

        private RelayCommand _saveFileAsCommand;
        public RelayCommand SaveFileAsCommand {
            get {
                return _saveFileAsCommand ??
                  (_saveFileAsCommand = new RelayCommand(obj => {
                      SaveFileAs();
                  }));
            }
        }
        private RelayCommand _saveFileCommand;
        public RelayCommand SaveFileCommand {
            get {
                return _saveFileCommand ??
                  (_saveFileCommand = new RelayCommand(obj => {
                      SaveFile();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
    public static class DocumentExtensions {
        public static XmlDocument ToXmlDocument(this XDocument xDocument) {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader()) {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument) {
            using (var nodeReader = new XmlNodeReader(xmlDocument)) {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
