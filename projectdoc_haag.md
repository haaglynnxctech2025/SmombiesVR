
### Final Project Documentation — 
*Lynn Haag | Berlin, March 2026**

---

## Title

# Smombies & Zombies — *A Virtual U-Bahn Ride*

---
![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/SCROLL.png)


## Description of Content and Technical Implementation

Smombies & Zombies is a short first-person VR experience set inside a Berlin S-Bahn. You sit in U8. In your hand is a phone. Around you, zombie-like figures stand, stare, and slowly approach. The game gives you a  mechanic: keep the phone's battery alive. Tap the trigger. Keep scrolling. Arrive at the destination with a full battery — and you win.

Except you don't. At the end of the ride, you realise you have become one of them.

**"Don't you dare to look up from your phone."**

The player isn't introduced completely to how the mechanics work — but that's the trick. The player has to self-reflect and maybe ride more than once to play through all three scenarios and understand what the narrative of the game is all about. The player can take away whatever they like: whether it is to stay safe on the phone or to engage and listen to what the figures have to say. It is completely up to the player. The message of the game is still clear — wherever you are on earth, it's good to realise what the environment tries to tell you, and not to look away or hide in social feed rabbit holes for hours on end, turning away from all the good or bad things that are happening around us in this moment.

---

*"Of course, safety comes first — especially at night or as a woman alone, a phone can serve as a shield: look busy, seem unapproachable, avoid unwanted interaction. But it can also drive a wedge between generations and social groups — the young, smartphone-dependent user and everyone else who shapes the urban landscape. Every now and then, it's worth looking up. To notice what's actually reflect on what's happening around you — whether the environment has a good or bad influence on you."*

---
![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/Endszene.png)
---
The project is built entirely in **Unity 6 (6000.0.62f1 LTS)** for **Meta Quest 3**, running as a standalone Android APK. The core stack is:

- **Unity 6 + OpenXR / Oculus XR Plugin** — VR rendering and headset integration
- **XR Interaction Toolkit** — controller input, ray interactors, haptics
- **C# scripting** — all game logic written from scratch
- **Blender** — 3D assets including train wagon, phone model, hand models
- **2.5D Sprite Animation** — zombie characters rendered as animated PNG sequences on Billboard Quads
- **Meta Quest 3 via USB Link** — PC VR streaming during development

The scene consists of a single S-Bahn wagon with scrolling city textures outside the windows, animated zombie sprites seated and standing around the player, a world-space phone UI canvas with a scrolling social media feed, and a battery bar that slowly drains throughout the 60-second ride.

The game logic is built around a single variable — the battery level — which is drained over time, affected by gaze logic (looking at zombies drains it faster, looking at the phone partially restores it), and recharged by pressing the trigger or moving the thumbstick. At the end of the ride, the game checks the battery level and routes to one of three endings: Win (Zombie), Smombie (Half), or Lose (Resisted).

![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/GameMechanic.png)


## Context and Related Work

The term **"Smombie"** — a portmanteau of "Smartphone" and "Zombie" — was voted **German Youth Word of the Year in 2015** by the Langenscheidt publishing house. It describes people so absorbed in their phones that they become oblivious to their surroundings, stumbling through public spaces with their heads down, half-present, half-absent.

The inspiration for this project comes from personal experience. After years of commuting on Berlin's S- and U-Bahn, I noticed something in myself: small social interactions — eye contact, a smile, a nod — started to feel uncomfortable. Using my phone felt safe. Familiar. Easy. The discomfort of shared public space was easier to avoid than to sit with.

There's also a deeper layer to this. As a woman, a phone is sometimes a shield — a way to seem unavailable, unapproachable, busy. It's protection. But it also creates distance from the world. It can drive a wedge between generations and social groups — the young, permanently-connected user and everyone else who still shows up in shared space.

The project does not judge smartphone users. It participates in the behaviour it critiques — you play as a scroller, and the game rewards you for scrolling. The twist at the end is not punishment. It's recognition.

Related creative reference points include:
- **Ingress / Pokémon GO** — augmented reality that brings attention back to physical space
- **Black Mirror (Season 1, Episode 2: "Fifteen Million Merits"/Season 2)** — compulsive media consumption as a dystopian loop
- **Janet Cardiff's audio walks** — urban space as narrative medium
- **Hito Steyerl's "In Free Fall"** — the smartphone screen as a new floor of reality
- **Gorillaz "Clint Eastwood"** — This song and the fictional characters that the band uses across many of their songs served as a really important inspiration for my zombies. The music and the vibe felt like a perfect fit for the world of the game and the underground Berlin street narrative of the 2000s.


![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/Gorillaz_Inspo.png)


## Results

### What was built

![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/Smombieszene.png)

The final deliverable is a functional standalone VR experience playable on Meta Quest 3:

**Core loop (fully functional):**
- 60-second ride with a countdown timer
- Battery bar drains over time, changes colour from green → yellow → red
- Right trigger and thumbstick both charge the battery and advance the phone animation
- Gaze logic: looking at zombies drains battery faster; looking at the phone slows drain
- Three end states: Win (>90% battery = Zombie), Smombie (1–89%), Lose (0%)

**Environment:**
- 3D U-Bahn wagon (Blender FBX import)
- Scrolling city texture outside windows (ScrollTexture.cs)
- Train front and back illustrated planes for the illusion of a full train
- Directional light, post-processing (vignette, colour grading) for atmosphere

**Characters:**
- Multiple animated zombie sprites (2.5D PNG sequences on Billboard Quads)
- Gaze logic: zombies slowly approach when looked at, retreat when ignored
- ZombieDialog system: closest zombie shows animated text dialogue at 1.5m proximity
- Aggressive vs. normal animation frames triggered by distance

---

![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/MALE.png)

---

**Phone interaction:**
- Custom 3D phone model (Blender)
- World-space canvas with scrolling social media feed (83-frame PNG animation)
- Phone flicker effect (red glow) when battery drops below 20%
- First-person hand model (Blender, static pose)
---
![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/PHONE.png)
---

**UI and flow:**
- Start scene with countdown (15s) and trigger-to-start
- Three distinct end scenes (WinScene, LoseScene, SmombieScene) with background images, text, post-processing atmosphere
- Smombie scene includes a two-way decision: Trigger = keep scrolling (WinScene), Thumbstick = resist (LoseScene)
- Trigger-to-restart in all end scenes

**Audio:**
- Ambient train sound loop
- Zombie spatial audio (3D, proximity-based)
- Phone tap click sound

---

## Discussion of Results

This project surprised me in how much it delivered, and in how much it resisted delivery.

The core mechanic works. The battery tension is real. Testing with other people — watching them reflexively tap the trigger, watching their battery creep up, watching them arrive at the WinScene and see the word "Zombie" — produced exactly the reaction I hoped for. A beat of confusion. Then a laugh. Then something quieter.

The gaze logic adds a dimension I didn't expect to be so effective. When a zombie starts approaching because you looked at it — and the battery starts draining faster — the instinct to look back at the phone is immediate and visceral. The mechanics do the philosophical work without explanation.

What didn't fully land: the Smombie scene decision mechanic came late in development and feels undercooked. The two choices (trigger = zombie, thumbstick = resist) are correct narratively but underdeveloped visually. Given more time, I'd build this into a proper dialogue moment with the zombie.

The hand model integration was technically the most painful part of the project. Blender-to-Unity scale and transform issues consumed several days. The phone flicker effect was a last-minute addition that ended up being one of the most visually striking moments.

---
![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/GUTE.png)

## Next Steps and Future Work

If I were to continue developing this project:

**Short term:**
- Proper Smombie scene with zombie dialogue and interactive choice UI
- More diverse zombie characters with individual dialogue sets
- Haptic feedback when battery is low or zombie approaches

**Medium term:**
- NavMesh-based zombie movement (actual pathfinding rather than direct vector movement)
- Multiple train stops with varying scenarios
- A "connection" path where ignoring the phone builds a relationship with a zombie

**Long term:**
- Real-time dynamic battery affected by multiple simultaneous zombies
- Hand tracking (no controller) — scrolling with physical finger gestures
- Installation version for public display in actual S-Bahn settings
- A companion app for the phone itself, blurring the boundary between the game and the player's real device

---
![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/trainview.png)
---
## Project Documentation

### Work Diary and Process

**November – December 2025 (pre-official period)**
The project emerged from a semester of S-Bahn commuting and an awareness of my own phone habits. The original concept was much more complex — full NPC AI, branching dialogue, gaze-driven narrative. The project plan submitted in January already reflected a scaled-down MVP-first approach.

**January – February 2026**
This period was dominated by setup hell. Unity, Git, OpenXR, Quest 3 — none of it was familiar. Getting a grey cube visible in a VR headset took three days. It felt absurd at the time. In retrospect it was the most important three days of the project because it established the workflow.

The first functioning prototype — battery bar draining, trigger charging it, two end scenes loading — existed by mid-February. From there it was iteration: train environment, zombie sprites, gaze logic, phone model, audio.

**March 2026**
The final weeks were about deepening what existed rather than adding new systems. The ZombieDialog system, the phone flicker, the Smombie decision moment, and the Start Scene were all built in the last two weeks. The APK was built and sideloaded to the Quest for final testing in the last few days.

### Failure Cases Worth Documenting

- **Hand tracking abandoned:** The original plan included full hand tracking. This was cut early. The XR Interaction Toolkit hand tracking setup for beginners is not beginner-friendly. Controller input with the right trigger was implemented instead. The result is arguably better — the trigger press as a deliberate "tap" gesture is more legible than a pinch.

- **Gaze logic through walls:** The GazeController raycast correctly uses a Zombie-only layer mask, but objects inside the train wagon still occasionally block the ray to further zombies. This is a known limitation of the current setup. A future fix would place the wagon walls on a non-blocking layer.

- **VR UI buttons:** Many hours were spent trying to make a proper Ray Interactor-based UI button work in the Start Scene. This was eventually abandoned in favour of an AutoStart countdown with trigger-to-start. The lesson: VR UI interaction is one of the most complex parts of the XR Interaction Toolkit and deserves its own dedicated research sprint.

- **Scale hell:** Every Blender model came into Unity at the wrong scale. The phone model, the hand model, the train wagon — all required manual scale correction. The solution (Apply All Transforms in Blender before exporting, Scale Factor adjustment in Unity) is now second nature, but cost days.

### Categories of Work

**Creative / Artistic Development**
The visual language of the project — Comics of the 2000s, risograph, colorful and deeply layered, 2.5D zombie sprites, scrolling social feed — was developed instinctively. The aesthetic owes something to Berlin's actual U-Bahn and underground scene, vibrant and very crazy, sometimes incredebly depressing, leaving the impression of inheriting many lost souls. But the comic look makes it  little old school, remebering better times in Berlin and in general. 

**Narrative Development**
The three-state ending system (Win/Smombie/Lose) is the core narrative innovation. The reversal — winning means losing yourself — is simple but the project was designed around it from the start. The zombie dialogue ("Put the phone down.", "We are the same.", "Or just keep scrolling.") reinforces the theme without explaining it.

**Audio-Visual Design**
Sound design originally collected from freesound.org and my recording on berlin U-Bahn were mixed and put together in Ableton 12. Post-processing volumes in each scene create distinct moods. The phone flicker effect at low battery is a late addition that dramatically improves the tension of the final seconds. In the future I want to add even more sounds, also to the phone and make zombies talk more distictive, create their own language.

**Software Development**
All scripts are findable in the GitRepo SmombiesVR in Asseets/Scripts.
- `BatteryManager.cs` — drain, add, colour interpolation
- `GameManager.cs` — timer, end state routing
- `PhoneTap.cs` — trigger, thumbstick, and gaze input combined
- `GazeController.cs` + `GazeZombie.cs` — raycast-based gaze logic
- `SpriteAnimator.cs` — PNG sequence animation
- `Billboard.cs` — camera-facing quads
- `ZombieDialog.cs` + `ZombieManager.cs` — proximity dialogue system
- `PhoneFlicker.cs` — emission-based red flicker
- `AutoStart.cs` + `TriggerRestart.cs` — scene flow
- `ScrollTexture.cs` — window animation

**Research / Experimentation**
Extensive research into Unity 6 + Quest 3 compatibility. The Oculus XR Plugin vs. OpenXR decision (ultimately: Oculus plugin for Play Mode stability, with awareness that OpenXR is the recommended long-term path). Research into 2.5D billboard techniques in VR. Testing of gaze distance, zombie approach speed, and battery drain rates for gameplay balance.

### Reflection on Technical Choices

**Why Unity 6 and not an older LTS?**
Meta officially recommends Unity 6 with the Unity OpenXR Plugin as of their v74 SDK. Staying current seemed right for a new project.

**Why 2.5D sprites and not 3D characters?**
Overall design and look of the world I wanted to create. Also Rigging and animating 3D humanoid characters was outside the scope of the MVP timeline and not really fitting to the surreal language. The 2.5D sprites with billboard logic are a legitimate artistic choice and have precedent in VR art — they create a slightly surreal, comices quality that suits the project's tone. This expressive illustrative style grew on me a lot during the process, because it very different than the well known meshy/voxel/pixelated 3D look, it can serve the message much better with less render capacities and therefore express more details.

**Why a fixed-duration timer instead of a distance-based ride?**
Simplicity. One variable (time) is easier to tune and test than a moving train position. The feeling of the train moving is created through scrolling textures, which decouples visual movement from game logic.

**What would I do differently?**
Start with hand tracking research earlier. Spend less time on environment polish in the first week. Build the Win/Lose scene routing on day two, not week three — having the full loop functional early makes everything else easier to evaluate.

---
### Reflection on MVP vs Best Case

![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/TRAIN.png)

The original project plan described three states:
- **Baseline:** One room, phone UI, battery bar, one static zombie, two end states
- **Best Case:** Gaze logic, NPC AI proximity, animations, dialogue, multiple endings

The delivered project exceeds the baseline in almost every dimension and reaches or approaches the best case in several:
- ✅ Multiple animated zombie sprites
- ✅ Gaze logic (not the full proximity AI from the best case, but functional and expressive)
- ✅ Dialogue system (implemented, though a little simpler and only one-sided, for the MaxVP I want a lot more interaction and engagement for player vs. zombie)
- ✅ Three end states (Win/Smombie/Lose — plus a decision moment in the Smombie scene)
- ✅ Phone scrolling animation
- ✅ Hand model
- ❌ Full NavMesh NPC movement
- ❌ Hand tracking

The project is complete as a VR experience. It communicates the core message and it finally functions on hardware. It has a beginning, a middle, and three possible endings.



### Challenge of Comfort Zone

I had never made a VR project before and also I`had never scrpted a lot of C# before. I still had to get comfortable with the Git and Unity workflow, also Unity as a program wasreally new to me and I had to watch a lot of tutorials and use Claude for help with some a lot of the scripts.

 The learning curve was hard to climb and at times demoralising — especially the first week of just trying to see something in the headset. But the curve flattened, and by the final weeks, writing scripts, debugging gaze logic, and managing scene transitions felt like i had actually acomplished something. When I added music and a lot of the animations I became more confident and developed a smooth workflow to add more variety and depth to every scene. but once i fixed something,some other mistake came up. So in the end there is still a lot that I want to fix and improve. The worlds are not as polished as I hoped for the final MaxVp but the time was just not enough. In the end I had a lot of fun designing the overall look and the comic mood of the world and applying it all to the finished website in the end.

The most difficult part were all the technical problems where i hot stuck and lost some time that I just didn't have. Knowing when to stop debugging one thing and move to the nextwas a big learning. And knowing when good enough was actually good enough. This project taught me a lot about how to make that call, even it when something was still not working perfectly.

What I learned, concretely:
- Unity scene management and VR setup from scratch
- C# scripting for game logic
- Git version control in a real project context
- Blender to Unity asset pipeline
- XR Interaction Toolkit architecture
- The difference between a great idea and a buildable idea
- designing characters and using AI workflows
- animating 2.5D characters in Unity
- building a world around a socio-political idea and making use of game mechanics
- Website workflows and mechanics and scripting them

### Original Timeline vs Reality

The original plan scheduled four weeks of work in two phases. In practice, work was distributed unevenly — slow starts, late-night sprints, a few days completely lost to a single bug. Also I lost a huge amount of time trying to keep my agency job to be able to afford the studies. I was under a lot of pressure to begin with and used my vacation for the execution of the firstterm project. So The final three weeks I worked very long hours and some nightshifts, but they were the most productive.

The core MVP was functional by week four. The final features (ZombieDialog, phone model, Smombie decision, sound design) were built in week five and six. The project submitted is richer than the plan described, and also more honest about what was dropped, so I am happy abput that at least !

---

## How to Access and Run the Project

### Option 1 — Source Files (GitHub)

The complete Unity project is available on GitHub:

[View on GitHub](https://github.com/haaglynnxctech2025/SmombiesVR)

The repository contains all Unity source files, C# scripts, assets, and scene files needed to open and build the project in Unity 6 (6000.0.62f1 LTS).

To run in the Unity Editor:
1. Clone the repo
2. Open in Unity Hub with Unity 6 (6000.0.62f1 LTS)
3. Install packages: `com.unity.xr.management`, `com.unity.xr.openxr`, `com.unity.xr.interaction.toolkit`
4. Open `Assets/Scenes/StartScene`
5. Connect Meta Quest 3 via Link cable
6. Press Play


### Option 2 — Visit the Website

[Website] 

### Option 3 — Find .APK file on OwnCloud

[Find.APK](https://owncloud.gwdg.de/index.php/s/lkqKy0FHnFErEiY)

### Option 4 — Or just watch the Demo on YouTube!

[Watch Trailer](https://youtu.be/efc4wJ1m8m4)


![Screenshot](https://raw.githubusercontent.com/haaglynnxctech2025/SmombiesVR/main/img/SmombieSzene02.png)


---

**Lynn Haag | Submission March 2026**
