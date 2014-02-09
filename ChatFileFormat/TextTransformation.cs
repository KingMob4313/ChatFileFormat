using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    class TextTranformation
    {
        //TODO: This needs to be moved to a strategy pattern, or at the very least a case statement
        //Also, this needs to be checking for 'start of line' using regex
        public static string PersonReplace(string output)
        {
            string x;
            if (output != string.Empty)
            {
                
                if (!string.IsNullOrEmpty(TempStorage.enteredNameOne))
                {
                    
                    if (TempStorage.storyTellerCheckOne == false)
                    {
                        x = ("^" + TempStorage.enteredNameOne);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameOne.ToString() + ":  ##110481| "));
                        output = xyz;
                    }
                    else
                    {
                        x = ("^" + TempStorage.enteredNameOne);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameOne.ToString() + ":  ##110481| "));
                        output = xyz;
                    }
                }

                if (!string.IsNullOrEmpty(TempStorage.enteredNameTwo))
                {
                    if (TempStorage.storyTellerCheckTwo == false)
                    {
                        x = ("^" + TempStorage.enteredNameTwo);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameTwo.ToString() + ":  ##666666| "));
                        output = xyz;
                    }
                    else
                    {
                        x = ("^" + TempStorage.enteredNameTwo);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameTwo.ToString() + ":  ##666666| "));
                        output = xyz;
                    }
                }



                if (!string.IsNullOrEmpty(TempStorage.enteredNameThree))
                {
                    if (TempStorage.storyTellerCheckThree == false)
                    {
                        x = ("^" + TempStorage.enteredNameThree);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameThree.ToString() + ":  ##800000| "));
                        output = xyz;
                    }
                    else
                    {
                        x = ("^" + TempStorage.enteredNameThree);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameThree.ToString() + ":  ##800000| "));
                        output = xyz;
                    }
                }

                if (!string.IsNullOrEmpty(TempStorage.enteredNameFour))
                {
                    if (TempStorage.storyTellerCheckFour == false)
                    {
                        x = ("^" + TempStorage.enteredNameFour);
                        string xyz = RegexStuffer(x, output, (TempStorage.enteredNameFour.ToString() + ":  ##208020| "));
                        output = xyz;
                    }
                    else
                    {
                        output = output;
                        //tempString = tempString.Replace(TempStorage.enteredNameFour, "Nivose:  ##666666| ");
                    }
                }
                
            }
            return output;
        }

        private static string RegexStuffer(string zzz, string aaa, string bbb)
        {
            Regex y = new Regex(zzz);
            aaa = y.Replace(aaa, bbb);
            return aaa;
        }
    }
}
