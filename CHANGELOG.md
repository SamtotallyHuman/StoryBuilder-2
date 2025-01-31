# StoryBuilder ChangeLog

## Release 2.4.0.0

As of Novermber 13, 2022, we've rolled out Release 2.4.0.0 for general distribution 
via the Microsoft Store. 

2.4 contains the following new/changed features:

The WebPage story element research tool introduced in Release 2.3 now has a Preferences
tab which allows you pick the search engine to use when locating the web resource you're 
looking for. 

### UI Improvements


#### Revised right-click menu

The flyout menu is a shortcut used to add new Story Elements and several other functions.
Jake's rewriten the flyout menu to make it much more user-friendly. 

#### Highlight in-process node

A StoryBuilder outline is a tree of Story Elements which are displayed in the Navigation Pane. 
Clicking (or touching) a Story Element node on the Navigation Pane displays that 
Story Element’s content in the Content Pane. A node can also be right-clicked to
display a commandbar flyout context menu. The current (clicked) node is highighted
in the Navigation Pane, but the highlight is not very visible. Right-clicking a node
momentarily highlights it but with the light theme it's almost impossible to see.

The Navigation Pane now displays the current node and the right-mouse clicked node
(used for a target for the flyout menu) using your Display Settings accent colors to 
better highlight where you are.

#### Cast List revamp

Scene Story Elements contain a Cast List control which, as its name implies,
is used to list the characters in a scene. The Cast List control is based
on a ListView and requires a convoluted set of interactions to add and
delete cast members using a second control. Weve simplified this by allowing you
to switch between a list of all characters, with a checkbox by each name to
add or remove the character to this scene's cast, or a list of just the scene's members.

#### Progress indicator

Several tasks, notably printing reports and loading installation data, may take 
a bit of time. We've added a progress indicator as an indicator that the app
hasn't frozen. 

### Default Preferences

Some Preferences data, such as the default outline and backup folder locations,
have have been updated with some defaults (including preserving previous versions' 
values) when installing StoryBuilder.

#### Codebase cleanup

Actively maintained programs tend to accumulate cruft over time. This release we've
started a process of addressing this by working through the codebase and removing
duplicate and unusued code, conforming to some newly-set naming conventions,
and making other improvements.This is a long-term process, which will continue in
future releases, but we're making progress.

#### Bug fixes:

StoryBuilder is a new product, and our number-one priority remains bug fixes and improvements.
Some specific fixes in this release include:

*Fixed a problem where the node wrapping Preference setting was not persisting.

*Fixed the app freezing when generating large reports. A progress indicator is now shown.

* Fixed a number of crashes relating to tool use and transitioning from one user action to 
another.

### Windows App SDK Api 1.2

We've updated to the latest version of the Windows App SDK (1.2).

## Release 2.3.0.0

As of October 3, 2022, we've rolled out Release 2.3.0.0 for general distribution 
via the Microsoft Store. 

2.3 has one significant new feature, the addition of researach tools. These take
the form of two new Story Element types which can be added as nodes to your outlines:
WebPage and Note nodes.

WebPage nodes are used to store links to web pages. They're implemented using the
WebView2 control, which is built on the Edge browser. A WebPage node can use search
to find a page and will persist that page's URL in your outline so that when you 
navigate to it the page is loaded and displays in the node's content area.

Note nodes are used to store text notes. They're implemented using the RichEditBox.
Major Story Element nodes (Story Overview, Problem, Character, Setting and Scene) all
have a Notes tabes which can be used to store notes about that particular Story Element,
but the new Note nodes are intended to be used to store notes about any topic  you
wish.

StoryBuilder is a new product, and our priority remains bug fixes and improvements.
2.3 is primarily a fix release, as will be future short-term releases. Some
specific fixes in this release include:

#### Implemented Single Instancing

StoryBuilder now uses Single Instancing. If the app is already open and you launch 
it again, the existing instance will be brought to the foreground rather than having
a new instance launched. While the ability to edit more than one outline at one time
has its uses, it can also cause problems. For example, if you have two instances of
StoryBuilder open and you edit the same Story Element in both instances, the changes
from one instance will overwrite the changes from the other instance. Single Instancing
prevents that from happening.

#### Codebase cleanup

Actively maintained programs tend to accumulate cruft over time. This release we've
started a process of addressing this by working through the codebase and removing
duplicate and unusued code, conforming to some newly-set naming conventions,
and making other improvements.This is a long-term process, which will continue in
future releases, but we're making progress.

#### User Manual and sample updates

We've updated the User Manual and several sample outlines to improve the documentation
and to reflect changes in the app. As with the codebase cleanup, this will be an
ongoing process. The User Manual changes are still mostly structural, and we're
well aware that line and copy edits are needed. We'll be working on those in future
releases.

#### Bug fixes:

* Fixed a bug preventing cast information from being saved.
* Fixes several issues causing progdram crashes.
* Fixed some issues relating to topics. Besides in-line topic
  data (topic/subtopic/notes), it's possible for a topic to 
  launch Notepad to display a file. This fix has that working.
* Fixed some issues with tracking changes.

https://github.com/storybuilder-org/StoryBuilder-2/compare/2.1.2.0...2.2.0.0

## Release 2.2.0.0

* As of August 31st, 2022, we've rolled out Release 2.2.0.0. We have now opened the app up to general distribution via the Microsoft Store. 
* This release has a few fixes and improvements whilst implementing new features such as the Narrative Editor.
* Optimized code
* Fixed accidental spell checking on the email box.
* Added a new menu called Narrative Tool to make editing
the narrator view easier.
* Fixed Icons on certain nodes not showing up.
* Added a prompt to open the quick start menu when opening
StoryBuilder for the first time.
* Updated the Danger Calls sample story and the tutorial in the User Manual.
* Fixed an error where the story said it was saved when it really wasn't.
* Made some minor changes to the contents of the comboboxes.
* New story overview nodes are now called the name of the story instead
of just working title.

https://github.com/storybuilder-org/StoryBuilder-2/compare/2.1.2.0...2.2.0.0

## Release 2.1.2.0

Fixed syncfusion licensing issue.

## Release 2.1.1.0

Fixed scaling issues.

Updated dependencies.

## Release 2.1.0.0

As of July 29, 2022, we've rolled out Release 2.1.0.0. This is the 
completion of a major milestone, distributing StoryBuilder 
via Windows Store direct link. 

This release has a ton of fixes, adds our privacy policy, and contains documentation improvements.
A point release, 2.1.1.0, on August 1, 2022, fixed a scaling issue we missed in 2.1.0.0. 
We allow Windows Store client installations for any Windows user who has a link to the download, from a
link through the website (https://storybuilder.org) and other channels. 

Added a roadmap

Added Autosave

Updated some combobox choices

Storybuilder will now show the changelog on an update.

Revamped Relationship layout

Updated manual

Added StoryBuilder Server support.


## Release 2.0.0.0

Fixed warning by @Rarisma in #311

Updated preferences UI

Fixed issues with Reports menu by @Rarisma in #317

Datalogging by @terrycox in #321

Fixed issues with Moving buttons

Fixed issues with generated reports by @Rarisma in #323

Updated dependencies by @Rarisma in #322

Fixed some crashes and inconsistencies in report naming by @Rarisma in #335

Make startup quicker by @Rarisma in #336

Update packages by @Rarisma in #340

Fixed CharacterName, ProblemName and SceneName control issues by @Rarisma in #341

User is now prevented from opening the add relationships menu if there arent any prospective partners
Get ready for the store by @Rarisma in #344

Fix DotEnv Requirement by @Rarisma in #346

Reverted AutoComplete controls to SyncFusionComboboxes by @Rarisma in #352

Added some new keybinds and fixes report issues relating to outertraits by @Rarisma in #355

https://github.com/storybuilder-org/StoryBuilder-2/compare/2.0.14.0...2.0.0.0

## Release 2.0.14.0

Tweak UI

Fixed logging

Fixed bugs

## Release 2.0.13.0

Fixed Numerous smaller bugs by @Rarisma in #258

Fixed crash caused by teaching tip by @terrycox in #259

Fix Dark Mode Coloring by @Rarisma in #265

Fix some fields not saving by @Rarisma in #282

Updated about pageby @Rarisma in #283

Updated search expirence by @Rarisma in #287

Fix Releationship display issue by @Rarisma in #291

Correct Setting Combobox by @terrycox in #292

Fix Logging Error by @Rarisma in #294

Added examples by @terrycox in #293

Updated Automated Release

## Release 2.0.12.0

Added privacy policy (Read it here https://github.com/storybuilder-org/StoryBuilder-2/blob/master/PRIVACY_POLICY.TXT)

Fix some issues with Cast Members

Added some tooltips

Updated repository documentation

Fixed issue with content persisting when a new story is loaded

Fixed some issues regarding dark mode

Fixed some grammar regarding search results

Added tool tip to the edit icon

Updated Scene purpose to allow multiple values

When StoryBuilder is opened, the file open menu is shown

Cleaned up code and removed unused values

Updated logging

Updated samples to fix typos and grammar

Fixed bug which would cause the report printer to make tons of reports

Renamed Literary device to Literary Technique

Fixed saveas being broken

Updated list of countrys to be much more complete

Implimented autobuilds


Made sizing better, especially for screens using scaling

Fixed issue releating to content in structure tab not saving

Fixed wording in problem page

Fixed issue with locale and season showing the wrong values

Fixed crash relating to moving certain elements

Fixed crash releating to adding cast to stories

Removed quotes and characterization aids

Fixed error caused when cancling dramatic situations

Updated dependencies

Updated File menu to show the last edited date, and the path on hover

Fixed bug which caused stock scenes to insert two nodes instead of one, and now shows default when opened.

Fixed bug which caused text to be at the right of the screen

Removed need for keys to be read through environment variables, this new system does not require the user to ddo anything

Improved logging clarity

Fixed bug which would cause crashes with teaching tips

Clicking on the save pen will now save your file





