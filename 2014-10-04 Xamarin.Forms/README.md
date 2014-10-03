Xamarin.Forms Presentation - 10/04/2014
=======================================

Short link to get to this presentation folder: http://bit.ly/xamforms

Table of Contents
-----------------

  1. [Information (and links to information) about Xamarin.Forms](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#information-about-xamarinforms)
  2. [Explanation of my cross-platform Sqlite library](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#portabledatasqlite) that works *excellently* with Xamarin.Forms - Portable.Data.Sqlite - and links to get the code and NuGet package
  3. [Sample project code - NAME HERE](https://github.com/ellisnet/TwinCitiesCodeCamp/tree/master/2014-10-04%20Xamarin.Forms#sample-project-code) - information about the sample application/demo project that I will build and demonstrate in my presentation.

Information about Xamarin.Forms
-------------------------------

  * Xamarin.Forms is a cross-platform framework that runs on top of [Xamarin](http://xamarin.com/platform) - it allows the same shared code application to (be compiled to) run on iOS, Android and Windows Phone (with possible future support for Windows 10?). It is very important to know that a Xamarin.Forms application for any of these platforms is a **native application** - for each of the platforms, the shared code (and a platform-specific stub) is **compiled to native code** that looks the same to the device as an application that was programmed using the native tools (Xcode/Objective-C/Swift on iOS, Java/Android Studio on Android, .NET on Windows). Xamarin.Forms is not a web-based or hybrid solution or something like the Java-Runtime-Engine-write-once-run-poorly-everywhere "cross platform" platforms of the past.
  * With Xamarin.Forms, all code is written in C# and user-interfaces can (optionally) be written in the XAML mark up language from Microsoft; you can write platform-specific code, but the goal really is to have most of your code be cross-platform in the shared project.
  * The best and most up-to-date source of information about Xamarin.Forms is the [Xamarin documentation site](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/)
  * Xamarin.Forms is not open-source.  It is actually a series of (closed-source) libraries and templates from Xamarin, that can be manually added to your projects as [NuGet packages](http://www.nuget.org/packages/Xamarin.Forms/).  However, there is a growing number of open-source addins or plugins for Xamarin.Forms - especially those available in [Xamarin Forms Labs](https://github.com/XForms/Xamarin-Forms-Labs) - some really great stuff there.
  * **Free videos** about Xamarin.Forms - [here](http://blog.xamarin.com/webinar-recording-meet-xamarin.forms/) and  [here](http://blog.xamarin.com/video-xamarin-forms-over-90-code-re-use-and-access-to-native-features/)
  * As of 10/4/2014 there is an **awesome free book** available for Kindle from Amazon.com from programming legend Charles Petzold.  If you want to learn about Xamarin.Forms, [this is the place to start](http://www.amazon.com/Creating-Xamarin-Forms-Preview-Developer-Reference-ebook/dp/B00NXYJ8DK/). Seriously, stop reading and go get the book now.  The final version is expected Spring 2015, and will probably no longer be free at that point.
  * As of 10/4/2014 there is **another awesome free book** available from Falafel Consulting written by another programming legend, Jesse Liberty.  This book isn't entirely about Xamarin.Forms, but Xamarin.Forms is covered.  Get that book  [here](http://falafel.com/landing-pages/learning-xamarin-ebook-download).
  * There is also an excellent series of blog posts about Xamarin.Forms from Jesse Liberty - available [here](http://blog.falafel.com/author/jesse-liberty/) - look for posts from July 2014.
  * Really great **online magazine articles** about Xamarin.Forms by Wally McClure - available [here](http://visualstudiomagazine.com/articles/2014/09/01/xamarin-forms.aspx) and [here](http://visualstudiomagazine.com/articles/2014/09/01/simplifying-cross-platform-mobile-app-dev.aspx)
  * There are some great blog posts from [James Montemagno about Xamarin.Forms](http://motzcod.es/)
  * There is always **a ton of exciting stuff** being anounced on Twitter about (hashtag) [#xamarinforms](https://twitter.com/hashtag/xamarinforms?f=realtime&src=hash) - check it out!

Portable.Data.Sqlite
--------------------

As you probably know, the standard way of storing local database-type-data on mobile devices is in SQLite.  This small-footprint SQL-based database engine comes built-in on iOS and Android devices, and is easily added to all Windows platform. SQLite is extremely well supported in the Xamarin community, with many libraries and add-ons.

I had a need to access my SQLite databases on Android, iOS and Windows from shared code (i.e. from a Portable Class Library). And I wanted things to work the same across platforms.  Also, I like to have direct ADO.NET-style access to the tables, columns and data; I like SqlCommands and SqlDataReaders. Finally, I wanted to be able selectively encrypt data in my databases.

So, there are excellent portable (PCL) libraries for accessing SQLite data - [here](https://github.com/ericsink/SQLitePCL.raw) and [here](https://sqlitepcl.codeplex.com/) - check those out if you are interested.  Also, there is a great encrypted SQLite solution called SQLCipher - available [here](https://www.zetetic.net/sqlcipher/) - though it is not free for Xamarin developers.

But there was nothing that combined everything I was looking for into a single portable (PCL) library - *so I created it*.  It is called Portable.Data.Sqlite - and it is available as a [NuGet package](http://www.nuget.org/packages/Portable.Data.Sqlite) and all [source code is available on GitHub](https://github.com/ellisnet/Portable.Data.Sqlite).  It works **great** with Xamarin.Forms - I tweaked it to be very easy to use with that framework - and there is a ton of information about how to use it in the [GitHub repository](https://github.com/ellisnet/Portable.Data.Sqlite). Check it out and let me know if you have any questions or problems.

Sample Project Code - NAME HERE
-------------------------------

Coming soon...

