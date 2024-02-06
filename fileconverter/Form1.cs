using NAudio.MediaFoundation;
using NAudio.Wave;
using NAudio.Vorbis;
using System.Drawing.Imaging;
using System.IO;
using Xabe.FFmpeg;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Timers;
using OggVorbisEncoder;
using GroupDocs.Conversion.FileTypes;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion;

namespace fileconverter
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> types = new Dictionary<string, string>()
        {
            { ".wav", "mp3,ogg" },
            { ".mp3", "wav,ogg" },
            { ".ogg", "wav,mp3"},
            { ".jpeg", "png,ico,bmp,gif,tiff" },
            { ".jpg", "png,ico,bmp,gif,tiff" },
            { ".png", "jpeg,ico,bmp,gif,tiff" },
            { ".ico", "png,jpeg,bmp,gif,tiff" },
            { ".bmp", "png,ico,jpeg,gif,tiff" },
            { ".tiff", "png,ico,jpeg,gif,bmp" },
            { ".tif", "png,ico,jpeg,gif,bmp,webp" },
            { ".webp", "png,ico,jpeg,gif,bmp,tiff" },
            { ".avi", "mp4,mov" },
            { ".mp4", "avi,mov" },
            { ".mov", "avi,mp4" }
        };
        Dictionary<string, Action> methods = new Dictionary<string, Action>()
        {
            // audio
            { ".wav,mp3", () => WavToMP3() },
            { ".wav,ogg", () => WavToOGG() },
            { ".mp3,wav", () => MP3ToWav() },
            { ".mp3,ogg", () => MP3ToOGG() },
            { ".ogg,mp3", () => OGGToMP3() },
            // images
            { ".jpeg,png", () => ConvertImage(ImageFileType.Png) },
            { ".jpeg,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".jpeg,bmp", () => ConvertImage(ImageFileType.Bmp) },
            { ".jpeg,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".jpeg,tiff", () => ConvertImage(ImageFileType.Tiff) },
            { ".jpeg,webp", () => ConvertImage(ImageFileType.Webp) },
            { ".jpg,png", () => ConvertImage(ImageFileType.Png) },
            { ".jpg,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".jpg,bmp", () => ConvertImage(ImageFileType.Bmp) },
            { ".jpg,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".jpg,tiff", () => ConvertImage(ImageFileType.Tiff) },
			{ ".jpg,webp", () => ConvertImage(ImageFileType.Webp) },
			{ ".png,jpeg", () => ConvertImage(ImageFileType.Jpeg) },
            { ".png,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".png,bmp", () => ConvertImage(ImageFileType.Bmp) },
            { ".png,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".png,tiff", () => ConvertImage(ImageFileType.Tiff) },
			{ ".png,webp", () => ConvertImage(ImageFileType.Webp) },
			{ ".bmp,png", () => ConvertImage(ImageFileType.Png) },
            { ".bmp,jpeg", () => ConvertImage(ImageFileType.Jpeg) },
            { ".bmp,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".bmp,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".bmp,tiff", () => ConvertImage(ImageFileType.Tiff) },
			{ ".bmp,webp", () => ConvertImage(ImageFileType.Webp) },
			{ ".tiff,png", () => ConvertImage(ImageFileType.Png) },
            { ".tiff,jpeg", () => ConvertImage(ImageFileType.Jpeg) },
            { ".tiff,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".tiff,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".tiff,bmp", () => ConvertImage(ImageFileType.Bmp) },
			{ ".tiff,webp", () => ConvertImage(ImageFileType.Webp) },
			{ ".tif,png", () => ConvertImage(ImageFileType.Png) },
            { ".tif,jpeg", () => ConvertImage(ImageFileType.Jpeg) },
            { ".tif,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".tif,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".tif,bmp", () => ConvertImage(ImageFileType.Bmp) },
			{ ".tif,webp", () => ConvertImage(ImageFileType.Webp) },
			{ ".webp,png", () => ConvertImage(ImageFileType.Png) },
            { ".webp,jpeg", () => ConvertImage(ImageFileType.Jpeg) },
            { ".webp,ico", () => ConvertImage(ImageFileType.Ico) },
            { ".webp,gif", () => ConvertImage(ImageFileType.Gif) },
            { ".webp,bmp", () => ConvertImage(ImageFileType.Bmp) },
			{ ".webp,tiff", () => ConvertImage(ImageFileType.Bmp) },
            //videos
            { ".avi,mp4", () => ConvertVideo() },
            { ".avi,mov", () => ConvertVideo() },
            { ".mp4,avi", () => ConvertVideo() },
            { ".mp4,mov", () => ConvertVideo() },
            { ".mov,mp4", () => ConvertVideo() },
            { ".mov,avi", () => ConvertVideo() }
        };

        #region Langs
        static Dictionary<string, string> en_us = new Dictionary<string, string>()
        {
            { "title", "File converter" },
            { "from", "From" },
            { "to", "To" },
            { "browse", "Browse" },
            { "file path", "File path" },
            { "file name", "File name" },
            { "path", "Path" },
            { "convert", "Convert" },
            { "settings", "Settings" },
            { "lang", "Language" },
            { "file exists", "File exists" },
            { "file exists msg", "This file already exists. Overwrite?" },
            { "file not supported msg", "This file type isn't supported" },
            { "finished", "Conversion finished in {0} sec" },
            { "error", "Error" },
            { "failed error", "Conversion failed due to error {0} ({1})\nPlease contact the software developer about this error." },
            { "generic error", "An unexpected error happened: {0} ({1})\nPlease contact the software developer about this error." },
            { "os outdated", "Your OS version is outdated. The following conversion methods are unavailable:" },
            { "warning", "Warning" },
            { "save", "Save" },
            { "saved settings", "Saved settings" },
            { "audio bitrate", "Audio bitrate" },
            { "bitrate help", "This bitrate will be used in conversion to the following types:\nwav > mp3\nThe more the bitrate is, the more file size is." },
            { "help", "Help" },
            { "help message", @"To convert a file, follow these steps:
1. Select the file you want to convert
2. Select the folder you want the converted file to be saved in
3. Enter the name of the file that will be saved
4. Select the file type
5. Press 'Convert'
If you've done everything correct, the file should appear in the output folder with the correct format.
If you want to get help for a specific feature, press '?' next to it.

This program is using the following libraries:{0}" },
            { "lang help", "Every text will be replaced with the corresponding translation from the selected language" },
            { "cancel", "Cancel" },
            { "cancel prompt", "Are you sure want to cancel?" },
            { "est time", "Estimated time left" },
            { "hour", "hour(s)" },
            { "min", "minute(s)" },
            { "sec", "second(s)" },
            { "samplerate", "Sample rate" },
            { "samplerate help", "The higher the sample rate, the higher the quality and so is the file size" },
            { "watermark", "Watermark" },
            { "watermark help", "Adds a watermark to images with custom text." },
            { "watermark text", "Watermark text" }
        };
        static Dictionary<string, string> ru_ru = new Dictionary<string, string>()
        {
            { "title", "Конвертер файлов" },
            { "from", "Из" },
            { "to", "В" },
            { "browse", "Обзор" },
            { "file path", "Путь к файлу" },
            { "file name", "Имя файла" },
            { "path", "Путь" },
            { "convert", "Конвертировать" },
            { "settings", "Настройки" },
            { "lang", "Язык" },
            { "file exists", "Файл существует" },
            { "file exists msg", "Этот файл уже существует. Заменить?" },
            { "file not supported msg", "Этот тип файла не поддерживается" },
            { "finished", "Конвертация завершена за {0} сек" },
            { "error", "Ошибка" },
            { "failed error", "Конвертация не удалась из-за ошибки {0} ({1})\nПожалуйста, сообщите разработчику программы об этой ошибке." },
            { "generic error", "Произошла непредвиденная ошибка: {0} ({1})\nПожалуйста, сообщите разработчику программы об этой ошибке." },
            { "os outdated", "Ваша операционная система устарела. Следующие петоды конвертации недоступны:" },
            { "warning", "Внимание" },
            { "save", "Сохранить" },
            { "saved settings", "Настройки сохранены" },
            { "audio bitrate", "Битрейт аудио" },
            { "bitrate help", "Этот битрейт будет использован в конвертации в следующие форматы:\nwav > mp3\nЧем больше битрейт, тем больше размер файла." },
            { "help", "Справка" },
            { "help message", @"Чтобы конвертировать файл, следуйте данным инструкциям:
1. Выберите файл, который вы хотите конвертировать
2. Выберите папку, куда будет сохранён конвертированный файл
3. Введите имя сохраняемого файла
4. Выберите тип файла
5. Нажмите 'Конвертировать'
Если вы всё сделали правильно, файл должен появиться в выходной папке в нужном формате.
Чтобы получить справку о каком-то другом элементе, нажмите на '?' рядом с ним.

Программа испроьзует следующие библиотеки:{0}" },
            { "lang help", "Каждая надпись будет заменена соответственным переводом из выбранного языка" },
            { "cancel", "Отмена" },
            { "cancel prompt", "Вы действительно хотите прервать операцию?" },
            { "est time", "Осталось примерно" },
            { "hour", "час(ов)" },
            { "min", "минут(ы)" },
            { "sec", "секунд(ы)" },
            { "samplerate", "Частота аудио" },
            { "samplerate help", "Чем выше частота, тем выше качество но и выше размер файла." },
            { "watermark", "Водяной знак" },
            { "watermark help", "Добавляет водяной знак к изображениям с пользовательским текстом." },
            { "watermark text", "Текст знака" }
        };
        static Dictionary<string, Dictionary<string, string>> langs = new Dictionary<string, Dictionary<string, string>>() {
            { "en_us", en_us },
            { "ru", ru_ru },
        };
        static string lang = "en_us";
        DateTime startTime = DateTime.Now;
        #endregion
        [DllImport("user32.dll")]
        public static extern int FlashWindow(IntPtr Hand, bool Revert);
        public Form1()
        {
            InitializeComponent();
        }
        static string TimeLabel(TimeSpan time)
        {

            if (time.TotalHours >= 1)
                return $"{time.TotalHours:0.##} {langs[lang]["hour"]}";
            else if (time.TotalMinutes >= 1)
                return $"{time.TotalMinutes:0.##} {langs[lang]["min"]}";
            return $"{time.TotalSeconds:0.##} {langs[lang]["sec"]}";
        }
        #region Conversions
        static async void ConvertVideo()
        {
            progressMax = 100;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            bar.Style = ProgressBarStyle.Continuous;
            var c = await FFmpeg.Conversions.FromSnippet.Convert(inPath, outPath);
            c.OnProgress += (_, args) =>
            {
                SetProgress(args.Percent, 100);
                if (args.Percent == 100)
                {
                    Finished?.Invoke(null);
                }
            };
            await c.Start();
        }
        static void WavToMP3()
        {
            using (var reader = new WaveFileReader(inPath))
            {
                MediaFoundationEncoder.EncodeToMp3(reader, outPath, bitrate);
            }
            Finished?.Invoke(null);
        }
        static void ToOGG(Stream stdin)
        {
            progressMax = 8;
            SetProgress(0, progressMax);
            var stdout = new FileStream(outPath, FileMode.Create, FileAccess.Write);
            var info = VorbisInfo.InitVariableBitRate(2, sampleRate, 0.1f);
            var serial = new Random().Next();
            var oggStream = new OggStream(serial);

            var comments = new Comments();
            comments.AddTag("ARTIST", "TEST");
            SetProgress(1, progressMax);
            var infoPacket = HeaderPacketBuilder.BuildInfoPacket(info);
            var commentsPacket = HeaderPacketBuilder.BuildCommentsPacket(comments);
            var booksPacket = HeaderPacketBuilder.BuildBooksPacket(info);

            oggStream.PacketIn(infoPacket);
            SetProgress(2, progressMax);
            oggStream.PacketIn(commentsPacket);
            SetProgress(3, progressMax);
            oggStream.PacketIn(booksPacket);
            SetProgress(4, progressMax);

            // Flush to force audio data onto its own page per the spec
            OggPage page;
            bar.Style = ProgressBarStyle.Marquee;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            while (oggStream.PageOut(out page, true))
            {
                stdout.Write(page.Header, 0, page.Header.Length);
                stdout.Write(page.Body, 0, page.Body.Length);
            }
            bar.Style = ProgressBarStyle.Continuous;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            SetProgress(5, progressMax);
            var processingState = ProcessingState.Create(info);
            SetProgress(6, progressMax);

            var buffer = new float[info.Channels][];
            buffer[0] = new float[1024];
            buffer[1] = new float[1024];

            var readbuffer = new byte[4096];
            SetProgress(7, progressMax);
            bar.Style = ProgressBarStyle.Marquee;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            while (!oggStream.Finished)
            {
                var bytes = stdin.Read(readbuffer, 0, readbuffer.Length);

                if (bytes == 0)
                {
                    processingState.WriteEndOfStream();
                }
                else
                {
                    var samples = bytes / 4;

                    for (var i = 0; i < samples; i++)
                    {
                        // uninterleave samples
                        buffer[0][i] = (short)((readbuffer[i * 4 + 1] << 8) | (0x00ff & readbuffer[i * 4])) / 32768f;
                        buffer[1][i] = (short)((readbuffer[i * 4 + 3] << 8) | (0x00ff & readbuffer[i * 4 + 2])) / 32768f;
                    }

                    processingState.WriteData(buffer, samples);
                }

                OggPacket packet;
                while (!oggStream.Finished
                       && processingState.PacketOut(out packet))
                {
                    oggStream.PacketIn(packet);

                    while (!oggStream.Finished
                           && oggStream.PageOut(out page, false))
                    {
                        stdout.Write(page.Header, 0, page.Header.Length);
                        stdout.Write(page.Body, 0, page.Body.Length);
                    }
                }
            }
            bar.Style = ProgressBarStyle.Continuous;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            SetProgress(8, progressMax);

            stdin.Close();
            stdout.Close();
        }
        static void WavToOGG()
        {
            using (var stdin = new WaveFileReader(inPath))
            {
                ToOGG(stdin);
            }
            Finished?.Invoke(null);
        }
        static void MP3ToOGG()
        {
            using (var stdin = new Mp3FileReader(inPath))
            {
                ToOGG(stdin);
            }
        }
        static void MP3ToWav()
        {
            using (var reader = new Mp3FileReader(inPath))
            {
                WaveFileWriter.CreateWaveFile(outPath, reader);
            }
            Finished?.Invoke(null);
        }
        static void OGGToMP3()
        {
            using (var reader = new VorbisWaveReader(inPath))
            {
                MediaFoundationEncoder.EncodeToMp3(reader, outPath, bitrate);
            }
            Finished?.Invoke(null);
        }
        static void ConvertImage(ImageFileType type)
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            Image img = Image.FromFile(inPath);
            if (type == ImageFileType.Ico)
            {
                Icon icon = IconFromImage(img);
                using (var stream = new FileStream(outPath, FileMode.Create))
                {
                    icon.Save(stream);
                }
                //throw new Exception("jhASKHNJGKJFKJNHKJF");
            }
            else
            {

                using (Converter converter = new Converter(inPath))
                {
                    ImageConvertOptions options = new()
                    {
                        Format = type,
                    };
                    if (wmarkCheck.Checked) {
                        options.Watermark = new WatermarkTextOptions(wmarkText.Text) {
                            Transparency = 0.7,
                            RotationAngle = 45,
                            AutoAlign = true
                        };
                    }
                    converter.Convert(outPath, options);

                }
            }
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            Finished?.Invoke(null);
        }
        static int progressMax = 0;
        static ProgressBar bar;
        static ToolStripStatusLabel progressLabel;
        static ToolStripStatusLabel estTimeLabel;
        static CheckBox wmarkCheck;
        static TextBox wmarkText;
        static event Action<Exception?> Finished;
        static DateTime lastPercentTime;
        public static Icon IconFromImage(Image img)
        {
            progressMax = 16;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            bar.Style = ProgressBarStyle.Continuous;
            bar.Maximum = progressMax;
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            // Header
            bw.Write((short)0);   // 0 : reserved
            SetProgress(1, progressMax);
            bw.Write((short)1);   // 2 : 1=ico, 2=cur
            SetProgress(2, progressMax);
            bw.Write((short)1);   // 4 : number of images
            SetProgress(3, progressMax);
            bw.Dispose();
            //throw new NotImplementedException();
            SetProgress(4, progressMax);
            // Image directory
            var w = img.Width;
            if (w >= 256) w = 0;
            bw.Write((byte)w);    // 0 : width of image
            SetProgress(5, progressMax);
            var h = img.Height;
            if (h >= 256) h = 0;
            bw.Write((byte)h);    // 1 : height of image
            SetProgress(6, progressMax);
            bw.Write((byte)0);    // 2 : number of colors in palette
            SetProgress(7, progressMax);
            bw.Write((byte)0);    // 3 : reserved
            SetProgress(8, progressMax);
            bw.Write((short)0);   // 4 : number of color planes
            SetProgress(9, progressMax);
            bw.Write((short)0);   // 6 : bits per pixel
            SetProgress(10, progressMax);
            var sizeHere = ms.Position;
            bw.Write((int)0);     // 8 : image size
            SetProgress(11, progressMax);
            var start = (int)ms.Position + 4;
            bw.Write(start);      // 12: offset of image data
            SetProgress(12, progressMax);
            // Image data
            img.Save(ms, ImageFormat.Png);
            SetProgress(13, progressMax);
            var imageSize = (int)ms.Position - start;
            ms.Seek(sizeHere, System.IO.SeekOrigin.Begin);
            SetProgress(14, progressMax);
            bw.Write(imageSize);
            SetProgress(15, progressMax);
            ms.Seek(0, SeekOrigin.Begin);
            SetProgress(16, progressMax);

            // And load it
            return new Icon(ms);
        }
        #endregion
        static void SetProgress(int value, int max)
        {
            TaskbarManager.Instance.SetProgressValue(value, max);
            bar.Invoke(() =>
            {
                bar.Maximum = max;
                bar.Value = value;
                TimeSpan span = (DateTime.Now - lastPercentTime) * (max - value);
                progressLabel.Text = $"{Math.Floor((float)value / max * 1000) / 10}%";
                estTimeLabel.Text = $"{langs[lang]["est time"]}: {TimeLabel(span)}";
            });
            lastPercentTime = DateTime.Now;
        }
        FileInfo? file;
        static string outPath = "";
        static string inPath = "";
        string version = "0.8.1";
        static int bitrate = 192000;
        static int sampleRate;
        void CheckValid()
        {
            try
            {
                if (string.IsNullOrEmpty(ImportPathBox.Text) || string.IsNullOrEmpty(OutputNameBox.Text)) return;
                ConvertButton.Enabled =
                    file != null &&
                    file.Exists &&
                    !string.IsNullOrEmpty(ImportPathBox.Text) &&
                    File.Exists(ImportPathBox.Text) &&
                    Directory.Exists(OutputPathBox.Text) &&
                    TypeBox.SelectedItem != null &&
                    methods.ContainsKey($"{file.Extension},{TypeBox.SelectedItem}");
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                    MessageBox.Show(e.ToString(), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(string.Format(langs[lang]["generic error"], e.HResult.ToString(), e.GetType().Name), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BrowseImport_Click(object sender, EventArgs e)
        {
            DialogResult res = OpenFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                ImportPathBox.Text = OpenFileDialog1.FileName;
                file = new FileInfo(ImportPathBox.Text);
                if (types.ContainsKey(file.Extension))
                {
                    TypeBox.Items.Clear();
                    TypeBox.Items.AddRange(types[file.Extension].Split(','));
                    TypeBox.Enabled = true;
                }
                else
                {
                    TypeBox.Enabled = false;
                    MessageBox.Show(langs[lang]["file not supported msg"], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CheckValid();
        }

        private void OutputPathBox_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                OutputPathBox.Text = FolderBrowserDialog1.SelectedPath;
            }
            CheckValid();
        }

        private void ImportPathBox_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void OutputNameBox_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            outPath = $"{OutputPathBox.Text}\\{OutputNameBox.Text}.{TypeBox.SelectedItem}";
            inPath = ImportPathBox.Text;
            FileInfo outFile = new FileInfo(outPath);
            if (outFile.Exists)
            {
                DialogResult r = MessageBox.Show(langs[lang]["file exists msg"], langs[lang]["file exists"], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.No)
                {
                    Progressbar.Style = ProgressBarStyle.Continuous;
                    return;
                }
            }
            Progressbar.Style = ProgressBarStyle.Marquee;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            PercentageLabel.Text = "Please wait...";
            EstTimeLabel.Text = "...";
            try
            {
                startTime = DateTime.Now;
                ConvertButton.Enabled = false;
                CancelButton.Enabled = true;
                methods[$"{file.Extension},{TypeBox.SelectedItem}"].Invoke();

            }
            catch (Exception exc)
            {


                Finished?.Invoke(exc);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LanguageBox.Items.AddRange(langs.Keys.ToArray());
            if (File.Exists("settings.txt"))
            {
                try
                {
                    string[] settings = File.ReadAllLines("settings.txt");
                    LanguageBox.SelectedItem = settings[1];
                    BitrateBox.SelectedItem = settings[2];
                    bitrate = int.Parse(settings[2]);
                    SampleRateBox.SelectedItem = settings[3];
                    sampleRate = int.Parse(settings[3]);
                }
                catch (Exception exc)
                {
                    if (Debugger.IsAttached)
                        MessageBox.Show(exc.ToString(), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(string.Format(langs[lang]["generic error"], exc.HResult.ToString(), exc.GetType().Name), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LanguageBox.SelectedItem = "en_us";
                    BitrateBox.SelectedItem = "192000";
                    SampleRateBox.SelectedItem = "44100";
                }
            }
            else
            {
                LanguageBox.SelectedItem = "en_us";
                BitrateBox.SelectedItem = "192000";
                SampleRateBox.SelectedItem = "44100";
            }
            MediaFoundationApi.Startup();
            Translate();
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor > 1)
                MessageBox.Show(langs[lang]["os outdated"] + "\n.wav > .mp3", langs[lang]["warning"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bar = Progressbar;
            progressLabel = PercentageLabel;
            estTimeLabel = EstTimeLabel;
            wmarkCheck = WatermarkCheckBox;
            wmarkText = WatermarkTextBox;
            lastPercentTime = DateTime.Now;
            FFmpeg.SetExecutablesPath("ffmpeg\\");
            Finished += OnFinish;
        }

        private void OnFinish(Exception? e)
        {
            Invoke(() =>
            {
                Progressbar.Style = ProgressBarStyle.Continuous;
                Progressbar.Value = 0;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                if (e != null)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                    TaskbarManager.Instance.SetProgressValue(1, 1);
                    if (Debugger.IsAttached)
                        MessageBox.Show(e.ToString(), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(string.Format(langs[lang]["failed error"], e.HResult.ToString(), e.GetType().Name), langs[lang]["error"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                else
                {
                    MessageBox.Show(string.Format(langs[lang]["finished"], (DateTime.Now - startTime).TotalSeconds), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (!Focused)
                        FlashWindow(Handle, false);
                }
                ConvertButton.Enabled = true;
                CancelButton.Enabled = false;
            });

        }

        void Translate()
        {
            lang = LanguageBox.SelectedItem.ToString();
            Text = langs[lang]["title"] + " " + version;
            FromLabel.Text = langs[lang]["from"];
            ToLabel.Text = langs[lang]["to"];
            BrowseImport.Text = BrowseOutput.Text = langs[lang]["browse"];
            ImportPathBox.PlaceholderText = langs[lang]["file path"];
            OutputPathBox.PlaceholderText = langs[lang]["path"];
            OutputNameBox.PlaceholderText = langs[lang]["file name"];
            ConvertButton.Text = langs[lang]["convert"];
            SettingsBox.Text = langs[lang]["settings"];
            LangLabel.Text = langs[lang]["lang"];
            SaveSettingsButton.Text = langs[lang]["save"];
            BitrateLabel.Text = langs[lang]["audio bitrate"];
            HelpButton.Text = langs[lang]["help"];
            SampleRateLabel.Text = langs[lang]["samplerate"];
            WatermarkCheckBox.Text = langs[lang]["watermark"];
            WatermarkTextBox.PlaceholderText = langs[lang]["watermark text"];
        }
        private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Translate();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            File.WriteAllLines("settings.txt", new string[]
            {
               "Do not edit this file manually",
               LanguageBox.Text,
               BitrateBox.Text,
               SampleRateBox.Text,
            });
            MessageBox.Show(langs[lang]["saved settings"], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BitrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BitrateHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(langs[lang]["bitrate help"], langs[lang]["help"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(langs[lang]["help message"], @"
NAudio 2.2.1
Naudio.Vorbis 1.5.0
OggVorbisEncoder 1.2.2
Xabe.FFmpeg 5.2.6,
GroupDocs.Conversion 24.1.0"), langs[lang]["help"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LangHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(langs[lang]["lang help"], langs[lang]["help"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void SampleRateHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(langs[lang]["samplerate help"], langs[lang]["help"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WatermarkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WatermarkTextBox.Enabled = WatermarkCheckBox.Checked;
        }

        private void WatermarkHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(langs[lang]["watermark help"], langs[lang]["help"], MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}