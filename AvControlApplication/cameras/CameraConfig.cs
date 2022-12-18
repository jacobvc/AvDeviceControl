using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace AVDeviceControl
{
    public class AvDeviceConfig
    {
        [JsonProperty]
        public string Name { get; set; } = "unnamed";
    }

    /// <summary>
    /// Device configuration class
    /// 
    /// This camera configuration supports both USB and IP devices, and:
    /// 
    /// It is bindable so the object can be bound to windows form controls.
    /// 
    /// It is XML serializable so the configuration can be saved to and restored from
    /// an XML file.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CameraConfig : AvDeviceConfig, IBindableComponent
    {
        #region Local variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        #region Bindable properties
        [JsonProperty]
        public string Port { get; set; } = "";
        public bool IsIp { get; set; } = false;
        public string Baud { get; set; } = "9600";
        public string Usb { get; set; } = "[Don't Display]";
        public string CamIp { get; set; } = "";
        public string CamIpPort { get; set; } = "5678";
        public string CamRtsp { get; set; } = "";

        public double CountsPerDegree { get; set; } = 14.4;
        public double FullScaleZoom { get; set; } = 0x4000;
        public double MinPan { get; set; } = -170;
        public double MaxPan { get; set; } = 170;
        public double MinTilt { get; set; } = -30;
        public double MaxTilt { get; set; } = 30;
        /// <summary>
        /// THE preset collection
        /// </summary>
        [JsonProperty]
        public List<Preset> presets = new List<Preset>();
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public CameraConfig() { }

        public Preset AddPreset(String name, double pan, double tilt, double zoom, Preset.PtSpeed speed)
        {
            Preset p = new Preset(name, pan, tilt, zoom, speed);
            presets.Add(p);
            presets.Sort((e1, e2) =>
            {
                return e1.Name.CompareTo(e2.Name);
            });
            return p;
        }
        public void RemovePreset(Preset p)
        {
            presets.Remove(p);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #region Binding boilerplate
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection(this);
                }
                return dataBindings;
            }
        }

        [XmlIgnore]
        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }
        [XmlIgnore]
        public ISite Site
        {
            get { return site; }
            set { site = value; }
        }
        #endregion
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Preset : IBindableComponent
    {
        #region Local variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        public Preset() { }

        public Preset(String name, double pan, double tilt, double zoom, PtSpeed speed)
        {
            this.Name = name;
            this.Pan = pan;
            this.Tilt = tilt;
            this.Zoom = zoom;
            this.Speed = speed;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public enum PtSpeed
        {
            Very_Slow,
            Slow,
            Normal,
            Fast,
            Very_Fast,
            NOT_SET
        }

        [JsonProperty]
        public string Name { get; set; }
        public double Pan { get; set; }
        public double Tilt { get; set; }
        public double Zoom { get; set; }
        public PtSpeed Speed { get; set; }

        #region Binding boilerplate
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection(this);
                }
                return dataBindings;
            }
        }

        [XmlIgnore]
        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }
        [XmlIgnore]
        public ISite Site
        {
            get { return site; }
            set { site = value; }
        }
        #endregion
        public override string ToString()
        {
            return Name + string.Format(" ({0:0.0},{1:0.0},{2:0.00},{3:0.00})", Pan, Tilt, Zoom, Speed);
        }
    }
    /// <summary>
    /// XML Serializable collection of CameraConfig
    /// </summary>
    [XmlInclude(typeof(CameraConfig))]
    [XmlInclude(typeof(MixerConfig))]
    public class DeviceConfigCollection
    {
        /// <summary>
        /// THE camera collection
        /// </summary>
        public List<AvDeviceConfig> devices = new List<AvDeviceConfig>();
        /// <summary>
        /// Default constructor
        /// </summary>
        public DeviceConfigCollection() { }
        /// <summary>
        /// Add camera to the collection
        /// </summary>
        /// <param name="cam"></param>
        public void AddCamera(CameraConfig cam)
        {
            devices.Add(cam);
        }
        /// <summary>
        /// Remove camera from the collection
        /// </summary>
        /// <param name="cam"></param>
        public void RemoveCamera(CameraConfig cam)
        {
            devices.Remove(cam);
        }
        /// <summary>
        /// Report number of devices in collection
        /// </summary>
        public int DeviceCount { get { return devices.Count; } }

        /// <summary>
        /// Add camera to the collection
        /// </summary>
        /// <param name="cam"></param>
        public void AddMixer(MixerConfig mixer)
        {
            devices.Add(mixer);
        }
        /// <summary>
        /// Remove camera from the collection
        /// </summary>
        /// <param name="cam"></param>
        public void RemoveMixer(MixerConfig mixer)
        {
            devices.Remove(mixer);
        }
        /// <summary>
        /// Report number of devices in collection
        /// </summary>
        //public int MixerCount { get { return mixers.Count; } }


        #region Serialization
        public bool Serialize(String filename)
        {
            TextWriter writer = null;

            try
            {

                if (Properties.Settings.Default.saveJsonConfigCopy)
                {
                   // writer = new StreamWriter(filename + ".json");
                  //  writer.WriteLine(JsonNet.Serialize(this));
                  //  writer.Close();
                }
                XmlSerializer ser = new XmlSerializer(typeof(DeviceConfigCollection));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
                //ser.Serialize(Console.Out, this);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return true;
        }
        public static DeviceConfigCollection Deserialize(String filename)
        {
            DeviceConfigCollection tmp;

            TextReader reader = null;
            try
            {
                // reader = new StreamReader(filename + ".json");
                // tmp = JsonNet.Deserialize<CameraConfigCollection>(reader);

                XmlSerializer ser = new XmlSerializer(typeof(DeviceConfigCollection));
                reader = new StreamReader(filename);
                tmp = (DeviceConfigCollection)ser.Deserialize(reader);
                if (tmp != null)
                {
                    foreach (AvDeviceConfig dev in tmp.devices)
                    {
                        CameraConfig cam = dev as CameraConfig;
                        if (cam != null)
                        {
                            cam.presets.Sort((e1, e2) =>
                            {
                                return e1.Name.CompareTo(e2.Name);
                            });
                        }
                    }
                }
                return tmp;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("FAILED to deserialize schema: " + e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return null;
        }
        #endregion
    }
}
