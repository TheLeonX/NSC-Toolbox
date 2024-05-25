using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSC_Toolbox {
    internal class BinaryReader {
        public static byte[] b_ReadByteArray(byte[] actual, int index, int count) {
            List<byte> a = new List<byte>();
            for (int x = 0; x < count; x++) {
                a.Add(actual[index + x]);
            }
            return a.ToArray();
        }
        public static byte[] b_ReadByteArrayOfString(byte[] actual, int index) {
            List<byte> a = new List<byte>();
            int count = 65535;
            for (int x = 0; x < count; x++) {
                if (actual[index + x] != 0)
                    a.Add(actual[index + x]);
                else
                    x = count;
            }
            return a.ToArray();
        }
        public static int b_byteArrayToInt(byte[] actual) {

            return actual[0] + actual[1] * 256 + actual[2] * 65536 + actual[3] * 16777216;
        }
        public static int b_byteArrayToIntTwoBytes(byte[] actual) {
            return actual[0] + actual[1] * 256;
        }
        public static Int16 b_byteArrayToInt16(byte[] actual) {
            return (short)(actual[0] + actual[1] * 256);
        }
        public static UInt16 b_byteArrayToUInt16(byte[] actual) {
            return (ushort)(actual[0] + actual[1] * 256);
        }
        public static int b_byteArrayToIntRevTwoBytes(byte[] actual) {
            return actual[1] + actual[0] * 256;
        }
        public static int b_byteArrayToIntRev(byte[] actual) {
            return actual[3] + actual[2] * 256 + actual[1] * 65536 + actual[0] * 16777216;
        }

        public static int b_ReadInt(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToInt(BinaryReader.b_ReadByteArray(fileBytes, index, 4));
        }
        public static Int16 b_ReadInt16(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToInt16(BinaryReader.b_ReadByteArray(fileBytes, index, 2));
        }
        public static UInt16 b_ReadUInt16(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToUInt16(BinaryReader.b_ReadByteArray(fileBytes, index, 2));
        }
        public static int b_ReadIntFromTwoBytes(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToIntTwoBytes(BinaryReader.b_ReadByteArray(fileBytes, index, 2));
        }
        public static int b_ReadIntRevFromTwoBytes(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToIntRevTwoBytes(BinaryReader.b_ReadByteArray(fileBytes, index, 2));
        }
        public static int b_ReadIntRev(byte[] fileBytes, int index) {
            return BinaryReader.b_byteArrayToIntRev(BinaryReader.b_ReadByteArray(fileBytes, index, 4));
        }

        public static float b_ReadFloat(byte[] actual, int index) {

            return BitConverter.ToSingle(actual, index);
        }
        public static float b_ReadFloatRev(byte[] actual, int index) {

            List<byte> a = new List<byte>();
            for (int x = 0; x < 4; x++) {
                a.Add(actual[index + 3 - x]);
            }
            return BitConverter.ToSingle(a.ToArray(), 0);
        }

        public static string b_ReadString(byte[] actual, int index, int count = -1) {
            string a = "";
            if (count == -1) {
                for (int x2 = index; x2 < actual.Length; x2++) {
                    if (actual[x2] != 0) {
                        string str = a;
                        char c = (char)actual[x2];
                        a = str + c;
                    } else {
                        x2 = actual.Length;
                    }
                }
            } else {
                for (int x = index; x < count; x++) {
                    string str2 = a;
                    char c = (char)actual[x];
                    a = str2 + c;
                }
            }
            return a;
        }

        public static string b_ReadString3(byte[] actual, int index, int count = -1, int skip = 0) {
            string a = "";
            if (count == -1) {
                for (int x2 = index; x2 < actual.Length; x2++) {
                    if (actual[x2] != 0 && actual[x2] != skip) {
                        string str = a;
                        char c = (char)actual[x2];
                        a = str + c;
                    } else {
                        x2 = actual.Length;
                    }
                }
            } else {
                for (int x = index; x < index + count; x++) {
                    string str2 = a;
                    char c = (char)actual[x];
                    a = str2 + c;
                }
            }
            return a;
        }

        public static byte[] b_ReplaceBytes(byte[] actual, byte[] bytesToReplace, int Index, int Invert = 0) {
            if (Invert == 0) {
                for (int x2 = 0; x2 < bytesToReplace.Length; x2++) {
                    actual[Index + x2] = bytesToReplace[x2];
                }
            } else {
                for (int x = 0; x < bytesToReplace.Length; x++) {
                    actual[Index + x] = bytesToReplace[bytesToReplace.Length - 1 - x];
                }
            }
            return actual;
        }

        public static byte[] b_ReplaceString(byte[] actual, string str, int Index, int Count = -1) {
            string new_str = str ?? "";

            if (Count == -1) {
                for (int x2 = 0; x2 < new_str.Length; x2++) {
                    actual[Index + x2] = (byte)new_str[x2];
                }
            } else {
                for (int x = 0; x < Count; x++) {
                    if (new_str is not null) {
                        if (new_str.Length > x) {
                            actual[Index + x] = (byte)new_str[x];
                        } else {
                            actual[Index + x] = 0;
                        }
                    }
                    
                }
            }
            return actual;
        }
        public static string b_ReplaceRealString(string actual, string str, int Index, int Count = -1) {
            string new_str = str ?? "";
            char[] test = actual.ToCharArray();
            string output = "";
            if (Count == -1) {
                for (int x2 = 0; x2 < new_str.Length; x2++) {

                    test[Index + x2] = new_str[x2];
                }
            } else {
                for (int x = 0; x < Count; x++) {
                    if (new_str.Length > x) {
                        test[Index + x] = new_str[x];
                    } else {
                        test[Index + x] = '\0';
                    }
                }
            }
            for (int i = 0; i < test.Length; i++) {
                output = output + test[i];
            }
            return output;
        }

        public static byte[] b_AddBytes(byte[] actual, byte[] bytesToAdd, int Reverse = 0, int index = 0, int count = -1) {
            List<byte> a = actual.ToList();
            if (Reverse == 0) {
                if (count == -1)
                    count = bytesToAdd.Length;
                for (int x = index; x < count; x++) {
                    a.Add(bytesToAdd[x]);
                }
            } else {
                if (count == -1) 
                    count = bytesToAdd.Length;
                for (int x = index; x < count; x++) {
                    a.Add(bytesToAdd[bytesToAdd.Length - 1 - x]);
                }
            }
            return a.ToArray();
        }

        public static byte[] b_AddInt(byte[] actual, int _num) {
            List<byte> a = actual.ToList();
            byte[] b = BitConverter.GetBytes(_num);
            for (int x = 0; x < 4; x++) {
                a.Add(b[x]);
            }
            return a.ToArray();
        }

        public static byte[] b_StringToBytes(string hexstr) {
            int length = hexstr.Length;
            string NewCode = "";
            for (int i = 0; i < length; i++) {
                if (hexstr[i] != (char)32) {
                    NewCode = NewCode + hexstr[i];
                }
            }
            if (string.IsNullOrWhiteSpace(NewCode))
                throw new ArgumentNullException("Wrong Format");

            if ((NewCode.Length % 2) != 0)
                throw new ArgumentException("Wrong Format");

            var arr = new byte[NewCode.Length / 2];

            for (int i = 0, j = 0; j < NewCode.Length; i++, j += 2) {
                var bstr = NewCode.Substring(j, 2);
                arr[i] = byte.Parse(bstr, NumberStyles.AllowHexSpecifier);
            }

            return arr;
        }

        public static byte[] b_AddString(byte[] actual, string _str, int count = -1) {
            List<byte> a = actual.ToList();
            if (_str is not null) {
                for (int x2 = 0; x2 < _str.Length; x2++) {
                    a.Add((byte)_str[x2]);
                }
                for (int x = _str.Length; x < count; x++) {
                    a.Add(0);
                }
            }
            return a.ToArray();
        }

        public static byte[] b_AddFloat(byte[] actual, float f) {
            List<byte> a = actual.ToList();
            byte[] floatBytes = BitConverter.GetBytes(f);
            for (int x = 0; x < 4; x++) {
                a.Add(floatBytes[x]);
            }
            return a.ToArray();
        }

        public static int b_FindBytes(byte[] actual, byte[] bytes, int index = 0) {
            int actualIndex = index;
            byte[] actualBytes = new byte[bytes.Length];
            bool f = false;

            int foundIndex = -1;

            for (int a = actualIndex; a < (actual.Length - bytes.Length); a++) {
                f = true;

                for (int x = 0; x < bytes.Length; x++) {
                    actualBytes[x] = actual[a + x];

                    if (actualBytes[x] != bytes[x]) {
                        x = bytes.Length;
                        f = false;
                    }
                }

                if (f) {
                    foundIndex = a;
                    a = actual.Length;
                }
            }

            return foundIndex;
        }
        public static bool b_FindBytesBool(byte[] actual, byte[] bytes, int index = 0) {
            int actualIndex = index;
            byte[] actualBytes = new byte[bytes.Length];
            bool found = false;
            bool f = false;

            int foundIndex = -1;

            for (int a = actualIndex; a < (actual.Length - bytes.Length); a++) {
                f = true;

                for (int x = 0; x < bytes.Length; x++) {
                    actualBytes[x] = actual[a + x];

                    if (actualBytes[x] != bytes[x]) {
                        x = bytes.Length;
                        f = false;
                    }
                }

                if (f) {
                    found = true;
                    foundIndex = a;
                    a = actual.Length;
                }
            }

            return found;
        }
        public static int b_FindString(string actual, string str, int index = 0) {
            int foundIndex = -1;
            if (str != null) {
                int actualIndex = index;
                char[] actualString = new char[str.Length];
                bool f = false;

                
                for (int a = actualIndex; a < (actual.Length - str.Length); a++) {
                    f = true;

                    for (int x = 0; x < str.Length; x++) {
                        actualString[x] = actual[a + x];

                        if (actualString[x] != str[x]) {
                            x = str.Length;
                            f = false;
                        }
                    }

                    if (f) {
                        foundIndex = a;
                        a = actual.Length;
                    }
                }
            }

            return foundIndex;
        }
        public static List<int> b_FindBytesList(byte[] actual, byte[] bytes, int index = 0) {
            int actualIndex = index;
            List<int> indexes = new List<int>();

            int lastFound = 0;
            while (lastFound != -1) {
                lastFound = b_FindBytes(actual, bytes, actualIndex);
                if (lastFound != -1) {
                    actualIndex = lastFound + 1;
                    indexes.Add(lastFound);
                }
            }

            return indexes;
        }

        public static List<long> crc32_table() {
            var a = new List<long>();
            foreach (var i in Enumerable.Range(0, 256)) {
                var k = i << 24;
                foreach (var _ in Enumerable.Range(0, 8)) {
                    if (Convert.ToBoolean(k & 0x80000000))
                        k = k << 1 ^ 0x4c11db7;
                    else
                        k = k << 1;
                }
                a.Add(k & 0xffffffff);
            }
            return a;
        }

        public static byte[] crc32(string str) {
            if (str != null) {
                byte[] bytestream = Encoding.ASCII.GetBytes(str);
                var crc_table = crc32_table();
                var crc = 0xffffffff;
                foreach (var bytes in bytestream) {
                    var lookup_index = (crc >> 24 ^ bytes) & 0xff;
                    crc = (uint)((crc & 0xffffff) << 8 ^ crc_table[(int)lookup_index]);
                }
                crc = ~crc & 0xffffffff;
                return BitConverter.GetBytes(crc);
            } else {
                return new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF };
            }
           
        }
    }
}
