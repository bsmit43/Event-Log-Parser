using System.Text.RegularExpressions;

namespace WpfApplication1
{
    public class universal
    { 
        public bool search(string searchString1, string log1)
        {
            //My unversal regex class built so I can have a central location to edit.
            //Checks if the searchstring matches the log 
            Regex search1 = new Regex(searchString1, RegexOptions.IgnoreCase);
            Match found = search1.Match(log1);
            if (found.Success)
            {
                return true;
            }
            return false;
        }

        public string section()
        {
            //Match a section of the log that correlates with one log Item
            string match = @"Audit \b[a-zA-Z]{7}\b(.+?Audit \b[a-zA-Z]{7}\b)";
            return match;
        }

        public string Audit(string log1)
        {
            //Get the success or failure log within matched section above
            Regex Audit1 = new Regex(@"Audit Failure|Audit Success", RegexOptions.Singleline);
            Match sucfail = Audit1.Match(log1);
            string sucfailvalue = sucfail.Value;
            return sucfailvalue;
        }

        public string secid(string log1)
        {
            //Get the security ID within matched section above
            Regex secid1 = new Regex(@"(?<=Security ID:)(.*?)([^\s]+)", RegexOptions.Singleline);
            Match sec = secid1.Match(log1);
            string secvalue = sec.Value;
            return secvalue;
        }
            
        public string source(string log1)
        {
            //Get the log source information from the matched section above
            Regex source1 = new Regex(@"(?<=\d{1,2}:\d{1,2}:\d{1,2} [a-zA-Z]{2}\t)[^\r\n]+(?=\t\d{4})", RegexOptions.Singleline);
            Match src = source1.Match(log1);
            string srcvalue = src.Value;
            return srcvalue;
        }
            
        public string accname(string log1)
        {
            //Get the account name within matched section above
            Regex accname1 = new Regex(@"(?<=Account Name:)(.*?)([^\s]+)", RegexOptions.Singleline);
            Match acc = accname1.Match(log1);
            string accvalue = acc.Value;
            return accvalue;
        }
            
        public string objtype(string log1)
        {
            //Get the object type from the matched section above
            Regex objtype1 = new Regex(@"(?<=Object Type:)(.*?)([^\s]+)", RegexOptions.Singleline);
            Match obj = objtype1.Match(log1);
            string objvalue = obj.Value;
            return objvalue;
        }

        public string finddate(string log1)
        {
            //find the date within the matched section above for comparing to the date withing the date pickers
            Regex finddate1 = new Regex(@"\d{1,2}/\d{1,2}/\d{4}.*[AM||PM]{2}\b\t", RegexOptions.Singleline);
            Match d = finddate1.Match(log1);
            Match datefound = finddate1.Match(log1);
            string datef = datefound.Value;
            return datef;
        }
       
        public string IDnum(string log1)
        {
            //Get the Id number of the event from the matched section above
            Regex IDnum1 = new Regex(@"(?<=Auditing)(.*?)([^\s]+)", RegexOptions.Singleline);            
            Match ID = IDnum1.Match(log1);
            string IDnumber = ID.Value;
            return IDnumber;
        }

        public string description(string log1)
        {
            //get the event description from the matched section above
            Regex description1 = new Regex(@"(?<=Authorization Policy Change)(.*?)([^.]+)", RegexOptions.Singleline);
            Match desc = description1.Match(log1);
            string descript = desc.Value;
            return descript;
        }                  
    }    
}
