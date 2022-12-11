using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVDeviceControl
{
    public enum ObsOpCode
    {
        /**
         * The initial message sent by obs-websocket to newly connected clients.
         *
         * Initial OBS Version: 5.0.0
         */
        Hello = 0,
        /**
         * The message sent by a newly connected client to obs-websocket in response to a `Hello`.
         *
         * Initial OBS Version: 5.0.0
         */
        Identify = 1,
        /**
         * The response sent by obs-websocket to a client after it has successfully identified with obs-websocket.
         *
         * Initial OBS Version: 5.0.0
         */
        Identified = 2,
        /**
         * The message sent by an already-identified client to update identification parameters.
         *
         * Initial OBS Version: 5.0.0
         */
        Reidentify = 3,
        /**
         * The message sent by obs-websocket containing an event payload.
         *
         * Initial OBS Version: 5.0.0
         */
        Event = 5,
        /**
         * The message sent by a client to obs-websocket to perform a request.
         *
         * Initial OBS Version: 5.0.0
         */
        Request = 6,
        /**
         * The message sent by obs-websocket in response to a particular request from a client.
         *
         * Initial OBS Version: 5.0.0
         */
        RequestResponse = 7,
        /**
         * The message sent by a client to obs-websocket to perform a batch of requests.
         *
         * Initial OBS Version: 5.0.0
         */
        RequestBatch = 8,
        /**
         * The message sent by obs-websocket in response to a particular batch of requests from a client.
         *
         * Initial OBS Version: 5.0.0
         */
        RequestBatchResponse = 9,
    }
    internal class Protocol
    {
    }
}
