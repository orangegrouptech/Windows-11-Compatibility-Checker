# Windows-11-Compatibility-Checker
Checks if your system meets the requirements of Windows 11.

This app features a better UI than WhyNotWin11.

If you don't trust me you can decompile the app, it's not obfuscated. Also, f you Microsoft for flagging this as malware but refusing to add the PanOS malware to your db. This piece of software is safe to use on your host, ignore any false positives

**Requirements**
- .NET Framework 4.5 or later
- Admin because the TPM status check command requires admin
- Windows 7 or later

**Known issues**
- App will seem blurry on displays with a high DPI scaling. ~~I may fix this issue if I'm in a mood to release a separate build for such devices ;)~~
- App may hang or stop responding when checking DirectX version for the first time. Just be patient.

![image](https://user-images.githubusercontent.com/63195743/123732321-50798000-d8cc-11eb-95d5-ed092e53e596.png)

![image](https://user-images.githubusercontent.com/63195743/123904190-a7518900-d9a2-11eb-884c-fe067c99a086.png)

![image](https://user-images.githubusercontent.com/63195743/123904208-b0425a80-d9a2-11eb-8f4c-9a6a08eb1244.png)


**To-do list**

Nothing rn, if you have something to suggest you can create an issue

**Compiling from source code**

Just open the solution in Visual Studio or JetBrains and click the (re)build button

If you run this on Windows 11, you'd get a friendly message
