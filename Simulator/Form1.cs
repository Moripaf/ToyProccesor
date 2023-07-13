using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace ToySimulator
{
    public partial class MainForm : Form
    {
        int c = 0, z = 0, pc;
        readonly FileStream fs;
        FileInfo file;
        public MainForm()
        {
            InitializeComponent();
            try
            {
                file = new FileInfo(@"memory.txt");            
            }
            catch (FileNotFoundException)
            {
                File.WriteAllBytes(@"memory.txt",new byte[8192]);
                file = new FileInfo(@"memory.txt");
            }

            fs = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);

        }
        public int MemRead(int addr)
        {
            int actualRead=0;
            byte[] buffer = new byte[2];
            fs.Position = addr*2;
            do
            {
                actualRead += fs.Read(buffer, actualRead, 2 - actualRead);
            } while (actualRead != 2 && fs.Position < fs.Length);

            return BitConverter.ToInt16(buffer, 0);
        }
        public void MemWrite(int addr,int data)
        {
            byte[] buffer = BitConverter.GetBytes(data);
            fs.Position = addr * 2;
            fs.Write(buffer, 0, 2);  
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
        public void Execute(string cmd,string addr)
        {
            int src = int.Parse(addr);
            int a = int.Parse(regA.Text);
            int t = int.Parse(regT.Text);
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
