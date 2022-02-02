# Code Style Guidelines

While it's important that everyone be able to write code in a non-constricted manner, it is for the benefit of everyone that we define and establish a clear set of rules for contributions. These rules are not hard to follow, and much of this process is automated by Visual Studio and its tools. Work smarter, not harder!

## Spaces vs Tabs and other arbitrary issues.

- Visual Studio will force you to use spaces, and these are actual hard spaces, not soft spaces - please don't try messing it up.
- Please set your git to checkout as CRLF and commit as LF (Checkout Windows Style, Commit Unix Style) in order to keep line feeds (new lines) consistent. If you don't, you'll end up generating large diffs per commit that we can't code review as efficiently (i.e. 20+ files changed, but no content added for 90% of them)
- Always leave a trailing newline at the end of a file like so: 
    ```c#
    class Life {
        public int MeaningOf() => return 42;
    }

    ```
    This tradition, while it may date back to the original C styling guidelines, has remained a staple feature commonly agreed upon by most languages, style guidelines, and linters / formatters.
- If you have long runaway lines of code (100+ characters per line -- some may say even 80+ characters per line is too much), break it up with a new line. Optimal places to put newlines are typically before operators or after commas / parentheses.
- Refactoring and renaming names should be done by doing the Right Click + Rename operation which guarantees all names will be renamed. This can be especially important when renaming variables in a class.
- Speaking of naming variables in a class, ideally private members should begin with an underscore and be made public only through a Property. This way, you can easily differentiate between the two.
- Don't introduce `null` and Null Checking unless absolutely necessary. The more `null`s we have floating around, the more possibilities that we can get screwed up.

## Pre-Commit Checks

- First things first, build it and make sure it runs. If it doesn't, fix your code, or create a branch to temporarily commit to while you tinker with it. You can then merge your branch at a later date (make sure to [rebase](https://git-scm.com/book/en/v2/Git-Branching-Rebasing) the branch to master first before committing to make sure you don't generate any conflicts with newer code!)
    - Preferrably, if you are creating a branch, [squash](https://medium.com/@slamflipstrom/a-beginners-guide-to-squashing-commits-with-git-rebase-8185cf6e62ec) (git rebase -i `<commit hash to squash to>`) all your commits into one commit then merge it so that a code review could be done on the entire change list in one swoop.
    - Extra note of caution -- when squashing or rebasing, **do not** use `git push --force` - this will actually force push **everyone's** branches, and can cost a lot of code! Please use `git push origin +mybranch:mybranch` to force push only your branch!
- Now that you have something running and (hopefully) functioning correctly, run a style check on your clone to make sure that your style complies to [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). This can be done quickly by doing (Alt + F11) or Analyze -> Run Code Analysis -> On Solution. All messages will pop up as a Message in the Error List tab. Make sure that you have Messages enabled so you can read them!
- If you are working on a file **and are 'done' or approaching 'done' with it** or you are **modifying previously existing 'complete' files**:
    - Make sure to add or update documentation for non-trivial public methods. An example of a trivial public method not needing explanation would be:
        ```c#
        public int AddOne(int x) => return x + 1; 
        ```
        Any similar method where documentation adds little to no value should not be documented.
    - Add documentation to protected or private methods when necessary to clarify the function or operation of said method. Documentation can be added by using the triple-slash (`///`) in front of a method or class which will auto-generate a documentation comment.
    - Do not add a class documentation comment to Concrete classes, and Abstract classes -- ideally your classes should be self-explanatory by the Interface comment.
    - Do not include comments inside of methods submitted to master unless absolutely necessary (no TODOs, commented out old code, or other ancient relics)
- Similarly, if your code is nearing completion or modifies 'complete' code, you should run Code Metrics on it. To do this, run Analyze -> Calculate Code Metrics -> For Solution. This will bring up a menu at the bottom that displays a "Maintainability Index" and "Cyclomatic Complexity". 
    - Ideally, you should refactor your class so that on average your Maintainability is >= 85 if possible. The main `Game1.cs` file (or whatever we rename it to) will naturally be a bit lower than this though, which is fine. 
    - You don't really need to pay too much attention to Cyclomatic Complexity unless that value is abnormally high (30-40+ in an average class). If it is, try seeing if all your conditional statements are really necessary for the class to function.

## Namespacing & Folder Organization

Ideally, we want to keep really two namespaces in the project. The first is `Engine` and the second is `Mario`. Each will have its own folder where it and its collected objects shall remain.

The `Engine` namespace should contain all necessary files, classes, and interfaces vital to the overarching design of our game such as Sprites, Commands, Factories, and State patterns and a limited subset of Concrete implementations. These concrete implementations should be things like `AnimatedSprite` or `DynamicSprite` and not `AnimatedSpriteCommand` referring to a specific `Game1` instance. Another instance would be `MarioState` should be in the `Mario` folder.

The `Mario` namespace should contain all necessary files and classes that implement and use the `Engine` but are not exclusively features of the Engine. This includes but is not limited to: Player Logic, Mario, the Game, and the World.

Inside these folders should be collections of related classes organized out into subfolders. These subfolders *should not* nest their namespaces unnecessarily. Necessary namespacing would include something like `Game.MarioState.{Super, Normal, Mini, Star, etc.}`