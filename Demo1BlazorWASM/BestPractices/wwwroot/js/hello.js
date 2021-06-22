window.helloJavascript = (argomento) => {
    console.log('Funzione Javascript: ' + argomento);
    return 'eseguito';
}


window.miaFunzioneSpeciale = (simbolo, prezzo) => {
    console.log(simbolo);
    console.log(prezzo);
    // facciamo qualcosa
    return 42;
}

window.funzioniEsempio = {
    restituisciArray: function() {
        DotNet.invokeMethodAsync("LibreriaDemo1", "RestituisciArrayAsync")
            .then(dati => {
                console.log(dati);
            });
    },
    sayHello: function (dotnetHelper) {
        return dotnetHelper.invokeMethodAsync("SayHello")
            .then(x => console.log(x));
    }
}