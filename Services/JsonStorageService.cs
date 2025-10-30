using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppFitShare.Services
{
    internal class JsonStorageService
    {
        private readonly string basePath;
        public JsonStorageService()
        {
            basePath = FileSystem.AppDataDirectory;
        }
        private string GetFilePath(string fileName)
            => Path.Combine(basePath, fileName);
        public async Task SaveAsync<T>(string fileName, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions {WriteIndented = true});
            var path = GetFilePath(fileName);
            await File.WriteAllTextAsync(path, json);
        }
        public async Task<List<T>> LoadAsync<T>(string fileName)
        {
            var path = GetFilePath(fileName);

            if (!File.Exists(path))
                return new List<T>();
            var json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

    }
}
