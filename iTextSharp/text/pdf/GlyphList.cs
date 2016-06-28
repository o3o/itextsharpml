using System;
using System.Collections;
using System.IO;
using System.Globalization;
using System.util;

namespace iTextSharp.text.pdf {
    public class GlyphList {
        private static Hashtable unicode2names = new Hashtable();
        private static Hashtable names2unicode = new Hashtable();

        static GlyphList() {
            Stream istr = null;
            try {
                istr = BaseFont.GetResourceStream("glyphlist.txt");
                if (istr == null) {
                   string msg = string.Format("glyphlist.txt not found as resource. (path: {0})", BaseFont.RESOURCE_PATH);
                   throw new Exception(msg);
                }
                byte[] buf = new byte[1024];
                MemoryStream outp = new MemoryStream();
                while (true) {
                    int size = istr.Read(buf, 0, buf.Length);
                    if (size == 0)
                        break;
                    outp.Write(buf, 0, size);
                }
                istr.Close();
                istr = null;
                String s = PdfEncodings.ConvertToString(outp.ToArray(), null);
                StringTokenizer tk = new StringTokenizer(s, "\r\n");
                while (tk.HasMoreTokens()) {
                    String line = tk.NextToken();
                    if (line.StartsWith("#"))
                        continue;
                    StringTokenizer t2 = new StringTokenizer(line, " ;\r\n\t\f");
                    String name = null;
                    String hex = null;
                    if (!t2.HasMoreTokens())
                        continue;
                    name = t2.NextToken();
                    if (!t2.HasMoreTokens())
                        continue;
                    hex = t2.NextToken();
                    int num = int.Parse(hex, NumberStyles.HexNumber);
                    unicode2names[num] = name;
                    names2unicode[name] = new int[]{num};
                }
            }
            catch (Exception e) {
                Console.Error.WriteLine("glyphlist.txt loading error: " + e.Message);
            }
            finally {
                if (istr != null) {
                    try {
                        istr.Close();
                    }
                    catch {
                        // empty on purpose
                    }
                }
            }
        }

        public static int[] NameToUnicode(string name) {
            return (int[])names2unicode[name];
        }

        public static string UnicodeToName(int num) {
            return (string)unicode2names[num];
        }
    }
}
