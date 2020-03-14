using System;

using Xamarin.Forms;

namespace Pedidos.Views
{
    public class LogoXamarin : ContentView
    {
        public LogoXamarin()
        {
            CriarImagem();
        }

        private void CriarImagem()
        {
            var imagem = new Image
            {
                Source = "xamarin_logo",
                HeightRequest = 64
            };
            imagem.VerticalOptions = LayoutOptions.Center;
            Content = imagem;
        }
    }
}

