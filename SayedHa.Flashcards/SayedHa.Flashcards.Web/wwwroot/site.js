window.PlayAudio = (elementName) => {
    console.log('trying to play audio on elementName: "' + elementName + '"');
    document.getElementById(elementName).play();
}

function PlayAudio2(elementName) {
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