# Social Media API 

Social media RestFul API like (Twitter or FaceBook) that build with C# + .NET Core

## Tech Stack

- C#
- .NET Core
- SQL Server

## Entity and desing of the system

`Note!` Entity and attributes can change overtimes.

## 1. User Entity
Represents a user on the platform.

### Attributes:
- `id` (Primary Key)
- `username` (Unique)
- `email` (Unique)
- `password` (Hashed)
- `profile_picture` (URL)
- `bio` (Text)
- `followers` (Array of User IDs)
- `following` (Array of User IDs)
- `created_at` (Timestamp)

### Relationships:
- **One-to-Many:** A user can have many posts.
- **Many-to-Many:** Users can follow each other.

## 2. Post Entity
Represents a post created by a user.

### Attributes:
- `id` (Primary Key)
- `author_id` (Foreign Key to User)
- `content` (Text)
- `image` (URL, optional)
- `likes` (Array of User IDs)
- `created_at` (Timestamp)

### Relationships:
- **One-to-Many:** A post can have many comments.
- **Many-to-Many:** A post can be liked by many users.

## 3. Comment Entity
Represents a comment on a post.

### Attributes:
- `id` (Primary Key)
- `post_id` (Foreign Key to Post)
- `author_id` (Foreign Key to User)
- `content` (Text)
- `created_at` (Timestamp)

### Relationships:
- **Many-to-One:** A comment belongs to a post.

## 4. Notification Entity
Represents a notification for user actions like likes, comments, and follows.

### Attributes:
- `id` (Primary Key)
- `recipient_id` (Foreign Key to User)
- `sender_id` (Foreign Key to User)
- `type` (String: 'like', 'comment', 'follow')
- `post_id` (Foreign Key to Post, optional)
- `comment_id` (Foreign Key to Comment, optional)
- `created_at` (Timestamp)
- `read` (Boolean)

### Relationships:
- **Many-to-One:** A notification belongs to a recipient user.
- **Optional relationships** to Post and Comment depending on the notification type.

## 5. Like Entity
Represents a like on a post (can be embedded in the Post entity or separate).

### Attributes:
- `id` (Primary Key)
- `post_id` (Foreign Key to Post)
- `user_id` (Foreign Key to User)
- `created_at` (Timestamp)

### Relationships:
- **Many-to-One:** A like belongs to a post.
- **Many-to-One:** A like belongs to a user.

## Relationships Diagram
1. **User <-> Post:** One-to-Many (One user can create many posts)
2. **User <-> User:** Many-to-Many (Users can follow each other)
3. **Post <-> Comment:** One-to-Many (One post can have many comments)
4. **Post <-> User:** Many-to-Many (Users can like many posts, and posts can have many likes)
5. **Notification <-> User:** Many-to-One (Notifications are for users)
6. **Notification <-> Post/Comment:** Optional (Depending on notification type)
