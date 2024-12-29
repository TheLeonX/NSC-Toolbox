using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DynamicData;

namespace NSC_Toolbox.Model
{
    //public class TrailEditorModel : ICloneable, INotifyPropertyChanged
    //{
    //    private ObservableCollection<TrailSettingModel> _trailSettings;
    //    public ObservableCollection<TrailSettingModel> TrailSettings
    //    {
    //        get { return _trailSettings; }
    //        set
    //        {
    //            _trailSettings = value;
    //            OnPropertyChanged("TrailSettings");
    //        }
    //    }

    //    private ObservableCollection<TrailMaterialModel> _trailMaterials;
    //    public ObservableCollection<TrailMaterialModel> TrailMaterials
    //    {
    //        get { return _trailMaterials; }
    //        set
    //        {
    //            _trailMaterials = value;
    //            OnPropertyChanged("TrailMaterials");
    //        }
    //    }
    //    private ObservableCollection<TrailClumpModel> _trailClumps;
    //    public ObservableCollection<TrailClumpModel> TrailClumps
    //    {
    //        get { return _trailClumps; }
    //        set
    //        {
    //            _trailClumps = value;
    //            OnPropertyChanged("TrailClumps");
    //        }
    //    }

        

    //    private ObservableCollection<TrailTimelineModel> _trailTimelines;
    //    public ObservableCollection<TrailTimelineModel> TrailTimelines
    //    {
    //        get { return _trailTimelines; }
    //        set
    //        {
    //            _trailTimelines = value;
    //            OnPropertyChanged("TrailTimelines");
    //        }
    //    }

    //    public object Clone()
    //    {
    //        ObservableCollection<TrailSettingModel> newTrailSettingList = new ObservableCollection<TrailSettingModel>();
    //        ObservableCollection<TrailMaterialModel> newTrailMaterialList = new ObservableCollection<TrailMaterialModel>();
    //        ObservableCollection<TrailClumpModel> newTrailClumpList = new ObservableCollection<TrailClumpModel>();
    //        //ObservableCollection<TrailBonesModel> newTrailBonesList = new ObservableCollection<TrailBonesModel>();
    //        ObservableCollection<TrailTimelineModel> newTrailTimelineList = new ObservableCollection<TrailTimelineModel>();
    //        for (int i = 0; i < this.TrailSettings.Count; i++)
    //        {
    //            newTrailSettingList.Add((TrailSettingModel)TrailSettings[i].Clone());
    //        }
    //        for (int i = 0; i < this.TrailMaterials.Count; i++)
    //        {
    //            newTrailMaterialList.Add((TrailMaterialModel)TrailMaterials[i].Clone());
    //        }
    //        for (int i = 0; i < this.TrailClumps.Count; i++)
    //        {
    //            newTrailClumpList.Add((TrailClumpModel)TrailClumps[i].Clone());
    //        }
    //        /*for (int i = 0; i < this.TrailBones.Count; i++)
    //        {
    //            newTrailBonesList.Add((TrailBonesModel)TrailBones[i].Clone());
    //        }*/
    //        for (int i = 0; i < this.TrailTimelines.Count; i++)
    //        {
    //            newTrailTimelineList.Add((TrailTimelineModel)TrailTimelines[i].Clone());
    //        }
    //        return new TrailEditorModel
    //        {
    //            TrailSettings = newTrailSettingList,
    //            TrailMaterials = newTrailMaterialList,
    //            TrailClumps = newTrailClumpList,
    //            TrailTimelines = newTrailTimelineList,
    //            AnimationPath = this.AnimationPath,
    //            AnimationName = this.AnimationName

    //        };
    //    }
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public void OnPropertyChanged([CallerMemberName] string prop = "")
    //    {
    //        if (PropertyChanged != null)
    //            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    //    }
    //}




    public class TrailSettingModel : ICloneable, INotifyPropertyChanged
    {
        private TrailMaterialModel _billboard;
        public TrailMaterialModel Billboard
        {
            get { return _billboard; }
            set
            {
                _billboard = value;
                OnPropertyChanged("Billboard");
            }
        }

        private TrailBonesModel _coords;
        public TrailBonesModel Coords
        {
            get { return _coords; }
            set
            {
                _coords = value;
                OnPropertyChanged("Coords");
            }
        }

        private uint _fadeTime;
        public uint FadeTime
        {
            get { return _fadeTime; }
            set
            {
                _fadeTime = value;
                OnPropertyChanged("FadeTime");
            }
        }
        private uint _unk1;
        public uint Unk1
        {
            get { return _unk1; }
            set
            {
                _unk1 = value;
                OnPropertyChanged("Unk1");
            }
        }
        private UInt16 _unk2;
        public UInt16 Unk2
        {
            get { return _unk2; }
            set
            {
                _unk2 = value;
                OnPropertyChanged("Unk2");
            }
        }
        private UInt16 _unk3;
        public UInt16 Unk3
        {
            get { return _unk3; }
            set
            {
                _unk3 = value;
                OnPropertyChanged("Unk3");
            }
        }
        private Color _color1;
        public Color Color1
        {
            get { return _color1; }
            set
            {
                _color1 = value;
                OnPropertyChanged("Color1");
            }
        }
        private Color _color2;
        public Color Color2
        {
            get { return _color2; }
            set
            {
                _color2 = value;
                OnPropertyChanged("Color3");
            }
        }
        private Color _color3;
        public Color Color3
        {
            get { return _color3; }
            set
            {
                _color3 = value;
                OnPropertyChanged("Color3");
            }
        }
        private float _colorBlend;
        public float ColorBlend
        {
            get { return _colorBlend; }
            set
            {
                _colorBlend = value;
                OnPropertyChanged("ColorBlend");
            }
        }
        private UInt16 _firstBone_Width_1;
        public UInt16 FirstBone_Width_1
        {
            get { return _firstBone_Width_1; }
            set
            {
                _firstBone_Width_1 = value;
                OnPropertyChanged("FirstBone_Width_1");
            }
        }
        private UInt16 _firstBone_Width_2;
        public UInt16 FirstBone_Width_2
        {
            get { return _firstBone_Width_2; }
            set
            {
                _firstBone_Width_2 = value;
                OnPropertyChanged("FirstBone_Width_2");
            }
        }
        private UInt16 _firstBone_Width_3;
        public UInt16 FirstBone_Width_3
        {
            get { return _firstBone_Width_3; }
            set
            {
                _firstBone_Width_3 = value;
                OnPropertyChanged("FirstBone_Width_3");
            }
        }
        private UInt16 _secondBone_Width_1;
        public UInt16 SecondBone_Width_1
        {
            get { return _secondBone_Width_1; }
            set
            {
                _secondBone_Width_1 = value;
                OnPropertyChanged("SecondBone_Width_1");
            }
        }
        private UInt16 _secondBone_Width_2;
        public UInt16 SecondBone_Width_2
        {
            get { return _secondBone_Width_2; }
            set
            {
                _secondBone_Width_2 = value;
                OnPropertyChanged("SecondBone_Width_2");
            }
        }
        private UInt16 _secondBone_Width_3;
        public UInt16 SecondBone_Width_3
        {
            get { return _secondBone_Width_3; }
            set
            {
                _secondBone_Width_3 = value;
                OnPropertyChanged("SecondBone_Width_3");
            }
        }

        private ObservableCollection<TrailTimelineModel> _trailTimelines;
        public ObservableCollection<TrailTimelineModel> TrailTimelines
        {
            get { return _trailTimelines; }
            set
            {
                _trailTimelines = value;
                OnPropertyChanged("TrailTimelines");
            }
        }


        public object Clone()
        {
            ObservableCollection<TrailTimelineModel> newTrailTimelineList = new ObservableCollection<TrailTimelineModel>();
            for (int i = 0; i < this.TrailTimelines.Count; i++)
            {
                newTrailTimelineList.Add((TrailTimelineModel)TrailTimelines[i].Clone());
            }
            return new TrailSettingModel
            {
                Billboard = this.Billboard,
                Coords = this.Coords,
                FadeTime = this.FadeTime,
                Unk1 = this.Unk1,
                Unk2 = this.Unk2,
                Unk3 = this.Unk3,
                Color1 = this.Color1,
                Color2 = this.Color2,
                Color3 = this.Color3,
                ColorBlend = this.ColorBlend,
                FirstBone_Width_1 = this.FirstBone_Width_1,
                FirstBone_Width_2 = this.FirstBone_Width_2,
                FirstBone_Width_3 = this.FirstBone_Width_3,
                SecondBone_Width_1 = this.SecondBone_Width_1,
                SecondBone_Width_2 = this.SecondBone_Width_2,
                SecondBone_Width_3 = this.SecondBone_Width_3,
                TrailTimelines = newTrailTimelineList
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class TrailMaterialModel : ICloneable, INotifyPropertyChanged
    {
        private string _billboardPath;
        public string BillboardPath
        {
            get { return _billboardPath; }
            set
            {
                _billboardPath = value;
                OnPropertyChanged("BillboardPath");
            }
        }
        private string _billboardName;
        public string BillboardName
        {
            get { return _billboardName; }
            set
            {
                _billboardName = value;
                OnPropertyChanged("BillboardName");
            }
        }
        public object Clone()
        {

            return new TrailMaterialModel
            {
                BillboardPath = this.BillboardPath,
                BillboardName = this.BillboardName
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class TrailClumpModel : ICloneable, INotifyPropertyChanged
    {
        private string _clumpPath;
        public string ClumpPath
        {
            get { return _clumpPath; }
            set
            {
                _clumpPath = value;
                OnPropertyChanged("ClumpPath");
            }
        }
        private string _clumpName;
        public string ClumpName
        {
            get { return _clumpName; }
            set
            {
                _clumpName = value;
                OnPropertyChanged("ClumpName");
            }
        }
        public object Clone()
        {

            return new TrailClumpModel
            {
                ClumpPath = this.ClumpPath,
                ClumpName = this.ClumpName
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class TrailBonesModel : ICloneable, INotifyPropertyChanged
    {
        private TrailClumpModel _clump;
        public TrailClumpModel Clump
        {
            get { return _clump; }
            set
            {
                _clump = value;
                OnPropertyChanged("Clump");
            }
        }
        private string _startCoordName;
        public string StartCoordName
        {
            get { return _startCoordName; }
            set
            {
                _startCoordName = value;
                OnPropertyChanged("StartCoordName");
            }
        }
        private string _endCoordName;
        public string EndCoordName
        {
            get { return _endCoordName; }
            set
            {
                _endCoordName = value;
                OnPropertyChanged("EndCoordName");
            }
        }

        public object Clone()
        {

            return new TrailBonesModel
            {
                Clump = this.Clump,
                StartCoordName = this.StartCoordName,
                EndCoordName = this.EndCoordName
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class TrailTimelineModel : ICloneable, INotifyPropertyChanged
    {

        private uint _frame;
        public uint Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                OnPropertyChanged("Frame");
            }
        }

        private bool _toggleTrail;
        public bool ToggleTrail
        {
            get { return _toggleTrail; }
            set
            {
                _toggleTrail = value;
                OnPropertyChanged("ToggleTrail");
            }
        }

        public object Clone()
        {

            return new TrailTimelineModel
            {
                Frame = this.Frame,
                ToggleTrail = this.ToggleTrail
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
