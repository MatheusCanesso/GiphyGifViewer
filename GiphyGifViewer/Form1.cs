using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiphyGifViewer
{
    public partial class Form1 : Form
    {
        private readonly GiphyService giphyService = new GiphyService();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                lblStatus.Text = "Por favor, digite uma palavra-chave!";
                return;
            }

            lblStatus.Text = "Buscando GIF...";
            string gifUrl = await giphyService.GetGifUrlAsync(searchTerm);

            if (string.IsNullOrEmpty(gifUrl))
            {
                lblStatus.Text = "Nenhum GIF encontrado!";
                return;
            }

            lblStatus.Text = "GIF encontrado!";
            picGif.Load(gifUrl);
        }
    }
}
