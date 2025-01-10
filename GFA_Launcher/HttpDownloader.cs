using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    public class HttpDownloader
    {
        private HttpClient client;

        public HttpDownloader(string baseUrl)
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") } }

            };
        }

        public async Task DownloadFileWithRetriesAsync(
            string downloadPath,
            string destinationPath,
            int size,
            Action<string, int> reportStatus, // Status callback
            Action<double> reportProgress, // Progress callback
            string? displayName = null,
            int maxRetries = -1)
        {
            reportProgress.Invoke(0);
            int retryCount = 0;
            while (maxRetries == -1 ? true : retryCount < maxRetries)
            {
                try
                {
                    reportStatus.Invoke($"Downloading {displayName ?? downloadPath}...", 1);
                    await DownloadFileAsync(downloadPath, destinationPath, size, reportProgress);
                    Console.WriteLine("Download completed successfully.");
                    return; // Exit function if download succeeds
                }
                catch (Exception ex)
                {
                    retryCount++;
                    reportStatus.Invoke(ex.Message, 2);
                    //reportStatus.Invoke($"Download failed for {displayName ?? downloadPath}, retrying in 3s...", 2);
                    if (maxRetries == -1 ? false : retryCount >= maxRetries)
                    {
                        Console.WriteLine("Max retry attempts reached. Download failed.");
                        return;
                    }
                    // Delete file that was being written
                    File.Delete(destinationPath);
                    await Task.Delay(3000); // Wait before retrying
                }
            }
        }
        
        private async Task DownloadFileAsync(
            string downloadPath,
            string destinationPath,
            int size,
            Action<double> reportProgress)
        {
            using (var response = await client.GetAsync(downloadPath, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var contentLength = size == 0 ? response.Content.Headers.ContentLength : size;
                var totalBytesRead = 0;

                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    var buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        // Report progress
                        if (contentLength > 0)
                        {
                            var percentage = (double)totalBytesRead / contentLength * 100;
                            reportProgress.Invoke(percentage ?? 0);
                        }
                    }
                }
            }
        }
    }
}
