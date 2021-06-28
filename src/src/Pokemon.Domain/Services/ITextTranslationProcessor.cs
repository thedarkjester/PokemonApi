using System.Threading.Tasks;

namespace Pokemon.Domain.Services
{
    public interface ITextTranslationProcessor
    {
        Task<string> Process(string stringToTranslate, string translateTo);
    }
}
