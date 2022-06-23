echo Build Directory $(pwd)
echo NuocLanh : Starting Build IOS from Xcode on saiwks2018
# xcodebuild -workspace /Volumes/X/TestJenkin/TestProject3D/build/ios/xcode <SCHEME NAME> build
# xcodebuild -list -project "/Volumes/saiwks2018/TestJenkin/TestProject3D/build/ios/xcode/Unity-iPhone.xcodeproj"
xcodebuild archive -scheme Unity-iPhone -sdk iphoneos -allowProvisioningUpdates -archivePath Unity-iPhone.xcarchive
echo NuocLanh : Done