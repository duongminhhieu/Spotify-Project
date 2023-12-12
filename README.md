# Spotify Project - MVVM Architecture

![Screenshot (147)](https://github.com/duongminhhieu/Spotify-Project/assets/76527212/f3a7acb0-92e3-49d2-ab15-a57fc6799e1a)

## Overview

Welcome to the Spotify Project, a feature-rich media player application that leverages the MVVM architecture for a robust and modular design. The application utilizes various technologies and libraries, including SQLite for data storage, WPF for the user interface, ID3 for metadata handling, and WMPLib for media playback. The implementation incorporates advanced techniques such as the Singleton Pattern and Factory Pattern to ensure efficiency and maintainability.

## Project Structure

- **Converter:** Contains converters to facilitate data binding between the view and view model.
  
- **Helper:** Holds utility classes and helper functions for various tasks within the application.

- **Models:** Defines data models representing entities used in the application, such as media files.

- **Resources:** Stores shared resources like styles, templates, and images.

- **Services:** Manages services responsible for handling specific functionalities, such as SQLite database interactions.

- **ViewModels:** Houses view models that orchestrate the logic for the corresponding views.

- **Views:** Includes the visual elements designed using WPF.

## Technologies and Libraries

- **SQLite:** A lightweight and efficient database for data storage and retrieval.

- **WPF (Windows Presentation Foundation):** Microsoft's UI framework for building desktop applications with rich user interfaces.

- **ID3:** A library for working with ID3 tags, allowing efficient handling of metadata in media files.

- **WMPLib (Windows Media Player Library):** Utilized for media playback capabilities within the application.

## Key Techniques

- **Singleton Pattern:** Ensures that certain classes have only one instance and provides a global point of access to that instance.

- **Factory Pattern:** Used for creating instances of classes without specifying their concrete classes, promoting loose coupling and flexibility.


## Core Features

1. **Add all media files to the playlist:**
   - Easily add multiple media files to the playlist at once.

2. **Remove files from the playlist:**
   - Intuitively remove specific files or clear the entire playlist.

3. **Save and load a playlist:**
   - Save your curated playlists for future use and load them seamlessly.

4. **Show the current progress and allow seeking:**
   - Visualize the current playback progress with a dynamic progress bar.
   - Effortlessly seek forward or backward within the playing file.

5. **Play in shuffle mode:**
   - Enjoy a randomized playback order for a dynamic listening experience.

6. **Play the next/previous file in the playlist:**
   - Navigate through the playlist with ease by playing the next or previous file.

## Additional Features

1. **Store recently played files:**
   - Keep a record of recently played files for quick access and reference.

2. **Keep last played position for continuous viewing:**
   - Automatically remember and resume playback from the last position.

3. **Support both audio and video files:**
   - Seamlessly play a variety of popular audio and video formats, including mp3, flv, and mpg.

4. **Display preview when seeking:**
   - Enhance the user experience by providing a visual preview while seeking through the media file.

5. **Add hooking to support global shortcut keys:**
   - Implement global shortcut keys for essential actions like pause, play, and skip to the next file.

6. **Create and manage playlists:**
   - Allow users to create multiple playlists, each with its own set of media files.

7. **Equalizer settings:**
   - Provide customizable equalizer settings for users to adjust audio output based on preferences.

8. **Lyrics display:**
   - Integrate a feature to display lyrics synchronized with the currently playing song.

9. **Visualizations:**
   - Include dynamic visualizations that respond to the audio, enhancing the overall visual experience.

10. **Smart recommendations:**
    - Implement an algorithm that suggests new tracks based on the user's listening history and preferences.

11. **Cross-platform synchronization:**
    - Enable synchronization of playlists and playback history across multiple devices.

12. **Integration with online streaming services:**
    - Optionally integrate with popular streaming services for an extended music catalog.


## Getting Started

1. **Prerequisites:** Ensure you have the necessary tools and libraries installed.
2. **Setup:** Clone the repository and follow the setup instructions in the [documentation](https://link_to_docs).
3. **Explore:** Familiarize yourself with the code structure and components in each folder.

## Contributing

1. Fork the repository.
2. Create a feature branch.
3. Make your changes.
4. Create a pull request.

