using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SubtitlesEditor
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog saveFileDialog1;
        private List<Subtitle> subtitles1;
        private List<Subtitle> subtitles2;
        private string[] words = new string[] { "", "" };
        private double timeOffset = 5.880;

        public Form1()
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a subtitles file",
                Filter = "Subtitles files (*.srt)|*.srt",
                Title = "Open subtitles file"
            };

            saveFileDialog1 = new FolderBrowserDialog();

            subtitles1 = new List<Subtitle>();
            subtitles2 = new List<Subtitle>();

            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        ReadFile(filePath);
                        Processing_btn.Enabled = true;
                        Save_btn.Enabled = false;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Processing_btn_Click(object sender, EventArgs e)
        {
            AddTimeOffset();
            SplitSubtitles();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string folderName = saveFileDialog1.SelectedPath;
                SaveNewFiles(folderName);

            }
        }

        private void ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            subtitles1.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                Subtitle subtitle = new Subtitle();
                subtitle.number = int.Parse(lines[i]);

                words = lines[++i].Split(" --> ");
                subtitle.startTime = DateTime.ParseExact(words[0], "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
                subtitle.endTime = DateTime.ParseExact(words[1], "HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

                subtitle.text1 = lines[++i];

                if (i < lines.Length - 1 && lines[++i] != string.Empty)
                {
                    subtitle.text2 = lines[i];
                    i++;
                }

                subtitles1.Add(subtitle);
            }
        }

        private void AddTimeOffset()
        {
            foreach (var subtitle in subtitles1)
            {
                subtitle.startTime = subtitle.startTime.AddSeconds(timeOffset);
                subtitle.endTime = subtitle.endTime.AddSeconds(timeOffset);
            }
        }

        private void SplitSubtitles()
        {
            subtitles2.Clear();

            foreach (var subtitle in subtitles1)
            {
                if (subtitle.startTime.Millisecond == 0)
                {
                    subtitles2.Add(subtitle);
                }
            }

            for (int i = subtitles2.Count - 1; i >= 0; i--)
            {
                subtitles1.RemoveAt(subtitles2[i].number - 1);
                subtitles2[i].number = i + 1;
            }

            for (int i = 0; i < subtitles1.Count; i++)
            {
                subtitles1[i].number = i + 1;
            }
            Processing_btn.Enabled = false;
            Save_btn.Enabled = true;
        }

        private void SaveNewFiles(string filePath)
        {
            using (StreamWriter writetext = new StreamWriter(filePath + "/newSubtitle_1.srt"))
            {
                Write(writetext, subtitles1);
            }

            using (StreamWriter writetext = new StreamWriter(filePath + "/newSubtitle_2.srt"))
            {
                Write(writetext, subtitles2);
            }
        }

        private void Write(StreamWriter writetext, List<Subtitle> subtitles)
        {
            foreach (var subtitle in subtitles)
            {
                writetext.WriteLine(subtitle.number);
                writetext.WriteLine(subtitle.startTime.ToString("HH:mm:ss,fff") + " ---> " + subtitle.endTime.ToString("HH:mm:ss,fff"));
                writetext.WriteLine(subtitle.text1);

                if (subtitle.text2 != string.Empty)
                {
                    writetext.WriteLine(subtitle.text2);
                }

                writetext.WriteLine();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            timeOffset = double.Parse(objTextBox.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = timeOffset.ToString();
        }


    }
}