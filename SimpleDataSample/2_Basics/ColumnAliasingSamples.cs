namespace SimpleDataSample
{
    internal class ColumnAliasingSamples
    {
        internal void RunAll()
        {
             ExampleRunner.RunQuery(
                "Use alias to reference Artist.Name column as 'Title'",
                db => db.Artists.All()
                        .Select(
                            db.Artists.Name.As("Title")
                          ));

            ExampleRunner.RunQuery(
                "Give As method a non-string alias",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title.As(123)
                          ));

            ExampleRunner.RunQuery(
                "Abuse As method to set one field name to that of another and then access one - throws ArgumentException",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId.As("Title"),
                            db.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Abuse As method to set two field names to the same value and then access one - throws ArgumentException",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId.As("Title"),
                            db.Albums.GenreId.As("Title"))
                );

            ExampleRunner.RunQuery(
                "Use As method to give column name an alias and then reference its original name - throws KeyNotFoundException",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title.As("AlbumName"))
                );
        }
    }
}