using System;
using System.Collections.Generic;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueModel
    {
        public long Id { get; set; }

        public string IssueName { get; set; }

        public string Intro { get; set; }

        public string IssueCoverPath { get; set; }
    }
}
