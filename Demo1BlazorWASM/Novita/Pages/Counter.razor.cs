using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Novita.Pages
{
    public partial class Counter
    {
        [Inject]
        IJSRuntime jsRuntime { get; set; }

        private string dropClass = string.Empty;
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool isLoading;
        private List<IBrowserFile> filesCaricati = new();
        private List<string> Immagini = new List<string>();
        private string Testo = string.Empty;

        private void CaricaFiles(InputFileChangeEventArgs e)
        {
            isLoading = true;
            filesCaricati.Clear();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                filesCaricati.Add(file);
            }

            isLoading = false;

        }

        private async Task CaricaImmagine(InputFileChangeEventArgs e)
        {
            var formatImage = "image/png";
            foreach (var immagine in e.GetMultipleFiles(3))
            {
                var immaginecaricata = await immagine.RequestImageFileAsync(formatImage, 100, 100);
                var buffer = new byte[immaginecaricata.Size];
                await immaginecaricata.OpenReadStream().ReadAsync(buffer);
                Immagini.Add($"data:{formatImage};base64,{Convert.ToBase64String(buffer)}");
            }
        }

        private void HandleDragEnter()
        {
            dropClass = "dropAreaDrug";
        }
        private void HandleDragLeave()
        {
            dropClass = string.Empty;
        }

        private async Task LeggiFile(InputFileChangeEventArgs e)
        {
            using var reader = new System.IO.StreamReader(
                e.File.OpenReadStream());

            Testo = await reader.ReadToEndAsync();


        }

    }
}
