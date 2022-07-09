#!/usr/bin/python
import random
import requests
import json


original_text = """Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."""
imageList = []

for count in range(50):
    result = False
    while result == False:
        random_number = random.randint(0,16777215)
        hex_number = str(hex(random_number)).upper()

        image = {
        "id": count,
        "title": ''.join(random.choice(original_text) for _ in range(50)),
        "url": "https://via.placeholder.com/600/{0}.png".format(hex_number),
        "thumbnailUrl": "https://via.placeholder.com/100/{0}.png".format(hex_number)
        }

        responseUrl = requests.get(image["url"])
        responseThumbnailUrl = requests.get(image["thumbnailUrl"])
        print("HEX: #" + hex_number + ", URL's:" + image["url"] + ":" + str(responseUrl.status_code) + " - " + image["thumbnailUrl"] + ":" + str(responseThumbnailUrl.status_code) + " - ID/Count: " + str(count))

        if responseUrl.status_code != 410 and responseThumbnailUrl.status_code != 410:
            result = True


    # If it worked we add the object
    imageList.append(image)
    


dbObject = {
    "photos": imageList,
}


dbJson = json.dumps(dbObject, indent=4)

print()
print()
print()
print(dbJson)

file1 = open('db.json', 'w')
file1.writelines(dbJson)