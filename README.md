# AvDeviceControl
A/V - VISCA Camera and MIDI Audio Interface Application

# Features
- Pan, Tilt, and Zoom support for VISCA cameras
- MIDI Audio Mixer Support
- Websocket Server serving OBS Studio Websocket v5 compatible protocol


# Design
- MainForm Windows.Form
    - Loads / Saves DeviceConfigCollection
    - Maintains DeviceCollection
    - Hosts ucViscaCamera
    - Hosts ucMixer

- ucViscaCamera(CameraConfig) UserControl
  - Contains PtzController
    - Connects to PtzCamera using CameraConfig
  - Camera property is controller's camera
  - PtzMonitor polls camera for changes
  - Uses ViscaTransport

- ucMixer(Midi, MixerConfig) UserControl
    - Connects to Midi and gets a MidiConnection
    - ucVolumeSlider UserControl for each channel
    - Uses Midi
- Transport
    - ViscaTransport VISCA (port) interface for camera
    - Midi - Midi interface for mixer
    - DeviceControlWebsocket - Protocol interface for websocket
        - uses Webserver - The websocket server