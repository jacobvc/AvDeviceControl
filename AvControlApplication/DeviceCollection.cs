using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDeviceControl
{
    public delegate void ConfigurationChanged(object sender);
    public delegate void ValueChanged(object sender, ValueChangedEventArgs e);

    public class ValueChangedEventArgs : EventArgs
    {
        public DeviceValueType valueType;
        public bool boolValue = false;
        public int intValue = 0;
        public bool isBool = false;

        public ValueChangedEventArgs(DeviceValueType valueType, int value)
        {
            this.valueType = valueType;
            this.intValue = value;
        }
        public ValueChangedEventArgs(DeviceValueType valueType, bool value)
        {
            this.valueType = valueType;
            this.boolValue = value;
            isBool = true;
        }
    }
    public enum DeviceValueType
    {
        Mute,
        VolumeSetting,
        VolumeLevel
    }
    /// <remarks>
    /// A collection of all of the loaded cameras
    /// </remarks>
    public partial class DeviceCollection
    {
        List<ucViscaCamera> cameras = new List<ucViscaCamera>();
        List<ucMixer> mixers = new List<ucMixer>();
        Dictionary<String, ucViscaCamera> cameraDict = new Dictionary<string, ucViscaCamera>();
        Dictionary<String, ucMixer> mixerDict = new Dictionary<string, ucMixer>();

        public event ConfigurationChanged configurationChangedEvent = null;
        public event ValueChanged valueChangedEvent = null;

        public DeviceCollection()
        {

        }
        public DeviceCollection(List<ucViscaCamera> cameras)
        {
            this.cameras = cameras;
            Update();
            configurationChangedEvent?.Invoke(this);
        }

        void Update()
        {
            cameraDict.Clear();
            foreach (ucViscaCamera cam in cameras)
            {
                cameraDict[cam.Config.Name] = cam;
            }
            mixerDict.Clear();
            foreach (ucMixer mixer in mixers)
            {
                mixerDict[mixer.Config.Name] = mixer;
            }
        }

        public void AddCamera(ucViscaCamera item)
        {
            cameras.Add(item);
            item.configurationChangedEvent += Device_configurationChangedEvent;
            item.valueChangedEvent += Device_valueChangedEvent;
            configurationChangedEvent?.Invoke(this);
        }

        private void Device_valueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            valueChangedEvent?.Invoke(sender, e);
        }

        private void Device_configurationChangedEvent(object sender)
        {
            configurationChangedEvent?.Invoke(sender);
        }

        public void RemoveCamera(ucViscaCamera item)
        {
            item.configurationChangedEvent -= Device_configurationChangedEvent;
            item.valueChangedEvent -= Device_valueChangedEvent;
            cameras.Remove(item);
            configurationChangedEvent?.Invoke(this);
        }

        public void AddMixer(ucMixer item)
        {
            mixers.Add(item);
            item.configurationChangedEvent += Device_configurationChangedEvent;
            item.valueChangedEvent += Device_valueChangedEvent;
            configurationChangedEvent?.Invoke(this);
        }
        public void RemoveMixer(ucMixer item)
        {
            item.configurationChangedEvent -= Device_configurationChangedEvent;
            item.valueChangedEvent -= Device_valueChangedEvent;
            mixers.Remove(item);
            configurationChangedEvent?.Invoke(this);
        }

        public ucViscaCamera Camera(int index)
        {
            return cameras[index];
        }
        public ucMixer Mixer(int index)
        {
            return mixers[index];
        }

        public void Clear()
        {
            cameras.Clear();
            mixers.Clear();
            configurationChangedEvent?.Invoke(this);
        }
        public int CameraCount
        {
            get { return cameras.Count; }
        }
        public int MixerCount
        {
            get { return mixers.Count; }
        }
    

        /// <summary>
        /// <code>ptz[]
        ///   name
        ///   presets
        ///   active</code>
        /// </summary>
        /// <returns></returns>
        public JArray GetCameras()
        {
            JArray array = new JArray();
            foreach (ucViscaCamera cam in cameras)
            {
                JObject o = new JObject();
                String s = "";
                o.Add("name", cam.Config.Name);
                if (cam.Config.presets.Count > 0)
                {
                    foreach (Preset p in cam.Config.presets)
                    {
                        s += p.Name + ","; ;
                    }
                    o.Add("presets", s.Substring(0, s.Length - 1));
                }
                o.Add("active", cam.Camera != null);
                array.Add(o);
            }

            return array;
        }

        public JArray GetMixers()
        {
            JArray array = new JArray();
            foreach (ucMixer mixer in mixers)
            {
                JObject o = new JObject();
                o.Add("name", mixer.Config.Name);
                if (mixer.Config.Channels.Count > 0)
                {
                    JArray channels = new JArray();
                    o.Add("channels", channels);
                    for (int i = 0; i < mixer.Config.Channels.Count; ++i)
                    {
                        JObject channel = new JObject();
                        channel.Add("name", mixer.Config.Channels[i].Name);
                        if (i < mixer.Sliders.Length)
                        {
                            ucVolumeSlider sld = mixer.Sliders[i];
                            channel.Add("mute", sld.Mute);
                            channel.Add("volumelevel", sld.InputValue);
                            channel.Add("volumesetting", sld.ControlValue);
                        }
                        channels.Add(channel);
                    }
                }
                o.Add("active", mixer.Connection != null);
                array.Add(o);
            }

            return array;
        }

        public bool Move(String cameraName, String direction, String amount)
        {
            Update();
            ucViscaCamera cam = null;
            if (cameraDict.TryGetValue(cameraName, out cam))
            {
                if (cam.Camera == null) return false;

                int iAmount = 50;
                try { iAmount = int.Parse(amount); } catch (Exception) { }
                int pan = (int)((cam.Config.MaxPan - cam.Config.MinPan)
                   * iAmount * iAmount / 10000 / 8 * cam.Config.CountsPerDegree);
                int tilt = (int)((cam.Config.MaxTilt - cam.Config.MinTilt)
                   * iAmount * iAmount / 10000 / 8 * cam.Config.CountsPerDegree);

                switch (direction)
                {
                    case "up":
                        cam.Camera?.PositionRelative(0, tilt);
                        break;
                    case "down":
                        cam.Camera?.PositionRelative(0, -tilt);
                        break;
                    case "left":
                        cam.Camera?.PositionRelative(-pan, 0);
                        break;
                    case "right":
                        cam.Camera?.PositionRelative(pan, 0);
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetZoom(String cameraName, String direction, String amount)
        {
            Update();
            ucViscaCamera cam = null;
            if (cameraDict.TryGetValue(cameraName, out cam))
            {
                if (cam.Camera == null) return false;
                int iAmount = 50;
                try { iAmount = int.Parse(amount); } catch (Exception) { }
                int position = cam.Camera.ZoomPosition;
                iAmount = (int)cam.Config.FullScaleZoom * iAmount * iAmount / 10000 / 4;
                //Console.Write("Zoom from RAW: " + position);
                switch (direction)
                {
                    case "in":
                        position += iAmount;
                        break;
                    case "out":
                        position -= iAmount;
                        break;
                }
                position = (int)Math.Max(0, Math.Min(cam.Config.FullScaleZoom, position));
                //Console.WriteLine(" to: " + position);

                cam.Camera?.ZoomSetPosition(position);
                cam.Camera?.UpdatePosition();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExecPreset(String cameraName, String presetName)
        {
            Update();
            ucViscaCamera cam = null;
            if (cameraDict.TryGetValue(cameraName, out cam))
            {
                foreach (Preset p in cam.Config.presets)
                {
                    if (p.Name.Equals(presetName))
                    {
                        cam.Camera?.MoveToPreset(p, cam.Config);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public bool ConnectAvDevice(String name)
        {
            Update();
            ucViscaCamera cam = null;
            ucMixer mixer = null;
            if (cameraDict.TryGetValue(name, out cam))
            {
                cam.Connect(!cam.Config.IsIp);
                return true;
            }
            else if (mixerDict.TryGetValue(name, out mixer))
            {
                mixer.Connect();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DisconnectAvDevice(String name)
        {
            Update();
            ucViscaCamera cam = null;
            ucMixer mixer = null;
            if (cameraDict.TryGetValue(name, out cam))
            {
                cam.Disconnect();
                return true;
            }
            else if (mixerDict.TryGetValue(name, out mixer))
            {
                mixer.Disconnect();
                return true;
            }
            else
            {
                return false;
            }
        }

        // MIXERS

        public bool SetMute(String mixerName, String channelName, bool value)
        {
            Update();
            ucMixer mixer = null;
            if (mixerDict.TryGetValue(mixerName, out mixer))
            {
                mixer.MuteButton(channelName, value);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetVolume(String mixerName, String channelName, int value)
        {
            Update();
            ucMixer mixer = null;
            if (mixerDict.TryGetValue(mixerName, out mixer))
            {
                mixer.MoveSlider(channelName, value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
