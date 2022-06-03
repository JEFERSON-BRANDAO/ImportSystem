using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class Criptografia
    {
        public int Asc(string letra)
        {
            return (int)(Convert.ToChar(letra));
        }
        //
        public char Chr(int codigo)
        {
            return (char)codigo;
        }

        public string Criptografar(string pStr)
        {
            #region CRIPTOGRAFA

            int j = pStr.Length;
            string lStr = string.Empty;
            char lChar;
            int lAsc;
            //
            for (int i = 0; i < j; i++)
            {
                lAsc = Convert.ToInt32(Asc(pStr.Substring(i, 1)));

                if (lAsc > 32 && lAsc <= 100)
                {
                    lAsc = lAsc + 22;
                }
                else if (lAsc > 100 && lAsc <= 122)
                {
                    lAsc = lAsc - 100 + 32;
                }
                //
                lChar = Chr(lAsc);
                lStr = lStr + lChar;
            }
            //
            return lStr;

            #endregion
        }

        public string Descriptografar(string pStr)
        {
            #region DESCRIPTOGRAFA

            int j = pStr.Length;
            string lStr = string.Empty;
            char lChar;
            int lAsc;
            //
            for (int i = 0; i < j; i++)
            {
                lAsc = Convert.ToInt32(Asc(pStr.Substring(i, 1)));

                if (lAsc > 54 && lAsc <= 122)
                {
                    lAsc = lAsc - 22;
                }
                else if (lAsc > 32 && lAsc <= 54)
                {
                    lAsc = 100 + lAsc - 32;//lAsc - 100 - 32;
                }
                //
                lChar = Chr(lAsc);
                lStr = lStr + lChar;
            }
            //
            return lStr;

            #endregion
        }
    }
}
