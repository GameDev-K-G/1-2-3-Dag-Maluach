# שם המשחק: 1, 2, 3 דג מלוח
  

## האם תצליחו להגיע עד לקו הסיום מבלי למות? ##
  
  

## מהות המשחק 

 על השחקן להגיע מנקודת ההתחלה עד לנקודת הסיום.
  בנקודת הסיום עומדת ילדה שכל כמה שניות.
 מסתובבת עם הגב אל השחקן וקוראת "1, 2, 3 דג מלוח", ומסתובבת חזרה אל השחקן.
 בזמן הזה שהלדה מסתובבת, השחקן יוכל להתקדם לעבר נק' הסיום ולנסות לעבור את המכשולים מבלי להיפגע.
  במהלך המסלול השחקן יוכל לאסוף מטבעות שייתנו לו מהירות גבוה, יהיו גם קוצנים שמאטים את השחקן לכמה שניות.
  שחקן שהילדה ראתה אותו זז נפסל ויוצא מהמשחק.

 
 ### המשחק מיועד למחשב.
 
## תמונה הממחישה את המשחק:

<img width="678" alt="Screenshot 2023-05-14 at 12 39 21" src="https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/assets/58401645/f2d2f9d6-6bce-4979-84cb-e47e37e42496">


## רכיבים רשמיים
* קישור לקובץ רכיבי המשחק הרשמיים :
[formal-elements.md](https://github.com/GameDev-K-G/1-2-3-/blob/main/formal-elements.md)


 ## פירוט הקוד:
 1)תזוזת השחקן:
 לתזוזה של של השחקן יש תנאי רק אם canMove שהשמשתנה הזה משתנה לtrue רק אחרי שהספירה לתחילת המשחק מסתיימת
 בקוד אנו בודקים אם "boosting" ז״א אם הוא לקח מהירות ואז המהירות שלו גדלה  ואם הוא ״injured״ שזה אומר שהוא נפגע ואז המהירות שלו נהיית יותר איטית
 השחקן זז לפי חיצי המקלדת ויכול לקפוץ במקש space. 
 הדמות של השחק לקוחה מmixamo ולכל תזוזה שלו מותאמת האנימציה המתאימה. <br />
[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Player/InputMover.cs)

2)האוייב-הסופרת:
הדמות של הסופרת גם לקוחה מmixmo. 
 <br />
 הסופרת מסתובבת באמצעות אנימציה עם הגבלשחקן וברגע שהיא מסתובבת מופעל הקטע קוד של הספירה.
כשהיא מסיימת לספור היא מסתובבת חזרה לשחקן בזמן הזה אסור לשחקן לזוז.  <br /> אני בודקים על זה ע״י כך שכל מילישניות מופעלת פונקציית הEnd()
בפונקציה נבדק אם בשחקן לחץ על אחד מחיצי התזוזה שלו במקלדת, אם הוא זז אז הסופרת ממקמת את עצמה בציר האיקס למיקום של השחקן, מופעל קטע הקוד ״ראיתי אותך״ ואנימציה של הצבעה לכיוון השחקן. <br />
נשלחת הודעה לlevel controll שהמשחק נגמר והזמן נעצר וגם מסך הסיום יופיע לאחר כמה שניות שהשחקן נפסל. <br />
[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Rotation.cs)

3)מנהל המשחק- Level Controll  <br />
יש לו כמה סקריפטים הוא מטפל בהם:  <br />
א. LevelStarter - מפעיל את הספירה, לאחר הספירה נותן רשות לשחקן לזוז ואומר לסופרת להסתובב כדי שהשחקן יתחיל לשחק, ומפעיל את הטיימר של השחקן.
 <br />
[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Environment/LevelStarter.cs)
 <br />
ב. GameOverSequence - עוצר את השעון, מפעיל מוזיקה של פסילה ומפעיל את המסך הסיום.
 <br />
[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Environment/GameOverSequence.cs)

4)מכשולים:
המכשולים בנויים מbox collider שמסומן בטריגר יש להם את הסקריפט ObstacleCollisin שבו מפעיל את הboolean שאומר לשחקן הוא לא יכול לזוז (כדי שלא יוכל יעבור דרך האובייקט) מופעלת מוזיקת התנגשות ואנימציה של נפילה.
אם הסופרה לא מסתכלת על אז השחקן אז אנימציה של עמידה מופעלת על השחקן לאחר שהוא נופל אך אם הסופרת מסתכלת לא מופעלת האנימציה הוא יחזור לעמוד כשהוא ילחץ על המשקשים במקלדת שזה מוגדל בקוד של התזוזה של השחקן.
 <br />
[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Environment/ObstacleCollisin.cs)


5) אזהרות:  <br />
למכשול של הבול עץ מוצמד collider עם טריגר שממוקם מספר צעדים לפני המכשול כך שברגע שהשחקן מתקרב לבול עץ מופיעה לו הודעת אזהרה ״jump״ ובאופן דומה קורה גם עם הקוצנים שבדרך שלפני שאתה מתקרב אליהם מופעלת הודעת אזהרה שהם מאיטים את מהירותך.
 <br />[לחץ כאן על מנת לראות את הסקריפט](https://github.com/GameDev-K-G/1-2-3-Dag-Maluach/blob/main/Assets/Scripts/Warning.cs)

*ברגע שמופעל מסך הסיום מופיעים הכפתורים לשלב הבא ולשמירת תוצאות, כפתרורים אלה עדיין לא עובדים.
    



* קישור למשחק ב  :
[itch.io](https://gamedevk-g.itch.io/dagmaluach3d)
 
## תהנו :smiley:
</div>



