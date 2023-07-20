using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToySimulator
{
    public partial class MainForm : Form
    {
        int c = 0, z = 0;
        public int pc {  get; set; }
        const int blockSize = 512;// 32 lins
        const int lineSize = 16; // 8 cells
        const int cellSize = 2; // 2 bytes

        short blockAddr;
        short[][] blockArr = new short[32][];

        readonly FileStream fs;
        FileInfo file;
        public MainForm()
        {
            InitializeComponent();
            blockAddr = 0;
            for(int i = 0; i < 32; i++)
            {
                blockArr[i] = new short[9];     
                
            }
            try
            {
                file = new FileInfo(@"memory.txt");
                fs = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (FileNotFoundException)
            {
                File.WriteAllBytes(@"memory.txt",new byte[512]);
                file = new FileInfo(@"memory.txt");
                fs = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
            }
            regA.Text = "0";
            regT.Text = "0";
            MemLoad();

        }
        public void UpdateMemView()
        {
            var data = from arr in blockArr
                       select new
                       {
                           Address = "0x" + arr[0].ToString("X"),
                           Value_0 = arr[1],
                           adr1 = "0x" + (arr[0] + 1).ToString("X"),
                           Value_1 = arr[2],
                           adr2 = "0x" + (arr[0] + 2).ToString("X"),
                           Value_2 = arr[3],
                           adr3 = "0x" + (arr[0] + 3).ToString("X"),
                           Value_3 = arr[4],
                           adr4 = "0x" + (arr[0] + 4).ToString("X"),
                           Value_4 = arr[5],
                           adr5 = "0x" + (arr[0] + 5).ToString("X"),
                           Value_5 = arr[6],
                           adr6 = "0x" + (arr[0] + 6).ToString("X"),
                           Value_6 = arr[7],
                           adr7 = "0x" + (arr[0] + 7).ToString("X"),
                           Value_7 = arr[8]
                       };
            MemGridView.DataSource = data.ToList();
        }
        public short MemRead(int addr)
        {
            int actualRead=0;
            byte[] buffer = new byte[cellSize];
            fs.Position = addr* cellSize;
            do
            {
                actualRead += fs.Read(buffer, actualRead, cellSize - actualRead);
            } while (actualRead != cellSize && fs.Position < fs.Length);

            return BitConverter.ToInt16(buffer, 0);
        }
        private void MemWrite(int addr, short data)
        {
            int blockstart = blockAddr * blockSize;
            int adrInBlock = addr - blockstart;
            if ((addr >= blockstart) && (addr < blockstart + blockSize))
            {
                blockArr[adrInBlock / 8][(adrInBlock % 8)+1] = data;
                UpdateMemView();
            }
           
            byte[] buffer = BitConverter.GetBytes(data);
            fs.Position = addr * cellSize;
            fs.Write(buffer, 0, cellSize);
           
        }
        public void MemLoad()
        {
            byte[] buffer = new byte[blockSize];
            int actualRead = 0;
            int addr = blockAddr * blockSize;
            fs.Position = addr;
            do
            {
                actualRead += fs.Read(buffer, actualRead, blockSize - actualRead);
            } while (actualRead != blockSize && fs.Position < fs.Length);
            for(short i=0;i<32;i++)
            {
                blockArr[i][0] = Convert.ToInt16(addr +(i*8));
                for (int j=0;j<8;j++)
                {
                    int startindex = (i * lineSize) + (j * cellSize);
                    blockArr[i][j+1] = BitConverter.ToInt16(buffer, startindex);
                }
            }
            UpdateMemView();
        }
        private void monitorBtn_Click(object sender, EventArgs e)
        {
            short tmp = short.Parse(MemBlockBox.Text);
            if (tmp > 128 || tmp < 0)
            {
                MemBlockBox.Text = "Enter number between 0-16!";
                return;
            }

            blockAddr = tmp;
            MemLoad();
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            pc = 0;
            while (pc < codeBox.Lines.Length)
            {
                pc++;
                ParseLine(codeBox.Lines[pc-1]);
               
            }
            PC.Text = pc.ToString();
        }
        private void lineBtn_Click(object sender, EventArgs e)
        {
            if(pc==codeBox.Lines.Length)
            {
                return;
            }
            pc++;
            ParseLine(codeBox.Lines[pc-1]);
            PC.Text = pc.ToString();
        }
        public void ParseLine(string line)
        {
            string cmd = "", addr="";
            int i;
            for (i = 0; (i < line.Length) && (line[i] != ' '); i++)
                cmd += line[i];
            for(i++;i<line.Length;i++)
                addr += line[i];
            Execute(cmd, addr);

        }

        

        public void Execute(string cmd,string addr)
        {
            addr = (addr != "") ? addr : "0";
            short src = short.Parse(addr);
            short a = short.Parse(regA.Text);
            short t = short.Parse(regT.Text);
            switch (cmd)
            {
                case "JMP":
                case "jmp":
                    pc = src;
                    PC.Text = pc.ToString();
                    break;
                case "ADC":
                case "adc":
                    regA.Text = (a + MemRead(src)).ToString();
                    if (a + src > 32768) { c = 1;cBox.Text = "1"; }
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "XOR":
                case "xor":
                    regA.Text = (a ^ MemRead(src)).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "SBC":
                case "sbc":
                    regA.Text = (a - MemRead(src) - c).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "ROR":
                case "ror":
                    regA.Text = RotateRight(a, 1).ToString();
                    break;
                case "TAT":
                case "tat":
                    regT.Text = regA.Text;
                    break;
                case "OR":
                case "or":
                    regA.Text = (a | MemRead(src)).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "AND":
                case "and":
                    regA.Text = (a & MemRead(src)).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "LDC":
                case "ldc":
                    regA.Text = MemRead(src).ToString();
                    c = 0;
                    cBox.Text = "0";
                    break;
                case "BCC":
                case "bcc":
                    if (c == 0) { pc = MemRead(src); PC.Text = pc.ToString(); }
                        break;
                case "BNE":
                case "bne":
                    if (z == 1) {pc = MemRead(src); PC.Text = pc.ToString();
            }
            break;
                case "LDI":
                case "ldi":
                    regA.Text = MemRead(a).ToString();
                    break;
                case "STT":
                case "stt":
                    MemWrite(MemRead(a), t);
                    break;
                case "LDA":
                case "lda":
                    regA.Text = MemRead(src).ToString();
                    break;
                case "STA":
                case "sta":
                    MemWrite(src, a);
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pc = int.Parse(PC.Text);
        }

        public int RotateRight(int value, int count)
        {
            return (value >> count) | (value << (16 - count));
        }

    }
}
