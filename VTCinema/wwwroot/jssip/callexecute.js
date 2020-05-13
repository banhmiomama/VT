session_call = {};
sessionCalling = null;
phone = null;
var interval;
var call_option = {
    'mediaConstraints': { 'audio': true, 'video': false },
    'pcConfig': {
        'iceServers': [
            { 'urls': ['stun:stun.l.google.com:19302'] }
        ]
    },
    'sessionTimersExpires': 120
};
//login extend in server
function Call_loginExtend(outbound, port, domain, extension, password,timeout) {
    var socket = new JsSIP.WebSocketInterface('wss://' + outbound + ':' + port);
    var configuration = {
        sockets: [socket],
        uri: extension + '@' + domain,
        password: password,
        register_expires: timeout
    };

    phone = new JsSIP.UA(configuration);
    phone.on('connected', function (e) {
        // Your code here
        console.log('connected');
    });
    phone.on('disconnected', function (e) {
        // Your code here
        console.log('disconnected');
    });
    phone.on('newSession', function (e) {
        // Your code here
        console.log('newSession');
    });
    phone.on('newMessage', function (e) {
        // Your code here
        console.log('newMessage');
    });
    phone.on('registered', function (e) {
        // Your code here
        console.log('registered');

    });
    phone.on('unregistered', function (e) {
        // Your code here
        console.log('unregistered');
    });
    phone.on('registrationFailed', function (e) {
        // Your code here
        console.log('registrationFailed');
    });
    phone.start();
}
function Call_newRTCSession() {
    phone.on("newRTCSession", function (data) {
        sessionCalling = data.session; // outgoing call session here
        if (sessionCalling.direction === "incoming") {
            console.log('incoming');
            sessionCalling.on("accepted", function () {
                console.log('accepted');

                clearInterval(interval);
                interval = null;
                interval = setInterval(setTime, 1000);

                var remoteAudio = window.document.createElement('audio');
                window.document.body.appendChild(remoteAudio);
                remoteAudio.src = window.URL.createObjectURL(
                    sessionCalling.connection.getRemoteStreams()[0]
                );
                remoteAudio.play();
            });
            sessionCalling.on("confirmed", function () {
                console.log('confirmed');
                // this handler will be called for incoming calls too
            });
            sessionCalling.on("ended", function () {
                console.log('end_time');
                console.log(sessionCalling.session)
                FailIncommingCall();
            });
            sessionCalling.on("failed", function () {
                console.log('failed');
                FailIncommingCall();
            });
            //sessionCalling.on('addstream', function (e) {
            //    console.log('addstream');
            //    // set remote audio stream (to listen to remote audio)
            //    // remoteAudio is <audio> element on page
            //    remoteAudio.src = window.URL.createObjectURL(e.stream);
            //    remoteAudio.play();
            //});

            //session_call[data.request.call_id] = {
            //    session: data.session
            //};
            //eventCall(session_call[data.request.call_id]);
            // Answer call
            //sessionCalling.answer(call_option);

            var header = sessionCalling.request.getHeader('From');
            var headername = sessionCalling.remote_identity.display_name;
            InccomingCall(header, headername);
           

            // Reject call (or hang up it)
            // session.terminate();
        }
        else {
            sessionCalling.on("confirmed", function () {
                console.log('confirmed');
                var localStream = sessionCalling.connection.getLocalStreams()[0];
                dtmfSender = sessionCalling.connection.createDTMFSender(localStream.getAudioTracks()[0])
                clearInterval(interval);
                interval = null;
                interval=setInterval(setTime, 1000);
            });
            sessionCalling.on("ended", function () {
                console.log('ended');
                FailIncommingCall();
            });
            sessionCalling.on("failed", function () {
                console.log('failed');
                FailIncommingCall();
            });
          
            sessionCalling.on('peerconnection', function (e) {
                e.peerconnection.onaddstream = function (d) {
                    audio_callcenter.srcObject = d.stream;
                }
            })
        }

    });
}
function eventCall(session) {
    session['session'].on('peerconnection', function (e) {
        e.peerconnection.onaddstream = function (d) {
            audio_callcenter.srcObject = d.stream;
        }
    })
}
function PhoneCallExe(phonenumber) {

    phone.call(phonenumber, call_option);
}

function Callinghangup () {
    sessionCalling.terminate();
}
function CallingAccept() {
    sessionCalling.answer(call_option);
}
function CallingMute() {
    sessionCalling.mute({ audio: true });
}
function CallingUnMute() {
    sessionCalling.unmute({ audio: true });
}
function CallingAnswer() {
    sessionCalling.answer(call_option);
}
