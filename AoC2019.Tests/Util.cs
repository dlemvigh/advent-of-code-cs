using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace AoC2019.Tests {
	public class Util {
		public static Task<string> ReadTestData(string filename) {
			var provider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
			using (var stream = provider.GetFileInfo($"TestData/{filename}").CreateReadStream())
			using (var reader = new StreamReader(stream)) {
				return reader.ReadToEndAsync();
			}
		}
	}
}