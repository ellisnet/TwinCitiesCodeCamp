Xamarin.Forms Presentation - Oct 4 2014
=======================================

Short link to get to this presentation folder: http://bit.ly/xamforms

Table of Contents
-----------------

  1. [Information (and links to information) about Xamarin.Forms](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#information-about-xamarinforms)
  2. [Explanation of my cross-platform Sqlite library](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#portabledatasqlite) that works *excellently* with Xamarin.Forms - Portable.Data.Sqlite - and links to get the code and NuGet package
  3. [Sample project code - NAME HERE](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#sample-project-code) - information about the sample application/demo project that I will build and demonstrate in my presentation.

Information about Xamarin.Forms
-------------------------------

Xamarin.Forms is a cross-platform framework that runs on top of [Xamarin](http://xamarin.com/platform) - it allows the same shared code application to (be compiled to) run on iOS, Android and Windows Phone (with possible future support for Windows 10?). It allows you to write user interface (UI) code that is not platform specific, but compiles and runs on all supported platforms using native UI controls that are correct for the platform.

It is very important to know that a Xamarin.Forms application for any of these platforms is a **native application** - for each of the platforms, the shared code (and a platform-specific stub) is **compiled to native code** that looks the same to the device as an application that was programmed using the native tools (Xcode/Objective-C/Swift on iOS, Java/Android Studio on Android, .NET on Windows). Xamarin.Forms is not a web-based or hybrid solution or something like the Java-Runtime-Engine-write-once-run-poorly-everywhere "cross platform" solutions of the past.

With Xamarin.Forms, all code is written in C# and user-interfaces can (optionally) be written in the XAML mark up language from Microsoft; you can write platform-specific code if you want to, but the goal really is to have most of your code be cross-platform in the shared project.

At first glance, Xamarin.Forms appears to just be a cross-platform UI framework. Write your non-platform-specific code in a shared project, and the UI just gets rendered properly on each of the supported platforms. But, when you get into it, you find out that it is also a nice, simple MVVM (Model-View-ViewModel) framework with support for data binding, and ICommand and INotifyPropertyChanged handling.  And it has a simple-but-elegant dependency resolver service.  Nonetheless, there are more advanced MVVM frameworks that work well with Xamarin.Forms and/or sit on top of it, like [ReactiveUI](https://github.com/reactiveui/ReactiveUI) and [Calcium for Xamarin.Forms](http://www.codeproject.com/Articles/818278/Introducing-Calcium-for-Xamarin-Forms).

The best and most up-to-date source of information about Xamarin.Forms is the [Xamarin documentation site](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/)

Xamarin.Forms is not open-source.  It is actually a series of (closed-source) libraries and templates from Xamarin, that can be manually added to your projects as [NuGet packages](http://www.nuget.org/packages/Xamarin.Forms/).  However, there is a growing number of open-source addins or plugins for Xamarin.Forms - especially those available in [Xamarin Forms Labs](https://github.com/XForms/Xamarin-Forms-Labs) - some really great stuff there.

More Resources:
  * There are **free videos** about Xamarin.Forms - [here](http://blog.xamarin.com/webinar-recording-meet-xamarin.forms/) and  [here](http://blog.xamarin.com/video-xamarin-forms-over-90-code-re-use-and-access-to-native-features/).  Another one about building [custom control renderers](http://developer.xamarin.com/videos/cross-platform/xamarinforms-custom-renderers/).
  * As of 10/4/2014 there is an **awesome free book** available for Kindle from Amazon.com from programming legend Charles Petzold.  If you want to learn about Xamarin.Forms, [this is the place to start](http://www.amazon.com/Creating-Xamarin-Forms-Preview-Developer-Reference-ebook/dp/B00NXYJ8DK/). Seriously, stop reading and go get the book now.  The final version is expected Spring 2015, and will probably no longer be free at that point.
  * As of 10/4/2014 there is **another awesome free book** available from Falafel Consulting written by another programming legend, Jesse Liberty.  This book isn't entirely about Xamarin.Forms, but Xamarin.Forms is covered well.  Get that book  [here](http://falafel.com/landing-pages/learning-xamarin-ebook-download).
  * There is also an excellent series of blog posts about Xamarin.Forms from Jesse Liberty - available [here](http://blog.falafel.com/author/jesse-liberty/) - look for posts from July 2014.
  * Some really great **online magazine articles** about Xamarin.Forms by Wally McClure - available [here](http://visualstudiomagazine.com/articles/2014/09/01/xamarin-forms.aspx) and [here](http://visualstudiomagazine.com/articles/2014/09/01/simplifying-cross-platform-mobile-app-dev.aspx)
  * There are some great blog posts from [James Montemagno about Xamarin.Forms](http://motzcod.es/tagged/xamarin.forms)
  * A podcast interview with the main Xamarinian - [Jason Smith](https://twitter.com/jassmith87) - responsible for the design of Xamarin.Forms is [here](http://gonemobile.io/blog/e0013-xamarin-forms/)
  * A super valuable [infographic](http://cdn1.xamarin.com/webimages/images/infographics/xamarin-mobile-controls-infographic-062014.pdf) that shows how various controls are rendered on the various platforms.
  * A tutorial for creating a [REST API-based client app](http://www.dotnetcurry.com/showarticle.aspx?ID=1029) from DotNetCurry magazine. 
  * There is always **a ton of exciting stuff** being anounced on Twitter about (hashtag) [#xamarinforms](https://twitter.com/hashtag/xamarinforms?f=realtime&src=hash) - check it out!

Portable.Data.Sqlite
--------------------

As you probably know, the standard way of storing local database-type-data on mobile devices is in SQLite.  This small-footprint SQL-based database engine comes built-in on iOS and Android devices, and is easily added to all Windows platforms. SQLite is extremely well supported in the Xamarin community, with many libraries and add-ons.

I had a need to access my SQLite databases in my applications on Android, iOS and Windows from shared code (i.e. from a Portable Class Library). And I wanted things to work the same across all platforms.  Also, I like to have direct ADO.NET-style access to the tables, columns and data; I like SqlCommands and SqlDataReaders. Finally, I wanted to be able to selectively encrypt data in my databases.

So, there are excellent portable (PCL) libraries for accessing SQLite data - [here](https://github.com/ericsink/SQLitePCL.raw) and [here](https://sqlitepcl.codeplex.com/) - check those out if you are interested.  Also, there is a great full-database encrypted SQLite solution called SQLCipher - available [here](https://www.zetetic.net/sqlcipher/) - though it is not free for Xamarin developers.

But there was nothing that combined everything I was looking for into a single portable (PCL) library - *so I created it*.  It is called Portable.Data.Sqlite - and it is available as a [NuGet package](http://www.nuget.org/packages/Portable.Data.Sqlite) and all [source code is available on GitHub](https://github.com/ellisnet/Portable.Data.Sqlite).  It works **great** with Xamarin.Forms - I tweaked it to be very easy to use with the framework - and there is a ton of information about how to use it in the [GitHub repository](https://github.com/ellisnet/Portable.Data.Sqlite). Check it out and let me know if you have any questions or problems.

Note: Since I would like this information page to be useful to anyone using Xamarin.Forms, it is worth mentioning that when it comes to working with SQLite and Xamarin, most peoople choose to use the [SQLite.Net library from Frank Krueger](https://github.com/praeclarum/sqlite-net) - it makes working with SQLite easy; and you won't be writing many SQL statements as it handles the actual database operations for you (though you can craft your own SELECT statements).  It also looks like there is a popular [portable (PCL) library available for SQLite.Net from NuGet](http://www.nuget.org/packages/SQLite.Net-PCL/) available that presumably works great with Xamarin.Forms.

Sample Project Code - NAME HERE
-------------------------------

Coming soon...

