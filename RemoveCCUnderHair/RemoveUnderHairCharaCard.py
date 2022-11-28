import os
import time
from kkloader import KoikatuCharaData

def main():
    PNGNum = 0
    CCNum = 0
    ChangedNum = 0
    root = "."
    InitTime = time.perf_counter()
    LastTime = InitTime
    for dirpath, dirnames, filenames in os.walk(root):
        for filepath in filenames:
            if filepath.endswith('.png'):
                PNGNum += 1
                TotalFilePath = os.path.join(dirpath, filepath)
                try:
                    kc = KoikatuCharaData.load(TotalFilePath)
                    if (not hasattr(kc, "Custom")):
                        continue
                    if kc["Custom"]["body"]["underhairId"] != 0:
                        kc["Custom"]["body"]["underhairId"] = 0
                        ''' Set its color transparent in case using mod item '''
                        kc["Custom"]["body"]["underhairColor"][3] = 0.0
                        kc.save(TotalFilePath)
                        ChangedNum += 1
                    CCNum += 1
                except Exception:
                    pass
        if time.perf_counter() - LastTime > 10 :
            LastTime = time.perf_counter()
            print("Run " + str(LastTime - InitTime) + " seconds:")
            print("PNGNum: " + str(PNGNum))
            print("CCNum: " + str(CCNum))
            print("ChangedNum: " + str(ChangedNum))
            print("")
            
    
    print("Runs " + str(time.perf_counter() - InitTime) + " seconds:")
    print("PNGNum: " + str(PNGNum))
    print("CCNum: " + str(CCNum))
    print("ChangedNum: " + str(ChangedNum))
    print("")
    os.system('pause')

if __name__ == '__main__':
    main()