using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ToySimulator
{
    public partial class MainForm : Form
    {
        int c = 0, z = 0, pc;

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
            for (short i = 0; i < 32; i++)
            {
                blockArr[i] = new short[9];
                blockArr[i][0] = i;
                for(int j = 1; j < 9; j++)
                    blockArr[i][j] = 0;
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


            MemLoad();

        }
        public void updateMemView()
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
        public int MemRead(int addr)
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
        public void MemWrite(int addr, Int16 data)
        {
            int blockstart = blockAddr * blockSize;
            int adrInBlock = addr - blockstart;
            if ((addr <= blockstart) && (addr < blockstart + blockSize))
            {
                blockArr[adrInBlock / 8][adrInBlock % 8] = data;
                updateMemView();
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
            fs.Position = blockAddr * blockSize;
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
            updateMemView();
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            pc = 0;
            while (pc < codeBox.Lines.Length)
            {
                ParseLine(codeBox.Lines[pc]);
                pc++;
            }

        }
        public void ParseLine(string line)
        {
            string cmd = "", addr="";
            int i;
            for (i = 0; line[i] != ' '; i++)
                cmd += line[i];
            for(i++;i<line.Length;i++)
                addr += line[i];
            Execute(cmd, addr);

        }

        private void MemoryView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        public void Execute(string cmd,string addr)
        {
            short src = short.Parse(addr);
            short a = short.Parse(regA.Text);
            short t = short.Parse(regT.Text);
            switch (cmd)
            {
                case "JMP":
                case "jmp":
                    pc = src;
                    break;
                case "ADC":
                case "adc":
                    regA.Text = (a + src).ToString();
                    if (a + src > 32768) c = 1;

                    break;
                case "XOR":
                case "xor":
                    regA.Text = (a ^ src).ToString();
                    break;
                case "SBC":
                case "sbc":
                    regA.Text = (a - src - c).ToString();

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
                    regA.Text = (a | src).ToString();
                    break;
                case "AND":
                case "and":
                    regA.Text = (a & src).ToString();
                    break;
                case "LDC":
                case "ldc":
                    regA.Text = MemRead(src).ToString();
                    c = 0;
                    break;
                case "BCC":
                case "bcc":
                    if (c == 0) pc = MemRead(src);
                    break;
                case "BNE":
                case "bne":
                    if (z == 1) pc = MemRead(src);
                    break;
                case "LDI":
                case "ldi":
                    regA.Text = MemRead(a).ToString();
                    break;
                case "STT":
                case "stt":
                    MemWrite(a, t);
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
        public int RotateRight(int value, int count)
        {
            return (value >> count) | (value << (16 - count));
        }

    }
}
