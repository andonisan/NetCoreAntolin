using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Data
{
    public class Milestone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MilestoneType MilestoneType { get; set; }

    }
}
