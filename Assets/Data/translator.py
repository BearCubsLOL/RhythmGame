import json

file = open('thick.csv').read().split('\n')
data = { "notes": [] }
for line in file:
    note = line.split(',')
    time_up = None
    if(len(note) > 2):
        time_up = note[2]
    data["notes"].append({
        "key": note[0],
        "time_down": note[1],
        "time_up": time_up
        })
with open('ThickOfIt.json', 'w') as f:
    json.dump(data, f)