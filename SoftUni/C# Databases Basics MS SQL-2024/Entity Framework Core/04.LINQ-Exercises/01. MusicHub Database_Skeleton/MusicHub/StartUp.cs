namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            string reslut = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(reslut);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder stringBuilder = new();

            var albums = context.Albums
                                .Where(a => a.ProducerId.HasValue &&
                        a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                            .Select(s => new
                            {
                                SongName = s.Name,
                                Price = s.Price.ToString("f2"),
                                Writer = s.Writer.Name,
                            })
                            .OrderByDescending(s => s.SongName)
                            .ThenBy(s => s.Writer)
                            .ToArray(),
                    AlbumPrice = a.Price,
                })
                .ToArray()
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            foreach (var album in albums)
            {
                stringBuilder.AppendLine($"-AlbumName: {album.Name}");
                stringBuilder.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                stringBuilder.AppendLine($"-ProducerName: {album.ProducerName}");
                stringBuilder.AppendLine("-Songs:");

                int songCount = 0;
                foreach (var song in album.Songs)
                {
                    songCount++;

                    stringBuilder.AppendLine($"---#{songCount}");
                    stringBuilder.AppendLine($"---SongName: {song.SongName}");
                    stringBuilder.AppendLine($"---Price: {song.Price}");
                    stringBuilder.AppendLine($"---Writer: {song.Writer}");
                }

                stringBuilder.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder stringBuilder = new();

            TimeSpan durationTimeSpan = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                .Where(s => s.Duration > durationTimeSpan)
                .Select(s => new
                {
                    s.Name,
                    PerformerFullName = s.SongPerformers
                                            .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                            .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    s.Duration
                }
                )
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int songsCount = 0;

            foreach (var song in songs)
            {
                songsCount++;

                stringBuilder.AppendLine($"-Song #{songsCount}")
                              .AppendLine($"---SongName: {song.Name}")
                              .AppendLine($"---Writer: {song.WriterName}");

                foreach (var peformer in song.PerformerFullName.OrderBy(p => p))
                {
                    stringBuilder.AppendLine($"---Performer: {peformer}");
                }

                stringBuilder.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                                .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
