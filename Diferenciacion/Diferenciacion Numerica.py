#Delgado Vasquez Erik No.Control 17211515
import sys
import math
import os
class Valores:
    def ingresar(self):
        global x4, x3, x2, x, c, xi, h
        global funcion
        print("Ingrese el valor de x4. ")
        x4=float(input())
        print("Ingrese el valor de x3. ")
        x3=float(input())
        print("Ingrese el valor de x2. ")
        x2=float(input())
        print("Ingrese el valor de x. ")
        x=float(input())
        print("Ingrese el valor de la constante. ")
        c=float(input())
        print("Ingrese el valor de xi. ")
        xi=float(input())
        print("Ingrese el valor de la h. ")
        h=float(input())
        a=(xi+(2*h))
        b=(xi+h)
        s=(xi-h)
        d=(xi-(2*h))
        p=(xi+(3*h))
        f=(xi-(3*h))
        funcion=((math.pow(a,4)*x4)+(math.pow(a,3)*x3)+(math.pow(a,2)*x2)+(a*x)+c)
        fun=((math.pow(b,4)*x4)+(math.pow(b,3)*x3)+(math.pow(b,2)*x2)+(b*x)+c)
        func=((math.pow(xi,4)*x4)+(math.pow(xi,3)*x3)+(math.pow(xi,2)*x2)+(xi*x)+c)
        fuun=((math.pow(s,4)*x4)+(math.pow(s,3)*x3)+(math.pow(s,2)*x2)+(s*x)+c)
        funn=((math.pow(d,4)*x4)+(math.pow(d,3)*x3)+(math.pow(d,2)*x2)+(d*x)+c)
        fn=((math.pow(p,4)*x4)+(math.pow(p,3)*x3)+(math.pow(p,2)*x2)+(p*x)+c)
        fu=((math.pow(f,4)*x4)+(math.pow(f,3)*x3)+(math.pow(f,2)*x2)+(f*x)+c)
        os.system('cls')
        print("\n1.-Diferenciacion centrada.\n2.-Diferenciación hacia adelante.\n3.-Diferenciación hacia atrás.")
        tipo=int(input())
        if tipo==1:
            print("\n1.-Primera derivada.\n2.-Segunda derivada.")
            der=int(input())
            if der==1:
                print("\n1.-O(h^2).\n2.-O(h^4).")
                oh=int(input())
                if oh==1:
                    resultado=((fun)-(fuun))/(2*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=((funcion))+(8*fun)-(8*fuun)+(funn)/(12*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
            elif der==2:
                print("\n1.-O(h^2).\n2.-O(h^4).")
                oh=int(input())
                if oh==1:
                    resultado=(funcion)-(2*func)+(fuun)/(math.pow(h,2))
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=(-funcion)+(16*fun)-(30*func)+(16*fuun)-(funn)/(12*math.pow(h,2))
                    print("El resultado de la aproximación es: %.4f " % (resultado))
        elif tipo==2:
            print("\n1.-Primera derivada.\n2.-Segunda derivada.")
            der=int(input())
            if der==1:
                print("\n1.-O(h).\n2.-O(h^2).")
                oh=int(input())
                if oh==1:
                    resultado=((fun)-(func))/(2*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=((-funcion)+(4*(fun))-(3*(func)))/(2*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
            elif der==2:
                print("\n1.-O(h).\n2.-O(h^2).")
                oh=int(input())
                if oh==1:
                    resultado=((funcion)-(2*fun)+(func)/(math.pow(h,2)))
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=((-fn)+(4*funcion)-(5*fun)+(2*func)/(math.pow(h,2)))
                    print("El resultado de la aproximación es %.4f: " % (resultado))
        elif tipo==3:
            print("\n1.-Primera derivada.\n2.-Segunda derivada.")
            der=int(input())
            if der==1:
                print("\n1.-O(h).\n2.-O(h^2).")
                oh=int(input())
                if oh==1:
                    resultado=((func)-(fuun))/(2*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=((3*func)-(4*fuun)+(1*funn))/(2*h)
                    print("El resultado de la aproximación es: %.4f " % (resultado))
            elif der==2:
                print("\n1.-O(h).\n2.-O(h^2).")
                oh=int(input())
                if oh==1:
                    resultado=((func)-(2*fuun)+(funcion))/(math.pow(h,2))
                    print("El resultado de la aproximación es: %.4f " % (resultado))
                elif oh==2:
                    resultado=((2*func)-(5*fuun)+(4*funcion)-(fu))/(math.pow(h,2))
                    print("El resultado de la aproximación es: %.4f " % (resultado))
do=Valores()
do.ingresar()
