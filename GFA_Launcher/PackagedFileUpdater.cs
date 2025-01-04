using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace GFA_Launcher
{
    public static class PackagedFileUpdater
    {
        static Dictionary<string, IdxItemModel> idx_list = [];

        static List<IdxItemModel> diffNewFiles = [];
        static List<IdxItemModel> diffMismatch = [];
        static List<IdxItemModel> diffDeletedFiles = [];

        static int last_pkg_id = 1;

        static int[] pkg_lengths = [];

        static string get_pkg_name(int int_0) => ((int_0 < 10) ? ("pkg00" + int_0) : ((int_0 >= 100) ? ("pkg" + int_0) : ("pkg0" + int_0))) + ".pkg";

        public static void ScanAndUpdateFiles(List<IdxItemModel> manifest)
        {
            idx_list = new Dictionary<string, IdxItemModel>();

            diffNewFiles = new List<IdxItemModel>();
            diffMismatch = new List<IdxItemModel>();
            diffDeletedFiles = new List<IdxItemModel>();

            last_pkg_id = 1;

            pkg_lengths = [];

            Console.Write("\nLoading existing IDX map...\n");

            LoadIDXFile();

            Console.Write("\nDiffing IDX map..\n");

            DiffIDXAndManifest(manifest);

            Console.WriteLine("\n=== Files with mismatch ===");
            foreach (IdxItemModel file in diffMismatch)
            {
                Console.WriteLine(file.file_path + file.file_name);
            }

            Console.WriteLine("\n=== Deleted Files ===");
            foreach (IdxItemModel file in diffDeletedFiles)
            {
                Console.WriteLine(file.file_path + file.file_name);
            }

            Console.WriteLine("=== New files to write ===");
            foreach (IdxItemModel file in diffNewFiles)
            {
                Console.WriteLine(file.file_path + file.file_name);
            }

            Console.Write("\nLoading archives...\n");
            LoadArchives();

            Console.Write("\nHandle deleted files...\n");
            diffDeletedFiles.ForEach(DeleteFile);

            Console.Write("\nHandle mismatch files..\n");
            diffMismatch.ForEach(DeleteFile);

            Console.Write("\nDownloading and adding new files..\n");

            // Download and flush new packages to .pkg 
            HandleNewFiles();

            Console.Write("Saving IDX map...\n");
            SaveNewIDXObfuscated();

            Console.Write("Creating sp...\n");
            CreateCustomSP();

            Console.Write("\nThis is it.\n");
        }

        static void LoadIDXFile()
        {
            try
            {
                using FileStream fileStream = new FileStream("pkg.idx", FileMode.Open, FileAccess.Read, FileShare.Read, 65535, FileOptions.SequentialScan);
                if (!fileStream.CanRead) return;

                byte[] buffer = new byte[292];
                fileStream.Read(buffer, 0, 292);

                while (fileStream.Position < fileStream.Length)
                {
                    IdxItemModel item = new IdxItemModel();
                    buffer = new byte[4];
                    fileStream.Read(buffer, 0, 4);
                    int index = BitConverter.ToInt32(buffer, 0);
                    fileStream.Read(buffer, 0, 4);
                    item.offset = BitConverter.ToInt32(buffer, 0);
                    fileStream.Read(buffer, 0, 4);
                    item.index_offset = BitConverter.ToInt32(buffer, 0);
                    fileStream.Read(buffer, 0, 4);
                    item.zsize = BitConverter.ToInt32(buffer, 0);
                    buffer = new byte[8];
                    fileStream.Read(buffer, 0, 8);
                    item.update_timestamp = BitConverter.ToInt64(buffer, 0);
                    fileStream.Read(buffer, 0, 8);
                    item.file_timestamp = BitConverter.ToInt64(buffer, 0);
                    fileStream.Seek(8, SeekOrigin.Current);
                    fileStream.Seek(8, SeekOrigin.Current);
                    fileStream.Seek(4, SeekOrigin.Current);
                    buffer = new byte[4];
                    fileStream.Read(buffer, 0, 4);
                    item.hashCRC = BitConverter.ToUInt32(buffer, 0);
                    fileStream.Read(buffer, 0, 4);
                    item.size = BitConverter.ToInt32(buffer, 0);
                    buffer = new byte[260];
                    fileStream.Read(buffer, 0, 260);
                    item.file_name = Encoding.UTF8.GetString(buffer).Trim('\0');
                    fileStream.Read(buffer, 0, 260);
                    item.file_path = Encoding.UTF8.GetString(buffer).Trim('\0');
                    fileStream.Seek(4, SeekOrigin.Current);
                    fileStream.Seek(4, SeekOrigin.Current);
                    fileStream.Read(buffer, 0, 4);
                    item.pkg_id = BitConverter.ToInt32(buffer, 0);
                    idx_list[Path.Combine(item.file_path, item.file_name)] = item;
                }
            }
            catch (Exception)
            {
            }
        }

        static void DiffIDXAndManifest(List<IdxItemModel> manifest)
        {
            foreach (IdxItemModel manifestFile in manifest)
            {
                string path = Path.Combine(manifestFile.file_path, manifestFile.file_name);

                IdxItemModel idxItem;
                if (idx_list.TryGetValue(path, out idxItem))
                {
                    if ((manifestFile.hashCRC != idxItem.hashCRC) || (manifestFile.zsize != idxItem.zsize))
                    {
                        diffMismatch.Add(idxItem);
                        diffNewFiles.Add(idxItem);
                    }
                }
                else
                {
                    diffNewFiles.Add(manifestFile);
                }
            }

            HashSet<string> manifestFileSet = [.. manifest.Select(x => Path.Combine(x.file_path, x.file_name))];
            foreach (var idxEntry in idx_list.Values)
            {
                if (!manifestFileSet.Contains(Path.Combine(idxEntry.file_path, idxEntry.file_name)))
                {
                    diffDeletedFiles.Add(idxEntry);
                }
            }
        }

        static void CreateCustomSP()
        {
            Console.WriteLine("Creating sp file for " + (Directory.GetFiles("*.pkg").Length - 1) + " files");
            using FileStream fileStream = new FileStream("pkg.sp", FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 65535, FileOptions.None);
            for (int i = 0; i < Directory.GetFiles("*.pkg").Length - 1; i++)
            {
                int num = i + 1;
                string text = get_pkg_name(num);
                if (!File.Exists(text))
                {
                    File.Create(text).Close();
                }
                int length = (int)new FileInfo(text).Length;
                fileStream.Write(BitConverter.GetBytes(num), 0, 4);
                fileStream.Write(BitConverter.GetBytes(length), 0, 4);
                fileStream.Write(new byte[4], 0, 4);
            }
            fileStream.Close();
        }

        static void LoadArchives()
        {
            for (int i = 1; i < 800; i++)
            {
                string text = Path.Combine(get_pkg_name(i));
                if (File.Exists(text))
                {
                    last_pkg_id = i;
                }
            }

            pkg_lengths = new int[last_pkg_id + 1];
            for (int j = 1; j <= last_pkg_id; j++)
            {
                string text = Path.Combine(get_pkg_name(j));
                if (!File.Exists(text))
                {
                    using FileStream fileStream = File.Create(text);
                    fileStream.Close();
                }
                pkg_lengths[j] = (int)new FileInfo(text).Length;
            }
        }

        static void DeleteFile(IdxItemModel mismatchItem)
        {
            string path = Path.Combine(mismatchItem.file_path, mismatchItem.file_name);

            if (idx_list.ContainsKey(path))
            {
                mismatchItem.pkg_id = idx_list[path].pkg_id;
                mismatchItem.offset = idx_list[path].offset; // This is crucial cause it might've been offset from previous deletions
                idx_list.Remove(path);
            }
            else
            {
                Console.WriteLine($"File {path} not found in idx_list, skipping deleted file");
                return;
            }

            Console.WriteLine($"DELETE OLD {path}");

            int pkgId = mismatchItem.pkg_id;
            int offset = mismatchItem.offset;

            string pkgFile = Path.Combine(get_pkg_name(pkgId));
            if (!File.Exists(pkgFile))
            {
                Console.WriteLine($"PKG file {pkgFile} not found, skipping deleted file {path}");
                return;
            }

            int newLength;
            using (FileStream fileStream = new FileStream(pkgFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 10485760, FileOptions.RandomAccess))
            {
                long oldLength = pkg_lengths[pkgId];
                long remainingBytes = oldLength - offset - mismatchItem.zsize;

                byte[] buffer = new byte[remainingBytes];
                fileStream.Seek(offset + mismatchItem.zsize, SeekOrigin.Begin);
                fileStream.Read(buffer, 0, buffer.Length);

                fileStream.Seek(offset, SeekOrigin.Begin);
                fileStream.Write(buffer, 0, buffer.Length);

                newLength = (int)(oldLength - mismatchItem.zsize);
                fileStream.SetLength(newLength);
            }

            if (newLength == 0)
            {
                File.Delete(pkgFile);
            }

            foreach (var kvp in idx_list)
            {
                if (kvp.Value.pkg_id == pkgId && kvp.Value.offset > offset)
                {
                    idx_list[kvp.Key].offset -= mismatchItem.zsize;
                }
            }
            pkg_lengths[pkgId] = newLength;
        }

        static void HandleNewFiles()
        {
            foreach (IdxItemModel newItem in diffNewFiles)
            {
                string path = Path.Combine(newItem.file_path, newItem.file_name);

                Console.WriteLine($"DOWNLOAD NEW {path}");

                // TODO: Connect here to download compressed and encrypted file:

                byte[] fileToWrite = ...; // File.ReadAllBytes(Path.Combine(path + "_Z_"));

                // TODO: Delete file once read in memory (probably no need to even save it to disk!)

                if (fileToWrite.Length > 10485760)
                {
                    Console.WriteLine("File is too big to fit into any pkg file.");
                    continue;
                }

                // Loop through pkg_lengths, find first which has enough space
                int pkgId = -1;
                for (int i = 1; i <= pkg_lengths.Length; i++)
                {
                    int length = (i < pkg_lengths.Length) ? pkg_lengths[i] : 0;
                    if ((length + fileToWrite.Length) < 10485760)
                    {
                        pkgId = i;
                        break;
                    }
                }

                if (pkgId == -1)
                {
                    Console.WriteLine("No pkg file can fit file. Perhaps new file is too big.");
                    continue;
                }

                string pkgFile = Path.Combine(get_pkg_name(pkgId));
                if (!File.Exists(pkgFile))
                {
                    using (FileStream fileStream = File.Create(pkgFile))
                    {
                        fileStream.Close();
                    }
                }

                int offset;
                using (FileStream fileStream = new FileStream(pkgFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None, 65536, FileOptions.None))
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    offset = (int)fileStream.Position;
                    fileStream.Write(fileToWrite, 0, fileToWrite.Length);
                }

                newItem.pkg_id = pkgId;
                newItem.offset = offset;

                idx_list[path] = newItem;

                if (pkgId >= pkg_lengths.Length)
                {
                    Array.Resize(ref pkg_lengths, pkgId + 1);
                }
                pkg_lengths[pkgId] += fileToWrite.Length;
            }
        }

        static void SaveNewIDXObfuscated()
        {
            int num = -1;
            int num2 = 0;
            using FileStream fileStream = new FileStream("pkg.idx", FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 65535, FileOptions.None);
            fileStream.Write(new byte[292], 0, 292);
            foreach (KeyValuePair<string, IdxItemModel> item in idx_list)
            {
                num2++;
                num++;
                int num3 = (int)fileStream.Position;
                idx_list[item.Key].index_offset = num3;
                byte[] bytes = BitConverter.GetBytes(num);
                fileStream.Write(bytes, 0, 4);
                bytes = BitConverter.GetBytes(item.Value.offset);
                fileStream.Write(bytes, 0, 4);
                bytes = BitConverter.GetBytes(num3);
                fileStream.Write(bytes, 0, 4);
                bytes = BitConverter.GetBytes(item.Value.zsize);
                fileStream.Write(bytes, 0, 4);
                bytes = BitConverter.GetBytes(item.Value.update_timestamp);
                fileStream.Write(bytes, 0, 8);
                bytes = BitConverter.GetBytes(item.Value.file_timestamp);
                fileStream.Write(bytes, 0, 8);
                fileStream.Write(new byte[8], 0, 8);
                fileStream.Write(new byte[8], 0, 8);
                fileStream.Write(new byte[4], 0, 4);
                bytes = BitConverter.GetBytes(item.Value.hashCRC);
                fileStream.Write(bytes, 0, 4);
                bytes = BitConverter.GetBytes(item.Value.size);
                fileStream.Write(bytes, 0, 4);
                bytes = Encoding.UTF8.GetBytes(item.Value.file_name);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Write(new byte[260 - bytes.Length], 0, 260 - bytes.Length);
                bytes = Encoding.UTF8.GetBytes(item.Value.file_path);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Write(new byte[260 - bytes.Length], 0, 260 - bytes.Length);
                fileStream.Write(new byte[4], 0, 4);
                fileStream.Write(new byte[4], 0, 4);
                bytes = BitConverter.GetBytes(item.Value.pkg_id);
                fileStream.Write(bytes, 0, 4);
            }
            fileStream.Close();
        }
    }
}