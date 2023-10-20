using NipissingU.SelfServe.Core.Models.Common;
using NipissingU.SelfServe.Core.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NipissingU.SelfServe.WebSite.Areas.SelfServe.Models.Student
{
    public class ClinicalCommitmentViewModel
    {
        public string StudentId { get; set; }

        // selection 
        public string HasValidProgram { get; set; }

        public List<SelectListItem> StudyYearsSelect { get; set; }

        public string ChangeRequestHeader { get; set; }

        public List<DateTime> FormOpenDates { get; set; }

        public List<DateTime> FormLockDates { get; set; }

        public List<string> HasFormIndicators { get; set; }

        //
        public string SpringSemesterTitle { get; set; }

        public string FallSemesterTitle { get; set; }

        public string WinterSemesterTitle { get; set; }

        // THESE ARE THE COURSE OPTIONS THAT I AM TRYING TO MAP TO THE REPORT FIELDS 
        public List<Course> SpringCourseOptions { get; set;}

        public List<Course> FallCourseOptions { get; set; }

        public List<Course> WinterCourseOptions { get; set; }
        // END COURSE OPTIONS

        
        public string SpringSemesterSelectedCourse { get; set; }

        public string FallSemesterSelectedCourse { get; set; }

        public string WinterSemesterSelectedCourse { get; set; }

        public string SpringSemesterChangeRequestReason { get; set; }

        public string FallSemesterChangeRequestReason { get; set; }

        public string WinterSemesterChangeRequestReason { get; set; }

        public string CurrentNBRegionalHealthEmployment { get; set; }

        public string CurrentPlaceOfEmployment { get; set; }

        public string CurrentUnitOrDepartment { get; set; }

        public string AltHealthCareAgencyEmployment { get; set; }

        public string AltHealthCareAgencyName { get; set; }

        public string AltHealthCareUnitDepartment { get; set; }

        public void PopulateSelectListsUsingModel(ClinicalCommitmentSelection clinicalCommitmentSelection)
        {
            if (clinicalCommitmentSelection?.StudyYears == null) return;

            StudyYearsSelect = clinicalCommitmentSelection.StudyYears.Select(pair =>
                new SelectListItem
                {
                    Value = pair.Key,
                    Text = pair.Value.ToString()
                }).ToList();
        }
    }
}
