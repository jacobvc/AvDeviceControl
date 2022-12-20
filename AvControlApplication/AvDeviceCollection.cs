using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using static AVDeviceControl.Preset;
using System.Windows.Media.Media3D;

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
    public partial class AvDeviceCollection
    {
        List<ucAvDevice> devices = new List<ucAvDevice>();
        Dictionary<String, ucAvDevice> deviceDict = new Dictionary<string, ucAvDevice>();

        public event ConfigurationChanged configurationChangedEvent = null;
        public event ValueChanged valueChangedEvent = null;

        public AvDeviceCollection()
        {

        }
        public AvDeviceCollection(List<ucAvDevice> devices)
        {
            this.devices = devices;
            Update();
            configurationChangedEvent?.Invoke(this);
        }

        void Update()
        {
            deviceDict.Clear();
            foreach (ucAvDevice uc in devices)
            {
                deviceDict[uc.DeviceName] = uc;
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

        public ucAvDevice Device(int index)
        {
            return devices[index];
        }
        public void MoveUcDevice(int index, bool left)
        {
            if (left && index > 0)
            {
                ucAvDevice tmp = devices[index - 1];
                devices[index - 1] = devices[index];
                devices[index] = tmp;
            }
            else if (!left && index < devices.Count - 1)
            {
                ucAvDevice tmp = devices[index + 1];
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
            foreach (ucAvDevice uc in devices)
            {
                ucViscaCamera cam = uc as ucViscaCamera;
                if (cam != null)
                {
                    JObject o = new JObject();
                    String s = "";
                    o.Add("devicetype", "viscacamera");
                    o.Add("name", uc.DeviceName);
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
                        o.Add("name", uc.DeviceName);
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

        public bool Move(String cameraName, String direction, String speed)
        {
            Update();
            ucViscaCamera cam = null;
            ucAvDevice uc;
            if (deviceDict.TryGetValue(cameraName, out uc))
            {
                cam = uc as ucViscaCamera;
                if (cam == null || cam.Camera == null) return false;

                int iSpeed = 50;
                try { iSpeed = int.Parse(speed); } catch (Exception) { }
                iSpeed = Math.Min(iSpeed, 100);
                int tiltSpeed = 0;
                int panSpeed = 0;

                switch (direction)
                {
                    case "up":
                        tiltSpeed = (int)(iSpeed * cam.Camera.Limits.TiltSpeedLimits.High);
                        break;
                    case "down":
                        tiltSpeed = -(int)(iSpeed * cam.Camera.Limits.TiltSpeedLimits.High);
                        break;
                    case "left":
                        panSpeed = -(int)(iSpeed * cam.Camera.Limits.PanSpeedLimits.High);
                        break;
                    case "right":
                        panSpeed = (int)(iSpeed * cam.Camera.Limits.PanSpeedLimits.High);
                        break;
                    case "stop":
                        break;
                }
                cam.Camera.ContinuousPanTilt(panSpeed / 100, tiltSpeed / 100);
                cam.Camera?.UpdatePosition();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetZoom(String cameraName, String direction, String speed)
        {
            Update();

            ucAvDevice uc;
            if (deviceDict.TryGetValue(cameraName, out uc))
            {
                ucViscaCamera cam = uc as ucViscaCamera;
                if (cam != null && cam.Camera != null)
                {
                    int iSpeed = 50;
                    try { iSpeed = int.Parse(speed); } catch (Exception) { }
                    iSpeed = Math.Min(iSpeed, 100);

                    int zoomSpeed = Math.Max(1, 
                        (int)(iSpeed * cam.Camera.Limits.ZoomSpeedLimits.High / 100));

                    switch (direction)
                    {
                        case "in":
                            cam.Camera.ContinuousZoom(zoomSpeed);
                            break;
                        case "out":
                            cam.Camera.ContinuousZoom(-zoomSpeed);
                            break;
                        default:
                            cam.Camera.ContinuousZoom(0);
                            break;
                    }
                    return true;
                }
            }
            return false;
        }
        
        public bool ExecPreset(String cameraName, String presetName)
        {
            Update();
            ucViscaCamera cam = null;
            ucAvDevice uc;
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
            ucAvDevice uc;
            if (deviceDict.TryGetValue(name, out uc))
            {
                uc.Connect();
                return true;
            }
            return false;
        }
        public bool DisconnectAvDevice(String name)
        {
            Update();
            ucViscaCamera cam = null;
            ucMixer mixer = null;
            ucAvDevice uc;
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
            ucAvDevice uc;
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
            ucAvDevice uc;
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
