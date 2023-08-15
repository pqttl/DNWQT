using System.Collections.Generic;

namespace DNQT.ViewModels.Admin.Order
{
    public class DisplayColumn_VMDataTable
    {

        public DisplayColumn_VMDataTable()
        {

        }

        public List<string> LstStringNameColumn { get; set; } = new List<string>();

        public List<string> LstStringColumnRight { get; set; } = new List<string>();

        public List<string> LstStringColumnCenter { get; set; } = new List<string>();

        public List<string> LstStringColumnCollapse { get; set; } = new List<string>();

        public string StrNameColumnIdMain { get; set; } = "";

        public string StrNoteTable { get; set; } = "";


        public List<string> LstStringColumnAddLink { get; set; } = new List<string>();

        /// <summary>
        /// LstStringLinkToAdd và LstStringColumnAddLink phải có cùng số lượng
        /// </summary>
        public List<string> LstStringHtmlAddToLink { get; set; } = new List<string>();

    }
}
