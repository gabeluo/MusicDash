# MusicDash
A 2D endless platformer that builds the level in real-time based on the music playing.

# What is it?
The game was developed in Unity and is a 2D endless platformer, but the platforms are created according to the bars in the music. The game uses the Spotify API to get a thorough audio analysis of the song that is playing in the background. For this demo the song chose was "Mr. Blue Sky" by Electric Light Orchestra. Due to the time constraints, the factor used to determine how the game looked was the length of each bar to keep things simple. Every time a new bar starts, a new platform is created. You will notice this in the gameplay where the new platforms appear synced up to the music.

The game uses the Spotify API, but does not currently support constantly refreshing the token. To play the game on your computer, please follow the following steps:

To run the game, first go to the link below and click on the "Get Token" button to get a token by logging in with your Spotify Account.
https://developer.spotify.com/console/get-audio-analysis-track/?id=06AKEBrKUckW0KREUWRnvT

Next, copy the token and paste it into line 34, replacing the previous token. Make sure to include the quotation marks.

Open the project in Unity, build, and run.