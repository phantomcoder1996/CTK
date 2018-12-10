using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTK
{
    public enum CourseStatus
    {
        /// <summary>
        /// No data for this course
        /// </summary>
        NotExist,
        /// <summary>
        /// Names are inserted for the course
        /// </summary>
        State1,
        /// <summary>
        /// Secrete Numbers are issued for the course
        /// </summary>
        State2,
        /// <summary>
        /// Final marks are imported for the course
        /// </summary>
        State3,
    }
}
