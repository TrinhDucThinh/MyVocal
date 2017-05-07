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

            word.Transcription = wordVm.Transcription;

            word.WordName = wordVm.WordName;

            word.WordCategoryId = wordVm.WordCategoryId;

            word.Sound = wordVm.Sound;

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
    }
}