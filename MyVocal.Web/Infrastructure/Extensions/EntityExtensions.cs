using MyVocal.Model.Models;
using MyVocal.Web.Models;

namespace MyVocal.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateWordCategory(this WordCategory wordCategory, WordCategoryViewModel wordCategoryVm)
        {
            wordCategory.WordCategoryId = wordCategoryVm.WordCategoryId;

            wordCategory.CategoryName = wordCategoryVm.CategoryName;

            wordCategory.Description = wordCategoryVm.Description;

            wordCategory.Identify = wordCategoryVm.Identify;
        }

        public static void UpdateWord(this Word word, WordViewModel wordVm)
        {
            word.WordId = wordVm.WordId;

            word.Defination = wordVm.Defination;

            word.Transcription = wordVm.Transcription;

            word.WordName = wordVm.WordName;

            word.WordCategoryId = wordVm.WordCategoryId;

            word.Sound = wordVm.Sound;

            word.Meaning = wordVm.Meaning;

            word.Image = wordVm.Image;

            word.Status = wordVm.Status;

            word.Example = wordVm.Example;

            word.ExampleTranslation = wordVm.ExampleTranslation;

            word.SoundExample = wordVm.SoundExample;

            word.SubjectId = wordVm.SubjectId;

            word.CreatedDate = wordVm.CreatedDate;

            word.UpdatedDate = wordVm.UpdatedDate;

            word.CreatedBy = wordVm.CreatedBy;

            word.UpdateBy = wordVm.UpdateBy;
        }

        public static void UpdateQuestion(this Question question, QuestionViewModel questionVm)
        {
            question.WordId = questionVm.WordId;

            question.AnswerA = questionVm.AnswerA;

            question.AnswerB = questionVm.AnswerB;

            question.AnswerC = questionVm.AnswerC;

            question.AnswerD = questionVm.AnswerD;

            question.Solution = questionVm.Solution;

            question.QuestionCategoryId = questionVm.QuestionCategoryId;

            question.QuestionName= questionVm.QuestionName;

            question.Image = questionVm.Image;

            question.Audio = questionVm.Audio;

        }

        public static void UpdateQuestionCategory(this QuestionCategory questionCategory,QuestionCategoryViewModel questionCategoryVm)
        {
            questionCategory.QuestionCategoryId = questionCategoryVm.QuestionCategoryId;

            questionCategory.QuestionCategoryName = questionCategoryVm.QuestionCategoryName;

            questionCategory.Description = questionCategoryVm.Description;

        }

        public static void UpdateSubjectGroup(this SubjectGroup subjectGroup, SubjectGroupViewModel subjectGroupVm)
        {
            subjectGroup.SubjectGroupId = subjectGroupVm.SubjectGroupId;

            subjectGroup.SubjecGroupName = subjectGroupVm.SubjecGroupName;

            subjectGroup.Identify = subjectGroupVm.Description;

            subjectGroup.Image = subjectGroupVm.Image;

            subjectGroup.Status = subjectGroupVm.Status;           
        }

        //public static void UpdateSubjectDepen(this Subject subject, SubjectDependUser subjectDep)
        //{
        //    subjectDep.SubjectId = subject.SubjectId;
        //    subjectDep.SubjectName = subject.SubjectName;
        //    subjectDep.SubjectGroupId = subject.SubjectGroupId;
        //    subjectDep.Description = subject.Description;
        //    subjectDep.Identify = subjectDep.Identify;
        //    subjectDep.Image = subject.Image;
        //    subjectDep.WordTotal = subject.WordTotal;
           
        //}

        public static void UpdateSubject(this Subject subject, SubjectViewModel subjectVm)
        {
            subject.SubjectId = subjectVm.SubjectId;
            subject.SubjectName = subjectVm.SubjectName;
            subject.SubjectGroupId = subjectVm.SubjectGroupId;
            subject.Description = subjectVm.Description;
            subject.Identify = subjectVm.Identify;
            subject.Image = subjectVm.Image;
            subject.WordTotal = subjectVm.WordTotal;

        }
    }
}