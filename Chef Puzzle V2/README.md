Description:
3D exploratory game with both visual puzzles and trivia questions.

Gameplay Description:

I focused more on the architecture, designing a solid foundation. The gameplay can be expanded with additional levels and questions easily.

Architecture:
Model-View-Controller pattern is used to achieve organization and separation of concerns.
Separate of concerns, between Game logic, Data Source, and User interaction.

DIAGRAM

For example, the User Inteface elements are fully separated from other components, such as Scene Management and Question Data.

Delegation - Delegation pattern was used for communication between then UI and Controllers. For responding to questions, the QuestionResponser has a delegate for updating the GameUI, so that it does not update the UI directly, but the updates are reflected.

Singleton - Singleton pattern is used for

GameManager is focused on the high level components. For example, it points to questionDataSource.questionCorrectValue, rather than containing that value itself.

Datasource

Extensibility - designed for expansion of levels and questions.

Key Components:

// MODEL : DATA

QuestionDataSource - Contains the Question data, including methods to access it
-- Question - Contains the question text, possible answers, and correctAnswer

Character - Contains the HP attribute for the character

GameState - retains the state of the Game, including Level, pause status, question mode, and remaining goals.

// VIEW LAYER : UI ELEMENTS

GameUI - The UI of the game, including reference to the UIText for questions, answers, and HP. Responsible for updating the UI.

Pickup - objects that user is looking for and can interact with. Each leads to a question.

// CONTROLLERS : LOGIC

GameManager - Manages the overall gameplay, moderates the relationships between all other components. Drives the overall logic of the gameplay. Passes data between the responsible components.

QuestionResponder - tracks user responses to questions, for question mode.

IntroResponder - tracks user responses to transitional screens, including the intro and game over. todo name?

SceneController - Manages Scenes and the transitions between them.

Game Design:

- 3D exploratory game with
- Pickup items are fruit or culinary objects
- Pixel font from: https://www.dafont.com/vcr-osd-mono.font

Question Data:

- Current 10 questions, as the focus of this project was the architecture and gameplay. In the future, the gameplay could be

Scenes

- Intro. Note that intro sceen is also used for Game Over and Winner state screens.
- Level 1
- Level 2

Existing components:

- FPSController was utilized

Out of scope:

- Several ideas to expand this game proved out of scope for the limited time of this project.
- Data persistence, such as hall of fame
- More than 3 Levels

Learnings:

- Originally I created specific scripts
- Unity took some time to get the hang of its quirks. After long enough it became more intuitive
- I was more interested in writing C# code than in designing in the Unity UI
- Relationships between objects and transitions between scenes are complex
- Transitions between scenes are difficult. Using DoNotDestroy. Using getInstance.
- Objects are initialized in an undefined order.
- Managing the instantiation and object relationships across multiple scenes proved to be the most challenging part, and was very time consuming to troubleshoot. Because of this, I spent less time on level development than expected.
- But the game architecture was a fun challenge and I enjoyed learning Unity and C#
