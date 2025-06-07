# Team Mood Board - Behavior Test

## Expected Behavior (Based on CodePen)

### Initial State
- [ ] Grid shows only the topic name in the center
- [ ] All emoji options are hidden
- [ ] No emoji text or vote counts are visible

### Mouse Hover Interactions
- [ ] When hovering over the grid: All emojis become visible with their text descriptions
- [ ] When mouse leaves the grid: 
  - If no emoji is selected: All emojis become hidden again
  - If an emoji is selected: Only emojis with votes are shown with vote counts (not text)

### Click Interactions
- [ ] Clicking an emoji: Selects it, shows border, triggers topic animation
- [ ] Clicking the topic: Shows all emojis with text
- [ ] Only one emoji can be selected per topic per user

### Animation
- [ ] When an emoji is selected, the topic should animate with flip-scale-down effect
- [ ] Animation should last 0.6 seconds

### Visual States
- [ ] Selected emoji has a black border
- [ ] Emoji text is shown when hovering or when no selection is made
- [ ] Vote counts are shown when not hovering and user has made a selection
- [ ] Emojis with 0 votes are hidden when showing results

## Test Cases

### Test 1: Initial Load
1. Load the page
2. Verify only topic is visible
3. Verify all emojis are hidden

### Test 2: Mouse Hover
1. Hover over the grid
2. Verify all emojis appear with text
3. Move mouse away
4. Verify all emojis disappear (since no selection made)

### Test 3: Emoji Selection
1. Hover over grid
2. Click an emoji
3. Verify topic animates
4. Verify emoji gets selected (border)
5. Move mouse away
6. Verify only selected emoji remains visible with vote count

### Test 4: Multiple Users
1. Open in two browser tabs
2. Have each tab select different emojis
3. Verify vote counts update correctly
4. Verify only emojis with votes are shown when not hovering

## Current Implementation Status
- ✅ Grid layout with 3x5 structure
- ✅ Topic centered at position 8
- ✅ Emojis at positions [2,4,6,10,12,14]
- ✅ Hover event handlers
- ✅ Click event handlers
- ✅ Animation implementation
- ✅ State management for show/hide logic
- ✅ Real-time updates via SignalR
- 🔄 Need to test all interactions work as expected

## Manual Testing Results
- [ ] Initial state correct
- [ ] Hover shows emojis with text
- [ ] Mouse leave hides emojis (no selection)
- [ ] Emoji selection works
- [ ] Topic animation triggers
- [ ] Results show vote counts
- [ ] Multiple user interaction works
- [ ] Real-time updates work
