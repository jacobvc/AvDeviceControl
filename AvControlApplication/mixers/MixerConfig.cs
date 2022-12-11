using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace AVDeviceControl
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MixerConfig : IBindableComponent
    {
        #region Local variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        #region Bindable properties
        [JsonProperty]
        public string Name { get; set; } = "unnamed";
        [JsonProperty]
        public String Device { get; set; } = "";
        /// <summary>
        /// THE channel collection
        /// </summary>
        [JsonProperty]
        public List<MidiChannel> Channels = new List<MidiChannel>();
        [JsonProperty]
        public bool Y01v96 { get; set; } = false;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public MixerConfig() { }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public MidiChannel AddChannel(String name, int channel, int control, int mute)
        {
            MidiChannel p = new MidiChannel(name, channel, control, mute);
            Channels.Add(p);
            return p;
        }
        public void RemoveChannel(MidiChannel p)
        {
            Channels.Remove(p);
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

    public class MidiChannel : IBindableComponent
    {
        #region Local variables
        public event EventHandler Disposed;
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        ISite site;
        #endregion

        #region Bindable variables
        public String Name { get; set; } = "unnamed";
        public int Channel { get; set; } = 1;
        public int Control { get; set; } = 7;
        public int Mute { get; set; } = 120;
        #endregion

        #region Constructors / Destructors
        public MidiChannel()
        {
        }
        public MidiChannel(String name, int channel, int control, int mute)
        {
            this.Name = name;
            this.Channel = channel;
            this.Control = control;
            this.Mute = mute;
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        #endregion

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
}
