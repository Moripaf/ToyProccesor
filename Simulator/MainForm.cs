using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

namespace ToySimulator
{
    public partial class MainForm : Form
    {
        int c = 0, z = 0;
        int org = 0;
        bool isBreakPoint = false;
        public short pc {  get; set; }
        const int blockSize = 512;// 32 lins
        const int lineSize = 16; // 8 cells
        const int cellSize = 2; // 2 bytes

        short blockAddr;
        short[][] blockArr = new short[32][];
        IDictionary<char, int> D = new Dictionary<char, int>();
        IDictionary<string, short> Labels = new Dictionary<string, short>();
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
            zBox.Text = "0";
            cBox.Text = "0";
            pc = 0;
            PC.Text = "0";
            MemLoad();

        }
        public void UpdateMemView()
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    var hdata = from arr in blockArr
                               select new
                               {
                                   Address = "0x" + arr[0].ToString("X"),
                                   Value_0 = "0x" + arr[1].ToString("X"),
                                   adr1 = "0x" + (arr[0] + 1).ToString("X"),
                                   Value_1 = "0x" + arr[2].ToString("X"),
                                   adr2 = "0x" + (arr[0] + 2).ToString("X"),
                                   Value_2 = "0x" + arr[3].ToString("X"),
                                   adr3 = "0x" + (arr[0] + 3).ToString("X"),
                                   Value_3 = "0x" + arr[4].ToString("X"),
                                   adr4 = "0x" + (arr[0] + 4).ToString("X"),
                                   Value_4 = "0x" + arr[5].ToString("X"),
                                   adr5 = "0x" + (arr[0] + 5).ToString("X"),
                                   Value_5 = "0x" + arr[6].ToString("X"),
                                   adr6 = "0x" + (arr[0] + 6).ToString("X"),
                                   Value_6 = "0x" + arr[7].ToString("X"),
                                   adr7 = "0x" + (arr[0] + 7).ToString("X"),
                                   Value_7 = "0x" + arr[8].ToString("X")
                               };
                     MemGridView.DataSource = hdata.ToList();
                    break;
                case 1:
                    var bdata = from arr in blockArr
                               select new
                               {
                                   Address = Convert.ToString(arr[0], 2),
                                   Value_0 = Convert.ToString(arr[1], 2),
                                   adr1 = Convert.ToString(arr[0] + 1, 2),
                                   Value_1 = Convert.ToString(arr[2], 2),
                                   adr2 = Convert.ToString(arr[0] + 2, 2),
                                   Value_2 = Convert.ToString(arr[3], 2),
                                   adr3 = Convert.ToString(arr[0] + 3, 2),
                                   Value_3 = Convert.ToString(arr[4], 2),
                                   adr4 = Convert.ToString(arr[0] + 4, 2),
                                   Value_4 = Convert.ToString(arr[5], 2),
                                   adr5 = Convert.ToString(arr[0] + 5, 2),
                                   Value_5 = Convert.ToString(arr[6], 2),
                                   adr6 = Convert.ToString(arr[0] + 6, 2),
                                   Value_6 = Convert.ToString(arr[7], 2),
                                   adr7 = Convert.ToString(arr[0] + 7, 2),
                                   Value_7 = Convert.ToString(arr[8], 2)
                               };
                    MemGridView.DataSource = bdata.ToList();
                    break;
                case 2:
                    var ddata = from arr in blockArr
                                select new
                                {
                                    Address =  arr[0],
                                    Value_0 = arr[1],
                                    adr1 = (arr[0] + 1),
                                    Value_1 = arr[2],
                                    adr2 = (arr[0] + 2),
                                    Value_2 = arr[3],
                                    adr3 = (arr[0] + 3),
                                    Value_3 = arr[4],
                                    adr4 = (arr[0] + 4),
                                    Value_4 = arr[5],
                                    adr5 = (arr[0] + 5),
                                    Value_5 = arr[6],
                                    adr6 = (arr[0] + 6),
                                    Value_6 = arr[7],
                                    adr7 = (arr[0] + 7),
                                    Value_7 = arr[8]
                                };
                    MemGridView.DataSource = ddata.ToList();
                    break;
            }
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
            short tmp;
            try
            {
                tmp = short.Parse(MemBlockBox.Text);
                if (tmp > 16 || tmp < 0)
                {
                    MemBlockBox.Text = "between 0-16!";
                    return;
                }

                blockAddr = tmp;
                MemLoad();
            }
            catch (FormatException ex)
            {
                MemBlockBox.Text = "Must be Number!";
            }
                        
        }
        private void runLine(string line)
        {
            pc++;
            ParseLine(line);
            PC.Text = pc.ToString();
        }
        private void runBtn_Click(object sender, EventArgs e)
        {
            while (pc < codeBox.Lines.Length)
            {
                if (codeBox.Lines[pc] != "")
                {
                    if ((codeBox.Lines[pc][0] == '*') && (!isBreakPoint))
                    {
                        isBreakPoint = true;
                        break;
                    }
                    else
                        isBreakPoint = false;
                    runLine(codeBox.Lines[pc]);
                }
            }
             
        }
        private void lineBtn_Click(object sender, EventArgs e)
        {
            if(pc==codeBox.Lines.Length)
            {
                return;
            }
            runLine(codeBox.Lines[pc]);
        }
        public void ParseLine(string line)
        {
            int i;
            string cmd = "", addr = "";
            if (line == null)
                return;
            if (line[0] == '*')
            {
                for (i = 1; (i < line.Length) && (line[i] != ' '); i++)
                    cmd += line[i];
            }
            else
            {
                for (i = 0; (i < line.Length) && (line[i] != ' '); i++)
                    cmd += line[i];
            }          
            for (i++;i<line.Length;i++)
                addr += line[i];
            Execute(cmd, addr);

        }

        

        public void Execute(string cmd,string addr)
        {
            short src=0;
            addr = (addr != "") ? addr : "0";
            if (!char.IsLetter(addr[0]))
            {              
                src = short.Parse(addr);
            }
            else if(Labels.ContainsKey(addr))
            {
                src = Labels[addr];
            }
            else if (D.ContainsKey(addr[0]))
            {
                addr = D[addr[0]].ToString();
                src = short.Parse(addr);
            }
            
            
            short a = short.Parse(regA.Text);
            short t = short.Parse(regT.Text);
            short b = MemRead(src);
            switch (cmd)
            {
                case "JMP":
                case "jmp":
                    pc = src;
                    PC.Text = pc.ToString();
                    break;
                case "ADC":
                case "adc":
                    regA.Text = (a + b).ToString();
                    GenerateCarry(a,b);

                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "XOR":
                case "xor":
                    regA.Text = (a ^ b).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "SBC":
                case "sbc":
                    b = (short)((short) ~b + 1);
                    regA.Text = (a + b).ToString();
                    GenerateCarry(a, b);
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
                    regA.Text = (a | b).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "AND":
                case "and":
                    regA.Text = (a & b).ToString();
                    if (regA.Text == "0") { z = 0; zBox.Text = "1"; }
                    break;
                case "LDC":
                case "ldc":
                    regA.Text = b.ToString();
                    c = 0;
                    cBox.Text = "0";
                    break;
                case "BCC":
                case "bcc":
                    if (c == 0) { pc = b; PC.Text = pc.ToString(); }
                        break;
                case "BNE":
                case "bne":
                    if (z == 1) {pc = b; PC.Text = pc.ToString();
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
                    regA.Text = b.ToString();
                    break;
                case "STA":
                case "sta":
                    MemWrite(src, a);
                    break;
                case ".ORG":
                case ".org":
                    org = src;
                    orgBox.Text = org.ToString();

                    break;
                case ".DATA":
                case ".data":
                    ParseDirective(addr);
                    break;

                default:
                    if (Labels.ContainsKey(cmd))
                        break;
                    Labels.Add(new KeyValuePair<string, short>(cmd, pc));
                    break;
            }
            
        }
        private void GenerateCarry(short a,short b)
        {
            try
            {
                checked
                {
                    var tmp = a + b;
                }
            }
            catch (OverflowException e)
            {
                c = 1;
                cBox.Text = "1";
            }
        }
        private void ParseDirective(string directive)
        {
            string v = "";
           for(int i = 2; i < directive.Length; i++)
            {
                v+= directive[i];
            }
            
           D.Add(new KeyValuePair<char, int>(directive[0], org));         
            if (v != "") 
                MemWrite(org,short.Parse(v));
            org++;
            orgBox.Text = org.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pc = short.Parse(PC.Text);
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    codeBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMemView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public int RotateRight(int value, int count)
        {
            c = value % 2;
            cBox.Text = c.ToString();
            return (value >> count) | (value << (16 - count));
        }

    }
}
