using System;
using System.Collections.Generic;
using System.Text;

namespace CalcoloRegressione
{
    class Calcolo
    {

        double[] AIncognito = new double[6];    // Parametri da calcolare
        double ah_r;
        double ah_c;
        double[] ODPunto = new double[6];       // Vettore contenente fino a 6 densità ottiche
        double[] ConcPunto = new double[6];     // Vettore contenente fino a 6 concentrazioni
        int ncal;                               // uso interno
        int errore;                             //  // Errore di regressione
        public int model;                              // Modello matematico :
        const double AEPSILON = 0.001;
        const double AHUGE = 1.0E+308;
        const double AMINIMO = 1.0E-308;
        Boolean mostraprogressi;
        double as_c;
        double as_r;
        double od;
        double[,] aa = new double[5, 6];// 5 vettori di 5 elementi
        double[] a1 = new double[6];
        double as_d;
        double aaa;
        double acc;
        int xp;
        double amain_diag;
        double aneg_r;
        double at;
        double at1;
        double af;
        double afprime;
        double ax1;
        double ax;
        int I7;
        double aconverge;
        double amininmo;
        double at0;
        double at2;
        double asd;
        double appo;
        double aoldconc;
        double ar0;
        int para;
        int iter;
        int I;
        int J7;
        int I8;
        int J8;
        double ak;
        double a;
        double arss;
        double athis_c;
        double athis_r;
        double aold_sd;
        double alambda;
        double ab;
        double at_sd;
        double anew_lamb;
        double adiff;
        double afirst_element;

        public Calcolo(int modello, ref double[] Param, int Numerocalibratori, ref int ErroreRegressione, double Od, ref double Concentrazione)
        {
            // Entro qui perche data una DO voglio conoscere la relativa concentrazione
            model = modello;
            for (int i = 0; i > 6; i++)
            {
                AIncognito[i] = Param[i];
                ncal = Numerocalibratori;
                as_r = Od;
                // Call CalcoloConc()
            }

        }

        public double inizializza5()
        {
            //  double[] ConcPunto = new double[6];
            //  double[] ODPunto = new double[6];
            //  double[] a1 = new double[6];
            //  double at;
            //  double aoldconc;
            //  double Ak;
            //  double ar0;


            ak = 1.1 * (ODPunto[ncal - 1] - ar0);

            for (int i = 0; i <= ncal - 1; i++)
            {
                // For I = 0 To ncal - 1
                if (ODPunto[i] != ar0)
                {
                    if (ConcPunto[i] != aoldconc)
                    {
                        aoldconc = ConcPunto[i];
                        a1[1] = Math.Log(ConcPunto[i]);
                        a1[2] = ConcPunto[i];
                    }
                    at = ODPunto[I] - ar0;
                    if (at == 0)
                    {
                        errore = 1;
                        return 1.0;
                    };

                    a1[3] = Math.Log(at / (ak - at));
                    xp = 3;
                     Stuff();
                }

            }

            xp = 3;
            Solve();
            a = aa[0, 3];
            ab = aa[1, 3];
            acc = aa[2, 3];

            return 0;

        }

        private int Solve()
        {


            errore = 0;

            //' Risolve semplificando il sestema nella matrice aa
            // '13040   Rem --- SOLVE ------------
            // ' 1) porta tutte le righe della matrice ad avere 1 al primo posto
            for (int I7 = 0; I7 < xp - 1; I7++)
            {
                //I7 = 0 To xp -1
                amain_diag = aa[I7, I7];

                //    IF amain_diag# < 1E-12 THEN errore = 1: RETURN
                for (int J7 = 0; J7 < xp; J7++)
                {

                    aa[I7, J7] = aa[I7, J7] / amain_diag;
                }
                int I8 = 0;

                do
                {

                    if (I8 == I7)
                    {
                        I8++;
                    };
                    int J8 = (I8 % xp);
                    afirst_element = aa[J8, I7];

                    for (int J7 = 0; J7 < xp; J7++)
                    {
                        aa[J8, J7] = aa[J8, J7] - afirst_element * aa[I7, J7];
                    }

                    I8 = I8 + 1;
                } while (I8 < xp);

            } 
                return errore;
        }

            int Stuff()
            {
                return 0;
            }

        }
    }


 //       ;
//        //Calcola(int modello , ref double[] AIncognito, int Numerocalibratori , ref int ErroreRegressione , double Od , ref double Concentrazione )
//        //    {
//        //        int x;
//        //        for (x = 0; x < 6; x++)
//        //        {
//        //                 ncal = Numerocalibratori; 
//        //            // non so se serve
//        //            errore = 0;
//        //            model = modello;
//        //            as_r = Od;
//        //        }


//        //    ErroreRegressione = errore

//        //    If errore = 0 Then
//        //        Concentrazione = as_c
//        //    Else
//        //        Concentrazione = 0
//        //    End If

//        //End Sub


//        Public Calibramodello(int modello, double[] concentrazioni, double[] odd, int Numerocalibratori, Double[] Parametri[] ,
//            ref int ErroreRegressione, ref double Hr, ref doubel Hc, Boolean MostraProgressi_ = False)
//        {


//            for (int appo = ncal; appo < 6; appo++) {
//                AIncognito(appo) = Parametri(appo)
//            }


//            ncal = Numerocalibratori  // non so se serve
//              for (int appo = 1; appo < (ncal - 1); appo++)
//            {

//                For appo = 0 To(ncal - 1)
//            ConcPunto(appo) = ods(appo); // concentrazioni(appo)
//                ODPunto(appo) = concentrazioni(appo); //ods(appo)
//            }


//            If(ncal < 6) {
//                for (int appo = ncal; appo < 6; appo++)
//                {


//                    ConcPunto(appo) = 0;
//                    ODPunto(appo) = 0;
//                }
//            }



//            errore = 0;
//            model = modello;
//            mostraprogressi = MostraProgressi_;

//            call FittingCurve()

//            // return the parameters
//            for (int appo = 0; app < 6; appo++)
//            {
//                Parametri(appo) = AIncognito(appo);
//            }

//            Hr = ah_r;
//            Hc = ah_c;
//            ErroreRegressione = errore;



//            //       //PRINT USING "& ##.###### "; "R0="; ar0#; "K="; ak#; "A="; a#; "B="; ab#; "C="; acc#; "D.S.="; asd#
//            //        ah_c = ConcPunto(ncal - 1) * 1.1
//            //        as_c = ah_c
//            //        calcolorate (model)    // AIncognito, as_r, as_c, errore, model, ah_r, ah_c
//            //        //(ByRef AIncognito(), ByRef as_r, ByRef as_c, ByRef errore, ByRef model, ByRef ah_r, ByRef ah_c)
//            //        ah_r = as_r
//            //        GoSub 13300
//            // DAti ncal punti memorizzati in ConcPunto ed ODPunto calcola i valori dei parametri del modello


//            //( ConcPunto(),  OD(),  model, ncal,  AIncognito,  errore,  ah_r,  ah_c)
//        }
//        ;
//        // ODPunto e ConcPunto vanno a coppie eson oi punti di calibrazione
//        //Public,  od As Double
//        //Public Sub CalcoloConc(od() As Double, conc() As Double, ByRef parametri() As Double, ByRef model As Integer, ByRef hr As Double, ByRef hc As Double, ByRef Rate As Double, ByRef Concentrazione As Double)
//        Private Sub CalcoloConc() //modello As Integer, Parametri() As Double, Numerocalibratori As Integer, ByRef errore As Integer, Od As Double, Concentrazione As Double)
//            // Aincognito devono essere gia valorizzati in memoria
//            // As_r è la densità ottica di cui si vuole conoscere la concentrazione
//            // As_c è la concentrazione risultante, e conterrà il risultato
//            // Model è il modello scelto
//            // ah_r =?
//            // Ah_c = ?
//            //( AIncognito,  as_r,  as_c,  errore,  model,  ah_r,  ah_c)
//        On Error GoTo errconc


//            switch case model;

//           // REM --- QUANTATE -------
//          //  Select Case model

//                Case 6  // modello lineare
//                    // Se devo usare le due costanti fattore + intercetta
//                    as_c = (as_r - AIncognito[0]) / AIncognito[1];

//                Case Else

//                If model<> 5 Then
//                    aneg_r# = AIncognito(0)
//                Else
//                    aneg_r# = AIncognito(0) + AIncognito(1) / (1.0# + Math.Exp(-AIncognito(2)))
//                End If
//                If (as_r <= aneg_r# And AIncognito(1) >= 0) Or (as_r >= aneg_r# And AIncognito(1) < 0) Then
//                    If model<> 4 Then
//                        as_c = 0

//                        Exit Sub
//                    End If

//                End If

//                Select Case model

//                        Case 1
//                            at# = (as_r - AIncognito(0)) / (AIncognito(1) - (as_r - AIncognito(0)))

//                            If at# <= 0 Then errore = 2 : Exit Sub
//                            at1# = AIncognito(3)

//                            If at1# < 0 Then at1# = -at1#
//                            If at1# < AMINIMO# * 10 Then errore = 2 : Exit Sub
//                            at1# = Log(at#)
//                            as_c = Exp(1.0# / AIncognito(3) * (at1# - AIncognito(2)))

//                        Case 2
//                            ax# = Log(((as_r - AIncognito(0)) / (ah_r - AIncognito(0))) * ah_c)
//                            at# = Log((as_r - AIncognito(0)) / (AIncognito(1) - (as_r - AIncognito(0))))

//                            For I7 = 0 To 25
//                                at1# = AIncognito(4) * Exp(ax#)
//                                af# = AIncognito(2) + AIncognito(3) * ax# + at1# - at#
//                                afprime# = AIncognito(3) + (AIncognito(4) * Exp(ax#))
//                                ax1# = ax# - (af# / afprime#)
//                                ax# = ax1#
//                                aconverge# = af# / afprime#

//                                If aconverge# < 0 Then aconverge# = -aconverge#
//                                If aconverge# <= 0.0001 Then
//                                    as_c = Exp(ax#)

//                                    Exit Sub

//                                End If

//                            Next I7

//                            errore = 2

//                        Case 3
//                            ax# = Log(((as_r - AIncognito(0)) / (ah_r - AIncognito(0))) * ah_c)
//                            at# = Log((as_r - AIncognito(0)) / AIncognito(1))

//                            For I7 = 0 To 25
//                                af# = (((((ax# * AIncognito(4)) + AIncognito(3)) * ax#) + AIncognito(2)) * ax#) - at#
//                                afprime# = (((3.0# * AIncognito(4) * ax#) + (2.0# * AIncognito(3))) * ax#) + AIncognito(2)
//                                ax1# = ax# - (af# / afprime#)
//                                ax# = ax1#
//                                aconverge# = af# / afprime#

//                                If aconverge# < 0 Then aconverge# = -aconverge#
//                                If aconverge# <= 0.0001 Then
//                                    as_c = Exp(ax#)

//                                    Exit Sub

//                                End If

//                            Next I7

//                            errore = 2

//                        Case 4
//                            at# = (as_r - AIncognito(0)) / 100
//                            at1# = AIncognito(1)
//                            at1# = at1# + AIncognito(2) * at#
//                            at1# = at1# + AIncognito(3) * at# * at#
//                            at1# = at1# + AIncognito(4) * at# * at# * at#
//                            as_c = Exp(at1#)

//                        Case 5
//                            at# = (as_r - AIncognito(0)) / (AIncognito(1) - (as_r - AIncognito(0)))

//                            If at# <= 0 Then errore = 2 : Exit Sub
//                            at1# = AIncognito(3)

//                            If at1# < 0 Then at1# = -at1#
//                            If at1# < amininmo# * 10 Then errore = 2 : Exit Sub
//                            at1# = Log(at#)
//                            as_c = 1 / AIncognito(3) * (at1# - AIncognito(2))
//                    End Select
//            End Select

//            Exit Sub

//errconc:
//            errore = 2

//            Exit Sub

//        End Sub

//        Public Sub calcolorate(model As Integer)

//            //(ByRef AIncognito(), ByRef as_r, ByRef as_c, ByRef errore, ByRef model, ByRef ah_r, ByRef ah_c)
//            On Error GoTo errrate

//            REM-- - INV.QUANT------ -
//            If as_c = 0 Then
//                If model <> 5 Then as_r = AIncognito(0) Else as_r = AIncognito(0) + AIncognito(1) / (1 + Exp(-AIncognito(2)))

//                Exit Sub

//            End If

//            Select Case model

//                Case 1
//                    REM-- - INV1------ -
//                    at# = Log(as_c)
//                    at0# = Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c)))
//                    at1# = 1.0# / (1.0# + Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c))))
//                    as_r = AIncognito(0) + AIncognito(1) * (1.0# / (1.0# + Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c)))))

//                Case 2
//                    REM-- - INV2------ -
//                    at# = Log(as_c)
//                    at0# = Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c) + AIncognito(4) * as_c))
//                    at1# = 1.0# / (1 + Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c) + AIncognito(4) * as_c)))
//                    as_r = AIncognito(0) + AIncognito(1) * (1.0# / (1 + Exp(-(AIncognito(2) + AIncognito(3) * Log(as_c) + AIncognito(4) * as_c))))

//                Case 3
//                    REM-- - INV3------ -
//                    at# = Log(as_c)
//                    at1# = (Log(as_c) ^ 2)
//                    at0# = Exp(AIncognito(2) * Log(as_c) + AIncognito(3) * (Log(as_c) ^ 2) + AIncognito(4) * (Log(as_c) ^ 3))
//                    as_r = AIncognito(0) + AIncognito(1) * Exp(AIncognito(2) * Log(as_c) + AIncognito(3) * (Log(as_c) ^ 2) + AIncognito(4) * (Log(as_c) ^ 3))

//                Case 4
//                    REM-- - INV4------ -
//                    ax# = ((as_c / ah_c) * (ah_r - AIncognito(0))) / 100
//                    at# = Log(as_c) - AIncognito(1)

//                    For I7 = 0 To 25
//                        at1# = AIncognito(3) * ax#
//                        at2# = AIncognito(4) * ax# * ax#
//                        af# = at# - AIncognito(2) * ax# - at1# * ax# - at2# * ax#
//                        afprime# = -AIncognito(2) - at1# * 2 - at2# * 3
//                        ax# = ax# - (af# / afprime#)
//                        aconverge# = af# / afprime#

//                        If aconverge# < 0 Then aconverge# = -aconverge#
//                        If aconverge# <= 0.0001 Then
//                            as_r = ax# * 100 + AIncognito(0)

//                            Exit Sub

//                        End If

//                    Next I7

//                    errore = 3

//                Case 5
//                    REM-- - INV5------ -
//                    at# = as_c
//                    at0# = Exp(-(AIncognito(2) + AIncognito(3) * at#))
//                    at1# = 1.0# / (1.0# + at0#)
//                    as_r = AIncognito(0) + (AIncognito(1) * at1#)

//                Case 6
//                    as_r = AIncognito(0) + AIncognito(1) * as_c
//            End Select

//            Exit Sub

//errrate:
//            errore = 3

//            Exit Sub

//        End Sub

//        Public Sub FittingCurve()

//            // DAti ncal punti memorizzati in ConcPunto ed ODPunto calcola i valori dei parametri del modello
//            Dim X As Integer

//            //( ConcPunto(),  OD(),  model, ncal,  AIncognito,  errore,  ah_r,  ah_c)
//            On Error GoTo errcurve

//            //  If numerocalibratori <> 0 Then ncal = numerocalibratori
//            For X = 0 To 6
//                AIncognito(X) = 0
//            Next X

//            errore = 0
//            ah_r = 0
//            ah_c = 0
//            asd# = 0
//            appo = ODPunto(0)
//            ar0# = appo
//            AzzeraMatrice()   //  aa ex  GoSub 12950
//            AzzeraVettore()   // a1
//            aoldconc# = -1

//            Select Case model

//                Case 1
//                    para = 4
//                    Call InitLoglog4()

//                Case 2
//                    para = 5
//                    Call Initll5()

//                Case 3
//                    para = 5

//                    REM-- - INIT3--------
//                    For I = 0 To ncal - 1

//                        If ODPunto(I) <> ar0# Then
//                            If ConcPunto(I) <> aoldconc# Then
//                                aoldconc# = ConcPunto(I)
//                                a1#(1) = Log(ConcPunto(I))
//                                a1#(2) = a1#(1) * a1#(1)
//                                a1#(3) = a1#(2) * a1#(1)
//                            End If

//                            at# = ODPunto(I) - ar0#
//                            If at# = 0 Then
//                                errore = 1
//                                Exit Sub
//                            End If

//                            If at# < 0 Then at# = -at#
//                            a1#(4) = Log(at#) : xp = 4
//                            Stuff()
//                        End If

//                    Next I

//                    xp = 4
//                    Solve()
//                    ak# = Exp(aa#(0, 4))

//                    If ODPunto(ncal - 1) < ar0# Then ak# = -ak#
//                    a# = aa#(1, 4)
//                    ab# = aa#(2, 4)
//                    acc# = aa#(3, 4)

//                Case 4
//                    para = 5

//                    For I = 0 To ncal - 1

//                        If ConcPunto(I) <> 0 Then
//                            a1#(1) = (ODPunto(I) - ar0#) / 100
//                            a1#(2) = a1#(1) * a1#(1)
//                            a1#(3) = a1#(2) * a1#(1)

//                            If ConcPunto(I) <> aoldconc# Then
//                                aoldconc# = ConcPunto(I)
//                                a1#(4) = Log(aoldconc#)
//                            End If

//                            xp = 4
//                            Stuff()
//                        End If

//                    Next I

//                    xp = 4
//                    Solve()
//                    ak# = aa#(0, 4)
//                    a# = aa#(1, 4)
//                    ab# = aa#(2, 4)
//                    acc# = aa#(3, 4)

//                Case 5
//                    para = 4

//                    REM-- - INIT5--------
//                    aoldconc# = -1 : ak# = 1.5 * (ODPunto(ncal - 1) - ar0#)

//                    For I = 0 To ncal - 1

//                        If ODPunto(I) <> ar0# Then
//                            If ConcPunto(I) <> aoldconc# Then aoldconc# = ConcPunto(I) : a1#(1) = ConcPunto(I)
//                            at# = (ODPunto(I) - ar0#) / (ak# - (ODPunto(I) - ar0#))

//                            If at# = 0 Then
//                                errore = 1
//                                Exit Sub
//                            End If

//                            a1#(2) = Log(at#)
//                            xp = 2
//                            Stuff()
//                        End If

//                    Next I

//                    xp = 2
//                    Solve()
//                    a# = aa#(0, 2)
//                    ab# = aa#(1, 2)

//                Case 6
//                    para = 2

//                    //13920   Rem --- INIT6 -----
//                    For I = 0 To ncal - 1

//                        If ConcPunto(I) <> aoldconc# Then aoldconc# = ConcPunto(I) : a1#(1) = ConcPunto(I)
//                        a1#(2) = ODPunto(I) : xp = 2
//                        Stuff()
//                    Next I

//                    xp = 2
//                    Solve()
//                    a# = aa#(0, 2)
//                    ab# = aa#(1, 2)
//                    AIncognito(0) = a#
//                    AIncognito(1) = ab#
//            End Select

//            If errore = 1 Then Exit Sub
//            If model = 6 Then
//                OttimizzaLineare()
//            Else

//                AIncognito(0) = ar0# + 0!
//                AIncognito(1) = ak# + 0!
//                AIncognito(2) = a# + 0!

//                If para = 5 Then
//                    AIncognito(4) = acc# + 0!
//                Else
//                    AIncognito(4) = 0
//                    acc# = 0
//                End If

//                If model = 4 Then
//                    FinalizzaCalcolo()
//                Else

//                    aold_sd# = AHUGE
//                    alambda# = AHUGE

//                    REM-- - MAIN CONVERGENCE--------------------
//                    For iter = 1 To 50
//                        Call AzzeraMatrice()
//                        arss# = 0 : aoldconc# = -1

//                        For I = 0 To ncal - 1
//                            athis_c = ConcPunto(I)
//                            athis_r# = ODPunto(I)

//                            Select Case model

//                                Case 1

//                                    //  930 --- MOD1 ---------
//                                    If athis_c# <> aoldconc# Then
//                                        aoldconc# = athis_c#

//                                        If athis_c# = 0 Then
//                                            AzzeraVettore()
//                                            at1# = 0
//                                        Else
//                                            at# = Log(athis_c#)
//                                            at0# = Exp(-(a# + ab# * Log(athis_c#)))
//                                            at1# = 1.0# / (1.0# + Exp(-(a# + ab# * Log(athis_c#))))
//                                            at0# = ak# * at1# * at1# * at0#
//                                            a1#(1) = at1#
//                                            a1#(2) = at0#
//                                            a1#(3) = at0# * at#
//                                        End If
//                                    End If

//                                    at# = athis_r# - (ar0# + ak# * at1#)
//                                    a1#(4) = at#
//                                    arss# = arss# + at# * at#

//                                Case 2

//                                    REM-- - MOD2-------- -
//                                    If athis_c# <> aoldconc# Then
//                                        aoldconc# = athis_c#

//                                        If athis_c# = 0 Then
//                                            AzzeraVettore()
//                                            at1# = 0
//                                        Else
//                                            at# = Log(athis_c#)
//                                            at0# = Exp(-(a# + ab# * at# + acc# * athis_c#))
//                                            at1# = 1.0# / (1.0# + at0#)
//                                            a1#(1) = at1#
//                                            at0# = ak# * at1# * at1# * at0#
//                                            a1#(2) = at0#
//                                            a1#(3) = at0# * at#
//                                            a1#(4) = at0# * athis_c#
//                                        End If
//                                    End If

//                                    at# = athis_r# - (ar0# + ak# * at1#)
//                                    a1#(5) = at#
//                                    arss# = arss# + at# * at#

//                                Case 3

//                                    If athis_c# <> aoldconc# Then
//                                        aoldconc# = athis_c#

//                                        If athis_c# = 0 Then
//                                            AzzeraVettore()
//                                            at1# = 0
//                                        Else
//                                            at# = Log(athis_c#)
//                                            at2# = at# * at#
//                                            at1# = Exp(a# * at# + ab# * at2# + acc# * at# * at2#)
//                                            a1#(1) = at1#
//                                            at0# = ak# * at1# * at#
//                                            a1#(2) = at0#
//                                            a1#(3) = at0# * at#
//                                            a1#(4) = at0# * at2#
//                                        End If
//                                    End If

//                                    at# = athis_r# - (ar0# + ak# * at1#)
//                                    a1#(5) = at#
//                                    arss# = arss# + at# * at#

//                                Case 5

//                                    REM-- - MOD5--------
//                                    If athis_c# <> aoldconc# Then
//                                        at# = athis_c#
//                                        aoldconc# = at#
//                                        at0# = Exp(-(a# + ab# * at#))
//                                        at1# = 1.0# / (1.0# + at0#)
//                                        a1#(1) = at1#
//                                        at0# = ak# * at1# * at1# * at0#
//                                        a1#(2) = at0#
//                                        a1#(3) = at0# * at#
//                                    End If

//                                    at# = athis_r# - (ar0# + ak# * at1#)
//                                    a1#(4) = at#
//                                    arss# = arss# + at# * at#

//                            End Select

//                            xp = para
//                            Stuff()
//                        Next I

//                        If(ncal - para) <= 1 Then
//                            asd# = arss#
//                        Else
//                            asd# = arss# / (ncal - para)
//                        End If

//                        asd# = Sqrt(asd#)
//                        at_sd# = asd# - aold_sd#

//                        If at_sd# < 0 Then at_sd# = -at_sd#

//                        If at_sd# < AEPSILON# Then

//                            Exit For

//                        Else

//                            If(asd# - aold_sd#) > 1 Then alambda# = 5
//                            If((200.0# / asd#) < iter + 3) Then
//                                anew_lamb# = 200.0# / asd#
//                            Else
//                                anew_lamb# = iter + 3
//                            End If

//                            If anew_lamb# < alambda# Then
//                                anew_lamb# = anew_lamb#
//                            Else
//                                anew_lamb# = alambda#
//                            End If

//                            anew_lamb# = 1 + Exp(-anew_lamb#)

//                            For I7 = 0 To para - 1
//                                aa#(I7, I7) = anew_lamb# * aa#(I7, I7)
//                            Next I7

//                            xp = para
//                            Solve()

//                            If errore = 1 Then
//                                Exit Sub
//                            End If
//                            ar0# = ar0# + aa#(0, para)
//                            ak# = ak# + aa#(1, para)
//                            a# = a# + aa#(2, para)
//                            ab# = ab# + aa#(3, para)
//                            AIncognito(0) = ar0#
//                            AIncognito(1) = ak#
//                            AIncognito(2) = a#
//                            AIncognito(3) = ab#

//                            If para = 5 Then
//                                acc# = acc# + aa#(4, 5)
//                                AIncognito(4) = acc#
//                            Else
//                                AIncognito(4) = 0
//                            End If

//                            aold_sd# = asd#

//                            Dim errorepred As Integer

//                            If mostraprogressi = True Then
//                                FinalizzaCalcolo()
//                                errorepred = errore

//                                //  Form1.disegnacurva
//                                errore = errorepred
//                            End If

//                        End If

//                    Next iter

//                End If
//            End If

//            FinalizzaCalcolo()
//            //       //PRINT USING "& ##.###### "; "R0="; ar0#; "K="; ak#; "A="; a#; "B="; ab#; "C="; acc#; "D.S.="; asd#
//            //        ah_c = ConcPunto(ncal - 1) * 1.1
//            //        as_c = ah_c
//            //        calcolorate (model)    // AIncognito, as_r, as_c, errore, model, ah_r, ah_c
//            //        //(ByRef AIncognito(), ByRef as_r, ByRef as_c, ByRef errore, ByRef model, ByRef ah_r, ByRef ah_c)
//            //        ah_r = as_r
//            //        GoSub 13300

//            Exit Sub

//            Return

//            //PRINT  "a=";A#;"b=";AB#;"asd";ASD#:RETURN
//errcurve:
//            errore = 1

//            Exit Sub

//        End Sub

//        Private Sub AzzeraMatrice()

//            //    --- ZEROMAT ----------
//            For I7 = 0 To 4
//                For J7 = 0 To 5
//                    aa#(I7, J7) = 0
//                Next J7
//            Next I7

//        End Sub

//        Private Sub AzzeraVettore()

//            //12970   Rem --- ZEROVEC ----------
//            For I7 = 1 To 5
//                a1#(I7) = 0
//            Next I7

//            a1#(0) = 1.0!
//        End Sub

//        Private Sub InitLoglog4()
//            //13430   Rem --- INIT1 -------
//            ak# = 1.5 * (ODPunto(ncal - 1) - ar0#)  // 1.5 delta tra od max e min allinizio

//            For I = 0 To ncal - 1

//                If ODPunto(I) <> ar0# Then
//                    If ConcPunto(I) <> aoldconc# Then
//                        aoldconc# = ConcPunto(I)
//                        a1#(1) = Log(ConcPunto(I))
//                    End If

//                    at# = ODPunto(I) - ar0#

//                    If at# = 0 Then
//                        errore = 1

//                        Exit Sub

//                    Else
//                        a1#(2) = Log(at# / (ak# - at#))
//                        xp = 2
//                        Stuff()
//                    End If
//                End If

//            Next I

//            xp = 2
//            Solve()
//            a# = aa#(0, 2)
//            ab# = aa#(1, 2)
//        End Sub

//        Private Sub Stuff()

//            //12990   Rem --- STUFF  -----------
//            For I7 = 0 To xp - 1
//                For J7 = 0 To xp
//                    aa#(I7, J7) = aa#(I7, J7) + a1#(I7) * a1#(J7)
//                Next J7
//            Next I7

//        End Sub

//        Public Sub Solve()

//            // Risolve semplificando il sestema nella matrice aa
//            //13040   Rem --- SOLVE ------------
//            // 1) porta tutte le righe della matrice ad avere 1 al primo posto
//            For I7 = 0 To xp - 1
//                amain_diag# = aa#(I7, I7)

//                //    IF amain_diag# < 1E-12 THEN errore = 1: RETURN
//                For J7 = 0 To xp
//                    aa#(I7, J7) = aa#(I7, J7) / amain_diag#
//                Next J7

//                I8 = 0

//                Do

//                    If I8 = I7 Then I8 = I8 + 1
//                    J8 = I8 Mod xp
//                    afirst_element# = aa#(J8, I7)

//                    For J7 = 0 To xp
//                        aa#(J8, J7) = aa#(J8, J7) - afirst_element# * aa#(I7, J7)
//                    Next J7

//                    I8 = I8 + 1
//                Loop While I8 < xp

//            Next I7

//        End Sub

//        Public Sub FinalizzaCalcolo()
//            //PRINT USING "& ##.###### "; "R0="; ar0#; "K="; ak#; "A="; a#; "B="; ab#; "C="; acc#; "D.S.="; asd#
//            ah_c = ConcPunto(ncal - 1) * 1.1
//            as_c = ah_c
//            calcolorate(model)    // AIncognito, as_r, as_c, errore, model, ah_r, ah_c
//            //(ByRef AIncognito(), ByRef as_r, ByRef as_c, ByRef errore, ByRef model, ByRef ah_r, ByRef ah_c)
//            ah_r = as_r
//            CheckSlope()

//        End Sub

//        Private Sub CheckSlope()

//            //13300   Rem --- CHECK.SLOPE ------
//            Select Case model

//                Case 2
//                    as_c = (-AIncognito(3)) / AIncognito(4)

//                    If as_c > 0 Then calcolorate(model)    // AIncognito(), as_r, as_c, errore, model, ah_r, ah_c

//            // (AIncognito(),as_r,  as_c,  errore,  model,  ah_r,  ah_c)
//            REM print using "#####.#####";as_c;as_r
//                Case 3
//                    at1# = AIncognito(3) ^ 2
//                    at1# = at1# - AIncognito(2) * AIncognito(4) * 3

//                    If at1# > 0 Then
//                        at0# = Sqrt(at1#)
//                        at1# = -(AIncognito(3)) - at0#
//                        at1# = at1# / (AIncognito(4) * 3)
//                        as_c = Exp(at1#)
//                        calcolorate(model)    // AIncognito(), as_r, as_c, errore, model, ah_r, ah_c
//                        REM print using "#####.#####";as_c;as_r
//                        at1# = -(AIncognito(3)) + at0#
//                        at1# = at1# / (AIncognito(4) * 3)
//                        as_c = Exp(at1#)
//                        calcolorate(model)    //
//                        // (AIncognito(),as_r,  as_c,  errore,  model,  ah_r,  ah_c)AIncognito(), as_r, as_c, errore, model, ah_r, ah_c
//                        REM print using "#####.#####";as_c;as_r
//                    End If

//            End Select

//        End Sub

//        Private Sub InitLineare()

//        End Sub

//        Public Sub OttimizzaLineare()
//            REM --- MODEL6----- arates=A+B* ConcPunto
//            aoldconc# = -1
//            Call AzzeraMatrice()  //: GoSub 12950

//            For I = 0 To ncal - 1
//                athis_c# = ConcPunto(I)
//                athis_r# = ODPunto(I)

//                If athis_c# <> aoldconc# Then
//                    at# = athis_c#
//                    aoldconc# = at#
//                    at0# = (a# + ab# * at#)
//                    a1#(1) = at0#
//                End If

//                a1#(2) = athis_r#

//                xp = para
//                Stuff()
//            Next I

//            xp = para
//            Solve()
//            //      AIncognito(0) = aa#(0, para)
//            //      AIncognito(1) = aa#(1, para)
//    aoldconc# = -1 : arss# = 0

//            For I = 0 To ncal - 1

//                If ConcPunto(I) <> aoldconc# Then
//                    aoldconc# = ConcPunto(I)
//                    as_c = ConcPunto(I)
//                    calcolorate(model)    // AIncognito(), as_r, as_c, errore, model, ah_r, ah_c
//                    // (AIncognito(),as_r,  as_c,  errore,  model,  ah_r,  ah_c)
//                End If

//                adiff# = ODPunto(I) - as_r
//                arss# = arss# + adiff# ^ 2
//            Next I

//            If(ncal - para) <= 1 Then
//               asd# = arss#
//            Else
//                asd# = arss# / (ncal - para)
//            End If

//            asd# = Sqrt(asd#)

//        End Sub
//}
   
