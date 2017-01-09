![Dataphile Logo](logo.png)

## Introduction
Dataphile is a "database" for those times when you don't actually want or need a database!  The core concept is that data is stored in files, organised with a particular folder structure, making it really easy to setup and well suited for use in prototypes and lightweight projects where concurrent editing of data isn't a concern.

## Getting Started
Dataphile is extremely easy to setup and use.  It is built using dotnet core and works equally well in console and web applications.  The following guide assumes that you are using the dotnet core command line tools and that you are familiar with dependency injection built into asp.net core.  If you are not familiar with either of these concepts then please refer to the following documenation.  This guide also assumes that you are developing a web application.  Please note that if you are developing a dotnet core console application then you should refer to the sample project included with the source code.  The dependency injection referred to in the second link actually works in dotnet core console application and is configured and used in the sample project.

[Getting started with dotnet core using the command line](https://docs.microsoft.com/en-us/dotnet/articles/core/tutorials/using-with-xplat-cli)
[Fundamentals of asp.net core dependency injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

* Add the library to your project.json file then restore project dependencies with the dotnet restore command:

```json
"dependencies": {
    "dataphile": "1.0.0"
  }
```

* Add the following line of code to the ConfigureServices() method in Startup.cs:

```c#
services.AddFileStore(Directory.GetCurrentDirectory());
```

* Inject the service into your controller/s and use the service to perform CRUD operations as indicated in the sample code below:

```c#
public class PizzaController : Controller
{
    private IFileStoreService _fileStoreService;

    public PizzaController(IFileStoreService fileStoreService)
    {
        _fileStoreService = fileStoreService;
    }

    [HttpGet]
    public IActionResult List()
    {
        var model = new ListViewModel() {
            Pizzas = _fileStoreService.RreadAll<Pizza>()
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Add", new Pizza());
    }

    [HttpPost]
    public IActionResult Add(Pizza model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        _fileStoreService.Insert(model, model.Id);
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(_fileStoreService.ReadSingle<Pizza>(id));
    }

    [HttpPost]
    public IActionResult Edit(Pizza model)
    {
        if (!ModelState.IsValid)
            return View(model);
        
        _fileStoreService.Update(model, model.Id);
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _fileStoreService.Delete<Pizza>(id);
        return RedirectToAction("List");
    }
}
```

## Custom Storage Path Resolution
by default, Dataphile resolves storage paths in the following manner:

```
[basePath]\[entity_type]\[entity_id].[extension]
```

Should you require some other method of storage path resolution, you can create a custom storage resolver, as shown below.

* Create a class which implements IStorageResolver:

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

* Register the custom storage resolver using the options builder:

```c#
services.AddFileStore(options =>
  options.StorageResolver(new MyCustomStorageResolver()));
```

## Custom Serialization
In much the same fashion as above, the serializer used by Dataphile can be customised to your own liking.

* Create a class which implements the ISerializer interface:

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

* Register the custom serializer using the options builder:

```c#
services.AddFileStore(options =>
  options.Serializer(new MyCustomSerializer()));
```