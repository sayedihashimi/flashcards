function PlayAudio(elementName) {
    console.log('trying to play audio on elementName: "' + elementName + '"');

    var element = document.getElementById(elementName);
    // if it's an audio element try to play it,
    // otherwise try to play first child node
    if ("AUDIO" === element.nodeName.toUpperCase()) {
        element.play();
    }
    else {
        element.firstChild.play();
    }
}

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
        }
        for (let i = 0; i < audioList.length; i++) {
            audioList[i].addEventListener('ended', (event) => {
                event.target.pause();
                event.target.currentTime = 0;
                if (event.target.nextAudio !== null) {
                    event.target.nextAudio.play();
                }
            });
        }

        // play the first one to kick off the sequence
        if (audioList !== null && audioList[0] !== null) {
            audioList[0].play();
        }
    }
    else {
        console.log('nothing to play');
    }
}
function SamplePlay() {
    console.log('sampleplay called.');
    let urls = []
    urls.push('https://localhost:44303/flashcards/media/audio/jump.wav')
    urls.push('https://localhost:44303/flashcards/media/audio/blue.wav')
    urls.push('https://localhost:44303/flashcards/media/audio/here.wav')
    PlayAudioSeries(urls);
}

