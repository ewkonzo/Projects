using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Hexabinary
    {
        public char Hexadecimal;
        public string Binary;
              
        public static List<Hexabinary> GetHexabinary()
        {
            List<Hexabinary> hbs = new List<Hexabinary>();
            Hexabinary hb = new Hexabinary();
            hb.Hexadecimal = '0';
            hb.Binary = "0000";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '1'; 
            hb.Binary = "0001";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '2'; 
            hb.Binary = "0010";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '3'; 
            hb.Binary = "0011";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '4'; 
            hb.Binary = "0100";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '5'; 
            hb.Binary = "0101";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '6'; 
            hb.Binary = "0110";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '7'; 
            hb.Binary = "0111";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '8'; 
            hb.Binary = "1000";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = '9'; 
            hb.Binary = "1001";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'A'; 
            hb.Binary = "1010";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'B'; 
            hb.Binary = "1011";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'C'; 
            hb.Binary = "1100";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'D'; 
            hb.Binary = "1101";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'E'; 
            hb.Binary = "1110";
            hbs.Add(hb);
            hb = new Hexabinary();
            hb.Hexadecimal = 'F'; 
            hb.Binary = "1111";
            hbs.Add(hb);
            return hbs;
        }

        public static string binary(string bitmap)
        {
            string temp = string.Empty ; 
            var h = Hexabinary.GetHexabinary();
            var len = bitmap.ToCharArray();
            foreach (var l in len)
            {
                var hh = h.FirstOrDefault(o => o.Hexadecimal == l);
                if (hh != null)
                    temp += hh.Binary;
            }
            return temp;
        }
        public static string hexadecimal(string bitmap)
        {

            
            string temp = string.Empty;
            var h = Hexabinary.GetHexabinary();
            var len = choppedtext( bitmap,4);
            foreach (var l in len)
            {
                var hh = h.FirstOrDefault(o => o.Binary == l);
                if (hh != null)
                    temp += hh.Hexadecimal;
            }
            return temp;
        }
        public static IEnumerable<string> choppedtext(string str, int chunkSize)
        {
            for (int i = 0; i < str.Length; i += chunkSize)
                yield return str.Substring(i, Math.Min(chunkSize, str.Length - i));
            //    return Enumerable.Range(0, str.Length / chunkSize)
            //   .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
    class IsoElements
    {
        public int Data_Element;
        public string Type;
        public string Usage;
        public int Length;
        public Boolean Variable_Field;
        public int Variable_Field_Length;
        public bool binary=false;

        public IsoElements(int ele, string type, string usage, int len, bool variable, int variable_length,bool Binary =false) {
            Data_Element = ele;
            Type = type;
            Usage = usage;
            Length = len;
            Variable_Field = variable;
            Variable_Field_Length = variable_length;
            binary = Binary;
        }
        public IsoElements() { }
        public static List<IsoElements> getisoelement()
        {
            List<IsoElements> isos = new List<IsoElements>() { };
            IsoElements iso = new IsoElements();
            isos.Add(new IsoElements(1, "b 64", "Bit Map Extended", 32, false, 0));
            isos.Add(new IsoElements(2, "n ..19", "Primary account number (PAN)", 18, true, 2));
            isos.Add(new IsoElements(3, "n 6", "Processing code", 6, false, 0));
            isos.Add(new IsoElements(4, "n 12", "Amount, transaction", 12, false, 0));
            isos.Add(new IsoElements(5, "n 12", "Amount, Settlement", 12, false, 0));
            isos.Add(new IsoElements(6, "n 12", "Amount, cardholder billing", 12, false, 0));
            isos.Add(new IsoElements(7, "n 10", "Transmission date & time", 10, false, 0));
            isos.Add(new IsoElements(8, "n 8", "Amount, Cardholder billing fee", 8, false, 0));
            isos.Add(new IsoElements(9, "n 8", "Conversion rate, Settlement", 8, false, 0));
            isos.Add(new IsoElements(10, "n 8", "Conversion rate, cardholder billing", 8, false, 0));
            isos.Add(new IsoElements(11, "n 6", "Systems trace audit number", 6, false, 0));
            isos.Add(new IsoElements(12, "n 12", "Time, Local transaction (hhmmss)", 12, false, 0));
            isos.Add(new IsoElements(13, "n 4", "Date, Local transaction (MMDD)", 4, false, 0));
            isos.Add(new IsoElements(14, "n 4", "Date, Expiration", 4, false, 0));
            isos.Add(new IsoElements(15, "n 4", "Date, Settlement", 4, false, 0));
            isos.Add(new IsoElements(16, "n 4", "Date, conversion", 4, false, 0));
            isos.Add(new IsoElements(17, "n 4", "Date, capture", 4, false, 0));
            isos.Add(new IsoElements(18, "n 4", "Merchant type", 4, false, 0));
            isos.Add(new IsoElements(19, "n 3", "Acquiring institution country code", 3, false, 0));
            isos.Add(new IsoElements(20, "n 3", "PAN Extended, country code", 3, false, 0));
            isos.Add(new IsoElements(21, "n 3", "Forwarding institution. country code", 3, false, 0));
            isos.Add(new IsoElements(22, "n 3", "Point of service entry mode", 12, false, 0));
            isos.Add(new IsoElements(23, "n 3", "Application PAN number", 3, false, 0));
            isos.Add(new IsoElements(24, "n 3", "Function code(ISO 8583:1993)/Network International identifier (NII)", 3, false, 0));
            isos.Add(new IsoElements(25, "n 2", "Point of service condition code", 4, false, 0));
            isos.Add(new IsoElements(26, "n 2", "Point of service capture code", 4, false, 0));
            isos.Add(new IsoElements(27, "n 1", "Authorizing identification response length", 1, false, 0));
            isos.Add(new IsoElements(28, "n 6", "Amount, transaction fee", 6, false, 0));
            isos.Add(new IsoElements(29, "n 3", "Amount. settlement fee", 3, false, 0));
            isos.Add(new IsoElements(30, "n 8", "Amount, transaction processing fee", 8, false, 0));
            isos.Add(new IsoElements(31, "n ..8", "Amount, settlement processing fee", 8, true, 2));
            isos.Add(new IsoElements(32, "n ..11", "Acquiring institution identification code (ATM)", 8, true, 2));
            isos.Add(new IsoElements(33, "n ..11", "Forwarding institution identification code", 6, true, 2));
            isos.Add(new IsoElements(34, "n ..28", "Primary account number, extended", 28, true, 2));
            isos.Add(new IsoElements(35, "z ..37", "Track 2 data", 37, true, 2));
            isos.Add(new IsoElements(36, "n ...104", "Track 3 data", 104, true, 3));
            isos.Add(new IsoElements(37, "an 12", "Retrieval reference number", 12, false, 0));
            isos.Add(new IsoElements(38, "an 6", "Authorization identification response", 6, false, 0));
            isos.Add(new IsoElements(39, "an 2", "Response code", 3, false, 0));
            isos.Add(new IsoElements(40, "an 3", "Service restriction code", 3, false, 0));
            isos.Add(new IsoElements(41, "ans 8", "Card acceptor terminal identification", 8, false, 0));
            isos.Add(new IsoElements(42, "ans 15", "Card acceptor identification code", 15, false, 0));
            isos.Add(new IsoElements(43, "ans ..40", "Card acceptor name/location", 40, true, 2));
            isos.Add(new IsoElements(44, "an ..25", "Additional response data", 99, true, 2));
            isos.Add(new IsoElements(45, "an ..76", "Track 1 Data", 76, true, 2));
            isos.Add(new IsoElements(46, "an ...999", "Additional data - ISO", 204, true, 3));
            isos.Add(new IsoElements(47, "an ...999", "Additional data - National", 999, true, 3));
            isos.Add(new IsoElements(48, "an ...999", "Additional data - Private", 9, true, 3));
            isos.Add(new IsoElements(49, "a 3", "Currency code, transaction", 3, false, 0));
            isos.Add(new IsoElements(50, "an 3", "Currency code, settlement", 3, false, 0));
            isos.Add(new IsoElements(51, "a 3", "Currency code, cardholder billing", 3, false, 0));
            isos.Add(new IsoElements(52, "b 16", "Personal Identification number data", 16, false, 0));
            isos.Add(new IsoElements(53, "n 18", "Security related control information", 18, false, 0));
            isos.Add(new IsoElements(54, "an ...120", "Additional amounts eg cleared,available and credit balances", 60, true, 3));
            isos.Add(new IsoElements(55, "ans ...999", "Reserved ISO", 255, true, 3));
            isos.Add(new IsoElements(56, "ans ..99", "Reserved ISO", 35, true, 2));
            isos.Add(new IsoElements(57, "ans ...999", "Reserved National", 999, true, 3));
            isos.Add(new IsoElements(58, "ans ...999", "Reserved National", 999, true, 3));
            isos.Add(new IsoElements(59, "ans ...999", "Reserved for national use", 999, true, 3));
            isos.Add(new IsoElements(60, "an .7", "Advice/reason code (private reserved)", 7, true, 1));
            isos.Add(new IsoElements(61, "ans ...999", "Reserved Private", 999, true, 3));
            isos.Add(new IsoElements(64, "b 16", "Message authentication code (MAC)", 16, false, 0));
            isos.Add(new IsoElements(65, "b 64", "Bit map, tertiary", 64, false, 0));
            isos.Add(new IsoElements(66, "n 1", "Settlement code", 1, false, 0));
            isos.Add(new IsoElements(67, "n 2", "Extended payment code", 2, false, 0));
            isos.Add(new IsoElements(68, "n 3", "Receiving institution country code", 3, false, 0));
            isos.Add(new IsoElements(69, "n 3", "Settlement institution county code", 3, false, 0));
            isos.Add(new IsoElements(70, "n 3", "Network management Information code", 3, false, 0));
            isos.Add(new IsoElements(71, "n 4", "Message number", 4, false, 0));
            isos.Add(new IsoElements(72, "ans ...999", "Data record (ISO 8583:1993)/n 4 Message number, last(?)", 99999, true, 3));
            isos.Add(new IsoElements(73, "n 6", "Date, Action", 6, false, 0));
            isos.Add(new IsoElements(74, "n 10", "Credits, number", 10, false, 0));
            isos.Add(new IsoElements(75, "n 10", "Credits, reversal number", 10, false, 0));
            isos.Add(new IsoElements(76, "n 10", "Debits, number", 10, false, 0));
            isos.Add(new IsoElements(77, "n 10", "Debits, reversal number", 10, false, 0));
            isos.Add(new IsoElements(78, "n 10", "Transfer number", 10, false, 0));
            isos.Add(new IsoElements(79, "n 10", "Transfer, reversal number", 10, false, 0));
            isos.Add(new IsoElements(80, "n 10", "Inquiries number", 10, false, 0));
            isos.Add(new IsoElements(81, "n 10", "Authorizations, number", 10, false, 0));
            isos.Add(new IsoElements(82, "n 12", "Credits, processing fee amount", 12, false, 0));
            isos.Add(new IsoElements(83, "n 12", "Credits, transaction fee amount", 12, false, 0));
            isos.Add(new IsoElements(84, "n 12", "Debits, processing fee amount", 12, false, 0));
            isos.Add(new IsoElements(85, "n 12", "Debits, transaction fee amount", 12, false, 0));
            isos.Add(new IsoElements(86, "n 15", "Credits, amount", 15, false, 0));
            isos.Add(new IsoElements(87, "n 15", "Credits, reversal amount", 15, false, 0));
            isos.Add(new IsoElements(88, "n 15", "Debits, amount", 15, false, 0));
            isos.Add(new IsoElements(89, "n 15", "Debits, reversal amount", 15, false, 0));
            isos.Add(new IsoElements(90, "n 42", "Original data elements", 42, false, 0));
            isos.Add(new IsoElements(91, "an 1", "File update code", 1, false, 0));
            isos.Add(new IsoElements(92, "n 2", "File security code", 2, false, 0));
            isos.Add(new IsoElements(93, "n 5", "Response indicator", 5, true, 2));
            isos.Add(new IsoElements(94, "an 7", "Service indicator", 10, true, 2));
            isos.Add(new IsoElements(95, "an 42", "Replacement amounts", 99, true, 2));
            isos.Add(new IsoElements(96, "an 8", "Message security code", 8, false, 0));
            isos.Add(new IsoElements(97, "n 16", "Amount, net settlement", 16, false, 0));
            isos.Add(new IsoElements(98, "ans 25", "Payee", 25, false, 0));
            isos.Add(new IsoElements(99, "n ..11", "Settlement institution identification code", 11, true, 2));
            isos.Add(new IsoElements(100, "n ..11", "Receiving institution identification code", 5, true, 2));
            isos.Add(new IsoElements(101, "ans 17", "File name", 17, false, 0));
            isos.Add(new IsoElements(102, "ans ..28", "Account identification 1", 28, true, 2));
            isos.Add(new IsoElements(103, "ans ..28", "Account identification 2", 28, true, 2));
            isos.Add(new IsoElements(104, "ans ...100", "Transaction description", 100, true, 3));
            isos.Add(new IsoElements(105, "ans ...999", "Reserved for ISO use", 999, true, 3));
            isos.Add(new IsoElements(113, "n ..11", "Authorizing agent institution id code", 11, true, 2));
            isos.Add(new IsoElements(120, "ans ...999", "Reserved for private use", 999, true, 3));
            isos.Add(new IsoElements(124, "ans ...255", "Info Text eg mini statement info", 255, true, 3));
            isos.Add(new IsoElements(125, "ans ..50", "Network management information", 50, true, 2));
            isos.Add(new IsoElements(126, "ans .6", "Issuer trace id", 6, true, 1));
            isos.Add(new IsoElements(128, "b 16", "Message Authentication code", 16, false, 0));
            return isos;
        }
    }


}
