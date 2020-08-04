using System;
using System.Linq;

class RecordIdentity
{
    public char[] code;
    private char[] allowed = { 'S', 'E', 'N','O','I','T','R','L','B','A','P','Q','G','J','W','V','H','X','Y' };
    public RecordIdentity(char[] code)
    {
        if (validCode(code))
        {
            this.code = code;
        } else
        {
            throw new Exception("Invalid Record Code");
        }
    }

    private bool validCode(char[] code)
    {
        bool valid = true;
        if (code[0] != 'Q') valid = false;
        if (!allowed.Contains(code[1])) valid = false;
        return valid;
    }
}
