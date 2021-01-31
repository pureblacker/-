#1、统计单个字出现的频率
#把文件夹里面的文件名存放在一个列表里面，循环访问
import os
file_path=r"‪C:\Users\YaliZhu\Desktop\数据结构实验题\数据".strip('\u202a')
#读取文件名存入列表中
name=os.listdir(file_path)

def onefre():
    #建立一个字典保存字频
    word_dict={}
    for i in name:
        #循环读取每个文件名，打开文件
        with open (file_path+"\\"+i,"r",encoding='utf-8') as file:
            #一行一行读取
            line=file.readline()
            while line:
                #一个一个词存到字典
                for word in line:
                        #如果不在字典中，说明出现次数为1
                        if word.strip() not in word_dict:
                            word_dict[word]=1
                        #否则次数加一
                        else:
                            word_dict[word]+=1
                #while循环继续条件：读取下一行
                line=file.readline()
    #将字典按字频排序，得到一个列表(按value排序x[1]，若按key排序则是x[0])
    wordfreq = sorted(word_dict.items(), key=lambda x:x[1],  reverse=True)
    #打开一个新的文件，将结果保存进文件中          
    with open(r"‪C:\Users\YaliZhu\Desktop\数据结构实验题\一元字频.txt".strip('\u202a'),"w",encoding='utf-8') as fileout:  
        print("-------一元--------")
        fileout.write("--------一元--------\n")
        for i in wordfreq:
            print("[%s]:%d次\n" %i)
            fileout.write("[%s]:%d次\n" % i)
    print("done")


def twofre():
    p=""#p用来判断是否是两个字的词
    word_dict={}#创建字典保存词频
    for i in name:
        with open(file_path+"\\"+i,"r",encoding="utf-8") as file:
            line=file.readline()
            while line:
                for word in line:
                    p+=word.strip()
                    if len(p)==2:
                        if p not in word_dict:
                            word_dict[p]=1
                        else:
                            word_dict[p]+=1
                        p=p[1:]#有个缺点就是 会把两个被空格隔开的字也视为一个词计算出现频率
                line=file.readline()
                
    wordfreq=sorted(word_dict.items(),key=lambda x:x[1],reverse=True)
    with open(r"‪C:\Users\YaliZhu\Desktop\数据结构实验题\二元字频.txt".strip("\u202a"),"a",encoding="utf-8") as fileout:
        print("-------二元--------")
        fileout.write("--------二元--------\n")
        for i in wordfreq:
            print("[%s]:%d次\n" %i)
            fileout.write("[%s]:%d次\n" %i)
        print("done")


def threefre():        
    p=""
    word_dict={}
    count=0
    for i in name:
        with open(file_path+"\\"+i,"r",encoding="utf-8") as file:
            line=file.readline()
            while line:
                for word in line:
                    p+=word.strip()
                    if len(p)==3:
                        if p not in word_dict:
                            word_dict[p]=1
                            count+=1
                        else:
                            word_dict[p]+=1
                        p=p[1:]
                line=file.readline()
    
    wordfreq=sorted(word_dict.items(),key=lambda x:x[1],reverse=True)#记得去查一查lambda啥意思和sorted的语法
    #list(word_dict.items())  不排序的话
    
    with open(r"‪C:\Users\YaliZhu\Desktop\数据结构实验题\三元字频.txt".strip("\u202a"),"a",encoding="utf-8") as fileout:
        print("-------三元--------")
        fileout.write("--------三元--------\n")
        for i in wordfreq:
            print("[%s]:%d次\n" %i)#记得去查一查python的输出控制格式
            fileout.write("[%s]:%d次\n" %i)
        print("done")
    
    
    
    
            
if __name__=="__main__":
    onefre()
    twofre()
    threefre()