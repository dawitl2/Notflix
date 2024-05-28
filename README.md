    # Notflix



Notflix is a comprehensive Netflix clone designed to provide an engaging and seamless movie streaming experience. This project includes an administration page for managing content and a user page for a personalized viewing experience.
This is a turm project for windows programming made 100% with c#.

## Features

### User Authentication
- **Registration and Login**: Users can sign up and log in securely.
- **Password Reset**: Users can reset their passwords via email verification to ensure account security.

### Movie Streaming
- **Multiple Servers**: Each movie is hosted on two servers. If one server fails, the application will automatically switch to the backup server, ensuring uninterrupted streaming.
- **High-Quality Playback**: Supports high-definition video streaming for an enhanced viewing experience.
- **Searching and Filtering**: The user can search or filter for movies from the database.

### Face Detection
- **Enhanced Viewing Experience**: Utilizes face detection technology to pause playback when the user is not watching, ensuring the user does not miss any part of the movie.

### Rating
- **Movie Ratings**: Users can leave a rating for the movie.

### Comments
- **User Interaction**: Users can leave comments on movies, allowing for community interaction and discussion.
- **Moderation**: Admins can manage and moderate comments to maintain a positive environment.

### Administration Panel
- **Content Management**: Administrators can add, update, and delete movies and other content.
- **User Management**: Admins can view and manage user data, including handling user issues and feedback.

## Technologies Used

### Frontend
- **WinForms**: Provides a user-friendly graphical interface for the application.

### Backend
- **MySQL**: Manages the database for storing user information, movie details, comments, and other data.

### Other Technologies
- **Face Detection**: Integrates advanced face detection algorithms to enhance user experience.
- **Dynamic Color Surround**: Real-time color analysis projects video's dominant shades on the background for a more immersive experience.
  
## Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/dawitl2/Notflix.git
    ```
2. **Set up the MySQL database using the provided scripts in the `/db` directory.**
3. **Update the configuration files with your database credentials and other necessary settings.**
4. **Build and run the application using Visual Studio.**

## Usage

1. **User Registration and Login**: Access the application and create a new account or log in with existing credentials.
2. **Browse and Stream Movies**: Navigate through the movie library, select a movie, and start streaming. The system will automatically switch servers if a failure occurs.
3. **Face Detection Setup**: Ensure your webcam is enabled to utilize the face detection feature.
4. **Comment on Movies**: Engage with the community by posting comments on movie pages.
5. **Admin Panel**: Log in with admin credentials to access the content and user management features.

## Contributions

Contributions are welcome! Please fork the repository and create a pull request.

