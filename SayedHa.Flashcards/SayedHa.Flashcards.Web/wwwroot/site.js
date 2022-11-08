function PlayAudio(elementName) {
    console.log('trying to play audio on elementName: "' + elementName + '"');

    var element = document.getElementById(elementName);
    // if it's an audio element try to play it,
    // otherwise try to play first child node
    if ("AUDIO" === element.nodeName.toUpperCase()) {
        element.pause();
        element.currentTime = 0;
        element.play();
    }
    else {
        element.firstChild.pause();
        element.firstChild.currentTime = 0;
        element.firstChild.play();
    }
}

var previousAudioList;
function PlayAudioSeries(urlsToPlay) {
    console.log('inside site.js:PlayAudioSeries')
    if (urlsToPlay !== null && urlsToPlay.length > 0) {
        // create a list of audio elements
        var audioList = [];
        for (let i = 0; i < urlsToPlay.length; i++) {
            audioList[i] = new Audio(urlsToPlay[i]);
            audioList[i].load();

            if (i > 0) {
                audioList[i - 1].nextAudio = audioList[i];
            }
            audioList[i].addEventListener('ended', AudioEndedPlayNextEvent);
        }

        if (previousAudioList != null && previousAudioList.length > 0) {
            for (var pi = 0; pi < previousAudioList.length; pi++) {
                previousAudioList[pi].pause();
                previousAudioList[pi].removeEventListener('ended', AudioEndedPlayNextEvent);
            }
        }
        previousAudioList = audioList;
        // play the first one to kick off the sequence
        if (audioList !== null && audioList[0] !== null) {
            audioList[0].play();
        }
    }
    else {
        console.log('nothing to play');
    }
}
function AudioEndedPlayNextEvent(event) {
    if (event === null) {
        return;
    }
    event.target.pause();
    event.target.currentTime = 0;
    if (event.target.nextAudio != null) {
        event.target.nextAudio.play();
    }
}
