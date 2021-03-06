using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Numerics;

namespace Data_Compression
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void LoadFileInfo(string path)
        {
            jpegCheckBox.Visible = false;
            jpegCheckBox.Checked = false;
            string ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".txt":
                    typeLabel.Text = "Тип файла: Текст";
                    compressButton.Focus();
                    break;
                case ".bmp":
                    try
                    {
                        if (new Bitmap(path).PixelFormat == PixelFormat.Format24bppRgb)
                        {
                            typeLabel.Text = "Тип файла: растровое изображение (24-разрядное)";
                            jpegCheckBox.Visible = true;
                            jpegCheckBox.Checked = true;
                        }
                        else
                            typeLabel.Text = "Тип файла: растровое изображение (не 24-битное)";
                    }
                    catch (Exception)
                    {
                        typeLabel.Text = "Тип файла: Не определено /";
                    };
                    compressButton.Focus();
                    break;
                case ".cdt":
                    typeLabel.Text = "Тип файла: CDT Сжатие";
                    extractButton.Focus();
                    break;
                default:
                    typeLabel.Text = "Тип файла: Не определено";
                    compressButton.Focus();
                    break;
            }
            FileInfo f = new FileInfo(path);
            lengthLabel.Text = "Общая длина: " + String.Format("{0:n0}", f.Length) + " байт";
        }

        CompressedFileInfo Compress(string sourcePath, string destPath, ALGORITHM algorithm, bool losslessJPEG)
        {
            CompressedFileInfo file = new CompressedFileInfo();
            string header = Path.GetExtension(sourcePath) + "\r\n";
            byte[] data = new byte[0];
            if (!losslessJPEG)
                data = File.ReadAllBytes(sourcePath);
            else
            {
                Bitmap image = new Bitmap(sourcePath);
                data = new DifferentialImageCoding().Encode(image);
                header += ((int)ALGORITHM.DifferentialImageCoding).ToString();
                string s1 = Utilities.ConvertIntegerToBinaryString(image.Width, 16);
                string s2 = Utilities.ConvertIntegerToBinaryString(image.Height, 16);
                int i1 = Utilities.ConvertBinaryStringToInteger(s1.Substring(0, 8));
                int i2 = Utilities.ConvertBinaryStringToInteger(s1.Substring(8, 8));
                int i3 = Utilities.ConvertBinaryStringToInteger(s2.Substring(0, 8));
                int i4 = Utilities.ConvertBinaryStringToInteger(s2.Substring(8, 8));
                header += ((char)i1).ToString() + ((char)i2).ToString() + ((char)i3).ToString() + ((char)i4).ToString();
            }
            byte[] encodeData = new byte[0];
            switch (algorithm)
            {
                case ALGORITHM.ShannonFanoCoding:
                    encodeData = new ShannonFanoCoding().Encode(data);
                    break;
                case ALGORITHM.HuffmanCoding:
                    encodeData = new HuffmanCoding().Encode(data);
                    break;
                case ALGORITHM.RunLengthCoding:
                    encodeData = new RunLengthCoding().Encode(data);
                    break;
                case ALGORITHM.LZWCoding:
                    encodeData = new LZWCoding().Encode(data);
                    break;
                case ALGORITHM.ArithmeticCoding:
                    encodeData = new ArithmeticCoding().Encode(data);
                    break;
            }
            header += ((int)algorithm).ToString();
            FileStream writer = new FileStream(destPath, FileMode.Create, FileAccess.Write);
            byte[] headerData = Utilities.ConvertStringToBytes(header);
            writer.Write(headerData, 0, headerData.Length);
            writer.Write(encodeData, 0, encodeData.Length);
            writer.Close();

            long compressedLength = new FileInfo(destPath).Length;
            long originalLength = new FileInfo(sourcePath).Length;
            file = new CompressedFileInfo(Path.GetFileName(destPath), algorithm.ToString(), originalLength, compressedLength);
            return file;
        }

        void DoCompression()
        {
            string sourcePath = pathTextBox.Text;
            string destPath = compressSaveFileDialog.FileName;
            long originalLength = new FileInfo(sourcePath).Length;
            bool losslessJPEG = jpegCheckBox.Checked;
            List<CompressedFileInfo> files = new List<CompressedFileInfo>();
            if (algorithmCheckBox.Checked)
            {
                string name = Path.GetFileNameWithoutExtension(destPath);
                string ext = Path.GetExtension(destPath);
                string path = Path.GetDirectoryName(destPath);
                string name1 = path + "/" + name + "_1" + ext;
                string name2 = path + "/" + name + "_2" + ext;
                string name3 = path + "/" + name + "_3" + ext;
                string name4 = path + "/" + name + "_4" + ext;
                files.Add(Compress(sourcePath, name1, ALGORITHM.ShannonFanoCoding, losslessJPEG));
                files.Add(Compress(sourcePath, name2, ALGORITHM.HuffmanCoding, losslessJPEG));
                files.Add(Compress(sourcePath, name3, ALGORITHM.RunLengthCoding, losslessJPEG));
                files.Add(Compress(sourcePath, name4, ALGORITHM.LZWCoding, losslessJPEG));
            }
            else
            {
                CompressedFileInfo file = new CompressedFileInfo();
                string header = Path.GetExtension(sourcePath) + "\r\n";
                byte[] data = new byte[0];
                if (!losslessJPEG)
                    data = File.ReadAllBytes(sourcePath);
                else
                {
                    Bitmap image = new Bitmap(sourcePath);
                    data = new DifferentialImageCoding().Encode(image);
                    header += ((int)ALGORITHM.DifferentialImageCoding).ToString();
                    string s1 = Utilities.ConvertIntegerToBinaryString(image.Width, 16);
                    string s2 = Utilities.ConvertIntegerToBinaryString(image.Height, 16);
                    int i1 = Utilities.ConvertBinaryStringToInteger(s1.Substring(0, 8));
                    int i2 = Utilities.ConvertBinaryStringToInteger(s1.Substring(8, 8));
                    int i3 = Utilities.ConvertBinaryStringToInteger(s2.Substring(0, 8));
                    int i4 = Utilities.ConvertBinaryStringToInteger(s2.Substring(8, 8));
                    header += ((char)i1).ToString() + ((char)i2).ToString() + ((char)i3).ToString() + ((char)i4).ToString();
                }
                ALGORITHM algorithm = 0;
                byte[] encodeData = new byte[0];
                if (shannonFanoRadioButton.Checked)
                {
                    algorithm = ALGORITHM.ShannonFanoCoding;
                    encodeData = new ShannonFanoCoding().Encode(data);
                };
                if (huffmanRadioButton.Checked)
                {
                    algorithm = ALGORITHM.HuffmanCoding;
                    encodeData = new HuffmanCoding().Encode(data);
                };
                if (runLengthRadioButton.Checked)
                {
                    algorithm = ALGORITHM.RunLengthCoding;
                    encodeData = new RunLengthCoding().Encode(data);
                };
                if (lzwRadioButton.Checked)
                {
                    algorithm = ALGORITHM.LZWCoding;
                    encodeData = new LZWCoding().Encode(data);
                };
                header += ((int)algorithm).ToString();
                FileStream writer = new FileStream(destPath, FileMode.Create, FileAccess.Write);
                byte[] headerData = Utilities.ConvertStringToBytes(header);
                writer.Write(headerData, 0, headerData.Length);
                writer.Write(encodeData, 0, encodeData.Length);
                writer.Close();

                long compressedLength = new FileInfo(destPath).Length;
                file = new CompressedFileInfo(Path.GetFileName(destPath), algorithm.ToString(), originalLength, compressedLength);
                files.Add(file);
            }
            new StatisticsForm(Path.GetDirectoryName(destPath), files).Show();
        }

        void DoExtraction(FileStream reader)
        {
            string sourcePath = pathTextBox.Text;
            string destPath = extractSaveFileDialog.FileName;
            ALGORITHM algorithm = (ALGORITHM)(reader.ReadByte() - '0');
            bool losslessJPEG = false;
            int width = 0, height = 0;
            if (algorithm == ALGORITHM.DifferentialImageCoding)
            {
                losslessJPEG = true;
                int i1 = reader.ReadByte();
                int i2 = reader.ReadByte();
                int i3 = reader.ReadByte();
                int i4 = reader.ReadByte();
                string s1 = Utilities.ConvertIntegerToBinaryString(i1) + Utilities.ConvertIntegerToBinaryString(i2);
                string s2 = Utilities.ConvertIntegerToBinaryString(i3) + Utilities.ConvertIntegerToBinaryString(i4);
                width = Utilities.ConvertBinaryStringToInteger(s1);
                height = Utilities.ConvertBinaryStringToInteger(s2);
                algorithm = (ALGORITHM)(reader.ReadByte() - '0');
            }
            byte[] data = new byte[reader.Length - reader.Position];
            reader.Read(data, 0, data.Length);
            reader.Close();
            byte[] result = new byte[0];
            switch (algorithm)
            {
                case ALGORITHM.ShannonFanoCoding:
                    result = new ShannonFanoCoding().Decode(data);
                    break;
                case ALGORITHM.HuffmanCoding:
                    result = new HuffmanCoding().Decode(data);
                    break;
                case ALGORITHM.RunLengthCoding:
                    result = new RunLengthCoding().Decode(data);
                    break;
                case ALGORITHM.LZWCoding:
                    result = new LZWCoding().Decode(data);
                    break;
                case ALGORITHM.ArithmeticCoding:
                    result = new ArithmeticCoding().Decode(data);
                    break;
            }
            if (!losslessJPEG)
            {
                File.WriteAllBytes(destPath, result);
            }
            else
            {
                Bitmap image = new DifferentialImageCoding().Decode(result, width, height);
                if (File.Exists(destPath))
                    File.Delete(destPath);
                image.Save(destPath, ImageFormat.Bmp);
            }
            Process.Start("explorer.exe", "/select, " + destPath);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            pathTextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(pathTextBox.Text))
            {
                existLabel.Visible = false;
                compressSaveFileDialog.InitialDirectory = Path.GetDirectoryName(pathTextBox.Text);
                compressSaveFileDialog.FileName = Path.GetFileNameWithoutExtension(new FileInfo(pathTextBox.Text).Name);
                extractSaveFileDialog.InitialDirectory = Path.GetDirectoryName(pathTextBox.Text);
                LoadFileInfo(pathTextBox.Text);
            }
            else
            {
                existLabel.Visible = true;
            }
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if (existLabel.Visible || pathTextBox.Text == "")
                return;
            if (compressSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                waitLabel.Visible = true;
                Application.DoEvents();
                DoCompression();
                waitLabel.Visible = false;
            }
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            if (existLabel.Visible || pathTextBox.Text == "")
                return;
            string path = pathTextBox.Text;
            FileStream reader = new FileStream(path, FileMode.Open, FileAccess.Read);
            string ext = "";
            int i = reader.ReadByte();
            while (i != '\r')
            {
                ext += ((char)i).ToString();
                i = reader.ReadByte();
            }
            reader.ReadByte();
            extractSaveFileDialog.FileName = Path.GetFileNameWithoutExtension(path) + ext;
            if (extractSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                waitLabel.Visible = true;
                Application.DoEvents();
                DoExtraction(reader);
                waitLabel.Visible = false;
            }
        }

        private void algorithmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            algorithmGroupBox.Enabled = !algorithmCheckBox.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Characters.Init();
        }
    }
}
