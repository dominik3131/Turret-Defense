### App Center Secret:
0af0ec98-6b8c-4e9e-88ae-34477ef5b560

### Add the App Center SDK to your project

Install the App Center Unity Editor Extensions plugin (https://github.com/Microsoft/AppCenter-SDK-Unity-Extension). Open the Editor Extensions via the Unity menu by selecting Window > App Center > Editor Extensions and click Install App Center SDK.

### Enable the SDK

Create an empty game object in the main scene.

In the Project window, navigate to the AppCenter folder that was added to your project. Locate the script AppCenterBehavior and drag it onto your newly created game object in the Hierarchy window.

Select this new object and add your app secret to the corresponding fields in the Inspector window. Make sure to check the Use {service} boxes for each App Center service you intend to use.

### Android app secret:

Note: If your project does not support one of the three platforms (Android/iOS/UWP) listed in the settings, simply leave the app secret field as it is; it will have no effect.

### Explore data

Now build and launch your app, then go to the Analytics section. You should see one active user and at least one session! The charts will get more relevant as you get more users. Once your app actually crashes, you will have Crashes data show up as well. You can look at the Troubleshooting section if you don't see any data.

### Use additional services

App Center’s distribution service enables your testers to get in-app updates when a new version of the app is available. To leverage the full power of distribution, add the distribute package to your project by following the steps from our distribute documentation. Your testers will be prompted with a dialog within the app that notifies them to update their current version to the latest release

### More links
https://docs.microsoft.com/en-us/appcenter/sdk/getting-started/unity
https://docs.microsoft.com/en-us/appcenter/sdk/distribute/unity
