# CoHNotAlwaysOnTop
This is a simple program to put City of Heroes into a fullscreen-like state that still allows other programs that are set as "Always on Top" to properly show on top of it.

To Use:
City of heroes must be running (this should work for any variant but has only been tested with Homecoming), once the login screen appears run the program, it should work regardless of city of heroes state (fullscreen or windowed, either will result in the same fullscreen-like state). It should also work if city of heroes is already logged in and in-game or anywhere else. It however does require being ran everytime City of Heroes is started (as CoH will set itself to the state it thinks it was last in).

How it Works:
City of Heroes allows Always on Top applications to show overtop of it if it is at any size other than your exact screen resolution, so this simply removes all decoration (ensuring that, if you're in windowed mode, the titlebar and all of that doesn't get in the way), and then sets CoH to a width equal to your desktop size plus one, and height equal to your desktop size.

Why it works:
I have no idea, it just does.

How can I use this program:
Do whatever you want with it, it is licensed under the Unlicense, which essentially means it's in the public domain, and I accept no culpability for anything it may do (See the LICENSE file for further details).

How can I contribute:
Submit a Pull Request, including in the description what the added code does, and why you think it should be changed. Any and all code submitted is assumed to similarly be released under the UNLICENSE, if you're not OK with this, do not submit a pull request.