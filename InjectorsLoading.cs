using Dal.Settings;
using Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

internal class InjectorsLoading
{
    private Class18 class18_0;
    private Class24_u class24_u_0 = null;


    public InjectorsLoading(ref Class18 class18_1)
    {
        class18_0 = class18_1;
        LoadINJ();
    }

    private void ReloadINJ()
    {
        for (int i = 0; i < 7; i++)
        {
            class24_u_0.double_0[i] = this.class18_0.method_208(this.class18_0.method_209(float.Parse(class24_u_0.double_0[i].ToString())));
            class24_u_0.double_1[i] = this.class18_0.method_224((int)((class24_u_0.double_1[i] * 1000.0) / 3.2));
        }
        this.class18_0.class24_u_0.Add(class24_u_0);

        class24_u_0 = null;
    }

    private void LoadINJ()
    {
        class24_u_0 = new Class24_u
        {
            string_0 = "Acura Integra (92-96 VTEC) 240cc (23lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.29, 0.29, 0.4, 0.56, 0.79, 1.22, 1.22 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (92-00 EX/SI) 240cc (23lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.32, 0.33, 0.47, 0.62, 1.09, 2.05, 2.05 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (92-00 LX/DX/HX) 190cc (18lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 13.0, 12.0, 10.0, 8.0 },
            double_1 = new double[] { 0.31, 0.34, 0.46, 0.60, 0.80, 1.17, 1.82 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda All (86-91) 240cc (23lb) 3ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.25, 0.30, 0.35, 0.41, 0.48, 0.59, 1.83 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (01-Up LX/DX/HX) 215cc (20lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 13.0, 12.0, 10.0, 8.0 },
            double_1 = new double[] { 0.47, 0.50, 0.60, 0.72, 0.81, 1.18, 1.71 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (01-Up EX) 240cc (23lb) 11ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.36, 0.42, 0.47, 0.56, 0.66, 0.82, 1.81 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (03-Up SI) (CRV 02+) 290cc (28lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.53, 0.61, 0.68, 0.79, 0.91, 1.06, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Civic (06-Up SI) 330cc (31lb) 10ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.42, 0.50, 0.57, 0.68, 0.82, 0.96, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Prelude (92-96 VTEC) 330cc (31lb) 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.21, 0.27, 0.35, 0.45, 0.56, 0.72, 1.12 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda Prelude (97-02) 290cc (28lb) 12ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.44, 0.63, 0.74, 0.85, 1.02, 1.24, 1.9 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda S2000 360cc 12ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.59, 0.71, 0.81, 0.95, 1.11, 1.27, 1.78 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Acura NSX 240cc (23lb) 2ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.25, 0.31, 0.36, 0.43, 0.51, 0.61, 1.60 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Acura RSX (02-04) 290cc (28lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.43, 0.50, 0.58, 0.69, 0.83, 1.00, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Acura RSX Typs-S (02-04) 330cc (31lb) 12ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.05, 8.09, 0.0 },
            double_1 = new double[] { 0.50, 0.56, 0.65, 0.77, 0.89, 1.06, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Acura RDX 440cc (31lb) 12ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.04, 1.10, 1.41, 1.80, 2.50, 2.50, 2.50 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Honda/Acura CL 240cc (23lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 13.0, 12.0, 10.0, 8.0 },
            double_1 = new double[] { 0.22, 0.25, 0.36, 0.43, 0.52, 0.73, 0.98 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi DSM Black 450cc (90-94 Turbo) (43lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.3, 0.53, 0.67, 0.82, 0.95, 1.11, 1.54 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi DSM Blue 450cc (95-99 Turbo) (43lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.19, 0.45, 0.55, 0.67, 0.81, 1.0, 1.48 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi 3000GT 370cc (32lb) 3ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.48, 0.55, 0.63, 0.70, 0.78, 0.88, 1.88 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi Lancer (2.4L) 240cc (23lb) 15ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.47, 0.55, 0.64, 0.83, 1.05, 1.28, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi EVO3 510cc (@43psi) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.90, 1.02, 1.02, 1.19, 1.35, 1.54, 2.08 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mitsubishi EVO VIII 550cc (52lb) 3ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.52, 0.58, 0.64, 0.72, 0.80, 0.91, 1.90 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Audi S4/TT 340cc (32lb) 14ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.40, 0.47, 0.54, 0.63, 0.74, 0.88, 1.98 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Dodge 4.7 273cc (26lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.61, 0.73, 0.89, 1.22, 1.75, 2.35, 2.35 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Dodge SRT-4 (2003) 525cc (50lb) 13ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.08, 0.13, 0.22, 0.50, 0.92, 1.45, 1.45 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Dodge SRT-4 (2004+) 577cc (55lb) 13ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.39, 0.48, 0.61, 1.00, 1.62, 2.33, 2.33 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Dodge Viper (96-2002) 336cc (32lb) 13ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.89, 0.96, 1.09, 1.50, 2.10, 3.00, 3.00 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Edelbrock 630cc (60lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.01, 0.04, 0.15, 0.39, 0.76, 1.45, 1.45 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Motorsport 378cc (36lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.25, 0.32, 0.41, 0.69, 1.15, 2.32, 2.32 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Motorsport 441cc (42lb) 14ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.42, 0.49, 0.56, 0.75, 1.14, 2.15, 2.15 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Motorsport 809cc (77lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.89, 0.96, 1.05, 1.33, 1.78, 2.54, 2.54 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Motorsport 1600cc (152lb) 5ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.67, 0.72, 0.83, 1.11, 1.61, 2.31, 2.31 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Motorsport 1680cc (160lb) 5ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.70, 0.80, 0.94, 1.28, 1.80, 2.47, 2.47 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford mustang (84-95) 200cc (19lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.11, 0.20, 0.34, 0.56, 0.86, 1.52, 1.52 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ford Mustang Cobra 252cc (24lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.19, 0.25, 0.36, 0.59, 0.91, 1.57, 1.57 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mustang GT (96-03) 200cc (19lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.39, 0.46, 0.54, 0.80, 1.15, 1.88, 1.88 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Mustang Turbo 315cc (30lb) 15ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.16, 0.23, 0.33, 0.56, 0.88, 1.55, 1.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nismo 740cc (70lb) 11ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.39, 0.44, 0.55, 0.79, 0.79, 1.96, 1.96 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan 180sx(88-93)/Skyline(86-88) 270cc (26lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.38, 0.42, 0.49, 0.75, 1.11, 1.94, 1.94 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan Pulsar Gti-R 444cc (42lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.51, 0.54, 0.60, 0.83, 1.14, 2.01, 2.01 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan Sentra/200sx/NX/G20 (2.0L ONLY) 259cc (25lb) 11ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.37, 0.42, 0.47, 0.64, 0.90, 1.65, 1.65 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan Skyline GT-R 440cc (42lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.58, 0.65, 0.76, 0.96, 1.35, 2.25, 2.25 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan Skyline GTS-T 380cc (36lb) 11ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.36, 0.42, 0.52, 0.73, 1.10, 1.91, 1.91 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan 300zx(95-96)/SR20DET 370cc (35lb) 11ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.54, 0.57, 0.64, 0.86, 1.17, 2.11, 2.11 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan 240SX(89-90) 230cc (22lb) 12ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.39, 0.42, 0.47, 0.62, 0.94, 1.74, 1.74 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Nissan 240sx(91-98)/Altima(93-01) 250cc (24lb) 11ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.35, 0.40, 0.47, 0.69, 1.00, 1.78, 1.78 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "Blitz 850cc (81lb) 14ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.44, 0.52, 0.59, 0.70, 0.84, 1.04, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Bosch 1545cc (147lb) 5ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.61, 0.68, 0.76, 0.89, 1.04, 1.27, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Deatschwerks 600cc (57lb) ?ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.20, 1.30, 1.60, 2.00, 2.35, 2.35, 2.35 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Deatschwerks 800cc (47lb) ?ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.99, 1.11, 1.32, 1.55, 1.98, 1.98, 1.98 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Accel 578cc (55lb) 3ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.48, 0.55, 0.62, 0.71, 0.83, 0.97, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Accel 872cc (83lb) 3ohm",
            double_0 = new double[] { 24.56, 16.08, 14.16, 12.13, 10.0, 8.09, 0.0 },
            double_1 = new double[] { 0.53, 0.61, 0.70, 0.80, 0.93, 1.11, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "MSD 525cc (50lb) 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.34, 0.49, 0.61, 0.75, 0.94, 1.19, 2.1 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "MSD 750cc (71lb) 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.49, 0.69, 0.81, 0.97, 1.17, 1.4, 2.19 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "P&H DRIVER RC 750cc 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.24, 0.35, 0.42, 0.49, 0.56, 0.65, 0.95 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "P&H DRIVER RC 1200cc 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.13, 0.24, 0.31, 0.38, 0.48, 0.57, 0.92 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Ultimate Racing 440cc 16ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.04, 0.19, 0.3, 0.42, 0.57, 0.74, 1.3 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "HKS 1000cc 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.71, 0.89, 0.97, 1.04, 1.14, 1.31, 1.9 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Denso 550cc 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.47, 0.64, 0.75, 0.87, 1.04, 1.24, 1.91 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Denso 660cc 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.47, 0.64, 0.74, 0.86, 0.99, 1.15, 1.71 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Denso 720cc 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.6, 0.75, 0.86, 0.99, 1.14, 1.35, 1.99 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Fuel Injector Clinic 650cc (62lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.39, 0.45, 0.54, 0.78, 1.13, 1.89, 1.89 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Fuel Injector Clinic 850cc (81lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.38, 0.43, 0.51, 0.74, 1.02, 1.56, 1.56 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Fuel Injector Clinic 950cc (90lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.50, 0.57, 0.65, 0.88, 1.30, 2.05, 2.05 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Hahn Racecraft 625cc (60lb) 3ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.46, 0.50, 0.57, 0.79, 1.19, 1.92, 1.92 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Holley 788cc (75lb) 2ohm",
            double_0 = new double[] { 16.0, 15.0, 14.0, 12.0, 10.0, 8.0, 8.0 },
            double_1 = new double[] { 0.38, 0.44, 0.54, 0.71, 1.02, 1.68, 1.68 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "Precision Turbo 525cc (50lb) 12ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.38, 0.54, 0.66, 0.84, 1.05, 1.33, 2.47 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Precision Turbo 680cc (65lb) 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.89, 1.05, 1.13, 1.22, 1.36, 1.56, 2.22 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Precision Turbo 1000cc (95lb) 2ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.53, 0.7, 0.81, 0.96, 1.15, 1.38, 2.19 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 270cc (23lb) 16ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.15, 0.32, 0.49, 0.61, 0.76, 0.89, 1.47 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 310cc (30lb) 16ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.25, 0.43, 0.55, 0.72, 0.89, 1.14, 1.92 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 370cc (35lb) 16ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.04, 0.21, 0.35, 0.47, 0.64, 0.85, 1.5 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 440cc (42lb) 13ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.44, 0.63, 0.74, 0.91, 1.08, 1.27, 1.83 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 440cc (42lb) 16ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.0, 0.14, 0.29, 0.42, 0.56, 0.76, 1.31 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 550cc (52lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.3, 0.51, 0.59, 0.68, 0.81, 0.92, 1.46 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 550cc (52lb) 13ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.35, 0.55, 0.67, 0.78, 0.88, 1.07, 1.65 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 650cc (62lb) 12ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.22, 0.41, 0.54, 0.69, 0.86, 1.08, 1.85 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 720cc (69lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.83, 1.06, 1.16, 1.31, 1.48, 1.7, 2.46 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 750cc (71lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.01, 0.18, 0.32, 0.48, 0.66, 0.88, 1.6 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 750cc (71lb) 12ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.4, 0.63, 0.76, 0.92, 1.12, 1.36, 2.18 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 900cc (86lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.35, 0.55, 0.67, 0.78, 0.88, 1.07, 1.65 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 1000cc (95lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.83, 1.06, 1.16, 1.31, 1.48, 1.7, 2.46 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 1200cc (114lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 1.32, 1.62, 1.79, 2.0, 2.28, 2.55, 2.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "RC Engineering 1600cc (152lb) 3ohm",
            double_0 = new double[] { 16.0, 14.0, 13.0, 12.0, 11.0, 10.0, 8.0 },
            double_1 = new double[] { 0.7, 0.92, 1.05, 1.23, 1.46, 1.8, 2.55 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @40Psi 690cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.66, 0.775, 1.03, 1.32, 1.91, 1.91, 1.91 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @43.5Psi 715cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.67, 0.795, 1.04, 1.35, 1.975, 1.975, 1.975 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @45Psi 730cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.68, 0.8, 1.045, 1.365, 2.005, 2.005, 2.005 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @50Psi 770cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.7, 0.83, 1.065, 1.42, 2.095, 2.095, 2.095 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @55Psi 810cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.72, 0.86, 1.09, 1.465, 2.185, 2.185, 2.185 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @60Psi 850cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.745, 0.895, 1.115, 1.52, 2.27, 2.27, 2.27 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @65Psi 890cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.765, 0.93, 1.14, 1.575, 2.35, 2.35, 2.35 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @70Psi 925cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.79, 0.97, 1.175, 1.63, 2.44, 2.44, 2.44 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @75Psi 960cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.815, 1.01, 1.215, 1.685, 2.545, 2.545, 2.545 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @80Psi 990cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.85, 1.045, 1.265, 1.74, 2.675, 2.675, 2.675 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @85Psi 1020cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.885, 1.075, 1.32, 1.79, 2.84, 2.84, 2.84 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @90Psi 1050cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.925, 1.1, 1.375, 1.845, 3.035, 3.035, 3.035 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @95Psi 1080cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.96, 1.125, 1.435, 1.9, 3.25, 3.25, 3.25 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @100Psi 1110cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 10.0, 10.0, 10.0 },
            double_1 = new double[] { 0.995, 1.155, 1.49, 1.965, 1.965, 1.965, 1.965 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @105Psi 1140cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.02, 1.185, 1.54, 2.04, 2.04, 2.04, 2.04 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @110Psi 1170cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.04, 1.22, 1.58, 2.12, 2.12, 2.12, 2.12 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @115Psi 1200cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.055, 1.26, 1.615, 2.219, 2.219, 2.219, 2.219 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID725 @120Psi 1235cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.07, 1.3, 1.65, 2.3, 2.3, 2.3, 2.3 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @40Psi 980cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.8, 0.97, 1.21, 1.63, 2.485, 2.485, 2.485 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @43.5Psi 1015cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.805, 0.99, 1.24, 1.675, 2.6, 2.6, 2.6 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @45Psi 1035cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.81, 1.0, 1.295, 1.705, 2.72, 2.72, 2.72 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @50Psi 1085cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.85, 1.025, 1.355, 1.75, 2.855, 2.855, 2.855 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @55Psi 1135cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.82, 1.055, 1.4, 1.815, 3.015, 3.015, 3.015 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @60Psi 1180cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.845, 1.08, 1.44, 1.88, 3.195, 3.195, 3.195 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @65Psi 1225cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.88, 1.1, 1.485, 1.96, 3.37, 3.37, 3.37 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @70Psi 1265cc",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.925, 1.125, 1.53, 2.05, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @75Psi 1305cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.975, 1.155, 1.58, 2.155, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @80Psi 1345cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.02, 1.195, 1.625, 2.28, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @85Psi 1390cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.06, 1.245, 1.675, 2.435, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @90Psi 1435cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.095, 1.305, 1.725, 2.61, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @95Psi 1485cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 1.125, 1.37, 1.775, 2.8, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "ID1000 @100Psi 1530cc require 10v",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 10.0, 10.0, 10.0 },
            double_1 = new double[] { 1.155, 1.44, 1.855, 2.995, 3.55, 3.55, 3.55 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "Bosch EV14 1000cc @29Psi 12ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.48, 0.70, 1.01, 1.45, 2.01, 2.01, 2.01 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Bosch EV14 1000cc @43.5Psi 12ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.68, 0.88, 1.22, 1.72, 2.37, 2.37, 2.37 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Bosch EV14 1000cc @58Psi 12ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.78, 1.02, 1.41, 1.92, 2.57, 2.57, 2.57 }
        };
        ReloadINJ();
        class24_u_0 = new Class24_u
        {
            string_0 = "Bosch EV14 1000cc @72.5Psi 12ohm",
            double_0 = new double[] { 16.0, 14.0, 12.0, 10.0, 8.0, 8.0, 8.0 },
            double_1 = new double[] { 0.91, 1.15, 1.52, 2.19, 2.91, 2.91, 2.91 }
        };
        ReloadINJ();

        //# #####################################################################
        //# #####################################################################
        //# #####################################################################

        class24_u_0 = new Class24_u
        {
            string_0 = "Custom",
            double_0 = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
            double_1 = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
        };
        ReloadINJ();
    }


}