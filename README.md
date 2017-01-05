# Dataphile

## Introduction
Dataphile is the "database" you need for all those times when you don't actually want or need a database.  Data is seralized and stored in files, making this super easy to setup and use in prototypes and small scale applications.

## Getting Started
Dataphile is built for use dotnet core and works well with both console and web applications.  To install Dataphile, follow these instructions:

1. Add it to the project.json file for your project:

```json
"dependencies": {
    "dataphile": "1.0.0"
  }
```
2. Save the file then run the following command from the command prompt:

```shell
dotnet restore
```

3. If you are creating an asp.net application then add the following line of code to the ConfigureServices() method in Startup.cs.  In the case of a console application check out the sample application included with the source code for more details:

```c#
services.AddFileStore(Directory.GetCurrentDirectory());
```

4.  Inject the FileStoreService into your controller/s using the IFileStoreService interface and use like so:

```c#
var hoverboard = new Entity() { Id = 1, Name = "Hoverboard" };

// Create
fileStoreService.Insert(hoverboard, hoverboard.Id);

// Read Single
fileStoreService.ReadSingle<Entity>(hoverboard.Id);

// Read All
fileStoreService.ReadAll<Entity>();

// Update
fileStoreService.Update(hoverboard, hoverboard.Id);

// Delete
fileStoreService.Delete<Entity>(entity.Id);
```

## Custom Storage Path Resolution
by default, Dataphile resolves storage paths in the following manner:

```
[basePath]\[entity_type]\[entity_id].[extension]
```

Should you require some other method of storage path resolution, you can create a custom storage resolver which implements the IStorageResolver interface as shown below:

```c#
public class MyCustomStorageResolver : IStorageResolver
{
    /// <summary>
    /// Resolves a storage path for a specified object.
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="basePath">The base storage path.</param>
    /// <param name="id">The id of the object.</param>
    /// <param name="extension">The storage file extension.</param>
    /// <returns>The storage path for the specified object.</returns>
    public string ResolveObject<T>(
        string basePath,
        object id,
        string extension) where T : class
    {
        // Provide your own code to resolve the path to an object
    }

    /// <summary>
    /// Resolves a storage path for a specified type.
    /// </summary>
    /// <typeparam name="T">The type to resolve.</typeparam>
    /// <param name="basePath">The base storage path.</typeparam>
    /// <returns>The storage path for the specified type.</returns>
    public string ResolveType<T>(
        string basePath
        ) where T : class
    {
        // Provider your own code to resolve the directory path of a type
    }
}
```

Register the custom storage resolver using the options builder:

```c#
services.AddFileStore(options =>
  options.StorageResolver(new MyCustomStorageResolver()));
```

## Custom Serialization
In much the same fashion as above, the serializer used by Dataphile can be customised to your own liking by creating a class which implements the ISerializer interface:

```c#
public class MyCustomSerializer : ISerializer
{
    /// <summary>
    /// Deserializes the specified object.
    /// </summary>
    /// <typeparam name="T">The deserialized type.</typeparam>
    /// <param name="value">The value to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    public T Deserialize<T>(string value) where T : class
    {
        // Provide your own code to deserialize an object
    }

    /// <summary>
    /// Serializes the specified object.
    /// </summary>
    /// <param name="value">The value to serialize.</param>
    /// <returns>The serialized object.</returns>
    public string Serialize<T>(T value) where T : class
    {
        // Provide your own code to serialize an object
    }
}
```

Register the custom serializer using the options builder:

```c#
services.AddFileStore(options =>
  options.Serializer(new MyCustomSerializer()));
```