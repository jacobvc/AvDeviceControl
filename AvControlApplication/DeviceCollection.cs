using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
    /// A collection of all of the loaded devices
    /// </remarks>
    public partial class DeviceCollection
    {
        List<UserControl> devices = new List<UserControl>();
        Dictionary<String, UserControl> deviceDict = new Dictionary<string, UserControl>();

        public event ConfigurationChanged configurationChangedEvent = null;
        public event ValueChanged valueChangedEvent = null;

        public DeviceCollection()
        {

        }
        public DeviceCollection(List<UserControl> devices)
        {
            this.devices = devices;
            Update();
            configurationChangedEvent?.Invoke(this);
        }

        void Update()
        {
            deviceDict.Clear();
            foreach (UserControl uc in devices)
            {
                ucViscaCamera cam = uc as ucViscaCamera;
                if (cam != null && cam.Camera != null)
                {
                    deviceDict[cam.Config.Name] = uc;
                }
                else
                {
                    ucMixer mixer = uc as ucMixer;
                    if (mixer != null)
                    {
                        deviceDict[mixer.Config.Name] = uc;
                    }
                }
            }
        }

        public void AddCamera(ucViscaCamera item)
        {
            devices.Add(item);
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
            devices.Remove(item);
            configurationChangedEvent?.Invoke(this);
        }

        public void AddMixer(ucMixer item)
        {
            devices.Add(item);
            item.configurationChangedEvent += Device_configurationChangedEvent;
            item.valueChangedEvent += Device_valueChangedEvent;
            configurationChangedEvent?.Invoke(this);
        }
        public void RemoveMixer(ucMixer item)
        {
            item.configurationChangedEvent -= Device_configurationChangedEvent;
            item.valueChangedEvent -= Device_valueChangedEvent;
            devices.Remove(item);
            configurationChangedEvent?.Invoke(this);
        }

        public UserControl Device(int index)
        {
            return devices[index];
        }
        public void MoveUcDevice(int index, bool left)
        {
            if (left && index > 0)
            {
                UserControl tmp = devices[index - 1];
                devices[index - 1] = devices[index];
                devices[index] = tmp;
            }
            else if (!left && index < devices.Count - 1)
            {
                UserControl tmp = devices[index + 1];
                devices[index + 1] = devices[index];
                devices[index] = tmp;
            }
        }

        public void Clear()
        {
            devices.Clear();
            configurationChangedEvent?.Invoke(this);
        }
        public int DeviceCount
        {
            get { return devices.Count; }
        }


        /// <summary>
        /// <code>ptz[]
        ///   name
        ///   presets
        ///   active</code>
        /// </summary>
        /// <returns></returns>
        public JArray GetAvDevices()
        {
            JArray array = new JArray();
            ucMixer mixer = null;
            foreach (UserControl uc in devices)
            {
                ucViscaCamera cam = uc as ucViscaCamera;
                if (cam != null)
                {
                    JObject o = new JObject();
                    String s = "";
                    o.Add("devicetype", "viscacamera");
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
                else
                {
                    mixer = uc as ucMixer;
                    if (mixer != null)
                    {
                        JObject o = new JObject();
                        o.Add("devicetype", "mixer");
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
                }
            }

            return array;
        }

        public bool Move(String cameraName, String direction, String amount)
        {
            Update();
            ucViscaCamera cam = null;
            UserControl uc;
            if (deviceDict.TryGetValue(cameraName, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam == null || cam.Camera == null) return false;

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
                cam.Camera?.UpdatePosition();
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
            UserControl uc;
            if (deviceDict.TryGetValue(cameraName, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam == null || cam.Camera == null) return false;

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
            UserControl uc;
            if (deviceDict.TryGetValue(cameraName, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam != null && cam.Camera != null)
                {
                    foreach (Preset p in cam.Config.presets)
                    {
                        if (p.Name.Equals(presetName))
                        {
                            cam.Camera?.MoveToPreset(p, cam.Config);
                            return true;
                        }
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
            UserControl uc;
            if (deviceDict.TryGetValue(name, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam != null && cam.Camera != null)
                {
                    cam.Connect(!cam.Config.IsIp);
                    return true;
                }
                else
                {
                    mixer = uc as ucMixer;
                    if (mixer != null)
                    {
                        mixer.Connect();
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DisconnectAvDevice(String name)
        {
            Update();
            ucViscaCamera cam = null;
            ucMixer mixer = null;
            UserControl uc;
            if (deviceDict.TryGetValue(name, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam != null && cam.Camera != null)
                {
                    cam.Disconnect();
                    return true;
                }
                else
                {
                    mixer = uc as ucMixer;
                    if (mixer != null)
                    {
                        mixer.Disconnect();
                        return true;
                    }
                }
            }
            return false;
        }

        // MIXERS

        public bool SetMute(String mixerName, String channelName, bool value)
        {
            Update();
            UserControl uc;
            if (deviceDict.TryGetValue(mixerName, out uc))
            {
                ucMixer mixer = uc as ucMixer;
                mixer?.MuteButton(channelName, value);
                return true;
            }
            return false;
        }
        
        public bool SetVolume(String mixerName, String channelName, int value)
        {
            Update();
            UserControl uc;
            if (deviceDict.TryGetValue(mixerName, out uc))
            {
                ucMixer mixer = uc as ucMixer;
                mixer?.MoveSlider(channelName, value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
