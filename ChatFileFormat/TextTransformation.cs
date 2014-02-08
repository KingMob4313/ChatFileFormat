using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    class TextTranformation
    {
        public static string PersonReplace(string output)
        {
            
            
            if (output != string.Empty)
            {
                if (!(TempStorage.enteredNameOne == string.Empty || TempStorage.enteredNameOne == null))
                {
                    if (TempStorage.storyTellerCheckOne == false)
                    {
                        output = output.Replace(("^" + TempStorage.enteredNameOne), TempStorage.enteredNameOne.ToString() + ":  ##110481| ");
                    }
                    else
                    {
                        output = output.Replace(("^" + TempStorage.enteredNameOne), TempStorage.enteredNameOne.ToString() + ":  ##110481| ");
                    }
                }

                if (!(TempStorage.enteredNameTwo == string.Empty || TempStorage.enteredNameTwo == null))
                {
                    if (TempStorage.storyTellerCheckTwo == false)
                    {
                        output = output.Replace("^" + TempStorage.enteredNameTwo, TempStorage.enteredNameTwo.ToString() + ":  ##666666| ");
                    }
                    else
                    {
                        output = output.Replace("^" + TempStorage.enteredNameTwo.ToString(), TempStorage.enteredNameTwo.ToString() + ":  ##666666| ");
                    }
                }

                if (!(TempStorage.enteredNameThree == string.Empty || TempStorage.enteredNameThree == null))
                {
                    if (TempStorage.storyTellerCheckThree == false)
                    {
                        output = output.Replace("^" + TempStorage.enteredNameThree.ToString(), TempStorage.enteredNameThree.ToString() + ":  ##800000| ");
                    }
                    else
                    {
                        output = output.Replace("^" + TempStorage.enteredNameThree, TempStorage.enteredNameThree.ToString() + ":  ##800000| ");
                    }
                }

                if (!(TempStorage.enteredNameFour == string.Empty || TempStorage.enteredNameFour == null))
                {
                    if (TempStorage.storyTellerCheckFour == false)
                    {
                        output = output.Replace((("^" + TempStorage.enteredNameFour)), TempStorage.enteredNameFour.ToString() + ":  ##208020| ");
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
    }
}
