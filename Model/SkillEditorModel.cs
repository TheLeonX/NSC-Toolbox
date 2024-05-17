using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NSC_Toolbox.Model {
    public class SkillEntryModel : ICloneable, INotifyPropertyChanged {
        private string _chunkName;
        public string ChunkName {
            get { return _chunkName; }
            set {
                _chunkName = value;
                OnPropertyChanged("ChunkName");
            }
        }
        private string _skillType;
        public string SkillType {
            get { return _skillType; }
            set {
                _skillType = value;
                OnPropertyChanged("SkillType");
            }
        }
        private SkillHitModel _hitEntry;
        public SkillHitModel HitEntry {
            get { return _hitEntry; }
            set {
                _hitEntry = value;
                OnPropertyChanged("HitEntry");
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
        private string _className;
        public string ClassName {
            get { return _className; }
            set {
                _className = value;
                OnPropertyChanged("ClassName");
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
        public object Clone() {
            ObservableCollection<string> newFilePathList = new ObservableCollection<string>();
            for (int i = 0; i < this.FilePathList.Count; i++) {
                newFilePathList.Add((string)FilePathList[i].Clone());
            }
            ObservableCollection<SkillActionModel> newActionList = new ObservableCollection<SkillActionModel>();
            for (int i = 0; i < this.ActionList.Count; i++) {
                newActionList.Add((SkillActionModel)ActionList[i].Clone());
            }

            return new SkillEntryModel {
                ChunkName = this.ChunkName,
                SkillType = this.SkillType,
                HitEntry = this.HitEntry,
                FilePathList = newFilePathList,
                ActionList = newActionList,
                ClassName = this.ClassName,
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillAnimationModel : ICloneable, INotifyPropertyChanged {
        private bool _keepPreviousAnimation;
        public bool KeepPreviousAnimation {
            get { return _keepPreviousAnimation; }
            set {
                _keepPreviousAnimation = value;
                OnPropertyChanged("KeepPreviousAnimation");
            }
        }
        private string _animationChunkName;
        public string AnimationChunkName {
            get { return _animationChunkName; }
            set {
                _animationChunkName = value;
                OnPropertyChanged("AnimationChunkName");
            }
        }
        public object Clone() {
            return new SkillAnimationModel {
                KeepPreviousAnimation = this.KeepPreviousAnimation,
                AnimationChunkName = this.AnimationChunkName
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillHitModel : ICloneable, INotifyPropertyChanged {
        private bool _enableHit;
        public bool EnableHit {
            get { return _enableHit; }
            set {
                _enableHit = value;
                OnPropertyChanged("EnableHit");
            }
        }
        private float _hitRadius;
        public float HitRadius {
            get { return _hitRadius; }
            set {
                _hitRadius = value;
                OnPropertyChanged("HitRadius");
            }
        }
        private float _hitHorizontalLimit;
        public float HitHorizontalLimit {
            get { return _hitHorizontalLimit; }
            set {
                _hitHorizontalLimit = value;
                OnPropertyChanged("HitHorizontalLimit");
            }
        }
        private float _hitVerticalLimit;
        public float HitVerticalLimit {
            get { return _hitVerticalLimit; }
            set {
                _hitVerticalLimit = value;
                OnPropertyChanged("HitVerticalLimit");
            }
        }
        private float _hitWorldRadius;
        public float HitWorldRadius {
            get { return _hitWorldRadius; }
            set {
                _hitWorldRadius = value;
                OnPropertyChanged("HitWorldRadius");
            }
        }
        private string _skillAttributeType;
        public string SkillAttributeType {
            get { return _skillAttributeType; }
            set {
                _skillAttributeType = value;
                OnPropertyChanged("SkillAttributeType");
            }
        }
        private string _hitPriorityCategory;
        public string HitPriorityCategory {
            get { return _hitPriorityCategory; }
            set {
                _hitPriorityCategory = value;
                OnPropertyChanged("HitPriorityCategory");
            }
        }
        private int _hitPriorityOffset;
        public int HitPriorityOffset {
            get { return _hitPriorityOffset; }
            set {
                _hitPriorityOffset = value;
                OnPropertyChanged("HitPriorityOffset");
            }
        }
        private string _hitDamageID;
        public string HitDamageID {
            get { return _hitDamageID; }
            set {
                _hitDamageID = value;
                OnPropertyChanged("HitDamageID");
            }
        }
        private int _hitPoint;
        public int HitPoint {
            get { return _hitPoint; }
            set {
                _hitPoint = value;
                OnPropertyChanged("HitPoint");
            }
        }
        private int _hitIntervalFrame;
        public int HitIntervalFrame {
            get { return _hitIntervalFrame; }
            set {
                _hitIntervalFrame = value;
                OnPropertyChanged("HitIntervalFrame");
            }
        }
        private bool _rigidBody;
        public bool RigidBody {
            get { return _rigidBody; }
            set {
                _rigidBody = value;
                OnPropertyChanged("RigidBody");
            }
        }
        public object Clone() {
            return new SkillHitModel {
                EnableHit = this.EnableHit,
                HitRadius = this.HitRadius,
                HitHorizontalLimit = this.HitHorizontalLimit,
                HitVerticalLimit = this.HitVerticalLimit,
                HitWorldRadius = this.HitWorldRadius,
                HitPriorityCategory = this.HitPriorityCategory,
                HitPriorityOffset = this.HitPriorityOffset,
                HitDamageID = this.HitDamageID,
                HitPoint = this.HitPoint,
                HitIntervalFrame = this.HitIntervalFrame,
                SkillAttributeType = this.SkillAttributeType,
                RigidBody = this.RigidBody,
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillEventModel : ICloneable, INotifyPropertyChanged {
        private string _eventType;
        public string EventType {
            get { return _eventType; }
            set {
                _eventType = value;
                OnPropertyChanged("EventType");
            }
        }
        private string _eventCommand;
        public string EventCommand {
            get { return _eventCommand; }
            set {
                _eventCommand = value;
                OnPropertyChanged("EventCommand");
            }
        }
        private int _eventCommandParameter;
        public int EventCommandParameter {
            get { return _eventCommandParameter; }
            set {
                _eventCommandParameter = value;
                OnPropertyChanged("EventCommandParameter");
            }
        }
        private int _eventArgument;
        public int EventArgument {
            get { return _eventArgument; }
            set {
                _eventArgument = value;
                OnPropertyChanged("EventArgument");
            }
        }
        private bool _enableLoopCount;
        public bool EnableLoopCount {
            get { return _enableLoopCount; }
            set {
                _enableLoopCount = value;
                OnPropertyChanged("EnableLoopCount");
            }
        }
        private int _loopCount;
        public int LoopCount {
            get { return _loopCount; }
            set {
                _loopCount = value;
                OnPropertyChanged("LoopCount");
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
        public object Clone() {
            ObservableCollection<SkillEffectModel> newEffectList = new ObservableCollection<SkillEffectModel>();
            for (int i = 0; i < this.EffectList.Count; i++) {
                newEffectList.Add((SkillEffectModel)EffectList[i].Clone());
            }
            return new SkillEventModel {
                EventType = this.EventType,
                EventCommand = this.EventCommand,
                EventCommandParameter = this.EventCommandParameter,
                EventArgument = this.EventArgument,
                EnableLoopCount = this.EnableLoopCount,
                LoopCount = this.LoopCount,
                EffectList = newEffectList
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillEffectModel : ICloneable, INotifyPropertyChanged {
        private string _effectName;
        public string EffectName {
            get { return _effectName; }
            set {
                _effectName = value;
                OnPropertyChanged("EffectName");
            }
        }
        private string _shotType;
        public string ShotType {
            get { return _shotType; }
            set {
                _shotType = value;
                OnPropertyChanged("ShotType");
            }
        }
        private float _shotParam1;
        public float ShotParam1 {
            get { return _shotParam1; }
            set {
                _shotParam1 = value;
                OnPropertyChanged("ShotParam1");
            }
        }
        private float _shotParam2;
        public float ShotParam2 {
            get { return _shotParam2; }
            set {
                _shotParam2 = value;
                OnPropertyChanged("ShotParam2");
            }
        }
        private string _coord;
        public string Coord {
            get { return _coord; }
            set {
                _coord = value;
                OnPropertyChanged("Coord");
            }
        }
        private bool _targetDir;
        public bool TargetDir {
            get { return _targetDir; }
            set {
                _targetDir = value;
                OnPropertyChanged("TargetDir");
            }
        }
        private bool _planeDir;
        public bool PlaneDir {
            get { return _planeDir; }
            set {
                _planeDir = value;
                OnPropertyChanged("PlaneDir");
            }
        }
        public object Clone() {
            return new SkillEffectModel {
                EffectName = this.EffectName,
                ShotType = this.ShotType,
                ShotParam1 = this.ShotParam1,
                ShotParam2 = this.ShotParam2,
                Coord = this.Coord,
                TargetDir = this.TargetDir,
                PlaneDir = this.PlaneDir
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillSoundModel : ICloneable, INotifyPropertyChanged {
        private string _code;
        public string Code {
            get { return _code; }
            set {
                _code = value;
                OnPropertyChanged("Code");
            }
        }
        private int _delay;
        public int Delay {
            get { return _delay; }
            set {
                _delay = value;
                OnPropertyChanged("Delay");
            }
        }
        private int _repeat;
        public int Repeat {
            get { return _repeat; }
            set {
                _repeat = value;
                OnPropertyChanged("Repeat");
            }
        }
        private int _interval;
        public int Interval {
            get { return _interval; }
            set {
                _interval = value;
                OnPropertyChanged("Interval");
            }
        }
        public object Clone() {
            return new SkillSoundModel {
                Code = this.Code,
                Delay = this.Delay,
                Repeat = this.Repeat,
                Interval = this.Interval
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillHomingModel : ICloneable, INotifyPropertyChanged {
        private bool _useSkillHoming;
        public bool UseSkillHoming {
            get { return _useSkillHoming; }
            set {
                _useSkillHoming = value;
                OnPropertyChanged("UseSkillHoming");
            }
        }
        private string _skillHomingSkillName;
        public string SkillHomingSkillName {
            get { return _skillHomingSkillName; }
            set {
                _skillHomingSkillName = value;
                OnPropertyChanged("SkillHomingSkillName");
            }
        }
        private string _skillHomingDummy;
        public string SkillHomingDummy {
            get { return _skillHomingDummy; }
            set {
                _skillHomingDummy = value;
                OnPropertyChanged("SkillHomingDummy");
            }
        }
        private int _skillHomingActionNum;
        public int SkillHomingActionNum {
            get { return _skillHomingActionNum; }
            set {
                _skillHomingActionNum = value;
                OnPropertyChanged("SkillHomingActionNum");
            }
        }
        private string _playerHomingDummy;
        public string PlayerHomingDummy {
            get { return _playerHomingDummy; }
            set {
                _playerHomingDummy = value;
                OnPropertyChanged("PlayerHomingDummy");
            }
        }
        private bool _useEnemyHoming;
        public bool UseEnemyHoming {
            get { return _useEnemyHoming; }
            set {
                _useEnemyHoming = value;
                OnPropertyChanged("UseEnemyHoming");
            }
        }
        public object Clone() {
            return new SkillHomingModel {
                UseSkillHoming = this.UseSkillHoming,
                SkillHomingSkillName = this.SkillHomingSkillName,
                SkillHomingDummy = this.SkillHomingDummy,
                SkillHomingActionNum = this.SkillHomingActionNum,
                PlayerHomingDummy = this.PlayerHomingDummy,
                UseEnemyHoming = this.UseEnemyHoming,
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillDecalModel : ICloneable, INotifyPropertyChanged {
        private bool _useDecalCheckBox;
        public bool UseDecalCheckBox {
            get { return _useDecalCheckBox; }
            set {
                _useDecalCheckBox = value;
                OnPropertyChanged("UseDecalCheckBox");
            }
        }
        private string _skillDecalType;
        public string SkillDecalType {
            get { return _skillDecalType; }
            set {
                _skillDecalType = value;
                OnPropertyChanged("SkillDecalType");
            }
        }
        private string _decalTextureName;
        public string DecalTextureName {
            get { return _decalTextureName; }
            set {
                _decalTextureName = value;
                OnPropertyChanged("DecalTextureName");
            }
        }
        private float _decalHeightScale;
        public float DecalHeightScale {
            get { return _decalHeightScale; }
            set {
                _decalHeightScale = value;
                OnPropertyChanged("DecalHeightScale");
            }
        }
        private float _decalWidthScale;
        public float DecalWidthScale {
            get { return _decalWidthScale; }
            set {
                _decalWidthScale = value;
                OnPropertyChanged("DecalWidthScale");
            }
        }
        public object Clone() {
            return new SkillDecalModel {
                UseDecalCheckBox = this.UseDecalCheckBox,
                SkillDecalType = this.SkillDecalType,
                DecalTextureName = this.DecalTextureName,
                DecalHeightScale = this.DecalHeightScale,
                DecalWidthScale = this.DecalWidthScale
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillCameraQuakeModel : ICloneable, INotifyPropertyChanged {
        private bool _useCameraQuake;
        public bool UseCameraQuake {
            get { return _useCameraQuake; }
            set {
                _useCameraQuake = value;
                OnPropertyChanged("UseCameraQuake");
            }
        }
        private int _heightStrength;
        public int HeightStrength {
            get { return _heightStrength; }
            set {
                _heightStrength = value;
                OnPropertyChanged("HeightStrength");
            }
        }
        private int _widthStrength;
        public int WidthStrength {
            get { return _widthStrength; }
            set {
                _widthStrength = value;
                OnPropertyChanged("WidthStrength");
            }
        }
        private int _quakeTime;
        public int QuakeTime {
            get { return _quakeTime; }
            set {
                _quakeTime = value;
                OnPropertyChanged("QuakeTime");
            }
        }
        private float _perReduction;
        public float PerReduction {
            get { return _perReduction; }
            set {
                _perReduction = value;
                OnPropertyChanged("PerReduction");
            }
        }
        public object Clone() {
            return new SkillCameraQuakeModel {
                UseCameraQuake = this.UseCameraQuake,
                HeightStrength = this.HeightStrength,
                WidthStrength = this.WidthStrength,
                QuakeTime = this.QuakeTime,
                PerReduction = this.PerReduction
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class SkillActionModel : ICloneable, INotifyPropertyChanged {
        private int _actionID;
        public int ActionID {
            get { return _actionID; }
            set {
                _actionID = value;
                OnPropertyChanged("ActionID");
            }
        }
        private string _actionType;
        public string ActionType {
            get { return _actionType; }
            set {
                _actionType = value;
                OnPropertyChanged("ActionType");
            }
        }
        //values
        private float _gravity;
        public float Gravity {
            get { return _gravity; }
            set {
                _gravity = value;
                OnPropertyChanged("Gravity");
            }
        }
        private float _restitution;
        public float Restitution {
            get { return _restitution; }
            set {
                _restitution = value;
                OnPropertyChanged("Restitution");
            }
        }
        private float _randomDirection;
        public float RandomDirection {
            get { return _randomDirection; }
            set {
                _randomDirection = value;
                OnPropertyChanged("RandomDirection");
            }
        }
        private float _randomRoll;
        public float RandomRoll {
            get { return _randomRoll; }
            set {
                _randomRoll = value;
                OnPropertyChanged("RandomRoll");
            }
        }
        private float _viewingAngle;
        public float ViewingAngle {
            get { return _viewingAngle; }
            set {
                _viewingAngle = value;
                OnPropertyChanged("ViewingAngle");
            }
        }
        private float _friction; //max 1, min 0
        public float Friction {
            get { return _friction; }
            set {
                _friction = value;
                OnPropertyChanged("Friction");
            }
        }
        private float _frequency_x;
        public float Frequency_x {
            get { return _frequency_x; }
            set {
                _frequency_x = value;
                OnPropertyChanged("Frequency_x");
            }
        }
        private float _frequency_y;
        public float Frequency_y {
            get { return _frequency_y; }
            set {
                _frequency_y = value;
                OnPropertyChanged("Frequency_y");
            }
        }
        private float _frequency_z;
        public float Frequency_z {
            get { return _frequency_z; }
            set {
                _frequency_z = value;
                OnPropertyChanged("Frequency_z");
            }
        }
        private float _bankStrong;
        public float BankStrong {
            get { return _bankStrong; }
            set {
                _bankStrong = value;
                OnPropertyChanged("BankStrong");
            }
        }
        private float _bankSpring; //max 1, min 0
        public float BankSpring {
            get { return _bankSpring; }
            set {
                _bankSpring = value;
                OnPropertyChanged("BankSpring");
            }
        }
        private float _bankRollMax;
        public float BankRollMax {
            get { return _bankRollMax; }
            set {
                _bankRollMax = value;
                OnPropertyChanged("BankRollMax");
            }
        }
        private float _amplitude_x;
        public float Amplitude_x {
            get { return _amplitude_x; }
            set {
                _amplitude_x = value;
                OnPropertyChanged("Amplitude_x");
            }
        }
        private float _amplitude_y;
        public float Amplitude_y {
            get { return _amplitude_y; }
            set {
                _amplitude_y = value;
                OnPropertyChanged("Amplitude_y");
            }
        }
        private float _amplitude_z;
        public float Amplitude_z {
            get { return _amplitude_z; }
            set {
                _amplitude_z = value;
                OnPropertyChanged("Amplitude_z");
            }
        }
        private float _velocity;
        public float Velocity {
            get { return _velocity; }
            set {
                _velocity = value;
                OnPropertyChanged("Velocity");
            }
        }
        private float _velocityRandomize;
        public float VelocityRandomize {
            get { return _velocityRandomize; }
            set {
                _velocityRandomize = value;
                OnPropertyChanged("VelocityRandomize");
            }
        }
        private float _inductivity;
        public float Inductivity {
            get { return _inductivity; }
            set {
                _inductivity = value;
                OnPropertyChanged("Inductivity");
            }
        }
        private bool _characterHitDisable;
        public bool CharacterHitDisable {
            get { return _characterHitDisable; }
            set {
                _characterHitDisable = value;
                OnPropertyChanged("CharacterHitDisable");
            }
        }
        private bool _worldHitDisable;
        public bool WorldHitDisable {
            get { return _worldHitDisable; }
            set {
                _worldHitDisable = value;
                OnPropertyChanged("WorldHitDisable");
            }
        }
        private int _numLimitNum;
        public int NumLimitNum {
            get { return _numLimitNum; }
            set {
                _numLimitNum = value;
                OnPropertyChanged("NumLimitNum");
            }
        }
        private bool _numLimitEnable;
        public bool NumLimitEnable {
            get { return _numLimitEnable; }
            set {
                _numLimitEnable = value;
                OnPropertyChanged("NumLimitEnable");
            }
        }
        private string _hitAttach;
        public string HitAttach {
            get { return _hitAttach; }
            set {
                _hitAttach = value;
                OnPropertyChanged("HitAttach");
            }
        }
        private string _hitAttach2;
        public string HitAttach2 {
            get { return _hitAttach2; }
            set {
                _hitAttach2 = value;
                OnPropertyChanged("HitAttach2");
            }
        }
        private string _hitAttach3;
        public string HitAttach3 {
            get { return _hitAttach3; }
            set {
                _hitAttach3 = value;
                OnPropertyChanged("HitAttach3");
            }
        }
        private string _hitAttach4;
        public string HitAttach4 {
            get { return _hitAttach4; }
            set {
                _hitAttach4 = value;
                OnPropertyChanged("HitAttach4");
            }
        }
        private string _hitAttach5;
        public string HitAttach5 {
            get { return _hitAttach5; }
            set {
                _hitAttach5 = value;
                OnPropertyChanged("HitAttach5");
            }
        }
        private bool _fixedUp;
        public bool FixedUp {
            get { return _fixedUp; }
            set {
                _fixedUp = value;
                OnPropertyChanged("FixedUp");
            }
        }
        private bool _skillHitMine;
        public bool SkillHitMine {
            get { return _skillHitMine; }
            set {
                _skillHitMine = value;
                OnPropertyChanged("SkillHitMine");
            }
        }
        private bool _atkHitMine;
        public bool AtkHitMine {
            get { return _atkHitMine; }
            set {
                _atkHitMine = value;
                OnPropertyChanged("AtkHitMine");
            }
        }
        private string _state;
        public string State {
            get { return _state; }
            set {
                _state = value;
                OnPropertyChanged("State");
            }
        }
        private SkillAnimationModel _animationEntry;
        public SkillAnimationModel AnimationEntry {
            get { return _animationEntry; }
            set {
                _animationEntry = value;
                OnPropertyChanged("AnimationEntry");
            }
        }
        private SkillHitModel _hitEntry;
        public SkillHitModel HitEntry {
            get { return _hitEntry; }
            set {
                _hitEntry = value;
                OnPropertyChanged("HitEntry");
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
        private SkillHomingModel _skillHomingEntry;
        public SkillHomingModel SkillHomingEntry {
            get { return _skillHomingEntry; }
            set {
                _skillHomingEntry = value;
                OnPropertyChanged("SkillHomingEntry");
            }
        }
        private SkillDecalModel _skillDecalEntry;
        public SkillDecalModel SkillDecalEntry {
            get { return _skillDecalEntry; }
            set {
                _skillDecalEntry = value;
                OnPropertyChanged("SkillDecalEntry");
            }
        }
        private SkillCameraQuakeModel _skillCameraQuakeEntry;
        public SkillCameraQuakeModel SkillCameraQuakeEntry {
            get { return _skillCameraQuakeEntry; }
            set {
                _skillCameraQuakeEntry = value;
                OnPropertyChanged("SkillCameraQuakeEntry");
            }
        }
        public object Clone() {
            ObservableCollection<SkillEventModel> newEventList = new ObservableCollection<SkillEventModel>();
            for (int i = 0; i < this.EventList.Count; i++) {
                newEventList.Add((SkillEventModel)EventList[i].Clone());
            }
            ObservableCollection<SkillSoundModel> newSoundList = new ObservableCollection<SkillSoundModel>();
            for (int i = 0; i < this.SoundList.Count; i++) {
                newSoundList.Add((SkillSoundModel)SoundList[i].Clone());
            }
            return new SkillActionModel {
                ActionID = this.ActionID,
                ActionType = this.ActionType,
                AnimationEntry = this.AnimationEntry,
                HitEntry = this.HitEntry,
                Gravity = this.Gravity,
                Restitution = this.Restitution,
                RandomDirection = this.RandomDirection,
                RandomRoll = this.RandomRoll,
                ViewingAngle = this.ViewingAngle,
                Friction = this.Friction,
                Frequency_x = this.Frequency_x,
                Frequency_y = this.Frequency_y,
                Frequency_z = this.Frequency_z,
                BankStrong = this.BankStrong,
                BankRollMax = this.BankRollMax,
                BankSpring = this.BankSpring,
                Amplitude_x = this.Amplitude_x,
                Amplitude_y = this.Amplitude_y,
                Amplitude_z = this.Amplitude_z,
                Velocity = this.Velocity,
                VelocityRandomize = this.VelocityRandomize,
                Inductivity = this.Inductivity,
                CharacterHitDisable = this.CharacterHitDisable,
                WorldHitDisable = this.WorldHitDisable,
                NumLimitNum = this.NumLimitNum,
                NumLimitEnable = this.NumLimitEnable,
                HitAttach = this.HitAttach,
                HitAttach2 = this.HitAttach2,
                HitAttach3 = this.HitAttach3,
                HitAttach4 = this.HitAttach4,
                HitAttach5 = this.HitAttach5,
                FixedUp = this.FixedUp,
                SkillHitMine = this.SkillHitMine,
                AtkHitMine = this.AtkHitMine,
                State = this.State,
                EventList = newEventList,
                SoundList = newSoundList,
                SkillHomingEntry = this.SkillHomingEntry,
                SkillDecalEntry = this.SkillDecalEntry,
                SkillCameraQuakeEntry = this.SkillCameraQuakeEntry,
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
