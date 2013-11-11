namespace SimpleDataSample
{
    internal class ColumnSelectionSamples
    {
        internal void RunAll()
        {
            // No arguments sent to select, Simple.Data ignores select function, returns all columns.
            ExampleRunner.RunQuery(
                "No arguments to Select.",
                db => db.Albums.All()
                        .Select());

            // select count(*) from OrderDetails using .Star().Count()
            ExampleRunner.RunQuery(
                "select * from Albums using db.Albums.Star()",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Star()));

            // select count(*) from OrderDetails using .Star().Count()
            ExampleRunner.RunQuery(
                "select * from Albums using db.Albums.AllColumns()",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AllColumns()));


            ExampleRunner.RunQuery(
                "Use indexer syntax: Get all AlbumIds and Titles in the Album table",
                db => db["Albums"].All()
                                  .Select(
                                      db["Albums"]["AlbumId"],
                                      db["Albums"]["Title"])
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table including schema name in column ids",
                db => db.Albums.All()
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table using FindAllByGenreId(1)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table using FindAll(db.Albums.GenreId == 1)",
                db => db.Albums.FindAll(db.Albums.GenreId == 1)
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Use Select cumulatively to Get all AlbumIds and Titles. Throws InvalidOperationException",
                db => db.Albums.FindAll(db.Albums.GenreId == 1)
                        .Select(db.dbo.Albums.AlbumId)
                        .Select(db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Run Select by itself without a command to qualify",
                db => db.Albums.Select(
                    db.Albums.AlbumId,
                    db.Albums.Title));

            ExampleRunner.RunQuery(
                "Try to access a data field not included in a Select command",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId)
                );

            ExampleRunner.RunQuery(
                "Try to select a column that doesn't exist in the table. Throws UnresolvableObjectException",
                db => db.Albums.All()
                        .Select(
                            db.Albums.OrderId)
                );
        }
    }
}