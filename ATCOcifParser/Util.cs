
namespace ATCOcif
{
    static class Util
    {
        public static string charArrSubs(char[] chars, int begin, int length, bool trim = true)
        {
            int end = (begin + length < chars.Length) ? length : chars.Length - begin;
            string result = "";
            for(int i=0; i < end; i++)
            {
                if (chars[begin + i] == ' ' && trim) break;
                result += chars[begin + i];
            }
            return result;
        }
    }
}
