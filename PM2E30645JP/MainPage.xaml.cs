using System.Text;
using Microsoft.Maui.Controls;
using System;
//using Xamarin.Essentials;
using System.Threading.Tasks;


namespace PM2E30645JP
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void TomarFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // Obtener la ruta del archivo de la foto capturada
                    string filePath = photo.FullPath;

                    // Hacer algo con la foto capturada, por ejemplo, mostrarla en un Image control:
                    CapturedImage.Source = ImageSource.FromFile(filePath);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo capturar la foto: {ex.Message}", "OK");
            }
        }

        void Guardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los campos de entrada
                ImageSource image = CapturedImage.Source;
                string nota = notaEntry.Text;
                DateTime fecha = DatePicker.Date;

                // Aquí puedes guardar los datos recolectados
                // Por ejemplo, podrías guardarlos en una base de datos, en un archivo local, o enviarlos a través de una API remota, según tus necesidades.

                // Ejemplo de cómo imprimir los datos capturados
                Console.WriteLine($"Foto: {image}, Nombre: {nota}, Fecha: {fecha}");

                // Otra lógica para guardar los datos según tus necesidades
                // ...

                // Notificar al usuario que los datos se han guardado correctamente
                DisplayAlert("Éxito", "Datos guardados correctamente", "OK");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir al guardar los datos
                Console.WriteLine($"Error al guardar datos: {ex.Message}");
                DisplayAlert("Error", "No se pudieron guardar los datos", "OK");
            }
        }
        /*async void Audio_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Comprueba si el dispositivo admite la grabación de audio
                if (!Recorder.IsRecordingAvailable)
                {
                    await DisplayAlert("Error", "El dispositivo no admite la grabación de audio.", "OK");
                    return;
                }

                // Comienza la grabación de audio
                var recordOptions = new MediaRecorderAudioOptions(OutputFormat.Default);
                var result = await MediaRecorder.StartRecordAsync(recordOptions);

                // El resultado puede contener la ruta del archivo de audio grabado
                if (result.Status == MediaCaptureResultStatus.Success && !string.IsNullOrEmpty(result.FullPath))
                {
                    // Aquí puedes hacer algo con el archivo de audio grabado, como mostrar su ruta o reproducirlo
                    await DisplayAlert("Éxito", $"Audio grabado en: {result.FullPath}", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo grabar el audio.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo grabar el audio: {ex.Message}", "OK");
            }
        }*/
    }
}