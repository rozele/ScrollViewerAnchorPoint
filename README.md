Here are a few things I tried:
1. Attempt to run the app as is. It generally throws an exception right off the bat and removing `CanBeScrollAnchor` from [here](https://github.com/rozele/ScrollViewerAnchorPoint/blob/master/ScrollViewerAnchorPoint/MainPage.xaml#L27) seems to fix it.
2. Play around with various settings for `VerticalAnchorRatio`. According to [these docs], scrolling to the bottom of the ScrollViewer and setting `VerticalAnchorRatio` to 1.0 should keep the view anchored to the bottom even when we add views above it. This does not seem to work.
