using Scraper.Parsers;
using Scraper.Scrapers;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliScraperWindowsForms
{
    public partial class AliExpressScraperForm : Form
    {
        public AliExpressScraperForm()
        {
            InitializeComponent();
        }

        private void ChooseDirButton_Click(object sender, EventArgs e)
        {
            if (OutputBrowser.ShowDialog() == DialogResult.OK)
            {
                OutpurDirText.Text = OutputBrowser.SelectedPath;
            }
            else
            {
                MessageBox.Show("You need to choose a valid directory!", "AliExpress Scraper", MessageBoxButtons.OK);
            }
        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AliURLText.Text))
            {
                MessageBox.Show("You need pass a valid URL to Download!", "AliExpress Scraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AliURLText.Focus();
                return;
            }

            if (String.IsNullOrEmpty(OutpurDirText.Text))
            {
                MessageBox.Show("You need to choose a valid directory to save the Download!", "AliExpress Scraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AliURLText.Enabled = false;
            DownloadButton.Enabled = false;
            ChooseDirButton.Enabled = false;
            PagesBox.Enabled = false;
            this.UseWaitCursor = true;

            var process = await Download(this);

            MessageBox.Show("All pages were downloaded!", "AliExpress Scraper", MessageBoxButtons.OK);

            AliURLText.Enabled = true;
            DownloadButton.Enabled = true;
            ChooseDirButton.Enabled = true;
            PagesBox.Enabled = true;
            this.UseWaitCursor = false;
        }

        private async Task<int> Download(AliExpressScraperForm form)
        {
            return await Task.Run(() =>
            {


                var scraper = new WebScraper(form.AliURLText.Text);
                var parser = new AliExpressParser(scraper.LoadPage());


                int page_counter = 1;

                var num_pages = form.PagesRadio10.Checked ? 10 : (form.PagesRadio50.Checked ? 50 : 100);

                do
                {
                    parser.ParseDocument();

                    var outputFile = Path.Combine(form.OutpurDirText.Text, $"{parser.Category.ToLower().Replace(" ", String.Empty)}_page_{page_counter}.json");

                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }

                    using (var stream = new FileStream(outputFile, FileMode.CreateNew))
                    {
                        LogText($"Saving page {page_counter} into {outputFile}\n");
                        parser.WriteOutput(stream);
                    }

                    if (!String.IsNullOrEmpty(parser.NextPage))
                    {
                        scraper = new WebScraper(parser.NextPage);
                        parser = new AliExpressParser(scraper.LoadPage());
                    }

                    page_counter++;
                } while (page_counter <= num_pages);

                return 1;
            });
        }

        delegate void SetTextCallback(string text);

        private void LogText(string text)
        {
            if (this.ProgressLogBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(LogText);
                this.Invoke(d, new object[] { $"{text}\r\n" });
            }
            else
            {
                this.ProgressLogBox.Text += text;
                this.ProgressLogBox.SelectionStart = this.ProgressLogBox.Text.Length;
                this.ProgressLogBox.ScrollToCaret();
            }
        }
    }
}
