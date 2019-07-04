using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_TimeChecking
{
    public class TimeCheckingClass
    {

        /// <summary>
        /// This Method will check if the actual time is between a defined Time Span.
        /// If no information is provided for the spans, it will take the whole day as the desired timespan.
        /// In case of an error it will return the error message.
        /// The method works on a 24 h format hour.
        /// </summary>
        /// <param name="lowerLimitSpan"></param>
        /// <param name="upperLimitSpan"></param>
        /// <returns>A string with the message if its within or out the TimeSpan</returns>
        public string checkTimeSpan(string lowerLimit, string upperLimit)
        {

            DateTime upperLimitSpan;

            DateTime lowerLimitSpan;

            if (lowerLimit is null||lowerLimit=="")
                lowerLimitSpan=DateTime.Parse("0:00");

            else
            {
                try
                {

                    lowerLimitSpan=DateTime.Parse(lowerLimit);
                }
                catch (Exception e)
                {
                    return "El parámetro lowerLimitSpan no pudo ser convertido, por favor checa su formato";
                }

            }

            if (upperLimit is null||upperLimit=="")
                upperLimitSpan=DateTime.Parse("23:59");
            else
            {
                try
                {

                    upperLimitSpan=DateTime.Parse(upperLimit);
                }
                catch (Exception e)
                {
                    return "El parámetro upperLimitSpan no pudo ser convertido, por favor checa su formato";
                }
            }

            DateTime target = DateTime.Now;



            while (lowerLimitSpan.ToShortTimeString()!=upperLimitSpan.ToShortTimeString())
            {
                if (lowerLimitSpan.ToShortTimeString()==target.ToShortTimeString())
                {
                    return "The Target is within the TimeSpan";

                }

                lowerLimitSpan=lowerLimitSpan.AddMinutes(1);
            }

            return "The target is out of the TimeSpan";



        }

    }
}
