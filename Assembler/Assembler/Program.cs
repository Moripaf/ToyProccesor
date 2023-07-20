using System;
using System.Reflection.Emit;
using System.IO;
namespace Assembler
{
    class  Assembler
    {

        static IDictionary<char, int> D = new Dictionary<char, int>();
        static IDictionary<string, short> Labels = new Dictionary<string, short>();
        static short org,pc=0;
        [STAThread]
        static void Main()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            OFD.Title = "Open Toy Assembly File";
            OFD.Filter = "txt files (*.txt)|*.txt";
            OFD.ShowDialog();
            string filename = OFD.FileName;
            var lines = File.ReadAllLines(filename);
            using StreamWriter writer = new StreamWriter(filename + ".out.txt");
            foreach (var line in lines)
                writer.WriteLine(ParseLine(line));

        }
    
        static string ParseLine(string line)
        {
            int i;
            string cmd = "", addr = "";
            if (line == null)
                return "\n";
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
            for (i++; i < line.Length; i++)
                addr += line[i];
            return Assemble(cmd, addr);

        }



        static string Assemble(string cmd, string addr)
        {
            short src = 0;
            string output="";
            if(addr == "")
            {
                src = 0;
            }
            else if (!char.IsLetter(addr[0]))
            {
                src = (addr != "") ? short.Parse(addr) : (short)-1;
            }
            else if (Labels.ContainsKey(addr))
            {
                src = Labels[addr];
            }
            else if (D.ContainsKey(addr[0]))
            {
                addr = D[addr[0]].ToString();
                src = short.Parse(addr);
            }

            switch (cmd)
            {
                case "JMP":
                case "jmp":
                    output = "0000" + To12BitBinary(src);
                    break;
                case "ADC":
                case "adc":
                    output = "0001" + To12BitBinary(src);
                    break;
                case "XOR":
                case "xor":
                    output = "0010" + To12BitBinary(src);
                    break;
                case "SBC":
                case "sbc":
                    output = "0011" + To12BitBinary(src);
                    break;
                case "ROR":
                case "ror":
                    output = "0100";
                    break;
                case "TAT":
                case "tat":
                    output = "0101";
                    break;
                case "OR":
                case "or":
                    output = "0110" + To12BitBinary(src);
                    break;
                case "AND":
                case "and":
                    output = "1000" + To12BitBinary(src);                  
                    break;
                case "LDC":
                case "ldc":
                    output = "1001" + To12BitBinary(src);
                    break;
                case "BCC":
                case "bcc":
                    output = "1010" + To12BitBinary(src);
                    break;
                case "BNE":
                case "bne":
                    output = "1011" + To12BitBinary(src);
                    break;
                case "LDI":
                case "ldi":
                    output = "1100";
                    break;
                case "STT":
                case "stt":
                    output = "1101";
                    break;
                case "LDA":
                case "lda":
                    output = "1110" + To12BitBinary(src);
                    break;
                case "STA":
                case "sta":
                    output = "1111" + To12BitBinary(src) ;
                    break;
                case ".ORG":
                case ".org":
                    org = src;
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
            pc++;
            return output;

        }
        static void ParseDirective(string directive)
        {
            if (!D.ContainsKey(directive[0]))
                {
                 D.Add(new KeyValuePair<char, int>(directive[0], org));
                 org++;
               }
        }
        public static string To12BitBinary(int number)
        {
            string binary = Convert.ToString(number, 2);

            binary = binary.PadLeft(12, '0');

            return binary;
        }
    }
}