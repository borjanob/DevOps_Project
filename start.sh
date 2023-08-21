
# Wait for the SQL Server container to start
until nc -z -w 1 db 1433; do
  echo "Waiting for the database server to start..."
  sleep 1
done

# Apply EF Core migrations
dotnet ef database update

# Start your .NET application
dotnet YourApp.dll