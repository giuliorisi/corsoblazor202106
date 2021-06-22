using LibreriaDemo1.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDemo1.Interops
{
    public class MiaClasseInteropJavascript: IDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<HelloHelper> reference;

        public MiaClasseInteropJavascript(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask<int> MiaFunzioneSpeciale(string simbolo, string prezzo)
        {
            return jsRuntime.InvokeAsync<int>("miaFunzioneSpeciale", simbolo, prezzo);
        }

        public async ValueTask DoppioGiro()
        {
            await jsRuntime.InvokeVoidAsync("funzioniEsempio.restituisciArray");
        }

        public ValueTask<string> ChiamaHelloHelperSayHello(string name)
        {
            var helper = new HelloHelper(name);
            reference = DotNetObjectReference.Create(helper);
            return jsRuntime.InvokeAsync<string>("funzioniEsempio.sayHello", reference);
        }

        public void Dispose()
        {
            reference?.Dispose();
        }
    }
}
