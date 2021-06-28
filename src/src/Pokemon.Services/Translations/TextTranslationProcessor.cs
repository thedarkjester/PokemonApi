using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Services.Translations
{
    public interface ITextTranslationProcessor
    {
        Task<string> Process(string stringToTranslate);
    }

    public class TextTranslationProcessor : ITextTranslationProcessor
    {
        public Task<string> Process(string stringToTranslate)
        {
            throw new NotImplementedException();
        }
    }

    //public interface IPokemonTranslationOrchestrator
    //{
    //    Task<string> Orchestrate( stringToTranslate);
    //}
}
